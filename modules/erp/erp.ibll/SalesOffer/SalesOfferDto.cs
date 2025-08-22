using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:36:08
    /// 描 述：lr_erp_salesofferDto
    /// </summary>
    public class SalesOfferDto
    {
        /// <summary>
        /// lr_erp_salesoffer(销售报价)表的实体
        /// </summary>
        public Erp_sales_offerEntity Erp_sales_offerEntity { get; set; }
        /// <summary>
        /// lr_erp_salesofferdetail(销售报价详细)表的实体
        /// </summary>
        public IEnumerable<Erp_sales_offer_detailEntity> Erp_sales_offer_detailList { get; set; }

    }
}