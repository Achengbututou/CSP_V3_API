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
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-30 15:26:32
    /// 描 述： 采购申请
    /// </summary>
    public class CaseErpApplyBLL : BLLBase, ICaseErpApplyBLL,BLL
    {
        private readonly CaseErpApplyService caseErpApplyService = new CaseErpApplyService();

        private readonly ICaseErpApplydetailBLL _iCaseErpApplydetailBLL;
        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iCaseErpApplydetailBLL">采购申请详情【case_erp_applydetail】接口</param>
        public CaseErpApplyBLL(ICaseErpApplydetailBLL iCaseErpApplydetailBLL)
        {
            _iCaseErpApplydetailBLL = iCaseErpApplydetailBLL?? throw new ArgumentNullException(nameof(iCaseErpApplydetailBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取采购申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpApplyEntity>> GetList(CaseErpApplyEntity queryParams)
        {
            return caseErpApplyService.GetList(queryParams);
        }

        /// <summary>
        /// 获取采购申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpApplyEntity>> GetPageList(Pagination pagination, CaseErpApplyEntity queryParams)
        {
            return await caseErpApplyService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<CaseErpApplyEntity> GetEntity(string keyValue)
        {
            #region 添加操作记录-采购申请
            string F_Description = "查看采购申请";
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(keyValue, "2", F_Description, GetUserId());
            #endregion

            return await caseErpApplyService.GetEntity(keyValue);
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
            await caseErpApplyService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new ApplyDto();
            res.CaseErpApplyEntity = await GetEntity(keyValue);
            if(res.CaseErpApplyEntity != null)
            {
                res.CaseErpApplydetailList = await _iCaseErpApplydetailBLL.GetList(new CaseErpApplydetailEntity { F_ApplyId = res.CaseErpApplyEntity.F_Id });
            }
            caseErpApplyService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if(res.CaseErpApplyEntity != null)
                {
                    await _iCaseErpApplydetailBLL.DeleteRelateEntity(res.CaseErpApplyEntity.F_Id);
                }
                caseErpApplyService.Commit();
            }
            catch (Exception)
            {
                caseErpApplyService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpApplyEntity entity)
        {
            
            await caseErpApplyService.SaveEntity(keyValue, entity);

            #region 添加操作记录-采购申请
            string F_Description = "修改采购申请";
            if (string.IsNullOrEmpty(keyValue))
            {
                F_Description = "新增采购申请";
            }
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(entity.F_Id, "2", F_Description, GetUserId());
            #endregion
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, ApplyDto dto)
        {
            if (dto.CaseErpApplyEntity.F_IsSysNum == 0)//是否系统编号(0是，1否)
            {
                dto.CaseErpApplyEntity.F_Number = (await GetRuleCodeEx(dto.CaseErpApplyEntity.F_Number)).ToString();
            }
            //物品概要
            var F_ApplySynopsis = string.Empty;
            if (dto.CaseErpApplydetailList != null)
            {
                foreach (var item in dto.CaseErpApplydetailList)
                {
                    F_ApplySynopsis += $"{item.F_Name}:{item.F_Count},";
                }
                dto.CaseErpApplyEntity.F_ApplySynopsis = F_ApplySynopsis.TrimEnd(',');
            }
            caseErpApplyService.BeginTrans();
            try
            {
                await SaveEntity(keyValue,dto.CaseErpApplyEntity);
                await _iCaseErpApplydetailBLL.SaveList(dto.CaseErpApplyEntity.F_Id,dto.CaseErpApplydetailList);
                caseErpApplyService.Commit();
            }
            catch (Exception)
            {
                caseErpApplyService.Rollback();
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
            await caseErpApplyService.Deletes(keyValues);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues)
        {
            var keyValuelist = keyValues.Split(",");
            foreach (var keyValue in keyValuelist)
            {
                var res = new ApplyDto();
                res.CaseErpApplyEntity = await GetEntity(keyValue);
            if(res.CaseErpApplyEntity != null)
            {
                res.CaseErpApplydetailList = await _iCaseErpApplydetailBLL.GetList(new CaseErpApplydetailEntity { F_ApplyId = res.CaseErpApplyEntity.F_Id });
            }
                caseErpApplyService.BeginTrans();
                try
                {
                    await Delete(keyValue);
                if(res.CaseErpApplyEntity != null)
                {
                    await _iCaseErpApplydetailBLL.DeleteRelateEntity(res.CaseErpApplyEntity.F_Id);
                }
                    caseErpApplyService.Commit();
                }
                catch (Exception)
                {
                    caseErpApplyService.Rollback();
                    throw;
                }
            }
        }


        #endregion
    }
}
