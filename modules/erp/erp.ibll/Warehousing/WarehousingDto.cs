using System.Collections.Generic;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:33:31
    /// 描 述：lr_erp_purchasewarehousDto
    /// </summary>
    public class WarehousingDto
    {
        /// <summary>
        /// lr_erp_purchasewarehous(采购入库)表的实体
        /// </summary>
        public Erp_warehousingEntity Erp_warehousingEntity { get; set; }
        /// <summary>
        /// lr_erp_purchasewarehoudetail(采购入库详细表)表的实体
        /// </summary>
        public IEnumerable<Erp_warehousing_detailEntity> Erp_warehousing_detailList { get; set; }

    }
}