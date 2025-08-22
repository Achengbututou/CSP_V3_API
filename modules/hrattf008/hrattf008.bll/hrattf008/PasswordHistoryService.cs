using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using HRATTF008.ibll;
namespace HRATTF008.bll
{
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：Password_History(查询密码历史记录表)
    /// </summary>
    public class PasswordHistoryService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<PasswordHistoryEntity, bool>> GetExpression(PasswordHistoryEntity queryParams)
        {
            var exp = Expressionable.Create<PasswordHistoryEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Company_Code), t => t.Company_Code.Equals(queryParams.Company_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Equals(queryParams.Emp_No));

            //能查出来代表密码在最近三次内有重复
            if (queryParams.PasswordQRangeList != null)
            {
                exp = exp.And(t => queryParams.PasswordQRangeList.Contains(t.Password));
            }

            return exp.ToExpression();
        }
        
        /// <summary>
        /// 获取历史密码记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<PasswordHistoryEntity>> GetPageList(Pagination pagination, PasswordHistoryEntity queryParams, string AuthoritySql = null)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList(expression, pagination, AuthoritySql);
        }
        #endregion

        #region
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, PasswordHistoryEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.RID))
                {
                    entity.RID = Guid.NewGuid().ToString();
                }
                await this.BaseRepository("OA").Insert(entity);
            }
            else
            {
                entity.RID = keyValue;
                entity.Last_Update_Date = DateTime.Now;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        #endregion
    }
}