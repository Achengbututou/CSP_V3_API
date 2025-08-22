using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace Test1.ibll {
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：
    /// 日 期： 2024-07-24 16:39:53
    /// 描 述： f_children
    /// </summary>
    public interface IF_childrenBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取f_children的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<F_childrenEntity>>GetList(F_childrenEntity queryParams);
        /// <summary>
        /// 获取f_children的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<F_childrenEntity>>GetPageList(Pagination pagination, F_childrenEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<F_childrenEntity>GetEntity(string keyValue);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除f_children的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        Task DeleteRelateEntity(string key);
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
        Task SaveEntity(string keyValue, F_childrenEntity entity);
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        Task SaveList(string key, IEnumerable<F_childrenEntity>list);
        #endregion
    }
}