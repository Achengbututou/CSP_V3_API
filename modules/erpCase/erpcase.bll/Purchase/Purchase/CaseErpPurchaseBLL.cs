using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using System.Linq;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-30 15:20:23
    /// 描 述： 采购订单
    /// </summary>
    public class CaseErpPurchaseBLL : BLLBase, ICaseErpPurchaseBLL, BLL
    {
        private readonly CaseErpPurchaseService caseErpPurchaseService = new CaseErpPurchaseService();
        private readonly ICaseErpPurchasedetailBLL _iCaseErpPurchasedetailBLL;
        private readonly ICaseErpApplyBLL _icaseErpApplyBLL;
        private readonly ICaseErpApplydetailBLL _icaseErpApplydetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpPurchasedetailBLL">采购订单详情【case_erp_purchasedetail】接口</param>
        public CaseErpPurchaseBLL(ICaseErpPurchasedetailBLL iCaseErpPurchasedetailBLL, ICaseErpApplyBLL icaseErpApplyBLL, ICaseErpApplydetailBLL icaseErpApplydetailBLL)
        {
            _iCaseErpPurchasedetailBLL = iCaseErpPurchasedetailBLL ?? throw new ArgumentNullException(nameof(iCaseErpPurchasedetailBLL));
            _icaseErpApplyBLL = icaseErpApplyBLL ?? throw new ArgumentNullException(nameof(icaseErpApplyBLL));
            _icaseErpApplydetailBLL = icaseErpApplydetailBLL ?? throw new ArgumentNullException(nameof(icaseErpApplydetailBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取采购订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchaseEntity>> GetList(CaseErpPurchaseEntity queryParams)
        {
            return caseErpPurchaseService.GetList(queryParams);
        }

        /// <summary>
        /// 获取采购订单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpPurchaseEntity>> GetPageList(Pagination pagination, CaseErpPurchaseEntity queryParams)
        {
            return await caseErpPurchaseService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<CaseErpPurchaseEntity> GetEntity(string keyValue)
        {
            #region 添加操作记录-采购订单
            string F_Description = "查看采购订单";
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(keyValue, "2", F_Description, GetUserId());
            #endregion

            return await caseErpPurchaseService.GetEntity(keyValue);
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
            await caseErpPurchaseService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new PurchaseDto();
            res.CaseErpPurchaseEntity = await GetEntity(keyValue);
            if (res.CaseErpPurchaseEntity != null)
            {
                res.CaseErpPurchasedetailList = await _iCaseErpPurchasedetailBLL.GetList(new CaseErpPurchasedetailEntity { F_PurchaseId = res.CaseErpPurchaseEntity.F_Id });
            }
            caseErpPurchaseService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if (res.CaseErpPurchaseEntity != null)
                {
                    await _iCaseErpPurchasedetailBLL.DeleteRelateEntity(res.CaseErpPurchaseEntity.F_Id);
                }
                caseErpPurchaseService.Commit();
            }
            catch (Exception)
            {
                caseErpPurchaseService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpPurchaseEntity entity)
        {

            await caseErpPurchaseService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, PurchaseDto dto)
        {
            caseErpPurchaseService.BeginTrans();
            //是否系统编号(0是，1否)
            if (dto.CaseErpPurchaseEntity.F_IsSysNum == 0)
            {
                dto.CaseErpPurchaseEntity.F_Number = (await GetRuleCodeEx(dto.CaseErpPurchaseEntity.F_Number)).ToString();
            }
            //采购订单关联到对应的采购申请，则进行采购申请状态的更新
            if (dto.CaseErpPurchaseEntity.F_IsRelated == 0)
            {
                var ApplyEntity = await _icaseErpApplyBLL.GetEntity(dto.CaseErpPurchaseEntity.F_ApplyId);
                if (ApplyEntity != null)
                {
                    ApplyEntity.F_PurchaseUserId = dto.CaseErpPurchaseEntity.F_PurchasePerson;

                    await _icaseErpApplyBLL.SaveEntity(ApplyEntity.F_Id, ApplyEntity);
                }
            }
            //采购物品
            var F_PurchaseSynopsis=string.Empty;
            if (dto.CaseErpPurchasedetailList!=null)
            {
                dto.CaseErpPurchaseEntity.F_AmountSum = 0;
                foreach (var item in dto.CaseErpPurchasedetailList)
                {
                    F_PurchaseSynopsis += $"{item.F_Name}:{item.F_Count},";
                    dto.CaseErpPurchaseEntity.F_AmountSum += item.F_AfterTaxAmount;
                }
                dto.CaseErpPurchaseEntity.F_PurchaseSynopsis = F_PurchaseSynopsis.TrimEnd(',');
            }

            if (string.IsNullOrEmpty(keyValue))
            {
                dto.CaseErpPurchaseEntity.F_AlreadyAmount = 0;
                dto.CaseErpPurchaseEntity.F_AlreadyTicket = 0;
            }
            
            try
            {
                await SaveEntity(keyValue, dto.CaseErpPurchaseEntity);
                await _iCaseErpPurchasedetailBLL.SaveList(dto.CaseErpPurchaseEntity.F_Id, dto.CaseErpPurchasedetailList);
                
                
                #region 添加操作记录-采购订单
                string F_Description = "修改采购订单";
                if (string.IsNullOrEmpty(keyValue))
                {
                    F_Description = "新增采购订单";
                }
                var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
                await _iCaseErpLogBLL.SaveLog(dto.CaseErpPurchaseEntity.F_Id, "2", F_Description, GetUserId());
                #endregion
                
                caseErpPurchaseService.Commit();
            }
            catch (Exception)
            {
                caseErpPurchaseService.Rollback();
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
            await caseErpPurchaseService.Deletes(keyValues);
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
                var res = new PurchaseDto();
                res.CaseErpPurchaseEntity = await GetEntity(keyValue);
                if (res.CaseErpPurchaseEntity != null)
                {
                    res.CaseErpPurchasedetailList = await _iCaseErpPurchasedetailBLL.GetList(new CaseErpPurchasedetailEntity { F_PurchaseId = res.CaseErpPurchaseEntity.F_Id });
                }
                caseErpPurchaseService.BeginTrans();
                try
                {
                    await Delete(keyValue);
                    if (res.CaseErpPurchaseEntity != null)
                    {
                        await _iCaseErpPurchasedetailBLL.DeleteRelateEntity(res.CaseErpPurchaseEntity.F_Id);
                    }
                    caseErpPurchaseService.Commit();
                }
                catch (Exception)
                {
                    caseErpPurchaseService.Rollback();
                    throw;
                }
            }
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取对应物料的采购记录
        /// </summary>
        /// <param name="num">物料编码</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchaseEntity>> GetPurchasesLog(Pagination pagination, CaseErpPurchaseEntity queryParams, string num)
        {
            return caseErpPurchaseService.GetPurchasesLog(pagination, queryParams,num);
        }
        
        /// <summary>
        /// 更新订单审批状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <param name="unitName"></param>
        public async Task UpdateStateByWf(string processId, string code,string unitName)
        {
            var entity =await caseErpPurchaseService.GetEntity(processId);
            if (entity != null)
            {
                switch (code)
                {
                    case "create":
                        entity.F_SaveState = 0;
                        entity.F_AuditState = 2;
                        break;
                    case "disagree":
                        entity.F_AuditState = 3;
                        break;
                    case "agree":
                        entity.F_AuditState = 4;
                        break;
                    case "revoke":
                        if (unitName == "更新流程发起状态")
                        {
                            entity.F_SaveState = 1;
                            entity.F_AuditState = 1;
                        }
                        else
                        {
                            entity.F_AuditState = 2;
                        }
                        break;
                        
                }
                await caseErpPurchaseService.SaveEntity(processId, entity);
            }
        }

        #endregion
    }
}
