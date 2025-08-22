using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:34:39
    /// 描 述：lr_erp_payinfoDto
    /// </summary>
    public class PayinfoDto
    {
        /// <summary>
        /// lr_erp_payinfo(付款单)表的实体
        /// </summary>
        public Erp_payinfoEntity Erp_payinfoEntity { get; set; }
        /// <summary>
        /// lr_erp_payinfodetail(付款单详细)表的实体
        /// </summary>
        public IEnumerable<Erp_payinfo_detailEntity> Erp_payinfo_detailList { get; set; }

    }
}