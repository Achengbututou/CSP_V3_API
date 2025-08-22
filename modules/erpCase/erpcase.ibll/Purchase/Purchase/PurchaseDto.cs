using System.Collections.Generic;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-11-30 15:20:23
    /// 描 述：采购订单表单提交参数
    /// </summary>
    public class PurchaseDto
    {
        /// <summary>
        /// case_erp_purchase(采购订单信息【case_erp_purchase】)表的实体
        /// </summary>
        public CaseErpPurchaseEntity CaseErpPurchaseEntity { get; set; }
        /// <summary>
        /// case_erp_purchasedetail(采购订单详情【case_erp_purchasedetail】)表的实体
        /// </summary>
        public IEnumerable<CaseErpPurchasedetailEntity> CaseErpPurchasedetailList { get; set; }

    }

    /// <summary>
    /// 采购概要
    /// </summary>
    public class PurchaseSynopsis
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 物料数量
        /// </summary>
        public decimal? Count { get; set; }

    }
}