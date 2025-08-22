using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.database;
using learun.util;
namespace EMEMO.ibll {
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： attendance_error_dtl
    /// </summary>
    public interface IEMEMO_dtlBLL : IBLL {
        #region 获取数据
        /// <summary>
        /// 获取attendance_error_dtl的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<EMEMO_dtlEntity>>GetList(EMEMO_dtlEntity queryParams);
        /// <summary>
        /// 获取attendance_error_dtl的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<EMEMO_dtlEntity>>GetPageList(Pagination pagination, EMEMO_dtlEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<EMEMO_dtlEntity> GetEntity(string keyValue);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除attendance_error_dtl的实体根据外键
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
        Task SaveEntity(string keyValue, EMEMO_dtlEntity entity);
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        Task SaveList(string key, IEnumerable<EMEMO_dtlEntity> list);

        /// <summary>
        /// 请数据数据验证和数据检查
        /// </summary>
        /// <returns></returns>

        Task EMEMOInterface(string InType, string par1, string par2, string par3, string par4, string par5, string par6);
        Task GetBaseDataFromFVB();
        #endregion
    }
}