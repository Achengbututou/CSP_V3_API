using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:49:03
    /// 描 述： 物料信息
    /// </summary>
    public interface ICaseErpMaterialBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取物料信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpMaterialEntity>> GetList(CaseErpMaterialEntity queryParams);

        /// <summary>
        /// 获取物料信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpMaterialEntity>> GetPageList(Pagination pagination, CaseErpMaterialEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpMaterialEntity> GetEntity(string keyValue);



        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, CaseErpMaterialEntity entity);



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取实体数据-【根据物料编号和物料名称获取物料实体】
        /// </summary>
        /// <param name="F_Number">物料编号</param>
        /// <returns></returns>
        Task<CaseErpMaterialEntity> GetEntityByNumName(string F_Number);
        #endregion
    }
}
