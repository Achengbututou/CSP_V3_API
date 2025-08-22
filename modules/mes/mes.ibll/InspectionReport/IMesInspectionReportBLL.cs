using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace mes.ibll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-29 16:23:56
    /// 描 述： 巡检报告
    /// </summary>
    public interface IMesInspectionReportBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取巡检报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesInspectionReportEntity>>GetList(MesInspectionReportEntity queryParams);
        /// <summary>
        /// 根据主键集合获取巡检报告数据
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesInspectionReportEntity>> GetListByIds(List<string> ids);
        /// <summary>
        /// 获取巡检报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesInspectionReportEntity>>GetPageList(Pagination pagination, MesInspectionReportEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesInspectionReportEntity>GetEntity(string keyValue);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task DeleteAll(string keyValue);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task DeleteAlls(string keyValues);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesInspectionReportEntity entity);
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        Task SaveAll(string keyValue, InspectionReportDto dto);
        /// <summary>
        /// 批量修改巡检报告
        /// </summary>
        /// <param name="mesInspectionReports"></param>
        /// <returns></returns>
        Task UpdateList(List<MesInspectionReportEntity> mesInspectionReports);
        #endregion
    }
}