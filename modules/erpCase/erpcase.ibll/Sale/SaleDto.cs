using System.Collections.Generic;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:40:15
    /// 描 述：销售订单信息表单提交参数
    /// </summary>
    public class SaleDto
    {
        /// <summary>
        /// case_erp_sale(销售订单信息【case_erp_sale】)表的实体
        /// </summary>
        public CaseErpSaleEntity CaseErpSaleEntity { get; set; }
        /// <summary>
        /// case_erp_saledetail(销售订单详情【case_erp_saledetail】)表的实体
        /// </summary>
        public IEnumerable<CaseErpSaledetailEntity> CaseErpSaledetailList { get; set; }

    }

    /// <summary>
    /// 产品概要
    /// </summary>
    public class ProductSynopsis
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public decimal? Count { get; set; }

    }
}