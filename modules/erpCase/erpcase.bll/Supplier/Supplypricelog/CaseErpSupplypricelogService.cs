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
    /// 日 期： 2022-12-05 16:15:15
    /// 描 述： 供货清单价格记录数据库执行类
    /// </summary>
    public class CaseErpSupplypricelogService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpSupplypricelogEntity, bool>> GetExpression(CaseErpSupplypricelogEntity queryParams) {
            var exp = Expressionable.Create<CaseErpSupplypricelogEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplymaterialId),t => t.F_SupplymaterialId.Contains(queryParams.F_SupplymaterialId));
            if (queryParams.F_CurrentPrice != null)
            {
                exp = exp.And(t => t.F_CurrentPrice == queryParams.F_CurrentPrice);
            }
            if (queryParams.F_BeforePrice != null)
            {
                exp = exp.And(t => t.F_BeforePrice == queryParams.F_BeforePrice);
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
        /// 获取供货清单价格记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplypricelogEntity>> GetList(CaseErpSupplypricelogEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSupplypricelogEntity>(expression);
        }

        /// <summary>
        /// 获取供货清单价格记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplypricelogEntity>> GetPageList(Pagination pagination, CaseErpSupplypricelogEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSupplypricelogEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplypricelogEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpSupplypricelogEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpSupplypricelogEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplypricelogEntity entity)
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
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<CaseErpSupplypricelogEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
