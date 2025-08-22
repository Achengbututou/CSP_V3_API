using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:29:59
    /// 描 述：lr_erp_purchaserequisitionDto
    /// </summary>
    public class PurchaseApplyDto
    {
        /// <summary>
        /// lr_erp_purchaserequisition(采购申请)表的实体
        /// </summary>
        public Erp_purchase_applyEntity erp_purchase_applyEntity { get; set; }
        /// <summary>
        /// lr_erp_productinfo(商品信息表)表的实体
        /// </summary>
        public IEnumerable<Erp_productEntity> erp_productList { get; set; }

    }
}