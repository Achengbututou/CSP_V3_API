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
    /// 日 期： 2023-08-30 17:20:47
    /// 描 述： 成品检验报告
    /// </summary>
    public interface IMesFinishedReportBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesFinishedReportEntity>>GetList(MesFinishedReportEntity queryParams);
        /// <summary>
        /// 根据主键集合获取成品检验报告数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IEnumerable<MesFinishedReportEntity>> GetListByIds(List<string> ids);
        /// <summary>
        /// 获取成品检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesFinishedReportEntity>>GetPageList(Pagination pagination, MesFinishedReportEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesFinishedReportEntity>GetEntity(string keyValue);
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
        /// 批量修改成品检验报告数据
        /// </summary>
        /// <param name="mesFinishedReports"></param>
        /// <returns></returns>

        Task UpdateList(List<MesFinishedReportEntity> mesFinishedReports);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesFinishedReportEntity entity);
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        Task SaveAll(string keyValue, FinishedReportDto dto);
        #endregion

        #region 扩展操作 流程状态更改
        /// <summary>
        /// 流程修改状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        Task UpdateStateByWf(string processId, string code, string unitName);
        #endregion
    }
}