using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-30 15:20:23
    /// 描 述： 采购订单
    /// </summary>
    public interface ICaseErpPurchaseBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取采购订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpPurchaseEntity>> GetList(CaseErpPurchaseEntity queryParams);

        /// <summary>
        /// 获取采购订单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpPurchaseEntity>> GetPageList(Pagination pagination, CaseErpPurchaseEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpPurchaseEntity> GetEntity(string keyValue);



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
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, CaseErpPurchaseEntity entity);

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        Task SaveAll(string keyValue, PurchaseDto dto);


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


        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取对应物料的采购记录
        /// </summary>
        /// <param name="num">物料编码</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpPurchaseEntity>> GetPurchasesLog(Pagination pagination, CaseErpPurchaseEntity queryParams, string num);

        /// <summary>
        /// 更新订单审批状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <param name="unitName"></param>
        Task UpdateStateByWf(string processId, string code, string unitName);

        #endregion
    }
}
