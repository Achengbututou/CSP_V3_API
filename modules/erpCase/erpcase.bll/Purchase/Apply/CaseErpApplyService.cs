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
    /// 日 期： 2022-11-30 15:26:32
    /// 描 述： 采购申请数据库执行类
    /// </summary>
    public class CaseErpApplyService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpApplyEntity, bool>> GetExpression(CaseErpApplyEntity queryParams) {
            var exp = Expressionable.Create<CaseErpApplyEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number),t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Theme),t => t.F_Theme.Contains(queryParams.F_Theme));
            if(!string.IsNullOrEmpty(queryParams.F_ApplyDateQRange))
            {
                var f_ApplyDate_list = queryParams.F_ApplyDateQRange.Split(" - ");
                DateTime f_ApplyDate = Convert.ToDateTime(f_ApplyDate_list[0]);
                DateTime f_ApplyDate_end = Convert.ToDateTime(f_ApplyDate_list[1]);
                exp = exp.And(t => t.F_ApplyDate >= f_ApplyDate &&t.F_ApplyDate <= f_ApplyDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplyDep),t => t.F_ApplyDep.Contains(queryParams.F_ApplyDep));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplyPerson),t => t.F_ApplyPerson.Contains(queryParams.F_ApplyPerson));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RelatedProject),t => t.F_RelatedProject.Contains(queryParams.F_RelatedProject));
            if (queryParams.F_IsSysNum != null)
            {
                exp = exp.And(t => t.F_IsSysNum == queryParams.F_IsSysNum);
            }
            if (queryParams.F_DeleteMark != null)
            {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if (queryParams.F_PurchaseState != null)
            {
                exp = exp.And(t => t.F_PurchaseState == queryParams.F_PurchaseState);
            }
            if (queryParams.PurchaseStateNot != null)
            {
                exp = exp.And(t => t.F_PurchaseState != queryParams.PurchaseStateNot);
            }
            
            
            
            

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchaseUserId), t => t.F_PurchaseUserId.Contains(queryParams.F_PurchaseUserId));
            if (queryParams.F_CountSum != null)
            {
                exp = exp.And(t => t.F_CountSum == queryParams.F_CountSum);
            }
            if(queryParams.F_AmountSum != null)
            {
                exp = exp.And(t => t.F_AmountSum == queryParams.F_AmountSum);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_File),t => t.F_File.Contains(queryParams.F_File));
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

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Number.Contains(queryParams.Keyword) || t.F_Theme.Contains(queryParams.Keyword));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取采购申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpApplyEntity>> GetList(CaseErpApplyEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpApplyEntity>(expression);
        }

        /// <summary>
        /// 获取采购申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpApplyEntity>> GetPageList(Pagination pagination, CaseErpApplyEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpApplyEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpApplyEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpApplyEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpApplyEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpApplyEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = this.GetUserId();
                    entity.F_CreateUserName = this.GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();

                    entity.F_PurchaseState = 0;
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
            await this.BaseRepository().Delete<CaseErpApplyEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
