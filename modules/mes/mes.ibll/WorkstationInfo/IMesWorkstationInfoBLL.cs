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
    /// 日 期： 2023-07-27 15:35:03
    /// 描 述： 工位信息维护
    /// </summary>
    public interface IMesWorkstationInfoBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取工位信息维护的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesWorkstationInfoEntity>>GetList(MesWorkstationInfoEntity queryParams);
        /// <summary>
        /// 获取工位信息维护的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesWorkstationInfoEntity>>GetPageList(Pagination pagination, MesWorkstationInfoEntity queryParams);
        /// <summary>
        /// 获取工位信息包含数据转换
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesWorkstationInfoEntity>> GetPageAllList(Pagination pagination, MesWorkstationInfoEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesWorkstationInfoEntity>GetEntity(string keyValue);
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
        Task SaveEntity(string keyValue, MesWorkstationInfoEntity entity);
        #endregion
    }
}