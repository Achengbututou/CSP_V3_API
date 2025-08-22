using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:37:10
    /// 描 述：lr_erp_salesorderDto
    /// </summary>
    public class SalesOrderDto
    {
        /// <summary>
        /// lr_erp_salesorder(销售订单)表的实体
        /// </summary>
        public Erp_sales_orderEntity Erp_sales_orderEntity { get; set; }
        /// <summary>
        /// lr_erp_salesorderdetail(销售订单详细)表的实体
        /// </summary>
        public IEnumerable<Erp_sales_order_detailEntity> Erp_sales_order_detailList { get; set; }

    }
}