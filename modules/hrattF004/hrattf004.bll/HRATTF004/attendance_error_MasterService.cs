using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using HRATTF004.ibll;
namespace HRATTF004.bll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤数据库执行类
    /// </summary>
    public class attendance_error_MasterService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<attendance_error_MasterEntity, bool>> GetExpression(attendance_error_MasterEntity queryParams)
        {
            var exp = Expressionable.Create<attendance_error_MasterEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Contains(queryParams.Emp_No));
            if (!string.IsNullOrEmpty(queryParams.Att_DateQRange))
            {
                var submit_Date_list = queryParams.Att_DateQRange.Split(" - ");
                DateTime Att_Date = Convert.ToDateTime(submit_Date_list[0]);
                DateTime Att_Date_end = Convert.ToDateTime(submit_Date_list[1]);
                exp = exp.And(t => t.Att_date >= Att_Date && t.Att_date <= Att_Date_end);
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<attendance_error_MasterEntity>> GetList(attendance_error_MasterEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<attendance_error_MasterEntity>(expression);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<attendance_error_MasterEntity>> GetPageList(Pagination pagination, attendance_error_MasterEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<attendance_error_MasterEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<attendance_error_MasterEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<attendance_error_MasterEntity>(keyValue);
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
            await this.BaseRepository("OA").Delete<attendance_error_MasterEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<attendance_error_MasterEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, attendance_error_MasterEntity entity)
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
                await this.BaseRepository("OA").Update(entity);
            }
        }
        #endregion
    }
}