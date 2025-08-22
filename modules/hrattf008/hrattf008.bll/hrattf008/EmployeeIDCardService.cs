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
    /// 描 述：FHIS_Empoyee_All_ID_Card(身份证)
    /// </summary>
    public class EmployeeIDCardService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<EmployeeIDCardEntity, bool>> GetExpression(EmployeeIDCardEntity queryParams)
        {
            var exp = Expressionable.Create<EmployeeIDCardEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Company_Code), t => t.Company_Code.Equals(queryParams.Company_Code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Equals(queryParams.Emp_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.ID_NO), t => t.ID_NO.Equals(queryParams.ID_NO));

            
            if (!string.IsNullOrEmpty(queryParams.Fjoin_DateQRange))
            {
                var from_Date_list = queryParams.Fjoin_DateQRange.Split(" - ");
                DateTime from_Date = Convert.ToDateTime(from_Date_list[0]);
                DateTime from_Date_end = Convert.ToDateTime(from_Date_list[1]);
                exp = exp.And(t => t.Fjoin_Date >= from_Date && t.Fjoin_Date <= from_Date_end);
            }
            if (!string.IsNullOrEmpty(queryParams.Join_DateQRange))
            {
                var to_Date_list = queryParams.Join_DateQRange.Split(" - ");
                DateTime to_Date = Convert.ToDateTime(to_Date_list[0]);
                DateTime to_Date_end = Convert.ToDateTime(to_Date_list[1]);
                exp = exp.And(t => t.Join_Date >= to_Date && t.Join_Date <= to_Date_end);
            }
            if (!string.IsNullOrEmpty(queryParams.Resign_DateQRange))
            {
                var to_Date_list = queryParams.Resign_DateQRange.Split(" - ");
                DateTime to_Date = Convert.ToDateTime(to_Date_list[0]);
                DateTime to_Date_end = Convert.ToDateTime(to_Date_list[1]);
                exp = exp.And(t => t.Resign_Date >= to_Date && t.Resign_Date <= to_Date_end);
            }

            return exp.ToExpression();
        }
        /// <summary>
        /// 获取身份证号的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EmployeeIDCardEntity>> GetPageList(Pagination pagination, EmployeeIDCardEntity queryParams, string AuthoritySql = null)
        {
            var expression = GetExpression(queryParams);
            return BaseRepository("OA").FindList(expression, pagination, AuthoritySql);
        }
        #endregion
    }
}