using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace ADMF005.ibll {
    /// <summary>
    /// 访客申请-访客出入厂
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2024-05-03 16:04:51
    /// 描 述： Visitors_Enter
    /// </summary>
    public interface IVisitorsEnterBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取Visitors_Enter的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<VisitorsEnterEntity>>GetList(VisitorsEnterEntity queryParams);
        /// <summary>
        /// 获取Visitors_Enter的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<VisitorsEnterEntity>>GetPageList(Pagination pagination, VisitorsEnterEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<VisitorsEnterEntity>GetEntity(string keyValue);
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
        Task SaveEntity(string keyValue, VisitorsEnterEntity entity);
        #endregion
    }
}