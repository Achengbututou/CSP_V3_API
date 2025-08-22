using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-01 14:27:53
    /// 描 述： 设备信息
    /// </summary>
    public class MesDeviceInfoBLL: BLLBase, IMesDeviceInfoBLL, BLL {
        private readonly MesDeviceInfoService mesDeviceInfoService = new MesDeviceInfoService();
        #region 获取数据
        /// <summary>
        /// 获取设备信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDeviceInfoEntity>>GetList(MesDeviceInfoEntity queryParams) {
            return mesDeviceInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取设备信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDeviceInfoEntity>>GetPageList(Pagination pagination, MesDeviceInfoEntity queryParams) {
            return mesDeviceInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesDeviceInfoEntity>GetEntity(string keyValue) {
            return mesDeviceInfoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesDeviceInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesDeviceInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesDeviceInfoEntity entity) {
            entity.F_DeviceCode = (await GetRuleCodeEx(entity.F_DeviceCode)).ToString();
            await mesDeviceInfoService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}