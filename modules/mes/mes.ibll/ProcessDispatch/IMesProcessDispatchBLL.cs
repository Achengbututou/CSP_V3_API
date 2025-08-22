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
    /// 日 期： 2023-08-18 11:24:51
    /// 描 述： 工序派工
    /// </summary>
    public interface IMesProcessDispatchBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessDispatchEntity>>GetList(MesProcessDispatchEntity queryParams);
        /// <summary>
        /// 获取工序派工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessDispatchEntity>>GetPageList(Pagination pagination, MesProcessDispatchEntity queryParams);
        /// <summary>
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessDispatchEntity>> GetDispatchList(string keyValue);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProcessDispatchEntity>GetEntity(string keyValue);
        /// <summary>
        /// 根据主键集合获取数据
        /// </summary>
        /// <param name="productionTicketIds"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessDispatchEntity>> GetListByIds(List<string> ids, string ProductionTicketId);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesProcessDispatchEntity entity);
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        Task SaveList(List<MesProcessDispatchEntity> mesProcessDispatches);
        /// <summary>
        /// 工序派工
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task mesProcessDispatch(ProcessDispatchDTO processDispatch);
        /// <summary>
        /// 多工序派工
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        Task DispatchEntity(List<string> ids);
        #endregion
    }
}