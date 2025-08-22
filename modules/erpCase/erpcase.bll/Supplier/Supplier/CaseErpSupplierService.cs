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
    /// 日 期： 2022-12-05 16:09:49
    /// 描 述： 供应商信息数据库执行类
    /// </summary>
    public class CaseErpSupplierService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpSupplierEntity, bool>> GetExpression(CaseErpSupplierEntity queryParams)
        {
            var exp = Expressionable.Create<CaseErpSupplierEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number), t => t.F_Number.Contains(queryParams.F_Number));
            if (queryParams.F_IsSysNum != null)
            {
                exp = exp.And(t => t.F_IsSysNum == queryParams.F_IsSysNum);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Name), t => t.F_Name.Contains(queryParams.F_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Person), t => t.F_Person.Contains(queryParams.F_Person));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Phone), t => t.F_Phone.Contains(queryParams.F_Phone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Scope), t => t.F_Scope.Contains(queryParams.F_Scope));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Type), t => t.F_Type.Contains(queryParams.F_Type));
            if (queryParams.F_LatentState != null)
            {
                exp = exp.And(t => t.F_LatentState == queryParams.F_LatentState);
            }
            if (queryParams.F_FormalState != null)
            {
                exp = exp.And(t => t.F_FormalState == queryParams.F_FormalState);
            }
            if (queryParams.F_State != null)
            {
                exp = exp.And(t => t.F_State == queryParams.F_State);
            }
            if (queryParams.F_AssessState != null)
            {
                exp = exp.And(t => t.F_AssessState == queryParams.F_AssessState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OutType), t => t.F_OutType.Contains(queryParams.F_OutType));
            if (queryParams.F_OutReason != null)
            {
                exp = exp.And(t => t.F_OutReason == queryParams.F_OutReason);
            }
            if (queryParams.F_RecoverReason != null)
            {
                exp = exp.And(t => t.F_RecoverReason == queryParams.F_RecoverReason);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RecoverFile), t => t.F_RecoverFile.Contains(queryParams.F_RecoverFile));
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

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Number.Contains(queryParams.Keyword) || t.F_Name.Contains(queryParams.Keyword) || t.F_Phone.Contains(queryParams.Keyword));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取供应商信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierEntity>> GetList(CaseErpSupplierEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository().FindList(expression);
        }

        /// <summary>
        /// 获取供应商信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierEntity>> GetPageList(Pagination pagination, CaseErpSupplierEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplierEntity> GetEntity(string keyValue)
        {
            return BaseRepository().FindEntityByKey<CaseErpSupplierEntity>(keyValue);
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
            await BaseRepository().Delete<CaseErpSupplierEntity>(keyValue);
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplierEntity entity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
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
                    await db.Insert(entity);
                }
                else
                {
                    entity.F_ModifyDate = DateTime.Now;
                    entity.F_ModifyUserId = GetUserId();
                    entity.F_ModifyUserName = GetUserName();
                    entity.F_Id = keyValue;

                    await db.Update(entity);
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
            await BaseRepository().Delete<CaseErpSupplierEntity>(keyValuesArr);
        }


        #endregion
    }
}
