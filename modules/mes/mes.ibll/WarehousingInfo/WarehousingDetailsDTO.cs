using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 入库物品详情dto
    /// </summary>
    public class WarehousingDetailsDTO
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 销售单号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_SpecificationsModels { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? F_UnitPrice { get; set; }
        /// <summary>
        /// 计划产量
        /// </summary>
        public int? F_PlannedOutput { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public int? F_PurchaseQuantity { get; set; }
        /// <summary>
        /// 已入库数量
        /// </summary>
        public int? F_WarehousedNumber { get; set; }
        /// <summary>
        /// 生成工单
        /// </summary>
        public string F_ProdTicketNumber { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? F_Count { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? F_Discount { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal? F_TaxRate { get; set; }
        /// <summary>
        /// 税费
        /// </summary>
        public decimal? F_TaxBreak { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string F_Id { get; set; }
        /// <summary>
        /// 在库数量
        /// </summary>
        public int? F_librariesNumber { get; set; }
    }

}
