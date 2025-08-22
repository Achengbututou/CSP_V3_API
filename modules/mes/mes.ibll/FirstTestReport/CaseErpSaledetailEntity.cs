using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:40:15
    /// 描 述：case_erp_saledetail(销售订单详情【case_erp_saledetail】)表的实体
    /// </summary>
    [MyTable("case_erp_saledetail")]
    public class CaseErpSaledetailEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 订单外键Id(case_erp_sale)
        /// </summary>
        public string F_SaleId { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_Model { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? F_Price { get; set; }
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
        /// 税后金额
        /// </summary>
        public decimal? F_AfterTaxAmount { get; set; }
        /// <summary>
        /// 交付日期
        /// </summary>
        public DateTime? F_DeliveryDate { get; set; }
        /// <summary>
        /// 已入库数量
        /// </summary>
        public decimal? F_InStoreCount { get; set; }
        /// <summary>
        /// 未入库数量
        /// </summary>
        public decimal? F_NoInStoreCount { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public decimal? F_ReturnCount { get; set; }
        /// <summary>
        /// 计划生产数量
        /// </summary>
        public decimal? F_PlanCount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Description { get; set; }
        /// <summary>
        /// 删除标记(0正常，1删除)
        /// </summary>
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 有效标志(0正常，1禁用)
        /// </summary>
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户id
        /// </summary>
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户id
        /// </summary>
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户名称
        /// </summary>
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 交付日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_DeliveryDateQRange { get; set; }
        /// <summary>
        /// 创建日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreateDateQRange { get; set; }
        /// <summary>
        /// 修改日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyDateQRange { get; set; }

        #endregion
    }
}
