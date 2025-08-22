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
    /// 日 期： 2022-12-05 16:09:49
    /// 描 述： 供应商信息
    /// </summary>
    public interface ICaseErpSupplierBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取供应商信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSupplierEntity>> GetList(CaseErpSupplierEntity queryParams);

        /// <summary>
        /// 获取供应商信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSupplierEntity>> GetPageList(Pagination pagination, CaseErpSupplierEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpSupplierEntity> GetEntity(string keyValue);



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
        Task SaveEntity(string keyValue, CaseErpSupplierEntity entity);



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion
        
        #region 流程状态处理

        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task UpdateStateByWf(string processId, string code);

        /// <summary>
        /// 更新供应商状态通过年审
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task UpdateStateByWfYear(string processId, string code);

        #endregion
    }
}
