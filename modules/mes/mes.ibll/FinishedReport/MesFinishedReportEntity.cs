using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-30 17:20:47
    /// 描 述：mes_FinishedReport(成品检验报告)表的实体
    /// </summary>
    [MyTable("mes_FinishedReport")]
    public class MesFinishedReportEntity
    {
        #region 实体成员
        /// <summary>
        /// 成品报告主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 成品报告编号
        /// </summary>
        public string F_FinishedNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? F_InspectionDate { get; set; }
        /// <summary>
        /// 报告抬头
        /// </summary>
        public string F_ReportHeader { get; set; }
        /// <summary>
        /// 校验员
        /// </summary>
        public string F_Inspector { get; set; }
        /// <summary>
        /// 抽样标准
        /// </summary>
        public string F_SamplingStandard { get; set; }
        /// <summary>
        /// 抽样数
        /// </summary>
        public int? F_SamplesNumber { get; set; }
        /// <summary>
        /// 检测类别
        /// </summary>
        public string F_DetectionCategoryId { get; set; }
        /// <summary>
        /// 检测项目
        /// </summary>
        public string F_DetectionItemId { get; set; }
        /// <summary>
        /// 校验标准
        /// </summary>
        public string F_CalibrationStandard { get; set; }
        /// <summary>
        /// 检验方法
        /// </summary>
        public string F_DetectionMethodId { get; set; }
        /// <summary>
        /// 整体判定
        /// </summary>
        public int? F_OveralJudgment { get; set; }
        /// <summary>
        /// 检测报告编号
        /// </summary>
        public string F_IncomingInspectionNo { get; set; }
        /// <summary>
        /// 异常报告填写状态
        /// </summary>
        public int? F_ExStates { get; set; }
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
        /// 工单编号
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_TicketNumber { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductName { get; set; }
        /// <summary>
        /// 销售单号
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_SalesOrderNumber { get; set; }
        /// <summary>
        /// 所属车间
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_WorkshopId { get; set; }
        /// <summary>
        /// 校验员
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InspectorName { get; set; }
        #endregion
    }
}