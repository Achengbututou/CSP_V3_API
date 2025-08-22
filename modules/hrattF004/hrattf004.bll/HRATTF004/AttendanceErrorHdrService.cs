using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using HRATTF004.ibll;
namespace HRATTF004.bll {
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤数据库执行类
    /// </summary>
    public class AttendanceErrorHdrService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<AttendanceErrorHdrEntity, bool>>GetExpression(AttendanceErrorHdrEntity queryParams) {
            var exp = Expressionable.Create<AttendanceErrorHdrEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.note_no), t => t.note_no.Contains(queryParams.note_no));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.submit_userid), t => t.submit_userid.Contains(queryParams.submit_userid));
            if (!string.IsNullOrEmpty(queryParams.submit_dateqrange)) {
                var submit_Date_list = queryParams.submit_dateqrange.Split(" - ");
                DateTime submit_Date = Convert.ToDateTime(submit_Date_list[0]);
                DateTime submit_Date_end = Convert.ToDateTime(submit_Date_list[1]);
                exp = exp.And(t => t.submit_date >= submit_Date && t.submit_date <= submit_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.approve_status), t => t.approve_status.Contains(queryParams.approve_status));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.approve_userid), t => t.approve_userid.Contains(queryParams.approve_userid));
            if (!string.IsNullOrEmpty(queryParams.approve_dateqrange)) {
                var approve_date_list = queryParams.approve_dateqrange.Split(" - ");
                DateTime approve_date = Convert.ToDateTime(approve_date_list[0]);
                DateTime approve_date_end = Convert.ToDateTime(approve_date_list[1]);
                exp = exp.And(t => t.approve_date >= approve_date && t.approve_date <= approve_date_end);
            }
            if (!string.IsNullOrEmpty(queryParams.sys_dateqrange)) {
                var sys_date_list = queryParams.sys_dateqrange.Split(" - ");
                DateTime sys_date = Convert.ToDateTime(sys_date_list[0]);
                DateTime sys_date_end = Convert.ToDateTime(sys_date_list[1]);
                exp = exp.And(t => t.sys_date >= sys_date && t.sys_date <= sys_date_end);
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceErrorHdrEntity>>GetList(AttendanceErrorHdrEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<AttendanceErrorHdrEntity>(expression);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceErrorHdrEntity>>GetPageList(Pagination pagination, AttendanceErrorHdrEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<AttendanceErrorHdrEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<AttendanceErrorHdrEntity>GetEntity(string keyValue) {
            return this.BaseRepository("OA").FindEntityByKey<AttendanceErrorHdrEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository("OA").Delete<AttendanceErrorHdrEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<AttendanceErrorHdrEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, AttendanceErrorHdrEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.rid)) {
                    entity.rid = Guid.NewGuid().ToString();
                }
                
                await this.BaseRepository("OA").Insert(entity);
            } else {
                entity.rid = keyValue;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        #endregion
    }
}