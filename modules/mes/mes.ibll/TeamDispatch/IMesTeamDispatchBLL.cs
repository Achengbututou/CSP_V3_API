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
    /// 日 期： 2023-08-18 11:18:30
    /// 描 述： 班组派工
    /// </summary>
    public interface IMesTeamDispatchBLL: IBLL {

        #region 获取数据
        /// <summary>
        /// 获取班组派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesTeamDispatchEntity>>GetList(MesTeamDispatchEntity queryParams);
        /// <summary>
        /// 获取工单班组派工信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<IEnumerable<MesTeamDispatchEntity>> GetTeamDispatchList(string keyValue);
        /// <summary>
        /// 获取班组派工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesTeamDispatchEntity>>GetPageList(Pagination pagination, MesTeamDispatchEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesTeamDispatchEntity>GetEntity(string keyValue);
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
        Task SaveEntity(string keyValue, MesTeamDispatchEntity entity);
        /// <summary>
        /// 班组派单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task TeamDispatch(MesTeamDispatchEntity entity);
        #endregion
    }
}