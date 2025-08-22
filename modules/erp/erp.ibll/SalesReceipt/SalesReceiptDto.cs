using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:38:08
    /// 描 述：lr_erp_salesreceiptDto
    /// </summary>
    public class SalesReceiptDto
    {
        /// <summary>
        /// lr_erp_salesreceipt(销售出库)表的实体
        /// </summary>
        public Erp_sales_receiptEntity Erp_sales_receiptEntity { get; set; }
        /// <summary>
        /// lr_erp_salesreceiptdetail(销售出库详细)表的实体
        /// </summary>
        public IEnumerable<Erp_sales_receipt_detailEntity> Erp_sales_receipt_detailList { get; set; }

    }
}