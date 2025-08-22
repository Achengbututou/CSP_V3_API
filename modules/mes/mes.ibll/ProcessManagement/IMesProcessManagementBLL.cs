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
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： 工序管理
    /// </summary>
    public interface IMesProcessManagementBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取工序管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessManagementEntity>>GetList(MesProcessManagementEntity queryParams);
        /// <summary>
        /// 获取工序
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessManagementEntity>> GetProductNumberList(MesProcessManagementEntity queryParams);
        /// <summary>
        /// 获取工单工序
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessManagementEntity>> GetProdTicketList(MesProcessManagementEntity queryParams);
        /// <summary>
        /// 获取工序管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessManagementEntity>>GetPageList(Pagination pagination, MesProcessManagementEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProcessManagementEntity>GetEntity(string keyValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<MesProcessManagementEntity> GetDetailEntity(string keyValue);
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
        Task<OutboundResultDTO> DeleteAll(string keyValue);
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
        Task SaveEntity(string keyValue, MesProcessManagementEntity entity);
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        Task SaveAll(string keyValue, ProcessManagementDto dto);
        #endregion
    }
}