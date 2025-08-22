using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:09:49
    /// 描 述： 供应商信息
    /// </summary>
    public class CaseErpSupplierBLL : BLLBase, ICaseErpSupplierBLL, BLL
    {
        private readonly CaseErpSupplierService caseErpSupplierService = new CaseErpSupplierService();
        private readonly ICaseErpSupplytimeBLL _icaseErpSupplytimeBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CaseErpSupplierBLL(ICaseErpSupplytimeBLL icaseErpSupplytimeBLL)
        {
            _icaseErpSupplytimeBLL = icaseErpSupplytimeBLL ?? throw new ArgumentNullException(nameof(icaseErpSupplytimeBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取供应商信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpSupplierEntity>> GetList(CaseErpSupplierEntity queryParams)
        {
            var list=await caseErpSupplierService.GetList(queryParams);
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.F_Type))
                {
                    item.F_Type = item.F_Type.TrimStart(',').TrimEnd(',');
                }
            }
            return list;
        }

        /// <summary>
        /// 获取供应商信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpSupplierEntity>> GetPageList(Pagination pagination, CaseErpSupplierEntity queryParams)
        {
            var list = await caseErpSupplierService.GetPageList(pagination, queryParams);
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.F_Type))
                {
                    item.F_Type = item.F_Type.TrimStart(',').TrimEnd(',');
                }
            }
            return list;
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<CaseErpSupplierEntity> GetEntity(string keyValue)
        {
            var entity=await caseErpSupplierService.GetEntity(keyValue);
            if (!string.IsNullOrEmpty(entity.F_Type))
            {
                entity.F_Type = entity.F_Type.TrimStart(',').TrimEnd(',');
            }
            return entity;
        }



        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue)
        {
            await caseErpSupplierService.Delete(keyValue);
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplierEntity entity)
        {
            if (entity.F_IsSysNum==0)//是否系统编号(0是，1否)
            {
                entity.F_Number= (await GetRuleCodeEx(entity.F_Number)).ToString();
            }
            if (string.IsNullOrEmpty(keyValue))//新增
            {
                if (entity.F_State == 0)//供应商状态(0潜在供应商，1正式供应商，2淘汰供应商)
                {
                    entity.F_LatentState = 0;//潜在供应商状态(0潜在，1审批中，2不通过)
                    entity.F_AssessState= 4;//风险评估报告状态(0优秀，1良好，2及格，3不及格，4未评估)
                }
            }
            
            await caseErpSupplierService.SaveEntity(keyValue, entity);
            
            if (string.IsNullOrEmpty(keyValue) && entity.F_State == 0)//新增
            {
                #region 记录供应商时间轴
                await _icaseErpSupplytimeBLL.SaveSupplyTime(entity.F_Id, "成为潜在供应商", "添加人：" + GetUserName(), "", "");
                #endregion
            }
            else if (entity.isOut)// 加入到淘汰供应商
            {
                #region 记录供应商时间轴
                await _icaseErpSupplytimeBLL.SaveSupplyTime(entity.F_Id, "被加入供应商淘汰名单", "操作者：" + GetUserName(), "delete"+ entity.F_OutType, entity.F_OutReason);
                #endregion
            }
            else if (entity.isRecover) // 恢复城正式供应商
            {
                #region 记录供应商时间轴
                await _icaseErpSupplytimeBLL.SaveSupplyTime(entity.F_Id, "恢复正式供应商", "操作者：" + GetUserName(), "recover" + entity.F_RecoverFile, entity.F_RecoverReason);
                #endregion
            }
        }



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSupplierService.Deletes(keyValues);
        }



        #endregion

        #region 流程状态处理
        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task UpdateStateByWf(string processId, string code)
        {
            var formalEntity = await caseErpSupplierService.BaseRepository()
                .FindEntity<CaseErpSupplierformalEntity>(t => t.F_Id == processId);
            if (formalEntity != null)
            {
                var entity = await GetEntity(formalEntity.F_SupplierId);
                if (code == "agree")
                {
                    entity.F_State = 1;
                    #region 记录供应商时间轴
                    await _icaseErpSupplytimeBLL.SaveSupplyTime(entity.F_Id, "成为正式供应商", "最终审批人：" + GetUserName(), "", "");
                    #endregion
                }
                else if (code == "create")
                {
                    entity.F_LatentState = 1;
                    entity.F_FormalState = 4; // 成为供应商第一年不需要年审批
                    entity.F_FormalDate = DateTime.Now; // 记录转正时间
                }
                else
                {
                    entity.F_LatentState = 2;
                }

                await caseErpSupplierService.SaveEntity(entity.F_Id,entity);
            }
        }
        
        /// <summary>
        /// 更新供应商状态通过年审
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task UpdateStateByWfYear(string processId, string code)
        {
            var formalEntity = await caseErpSupplierService.BaseRepository()
                .FindEntity<CaseErpSupplierriskEntity>(t => t.F_Id == processId);
            if (formalEntity != null)
            {
                var entity = await GetEntity(formalEntity.F_SupplierId);
                if (code == "create")
                {
                    entity.F_FormalState = 1;
                }
                else
                {
                    if (code == "fail")
                    {
                        entity.F_FormalState = 2;
                    }
                    else
                    {
                        entity.F_FormalState = 3;
                    }

                    string res = "";
                    switch (code)
                    {
                        case "fine":
                            res = "优秀";
                            break;
                        case "good":
                            res = "良好";
                            break;
                        case "pass":
                            res = "及格";
                            break;
                        case "fail":
                            res = "不及格";
                            break;
                    }
                    
                    #region 记录供应商时间轴
                    await _icaseErpSupplytimeBLL.SaveSupplyTime(entity.F_Id, $"完成{DateTime.Now.Year}供应商年审-{res}", "最终审批人：" + GetUserName(), processId, "yearAssess");
                    #endregion
                }
                await caseErpSupplierService.SaveEntity(entity.F_Id,entity);
            }
        }
        
        #endregion
    }
}
