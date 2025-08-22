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
    /// 日 期： 2023-09-15 15:37:57
    /// 描 述： 仓库操作日志
    /// </summary>
    public interface IMesOperationLogInfoBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取仓库操作日志的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesOperationLogInfoEntity>>GetList(MesOperationLogInfoEntity queryParams);
        /// <summary>
        /// 获取仓库操作日志的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesOperationLogInfoEntity>>GetPageList(Pagination pagination, MesOperationLogInfoEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesOperationLogInfoEntity>GetEntity(string keyValue);
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
        Task SaveEntity(string keyValue, MesOperationLogInfoEntity entity);
        /// <summary>
        /// 操作日志写入
        /// </summary>
        /// <param name="functionModule"></param>
        /// <param name="operationInfo"></param>
        /// <returns></returns>
        Task SaveLog(string functionModule, string operationInfo);
        #endregion
    }
}