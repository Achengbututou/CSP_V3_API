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
    /// 日 期： 2023-09-06 09:56:11
    /// 描 述： mes_OutboundDetails
    /// </summary>
    public interface IMesOutboundDetailsBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取mes_OutboundDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesOutboundDetailsEntity>>GetList(MesOutboundDetailsEntity queryParams);
        /// <summary>
        /// 获取mes_OutboundDetails的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesOutboundDetailsEntity>>GetPageList(Pagination pagination, MesOutboundDetailsEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesOutboundDetailsEntity>GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除mes_OutboundDetails的实体根据外键
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
        Task SaveEntity(string keyValue, MesOutboundDetailsEntity entity);
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        Task SaveList(string key, IEnumerable<MesOutboundDetailsEntity>list);
        #endregion

        #region 扩展操作
        /// <summary>
        /// 获取生产订单物料详情
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        List<OutBoundProductInfoDTO> GETProductionTicketPList(Pagination pagination, MesOutboundDetailsEntity queryParams);
        /// <summary>
        /// 获取采购订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        List<OutBoundProductInfoDTO> GetPurchasedetailList(Pagination pagination, MesOutboundDetailsEntity queryParams);
        /// <summary>
        /// 获取销售订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        List<OutBoundProductInfoDTO> GetSalesDetailList(Pagination pagination, MesOutboundDetailsEntity queryParams);
        /// <summary>
        /// 获取物料带库存
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        List<OutBoundProductInfoDTO> GetProductList(Pagination pagination, MesOutboundDetailsEntity queryParams);
        #endregion
    }
}