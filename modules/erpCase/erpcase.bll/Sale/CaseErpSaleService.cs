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
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:40:15
    /// 描 述： 销售订单信息数据库执行类
    /// </summary>
    public class CaseErpSaleService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpSaleEntity, bool>> GetExpression(CaseErpSaleEntity queryParams) {
            var exp = Expressionable.Create<CaseErpSaleEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number),t => t.F_Number.Contains(queryParams.F_Number));
            if(queryParams.F_IsSysNum != null)
            {
                exp = exp.And(t => t.F_IsSysNum == queryParams.F_IsSysNum);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Theme),t => t.F_Theme.Contains(queryParams.F_Theme));
            if(!string.IsNullOrEmpty(queryParams.F_SaleDateQRange))
            {
                var f_SaleDate_list = queryParams.F_SaleDateQRange.Split(" - ");
                DateTime f_SaleDate = Convert.ToDateTime(f_SaleDate_list[0]);
                DateTime f_SaleDate_end = Convert.ToDateTime(f_SaleDate_list[1]);
                exp = exp.And(t => t.F_SaleDate >= f_SaleDate &&t.F_SaleDate <= f_SaleDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ClientName),t => t.F_ClientName.Contains(queryParams.F_ClientName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ClientPerson),t => t.F_ClientPerson.Contains(queryParams.F_ClientPerson));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ClientWay),t => t.F_ClientWay.Contains(queryParams.F_ClientWay));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Manager),t => t.F_Manager.Contains(queryParams.F_Manager));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Dep),t => t.F_Dep.Contains(queryParams.F_Dep));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Phone),t => t.F_Phone.Contains(queryParams.F_Phone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RelatedProject),t => t.F_RelatedProject.Contains(queryParams.F_RelatedProject));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PayType),t => t.F_PayType.Contains(queryParams.F_PayType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ClientNumber),t => t.F_ClientNumber.Contains(queryParams.F_ClientNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PayAddress),t => t.F_PayAddress.Contains(queryParams.F_PayAddress));
            if(queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_File),t => t.F_File.Contains(queryParams.F_File));
            if(queryParams.F_CountSum != null)
            {
                exp = exp.And(t => t.F_CountSum == queryParams.F_CountSum);
            }
            if(queryParams.F_AmountSum != null)
            {
                exp = exp.And(t => t.F_AmountSum == queryParams.F_AmountSum);
            }
            if(queryParams.F_Discount != null)
            {
                exp = exp.And(t => t.F_Discount == queryParams.F_Discount);
            }
            if(queryParams.F_AlreadyAmount != null)
            {
                exp = exp.And(t => t.F_AlreadyAmount == queryParams.F_AlreadyAmount);
            }
            if(queryParams.F_AlreadyTicket != null)
            {
                exp = exp.And(t => t.F_AlreadyTicket == queryParams.F_AlreadyTicket);
            }
            if(queryParams.F_AuditState != null)
            {
                exp = exp.And(t => t.F_AuditState == queryParams.F_AuditState);
            }
            if(queryParams.F_SaveState != null)
            {
                exp = exp.And(t => t.F_SaveState == queryParams.F_SaveState);
            }
            if(queryParams.F_DeleteMark != null)
            {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if(queryParams.F_EnabledMark != null)
            {
                exp = exp.And(t => t.F_EnabledMark == queryParams.F_EnabledMark);
            }
            if(queryParams.F_OutStoreState != null)
            {
                exp = exp.And(t => t.F_OutStoreState == queryParams.F_OutStoreState);
            }
            if(queryParams.F_InvoiceState != null)
            {
                exp = exp.And(t => t.F_InvoiceState == queryParams.F_InvoiceState);
            }
            if(queryParams.F_GatherState != null)
            {
                exp = exp.And(t => t.F_GatherState == queryParams.F_GatherState);
            }
            if(!string.IsNullOrEmpty(queryParams.F_CreateDateQRange))
            {
                var f_CreateDate_list = queryParams.F_CreateDateQRange.Split(" - ");
                DateTime f_CreateDate = Convert.ToDateTime(f_CreateDate_list[0]);
                DateTime f_CreateDate_end = Convert.ToDateTime(f_CreateDate_list[1]);
                exp = exp.And(t => t.F_CreateDate >= f_CreateDate &&t.F_CreateDate <= f_CreateDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserId),t => t.F_CreateUserId.Contains(queryParams.F_CreateUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserName),t => t.F_CreateUserName.Contains(queryParams.F_CreateUserName));
            if(!string.IsNullOrEmpty(queryParams.F_ModifyDateQRange))
            {
                var f_ModifyDate_list = queryParams.F_ModifyDateQRange.Split(" - ");
                DateTime f_ModifyDate = Convert.ToDateTime(f_ModifyDate_list[0]);
                DateTime f_ModifyDate_end = Convert.ToDateTime(f_ModifyDate_list[1]);
                exp = exp.And(t => t.F_ModifyDate >= f_ModifyDate &&t.F_ModifyDate <= f_ModifyDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserId),t => t.F_ModifyUserId.Contains(queryParams.F_ModifyUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserName),t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId),t => t.F_TenantId.Contains(queryParams.F_TenantId));

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Number.Contains(queryParams.Keyword) || t.F_Theme.Contains(queryParams.Keyword));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取销售订单信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaleEntity>> GetList(CaseErpSaleEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSaleEntity>(expression);
        }

        /// <summary>
        /// 获取销售订单信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaleEntity>> GetPageList(Pagination pagination, CaseErpSaleEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSaleEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSaleEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpSaleEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpSaleEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSaleEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = this.GetUserId();
                    entity.F_CreateUserName = this.GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();

                    entity.F_OutStoreState = 0;
                    entity.F_InvoiceState = 0;
                    entity.F_GatherState = 0;
                }


                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = this.GetUserId();
                entity.F_ModifyUserName = this.GetUserName();
                entity.F_Id = keyValue;


                await this.BaseRepository().Update(entity);
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
            await this.BaseRepository().Delete<CaseErpSaleEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
