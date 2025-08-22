using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-23 09:44:54
    /// 描 述：mes_incominginspect(来料检验报告)表的实体
    /// </summary>
    [MyTable("mes_incominginspect")]
    public class MesIncomingInspectionEntity
    {
        #region 实体成员
        /// <summary>
        /// 来料检验主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 报告编号
        /// </summary>
        public string F_ReportNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 报告名称
        /// </summary>
        public string F_ReportName { get; set; }
        /// <summary>
        /// 送货日期
        /// </summary>
        public DateTime? F_DeliveryDate { get; set; }
        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? F_InspectionDate { get; set; }
        /// <summary>
        /// 检验员
        /// </summary>
        public string F_Inspector { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string F_SupplierName { get; set; }
        /// <summary>
        /// 采购订单号
        /// </summary>
        public string F_PurchaseOrderNo { get; set; }
        /// <summary>
        /// 送货单号
        /// </summary>
        public string F_ShippingNumber { get; set; }
        /// <summary>
        /// 报告类型
        /// </summary>
        public int? F_ReportType { get; set; }
        /// <summary>
        /// 抽样标准
        /// </summary>
        public string F_SamplingStandard { get; set; }
        /// <summary>
        /// 送货数
        /// </summary>
        public int? F_DeliveriesNumber { get; set; }
        /// <summary>
        /// 抽样数
        /// </summary>
        public int? F_SamplesNumber { get; set; }
        /// <summary>
        /// 检测报告编号
        /// </summary>
        public string F_IncomingInspectionNo { get; set; }
        /// <summary>
        /// 整体判定
        /// </summary>
        public int? F_OveralJudgment { get; set; }
        /// <summary>
        /// 货物处置方式
        /// </summary>
        public string F_GoodsMethod { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Remarks { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string F_CreatUserName { get; set; }
        /// <summary>
        /// 创建人主键
        /// </summary>
        public string F_CreatUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_CreatUserTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string F_ModifyName { get; set; }
        /// <summary>
        /// 修改人主键
        /// </summary>
        public string F_ModifyId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? F_ModifyTime { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public string F_TenantId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 送货日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_DeliveryDateQRange { get; set; }
        /// <summary>
        /// 检验日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InspectionDateQRange { get; set; }
        /// <summary>
        /// 创建时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreatUserTimeQRange { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyTimeQRange { get; set; }
        /// <summary>
        /// 检验员
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InspectorName { get; set; }
        #endregion
    }
}