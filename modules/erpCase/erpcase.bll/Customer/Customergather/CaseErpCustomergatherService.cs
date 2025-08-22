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
    /// 日 期： 2022-12-05 16:43:25
    /// 描 述： 客户回款数据库执行类
    /// </summary>
    public class CaseErpCustomergatherService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpCustomergatherEntity, bool>> GetExpression(CaseErpCustomergatherEntity queryParams) {
            var exp = Expressionable.Create<CaseErpCustomergatherEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CustomerId),t => t.F_CustomerId.Contains(queryParams.F_CustomerId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Name),t => t.F_Name.Contains(queryParams.F_Name));
            if(queryParams.F_WaitAmount != null)
            {
                exp = exp.And(t => t.F_WaitAmount == queryParams.F_WaitAmount);
            }
            if(!string.IsNullOrEmpty(queryParams.F_ReceivedDateQRange))
            {
                var f_ReceivedDate_list = queryParams.F_ReceivedDateQRange.Split(" - ");
                DateTime f_ReceivedDate = Convert.ToDateTime(f_ReceivedDate_list[0]);
                DateTime f_ReceivedDate_end = Convert.ToDateTime(f_ReceivedDate_list[1]);
                exp = exp.And(t => t.F_ReceivedDate >= f_ReceivedDate &&t.F_ReceivedDate <= f_ReceivedDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_FinallyDateQRange))
            {
                var f_FinallyDate_list = queryParams.F_FinallyDateQRange.Split(" - ");
                DateTime f_FinallyDate = Convert.ToDateTime(f_FinallyDate_list[0]);
                DateTime f_FinallyDate_end = Convert.ToDateTime(f_FinallyDate_list[1]);
                exp = exp.And(t => t.F_FinallyDate >= f_FinallyDate &&t.F_FinallyDate <= f_FinallyDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Principal),t => t.F_Principal.Contains(queryParams.F_Principal));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Title),t => t.F_Title.Contains(queryParams.F_Title));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_File),t => t.F_File.Contains(queryParams.F_File));
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
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SaleId), t => t.F_SaleId.Contains(queryParams.F_SaleId));

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Name.Contains(queryParams.Keyword) || t.F_Title.Contains(queryParams.Keyword));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取客户回款的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomergatherEntity>> GetList(CaseErpCustomergatherEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpCustomergatherEntity>(expression);
        }

        /// <summary>
        /// 获取客户回款的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomergatherEntity>> GetPageList(Pagination pagination, CaseErpCustomergatherEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpCustomergatherEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpCustomergatherEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpCustomergatherEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpCustomergatherEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpCustomergatherEntity entity)
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


                await this.BaseRepository().Update(entity,true);
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
            await this.BaseRepository().Delete<CaseErpCustomergatherEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
