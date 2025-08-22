using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace EMEMO.ibll
{
    /// <summary>
    /// EMEMO-EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： EMEMO
    /// </summary>
    public interface IBaseDataFromFVBBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取EMEMO的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<BaseDataFromFVBEntity>> GetList(BaseDataFromFVBEntity queryParams);
        /// <summary>
        /// 获取EMEMO的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<BaseDataFromFVBEntity>> GetPageList(Pagination pagination, BaseDataFromFVBEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<BaseDataFromFVBEntity> GetEntity(string keyValue);
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
        Task SaveEntity(string keyValue, BaseDataFromFVBEntity entity);
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        Task SaveAll(string keyValue, EMEMODto dto);


        Task GetBaseDataFromFVB();

        Task EMEMOInterface(string InType, string par1, string par2, string par3, string par4, string par5, string par6);
        #endregion
    }
}