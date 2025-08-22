using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-06 09:56:11
    /// 描 述： mes_OutboundDetails
    /// </summary>
    public class MesOutboundDetailsBLL: BLLBase, IMesOutboundDetailsBLL, BLL {
        private readonly MesOutboundDetailsService mesOutboundDetailsService = new MesOutboundDetailsService();
        #region 获取数据
        /// <summary>
        /// 获取mes_OutboundDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOutboundDetailsEntity>>GetList(MesOutboundDetailsEntity queryParams) {
            return mesOutboundDetailsService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_OutboundDetails的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOutboundDetailsEntity>>GetPageList(Pagination pagination, MesOutboundDetailsEntity queryParams) {
            return mesOutboundDetailsService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesOutboundDetailsEntity>GetEntity(string keyValue) {
            return mesOutboundDetailsService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesOutboundDetailsService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_OutboundDetails的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesOutboundDetailsService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesOutboundDetailsService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesOutboundDetailsEntity entity) {
            await mesOutboundDetailsService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesOutboundDetailsEntity>list) {
            await mesOutboundDetailsService.SaveList(key, list);
        }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 获取生产订单物料详情
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GETProductionTicketPList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            return mesOutboundDetailsService.GETProductionTicketPList(pagination, queryParams);
        }
        /// <summary>
        /// 获取采购订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GetPurchasedetailList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            return mesOutboundDetailsService.GetPurchasedetailList(pagination, queryParams);
        }
        /// <summary>
        /// 获取销售订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GetSalesDetailList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            return mesOutboundDetailsService.GetSalesDetailList(pagination, queryParams);   
        }
        /// <summary>
        /// 获取物料带库存
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GetProductList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            return mesOutboundDetailsService.GetProductList(pagination, queryParams);   
        }
        #endregion
    }
}