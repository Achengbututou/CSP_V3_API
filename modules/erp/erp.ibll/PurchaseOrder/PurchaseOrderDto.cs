using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:32:13
    /// 描 述：lr_erp_purchaseorderDto
    /// </summary>
    public class PurchaseOrderDto
    {
        /// <summary>
        /// lr_erp_purchaseorder(采购订单)表的实体
        /// </summary>
        public Erp_purchase_orderEntity Erp_purchase_orderEntity { get; set; }
        /// <summary>
        /// lr_erp_purchaseorderdetail(采购订单详细)表的实体
        /// </summary>
        public IEnumerable<Erp_purchase_order_detailEntity> Erp_purchase_order_detailList { get; set; }

    }
}