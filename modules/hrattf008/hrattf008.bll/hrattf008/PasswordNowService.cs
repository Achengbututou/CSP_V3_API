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
    /// 描 述：Password_Now(查询密码)
    /// </summary>
    public class PasswordNowService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<PasswordNowEntity, bool>> GetExpression(PasswordNowEntity queryParams)
        {
            var exp = Expressionable.Create<PasswordNowEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Company_Code), t => t.Company_Code.Equals(queryParams.Company_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Equals(queryParams.Emp_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Password), t => t.Password.Equals(queryParams.Password));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Key), t => t.Key.Equals(queryParams.Key));

            if (queryParams.Type != 0 && queryParams.Type != 2)
            {
                exp = exp.And(t => t.Type.Equals(queryParams.Type));
            }

            if (!string.IsNullOrEmpty(queryParams.Effect_DateQRange))
            {
                var from_Date_list = queryParams.Effect_DateQRange.Split(" - ");
                DateTime from_Date = Convert.ToDateTime(from_Date_list[0]);
                DateTime from_Date_end = Convert.ToDateTime(from_Date_list[1]);
                exp = exp.And(t => t.Effect_Date >= from_Date && t.Effect_Date <= from_Date_end);
            }
            if (!string.IsNullOrEmpty(queryParams.End_DateQRange))
            {
                var to_Date_list = queryParams.End_DateQRange.Split(" - ");
                DateTime to_Date = Convert.ToDateTime(to_Date_list[0]);
                DateTime to_Date_end = Convert.ToDateTime(to_Date_list[1]);
                exp = exp.And(t => t.End_Date >= to_Date && t.End_Date <= to_Date_end);
            }

            return exp.ToExpression();
        }
        /// <summary>
        /// 获取密码的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<PasswordNowEntity>> GetList(PasswordNowEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository("OA").FindList(expression);
        }
        /// <summary>
        /// 获取密码的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<PasswordNowEntity>> GetPageList(Pagination pagination, PasswordNowEntity queryParams, string AuthoritySql = null)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository("OA").FindList(expression, pagination, AuthoritySql);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, PasswordNowEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.RID))
                {
                    entity.RID = Guid.NewGuid().ToString();
                }
                //entity.Submit_UserID = this.GetUserId();
                //entity.Leave_Submit_Date = DateTime.Now;
                await BaseRepository("OA").Insert(entity);
            }
            else
            {
                entity.RID = keyValue;
                entity.Last_Update_Date = DateTime.Now;
                await BaseRepository("OA").Update(entity);
            }
        }
        #endregion
    }
}