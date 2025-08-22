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
    public class FHISPayrollEnHeaderService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<FHISPayrollEnHeaderEntity, bool>> GetExpression(PayrollEnDto queryParams)
        {
            var exp = Expressionable.Create<FHISPayrollEnHeaderEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Company_Code), t => t.Company_Code.Equals(queryParams.Company_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Equals(queryParams.Emp_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Period_Code), t => t.Period_Code.Equals(queryParams.Period_Code));
            //exp = exp.And(t => t.From_Date == queryParams.From_Date);

            return exp.ToExpression();
        }
        private Expression<Func<FHISPayrollEnHeaderEntity, bool>> GetExpression(FHISPayrollEnHeaderEntity queryParams)
        {
            var exp = Expressionable.Create<FHISPayrollEnHeaderEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Company_Code), t => t.Company_Code.Contains(queryParams.Company_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Contains(queryParams.Emp_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Period_Code), t => t.Period_Code.Equals(queryParams.Period_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Dept_Code), t => t.Dept_Code.Equals(queryParams.Dept_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Sect_Code), t => t.Sect_Code.Equals(queryParams.Sect_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Line_Code), t => t.Line_Code.Equals(queryParams.Line_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Sub_Line_Code), t => t.Sub_Line_Code.Equals(queryParams.Sub_Line_Code));

            if (queryParams.Status != 0)
            {
                exp = exp.And(t => t.Status.Equals(queryParams.Status));
            }
            //exp = exp.And(t => t.From_Date == queryParams.From_Date);

            if (queryParams.Resign_Status == 1)
            {
                exp = exp.And(t => t.Resign_Date == null || t.Resign_Date.Equals(""));
            } 
            else if (queryParams.Resign_Status == 2)
            {
                exp = exp.And(t => t.Resign_Date != null && !"".Equals(t.Resign_Date));
            }

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISPayrollEnHeaderEntity>> GetList(PayrollEnDto queryParams)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository("OA").FindList(expression);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISPayrollEnHeaderEntity>> GetPageList(Pagination pagination, FHISPayrollEnHeaderEntity queryParams, string AuthoritySql = null)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository("OA").FindList(expression, pagination, AuthoritySql);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<FHISPayrollEnHeaderEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<FHISPayrollEnHeaderEntity>(keyValue);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, FHISPayrollEnHeaderEntity entity)
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
                await this.BaseRepository("OA").Update(entity);
            }
        }

        #endregion
    }
}