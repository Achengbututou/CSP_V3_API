using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF004.ibll;
namespace HRATTF004.bll {
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤
    /// </summary>
    public class AttendanceErrorHdrBLL: BLLBase, IAttendanceErrorHdrBLL, BLL {
        private readonly AttendanceErrorHdrService attendanceErrorHdrService = new AttendanceErrorHdrService();
        private readonly IAttendanceErrorDtlBLL _iAttendanceErrorDtlBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iAttendanceErrorDtlBLL">null接口</param>
        public AttendanceErrorHdrBLL(IAttendanceErrorDtlBLL iAttendanceErrorDtlBLL) {
            _iAttendanceErrorDtlBLL = iAttendanceErrorDtlBLL ??
                throw new ArgumentNullException(nameof(iAttendanceErrorDtlBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceErrorHdrEntity>>GetList(AttendanceErrorHdrEntity queryParams) {
            return attendanceErrorHdrService.GetList(queryParams);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceErrorHdrEntity>>GetPageList(Pagination pagination, AttendanceErrorHdrEntity queryParams) {
            return attendanceErrorHdrService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<AttendanceErrorHdrEntity>GetEntity(string keyValue) {
            return attendanceErrorHdrService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await attendanceErrorHdrService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new HRATTF004Dto();
            res.AttendanceErrorHdrEntity = await GetEntity(keyValue);
            attendanceErrorHdrService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.AttendanceErrorHdrEntity != null) {
                    await _iAttendanceErrorDtlBLL.DeleteRelateEntity(res.AttendanceErrorHdrEntity.rid);
                }
                attendanceErrorHdrService.Commit();
            } catch (Exception) {
                attendanceErrorHdrService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await attendanceErrorHdrService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues) {
            var keyValuelist = keyValues.Split(",");
            foreach(var keyValue in keyValuelist) {
                await DeleteAll(keyValue);
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, AttendanceErrorHdrEntity entity) {
            entity.note_no = (await GetRuleCodeEx(entity.note_no)).ToString();
            await attendanceErrorHdrService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, HRATTF004Dto dto) {
            attendanceErrorHdrService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.AttendanceErrorHdrEntity);
                await _iAttendanceErrorDtlBLL.SaveList(dto.AttendanceErrorHdrEntity.rid, dto.AttendanceErrorDtlList);
                attendanceErrorHdrService.Commit();
            } catch (Exception) {
                attendanceErrorHdrService.Rollback();
                throw;
            }
        }
        #endregion
    }
}