using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:32:13
    /// 描 述： lr_erp_purchaseorder
    /// </summary>
    public interface IPurchaseOrderBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchaseorder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_purchase_orderEntity>> GetList(Erp_purchase_orderEntity queryParams);

        /// <summary>
        /// 获取lr_erp_purchaseorder的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_purchase_orderEntity>> GetPageList(Pagination pagination, Erp_purchase_orderEntity queryParams);
        
        /// <summary>
        /// 获取主表lr_erp_purchaseorder的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        Task<Erp_purchase_orderEntity> GetEntity(String f_Id);
        /// <summary>
        /// 获取表lr_erp_purchaseorderdetail的列表
        /// </summary>
        /// <param name="f_POID">表lr_erp_purchaseorder关联字段F_Id</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_purchase_order_detailEntity>> GetLr_erp_purchaseorderdetailList(String f_POID);


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        Task Delete(String f_Id);
        /// <summary>
        /// 删除采购订单详细lr_erp_purchaseorderdetail表数据
        /// </summary>
        /// <param name="f_POID">表lr_erp_purchaseorder关联字段F_Id</param>
        Task DeleteLr_erp_purchaseorderdetail(String f_POID);


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchaseorderEntity">采购订单lr_erp_purchaseorder实体数据</param>
        /// <param name="lr_erp_purchaseorderdetailList">采购订单详细lr_erp_purchaseorderdetail实体数据列表</param>
        Task SaveEntity(String f_Id,Erp_purchase_orderEntity lr_erp_purchaseorderEntity,IEnumerable<Erp_purchase_order_detailEntity> lr_erp_purchaseorderdetailList);
        /// <summary>
        /// 保存采购订单详细lr_erp_purchaseorderdetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_purchaseorderdetailEntity">lr_erp_purchaseorderdetail实体数据</param>
        Task SaveLr_erp_purchaseorderdetail(String f_Id,Erp_purchase_order_detailEntity lr_erp_purchaseorderdetailEntity);

        
        #endregion
    }
}
