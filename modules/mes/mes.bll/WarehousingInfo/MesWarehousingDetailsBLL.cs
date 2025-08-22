using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using mes.ibll.WarehousingInfo;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-05 17:17:28
    /// 描 述： mes_warehousingde
    /// </summary>
    public class MesWarehousingDetailsBLL: BLLBase, IMesWarehousingDetailsBLL, BLL {
        private readonly MesWarehousingDetailsService mesWarehousingDetailsService = new MesWarehousingDetailsService();
        #region 获取数据
        /// <summary>
        /// 获取mes_WarehousingDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehousingDetailsEntity>>GetList(MesWarehousingDetailsEntity queryParams) {
            return mesWarehousingDetailsService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_WarehousingDetails的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehousingDetailsEntity>>GetPageList(Pagination pagination, MesWarehousingDetailsEntity queryParams) {
            return mesWarehousingDetailsService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesWarehousingDetailsEntity>GetEntity(string keyValue) {
            return mesWarehousingDetailsService.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取采购订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public QueryReturnWareDTO GetPurchasedetailList(Pagination pagination, MesWarehousingDetailsEntity queryParams)
        {
            return mesWarehousingDetailsService.GetPurchasedetailList(pagination, queryParams); 
        }
        /// <summary>
        /// 获取销售订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public QueryReturnWareDTO GetSalesDetailList(Pagination pagination, MesWarehousingDetailsEntity queryParams)
        {
            return mesWarehousingDetailsService.GetSalesDetailList(pagination, queryParams);    
        }
        /// <summary>
        /// 获取物料带库存
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<WarehousingDetailsDTO> GetProductList(Pagination pagination, MesWarehousingDetailsEntity queryParams)
        {
            return mesWarehousingDetailsService.GetProductList(pagination, queryParams);    
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesWarehousingDetailsService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_WarehousingDetails的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesWarehousingDetailsService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesWarehousingDetailsService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesWarehousingDetailsEntity entity) {
            await mesWarehousingDetailsService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesWarehousingDetailsEntity>list) {
            await mesWarehousingDetailsService.SaveList(key, list);
        }
        #endregion
    }
}