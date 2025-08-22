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
    /// 日 期： 2022-12-05 16:42:10
    /// 描 述： 客户信息数据库执行类
    /// </summary>
    public class CaseErpCustomerService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpCustomerEntity, bool>> GetExpression(CaseErpCustomerEntity queryParams)
        {
            var exp = Expressionable.Create<CaseErpCustomerEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Name), t => t.F_Name.Contains(queryParams.F_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Type), t => t.F_Type.Contains(queryParams.F_Type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Person), t => t.F_Person.Contains(queryParams.F_Person));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Phone), t => t.F_Phone.Contains(queryParams.F_Phone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Industry), t => t.F_Industry.Contains(queryParams.F_Industry));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Source), t => t.F_Source.Contains(queryParams.F_Source));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Scale), t => t.F_Scale.Contains(queryParams.F_Scale));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Address), t => t.F_Address.Contains(queryParams.F_Address));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ComNature), t => t.F_ComNature.Contains(queryParams.F_ComNature));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_File), t => t.F_File.Contains(queryParams.F_File));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DefaultName), t => t.F_DefaultName.Contains(queryParams.F_DefaultName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DefaultPhone), t => t.F_DefaultPhone.Contains(queryParams.F_DefaultPhone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DefaultPost), t => t.F_DefaultPost.Contains(queryParams.F_DefaultPost));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DefaultDep), t => t.F_DefaultDep.Contains(queryParams.F_DefaultDep));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SaleId), t => t.F_SaleId.Contains(queryParams.F_SaleId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_State), t => t.F_State.Contains(queryParams.F_State));
            if (!string.IsNullOrEmpty(queryParams.F_InOpenDateQRange))
            {
                var f_InOpenDate_list = queryParams.F_InOpenDateQRange.Split(" - ");
                DateTime f_InOpenDate = Convert.ToDateTime(f_InOpenDate_list[0]);
                DateTime f_InOpenDate_end = Convert.ToDateTime(f_InOpenDate_list[1]);
                exp = exp.And(t => t.F_InOpenDate >= f_InOpenDate && t.F_InOpenDate <= f_InOpenDate_end);
            }
            if (queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
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
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Name.Contains(queryParams.Keyword) || t.F_Person.Contains(queryParams.Keyword) || t.F_Phone.Contains(queryParams.Keyword));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取客户信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomerEntity>> GetList(CaseErpCustomerEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository().FindList(expression);
        }

        /// <summary>
        /// 获取客户信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <param name="AuthoritySql">数据权限</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomerEntity>> GetPageList(Pagination pagination, CaseErpCustomerEntity queryParams,string AuthoritySql)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository().FindList(expression, pagination, AuthoritySql);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpCustomerEntity> GetEntity(string keyValue)
        {
            return BaseRepository().FindEntityByKey<CaseErpCustomerEntity>(keyValue);
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
            await BaseRepository().Delete<CaseErpCustomerEntity>(keyValue);
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpCustomerEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = GetUserId();
                    entity.F_CreateUserName = GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_SaleId = GetUserId();
                    if (string.IsNullOrEmpty(entity.F_State))
                    {
                        entity.F_State = "0";
                    }
                }


                await BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = GetUserId();
                entity.F_ModifyUserName = GetUserName();
                entity.F_Id = keyValue;


                await BaseRepository().Update(entity,true);
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
            await BaseRepository().Delete<CaseErpCustomerEntity>(keyValuesArr);
        }


        #endregion
    }
}
