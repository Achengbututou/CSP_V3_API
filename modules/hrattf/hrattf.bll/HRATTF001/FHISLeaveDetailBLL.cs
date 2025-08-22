using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF.ibll;
namespace HRATTF.bll {
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-10-24 09:19:39
    /// 描 述： FHIS_Leave_Detail
    /// </summary>
    public class FHISLeaveDetailBLL: BLLBase, IFHISLeaveDetailBLL, BLL {
        private readonly FHISLeaveDetailService fhisLeaveDetailService = new FHISLeaveDetailService();
        #region 获取数据
        /// <summary>
        /// 获取FHIS_Leave_Detail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveDetailEntity>>GetList(FHISLeaveDetailEntity queryParams) {
            return fhisLeaveDetailService.GetList(queryParams);
        }
        /// <summary>
        /// 获取FHIS_Leave_Detail的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveDetailEntity>>GetPageList(Pagination pagination, FHISLeaveDetailEntity queryParams) {
            return fhisLeaveDetailService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<FHISLeaveDetailEntity>GetEntity(string keyValue) {
            return fhisLeaveDetailService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await fhisLeaveDetailService.Delete(keyValue);
        }
        /// <summary>
        /// 删除FHIS_Leave_Detail的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return fhisLeaveDetailService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await fhisLeaveDetailService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, FHISLeaveDetailEntity entity) {
            await fhisLeaveDetailService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<FHISLeaveDetailEntity>list) {
            await fhisLeaveDetailService.SaveList(key, list);
        }
        #endregion
    }
}