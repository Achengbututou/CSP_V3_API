using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// Quartz
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:39:23
    /// 描 述：lr_erp_receiptinfoDto
    /// </summary>
    public class ReceiptinfoDto
    {
        /// <summary>
        /// lr_erp_receiptinfo(收款单)表的实体
        /// </summary>
        public Erp_receiptinfoEntity Erp_receiptinfoEntity { get; set; }
        /// <summary>
        /// lr_erp_receiptinfodetail(收款单详细)表的实体
        /// </summary>
        public IEnumerable<Erp_receiptinfo_detailEntity> Erp_receiptinfo_detailList { get; set; }

    }
}