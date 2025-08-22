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
    public class CaseErpSaledetailService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpSaledetailEntity, bool>> GetExpression(CaseErpSaledetailEntity queryParams) {
            var exp = Expressionable.Create<CaseErpSaledetailEntity>();
            if(!string.IsNullOrEmpty(queryParams.F_SaleId))
            {
                exp = exp.And(t => t.F_SaleId == queryParams.F_SaleId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number),t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Name),t => t.F_Name.Contains(queryParams.F_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Model),t => t.F_Model.Contains(queryParams.F_Model));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit),t => t.F_Unit.Contains(queryParams.F_Unit));
            if(queryParams.F_Price != null)
            {
                exp = exp.And(t => t.F_Price == queryParams.F_Price);
            }
            if(queryParams.F_Count != null)
            {
                exp = exp.And(t => t.F_Count == queryParams.F_Count);
            }
            if(queryParams.F_Discount != null)
            {
                exp = exp.And(t => t.F_Discount == queryParams.F_Discount);
            }
            if(queryParams.F_TaxRate != null)
            {
                exp = exp.And(t => t.F_TaxRate == queryParams.F_TaxRate);
            }
            if(queryParams.F_TaxBreak != null)
            {
                exp = exp.And(t => t.F_TaxBreak == queryParams.F_TaxBreak);
            }
            if(queryParams.F_AfterTaxAmount != null)
            {
                exp = exp.And(t => t.F_AfterTaxAmount == queryParams.F_AfterTaxAmount);
            }
            if(!string.IsNullOrEmpty(queryParams.F_DeliveryDateQRange))
            {
                var f_DeliveryDate_list = queryParams.F_DeliveryDateQRange.Split(" - ");
                DateTime f_DeliveryDate = Convert.ToDateTime(f_DeliveryDate_list[0]);
                DateTime f_DeliveryDate_end = Convert.ToDateTime(f_DeliveryDate_list[1]);
                exp = exp.And(t => t.F_DeliveryDate >= f_DeliveryDate &&t.F_DeliveryDate <= f_DeliveryDate_end);
            }
            if(queryParams.F_InStoreCount != null)
            {
                exp = exp.And(t => t.F_InStoreCount == queryParams.F_InStoreCount);
            }
            if(queryParams.F_NoInStoreCount != null)
            {
                exp = exp.And(t => t.F_NoInStoreCount == queryParams.F_NoInStoreCount);
            }
            if(queryParams.F_ReturnCount != null)
            {
                exp = exp.And(t => t.F_ReturnCount == queryParams.F_ReturnCount);
            }
            if(queryParams.F_PlanCount != null)
            {
                exp = exp.And(t => t.F_PlanCount == queryParams.F_PlanCount);
            }
            if(queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
            }
            if(queryParams.F_DeleteMark != null)
            {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if(queryParams.F_EnabledMark != null)
            {
                exp = exp.And(t => t.F_EnabledMark == queryParams.F_EnabledMark);
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

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取销售订单信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaledetailEntity>> GetList(CaseErpSaledetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSaledetailEntity>(expression);
        }

        /// <summary>
        /// 获取销售订单信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaledetailEntity>> GetPageList(Pagination pagination, CaseErpSaledetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSaledetailEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSaledetailEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpSaledetailEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpSaledetailEntity>(keyValue);
        }

        /// <summary>
        /// 删除销售订单信息的数据根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository().Delete<CaseErpSaledetailEntity>(t=>t.F_SaleId == key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSaledetailEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = this.GetUserId();
                    entity.F_CreateUserName = this.GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();
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
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<CaseErpSaledetailEntity> list) {
            var addList = new List<CaseErpSaledetailEntity>();
            var db = this.BaseRepository().BeginTrans();
            try{
                await db.Delete<CaseErpSaledetailEntity>(t => t.F_SaleId == key);
                foreach (var item in list)
                {
                    if(string.IsNullOrEmpty(item.F_Id))
                    {
                        item.F_CreateDate = DateTime.Now;
                        item.F_CreateUserId = this.GetUserId();
                        item.F_CreateUserName = this.GetUserName();
                        item.F_Id = Guid.NewGuid().ToString();
                    }
                    else {
                        item.F_ModifyDate = DateTime.Now;
                        item.F_ModifyUserId = this.GetUserId();
                        item.F_ModifyUserName = this.GetUserName();
                    }
                    item.F_SaleId = key;
                    addList.Add(item);
                }
                if (addList.Count > 0)
                {
                    await db.Inserts(addList);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
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
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<CaseErpSaledetailEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
