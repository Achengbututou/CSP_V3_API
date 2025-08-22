using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-30 15:20:23
    /// 描 述： 采购订单数据库执行类
    /// </summary>
    public class CaseErpPurchaseService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpPurchaseEntity, bool>> GetExpression(CaseErpPurchaseEntity queryParams)
        {
            var exp = Expressionable.Create<CaseErpPurchaseEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number), t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplyId), t => t.F_ApplyId.Contains(queryParams.F_ApplyId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplyNumber), t => t.F_ApplyNumber.Contains(queryParams.F_ApplyNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Theme), t => t.F_Theme.Contains(queryParams.F_Theme));
            if (!string.IsNullOrEmpty(queryParams.F_PurchaseDateQRange))
            {
                var f_PurchaseDate_list = queryParams.F_PurchaseDateQRange.Split(" - ");
                DateTime f_PurchaseDate = Convert.ToDateTime(f_PurchaseDate_list[0]);
                DateTime f_PurchaseDate_end = Convert.ToDateTime(f_PurchaseDate_list[1]);
                exp = exp.And(t => t.F_PurchaseDate >= f_PurchaseDate && t.F_PurchaseDate <= f_PurchaseDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierName), t => t.F_SupplierName.Contains(queryParams.F_SupplierName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierPerson), t => t.F_SupplierPerson.Contains(queryParams.F_SupplierPerson));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierWay), t => t.F_SupplierWay.Contains(queryParams.F_SupplierWay));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchaseDep), t => t.F_PurchaseDep.Contains(queryParams.F_PurchaseDep));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchasePerson), t => t.F_PurchasePerson.Contains(queryParams.F_PurchasePerson));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchasePhone), t => t.F_PurchasePhone.Contains(queryParams.F_PurchasePhone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RelatedProject), t => t.F_RelatedProject.Contains(queryParams.F_RelatedProject));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PayType), t => t.F_PayType.Contains(queryParams.F_PayType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PayAddress), t => t.F_PayAddress.Contains(queryParams.F_PayAddress));
            if (queryParams.F_IsSysNum != null)
            {
                exp = exp.And(t => t.F_IsSysNum == queryParams.F_IsSysNum);
            }
            if (queryParams.F_IsRelated != null)
            {
                exp = exp.And(t => t.F_IsRelated == queryParams.F_IsRelated);
            }
            if (queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_File), t => t.F_File.Contains(queryParams.F_File));
            if (queryParams.F_CountSum != null)
            {
                exp = exp.And(t => t.F_CountSum == queryParams.F_CountSum);
            }
            if (queryParams.F_AmountSum != null)
            {
                exp = exp.And(t => t.F_AmountSum == queryParams.F_AmountSum);
            }
            if (queryParams.F_Discount != null)
            {
                exp = exp.And(t => t.F_Discount == queryParams.F_Discount);
            }
            if (queryParams.F_AlreadyAmount != null)
            {
                exp = exp.And(t => t.F_AlreadyAmount == queryParams.F_AlreadyAmount);
            }
            if (queryParams.F_AlreadyTicket != null)
            {
                exp = exp.And(t => t.F_AlreadyTicket == queryParams.F_AlreadyTicket);
            }
            if (queryParams.F_AuditState != null)
            {
                exp = exp.And(t => t.F_AuditState == queryParams.F_AuditState);
            }
            if (queryParams.F_SaveState != null)
            {
                exp = exp.And(t => t.F_SaveState == queryParams.F_SaveState);
            }
            if (queryParams.F_InStoreState != null)
            {
                exp = exp.And(t => t.F_InStoreState == queryParams.F_InStoreState);
            }
            if (queryParams.F_TicketState != null)
            {
                exp = exp.And(t => t.F_TicketState == queryParams.F_TicketState);
            }
            if (queryParams.F_PayState != null)
            {
                exp = exp.And(t => t.F_PayState == queryParams.F_PayState);
            }
            if (queryParams.F_DeleteMark != null)
            {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if (queryParams.F_EnabledMark != null)
            {
                exp = exp.And(t => t.F_EnabledMark == queryParams.F_EnabledMark);
            }
            if (!string.IsNullOrEmpty(queryParams.F_CreateDateQRange))
            {
                var f_CreateDate_list = queryParams.F_CreateDateQRange.Split(" - ");
                DateTime f_CreateDate = Convert.ToDateTime(f_CreateDate_list[0]);
                DateTime f_CreateDate_end = Convert.ToDateTime(f_CreateDate_list[1]);
                exp = exp.And(t => t.F_CreateDate >= f_CreateDate && t.F_CreateDate <= f_CreateDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserId), t => t.F_CreateUserId.Contains(queryParams.F_CreateUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserName), t => t.F_CreateUserName.Contains(queryParams.F_CreateUserName));
            if (!string.IsNullOrEmpty(queryParams.F_ModifyDateQRange))
            {
                var f_ModifyDate_list = queryParams.F_ModifyDateQRange.Split(" - ");
                DateTime f_ModifyDate = Convert.ToDateTime(f_ModifyDate_list[0]);
                DateTime f_ModifyDate_end = Convert.ToDateTime(f_ModifyDate_list[1]);
                exp = exp.And(t => t.F_ModifyDate >= f_ModifyDate && t.F_ModifyDate <= f_ModifyDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserId), t => t.F_ModifyUserId.Contains(queryParams.F_ModifyUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserName), t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Number.Contains(queryParams.Keyword) || t.F_Theme.Contains(queryParams.Keyword) || t.F_SupplierName.Contains(queryParams.Keyword));
            return exp.ToExpression();
        }

        /// <summary>
        /// 获取采购订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchaseEntity>> GetList(CaseErpPurchaseEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository().FindList(expression);
        }

        /// <summary>
        /// 获取采购订单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchaseEntity>> GetPageList(Pagination pagination, CaseErpPurchaseEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpPurchaseEntity> GetEntity(string keyValue)
        {
            return BaseRepository().FindEntityByKey<CaseErpPurchaseEntity>(keyValue);
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
            await BaseRepository().Delete<CaseErpPurchaseEntity>(keyValue);
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpPurchaseEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_CreateDate = DateTime.Now;
                entity.F_CreateUserId = GetUserId();
                entity.F_CreateUserName = GetUserName();
                //entity.F_InStoreState = 0;
                //entity.F_TicketState = 0;
                //entity.F_PayState = 0;


                await BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = GetUserId();
                entity.F_ModifyUserName = GetUserName();
                entity.F_Id = keyValue;


                await BaseRepository().Update(entity);
            }
        }



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await BaseRepository().Delete<CaseErpPurchaseEntity>(keyValuesArr);
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取对应物料的采购记录
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <param name="num">物料编码</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchaseEntity>> GetPurchasesLog(Pagination pagination, CaseErpPurchaseEntity queryParams, string num)
        {
            return this.BaseRepository().FindListByQueryable<CaseErpPurchaseEntity>(q => {
                var queryable = q.LeftJoin<CaseErpPurchasedetailEntity>((t, t1) => t.F_Id == t1.F_PurchaseId);
                var exp = Expressionable.Create<CaseErpPurchaseEntity, CaseErpPurchasedetailEntity>();
                //查询关键字
                exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), (t, t1) => t.F_Number.Contains(queryParams.Keyword) || t.F_Theme.Contains(queryParams.Keyword));
                //查询物料编号
                exp = exp.AndIF(!string.IsNullOrEmpty(num), (t, t1) => t1.F_Number.Contains(num));
                return queryable
                .Where(exp.ToExpression())
                .Select((t, t1) => new CaseErpPurchaseEntity()
                {
                    F_Id = t.F_Id,
                    F_Number = t.F_Number,
                    F_Theme = t.F_Theme,
                    F_PurchaseDate = t.F_PurchaseDate,
                    F_PurchasePerson = t.F_PurchasePerson,
                    F_PurchaseDep = t.F_PurchaseDep,
                    F_SupplierName = t.F_SupplierName,
                    F_CountSum = t1.F_Count,
                    F_AmountSum = t1.F_AfterTaxAmount,
                    F_CreateUserId = t.F_CreateUserId,
                    F_CreateUserName = t.F_CreateUserName,
                    F_CreateDate = t.F_CreateDate
                });
            }, pagination);
        }
        #endregion
    }
}
