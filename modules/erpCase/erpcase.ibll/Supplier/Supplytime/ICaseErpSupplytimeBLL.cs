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
    /// 日 期： 2022-12-07 15:18:03
    /// 描 述： 供应商时间轴
    /// </summary>
    public interface ICaseErpSupplytimeBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取供应商时间轴的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSupplytimeEntity>> GetList(CaseErpSupplytimeEntity queryParams);

        /// <summary>
        /// 获取供应商时间轴的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSupplytimeEntity>> GetPageList(Pagination pagination, CaseErpSupplytimeEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpSupplytimeEntity> GetEntity(string keyValue);

        

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
        Task SaveEntity(string keyValue, CaseErpSupplytimeEntity entity);

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion

        #region 扩展方法
        /// <summary>
        /// 保存供应商时间轴数据
        /// </summary>
        /// <param name="F_SupplierId">供应商外键(case_erp_supplier)</param>
        /// <param name="F_Title">时间轴标题</param>
        /// <param name="F_ContentUser">内容(人员)</param>
        /// <param name="F_ContentReason">内容(原因)</param>
        /// <param name="F_ContentExplain">内容(说明)</param>
        /// <returns></returns>
        Task SaveSupplyTime(string F_SupplierId, string F_Title, string F_ContentUser, string F_ContentReason, string F_ContentExplain);
        #endregion
    }
}
