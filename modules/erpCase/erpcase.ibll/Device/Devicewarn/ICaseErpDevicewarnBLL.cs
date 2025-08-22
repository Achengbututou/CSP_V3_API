using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-28 17:03:09
    /// 描 述： 设备告警
    /// </summary>
    public interface ICaseErpDevicewarnBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取设备告警的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpDevicewarnEntity>> GetList(CaseErpDevicewarnEntity queryParams);

        /// <summary>
        /// 获取设备告警的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpDevicewarnEntity>> GetPageList(Pagination pagination, CaseErpDevicewarnEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpDevicewarnEntity> GetEntity(string keyValue);

        

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, CaseErpDevicewarnEntity entity);

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion

        #region 扩展方法

        #region 定时任务

        #region 定时插入设备告警信息
        /// <summary>
        /// 定时插入设备告警信息
        /// </summary>
        /// <returns></returns>
        Task DeviceWarn();
        #endregion

        #endregion

        #region 导出Excel
        /// <summary>
        /// 设备告警列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        Task<string> GetExportList(string ids);
        #endregion

        #endregion
    }
}
