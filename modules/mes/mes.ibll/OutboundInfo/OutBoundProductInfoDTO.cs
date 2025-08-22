using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 出库物料弹窗选择数据实体
    /// </summary>
    public class OutBoundProductInfoDTO
    {
        /// <summary>
        /// 前端数据key
        /// </summary>
        public string F_Key { get; set; }   
        /// <summary>
        /// 主键
        /// </summary>
        public string F_Id { get; set; }    
        /// <summary>
        /// 生成工单
        /// </summary>
        public string F_ProdTicketNumber { get; set; }  
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string F_MaterialType { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_SpecificationsModels { get; set; }
        /// <summary>
        /// 库区主键
        /// </summary>
        public string F_ReservoirAreaId { get; set; }
        /// <summary>
        /// 库位主键
        /// </summary>
        public string F_LibraryLocationId { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? F_UnitPrice { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal? F_Count { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal? F_TotalAmount { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int? F_WarehousedNumber { get; set; }
        /// <summary>
        /// 已入库数量
        /// </summary>
        public int? F_ThisQuantity { get; set; }    

    }
}
