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
    /// 日 期： 2022-12-05 16:10:51
    /// 描 述： 供应商风险评估
    /// </summary>
    public class CaseErpSupplierriskBLL : BLLBase, ICaseErpSupplierriskBLL,BLL
    {
        private readonly ICaseErpSupplierBLL _icaseErpSupplierBLL;
        private readonly CaseErpSupplierriskService caseErpSupplierriskService = new CaseErpSupplierriskService();
        private readonly ICaseErpSupplytimeBLL _icaseErpSupplytimeBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CaseErpSupplierriskBLL(ICaseErpSupplierBLL icaseErpSupplierBLL, ICaseErpSupplytimeBLL icaseErpSupplytimeBLL)
        {
            _icaseErpSupplierBLL = icaseErpSupplierBLL ?? throw new ArgumentNullException(nameof(icaseErpSupplierBLL));
            _icaseErpSupplytimeBLL = icaseErpSupplytimeBLL ?? throw new ArgumentNullException(nameof(icaseErpSupplytimeBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取供应商风险评估的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierriskEntity>> GetList(CaseErpSupplierriskEntity queryParams)
        {
            return caseErpSupplierriskService.GetList(queryParams);
        }

        /// <summary>
        /// 获取供应商风险评估的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierriskEntity>> GetPageList(Pagination pagination, CaseErpSupplierriskEntity queryParams)
        {
            return caseErpSupplierriskService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplierriskEntity> GetEntity(string keyValue)
        {
            return caseErpSupplierriskService.GetEntity(keyValue);
        }

        /// <summary>
        /// 获取最近的年审信息
        /// </summary>
        /// <param name="supplierId">供应商主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplierriskEntity> GetEntityLastBySupplierId(string supplierId)
        {
            return  caseErpSupplierriskService.GetEntityLastBySupplierId(supplierId);
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
            await caseErpSupplierriskService.Delete(keyValue);
        }

        
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplierriskEntity entity)
        {
            var SupplierEntity = await _icaseErpSupplierBLL.GetEntity(entity.F_SupplierId);
            
            caseErpSupplierriskService.BeginTrans();
            try
            {
                if (SupplierEntity != null)
                {
                    SupplierEntity.F_AssessState =
                        Convert.ToInt32(entity.F_FinalState); //风险评估报告状态(0优秀，1良好，2及格，3不及格，4未评估)
                    await _icaseErpSupplierBLL.SaveEntity(entity.F_SupplierId, SupplierEntity);
                }

                #region 记录供应商时间轴

                string title = string.Empty;
                if (entity.F_Type == 0) //风险评估
                {
                    title += "完成风险评估-";
                    switch (entity.F_FinalState)
                    {
                        case "0":
                            title += "优秀";
                            break;
                        case "1":
                            title += "良好";
                            break;
                        case "2":
                            title += "及格";
                            break;
                        case "3":
                            title += "不及格";
                            break;
                        default:
                            break;
                    }

                    await _icaseErpSupplytimeBLL.SaveSupplyTime(entity.F_SupplierId, title,
                        "评估人：" + GetUserName(),"", "");
                }


                #endregion
                await caseErpSupplierriskService.SaveEntity(keyValue, entity);
                caseErpSupplierriskService.Commit();
            }
            catch (Exception e)
            {
                caseErpSupplierriskService.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSupplierriskService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="supplierid">供应商主键</param>
        /// <param name="risktype">报告类型(0风险评估，1年审评估)</param>
        /// <returns></returns>
        public async Task<CaseErpSupplierriskEntity> GetAssess(string supplierid,int risktype)
        {
            return await caseErpSupplierriskService.BaseRepository().FindEntity<CaseErpSupplierriskEntity>(
                it => it.F_SupplierId == supplierid && it.F_Type == risktype);
        }

        #endregion
    }
}
