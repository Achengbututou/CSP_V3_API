using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF004.ibll;
namespace HRATTF004.bll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤
    /// </summary>
    public class attendance_error_MasterBLL : BLLBase, Iattendance_error_MasterBLL, BLL
    {
        private readonly attendance_error_MasterService attendance_error_MasterService = new attendance_error_MasterService();
        private readonly IAttendanceErrorDtlBLL _iAttendanceErrorDtlBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iAttendanceErrorDtlBLL">null接口</param>
        public attendance_error_MasterBLL(IAttendanceErrorDtlBLL iAttendanceErrorDtlBLL)
        {
            _iAttendanceErrorDtlBLL = iAttendanceErrorDtlBLL ??
                throw new ArgumentNullException(nameof(iAttendanceErrorDtlBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<attendance_error_MasterEntity>> GetList(attendance_error_MasterEntity queryParams)
        {
            return attendance_error_MasterService.GetList(queryParams);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<attendance_error_MasterEntity>> GetPageList(Pagination pagination, attendance_error_MasterEntity queryParams)
        {
            return attendance_error_MasterService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<attendance_error_MasterEntity> GetEntity(string keyValue)
        {
            return attendance_error_MasterService.GetEntity(keyValue);
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
            await attendance_error_MasterService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new HRATTF004Dto();
            res.attendance_error_MasterEntity = await GetEntity(keyValue);
            attendance_error_MasterService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if (res.attendance_error_MasterEntity != null)
                {
                    await _iAttendanceErrorDtlBLL.DeleteRelateEntity(res.attendance_error_MasterEntity.RID);
                }
                attendance_error_MasterService.Commit();
            }
            catch (Exception)
            {
                attendance_error_MasterService.Rollback();
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
            await attendance_error_MasterService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues)
        {
            var keyValuelist = keyValues.Split(",");
            foreach (var keyValue in keyValuelist)
            {
                await DeleteAll(keyValue);
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, attendance_error_MasterEntity entity)
        {
            await attendance_error_MasterService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, HRATTF004Dto dto)
        {
            attendance_error_MasterService.BeginTrans();
            try
            {
                await SaveEntity(keyValue, dto.attendance_error_MasterEntity);
                await _iAttendanceErrorDtlBLL.SaveList(dto.attendance_error_MasterEntity.RID, dto.AttendanceErrorDtlList);
                attendance_error_MasterService.Commit();
            }
            catch (Exception)
            {
                attendance_error_MasterService.Rollback();
                throw;
            }
        }
        #endregion
    }
}