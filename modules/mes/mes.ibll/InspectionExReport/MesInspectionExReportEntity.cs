using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-29 17:24:38
    /// 描 述：mes_inspectexreport(巡检异常报告)表的实体
    /// </summary>
    [MyTable("mes_inspectexreport")]
    public class MesInspectionExReportEntity
    {
        #region 实体成员
        /// <summary>
        /// 巡检异常报告主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 异常巡检报告编号
        /// </summary>
        public string F_ExceptionNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 巡检报告主键
        /// </summary>
        public string F_InspectionId { get; set; }
        /// <summary>
        /// 异常描述
        /// </summary>
        public string F_ExceptionDescriptio { get; set; }
        /// <summary>
        /// 异常等级
        /// </summary>
        public string F_ExceptionLevel { get; set; }
        /// <summary>
        /// 处置判定
        /// </summary>
        public string F_DisposalJudgment { get; set; }
        /// <summary>
        /// 判定依据
        /// </summary>
        public string F_JudgmentBase { get; set; }
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
        /// 巡检报告编号
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InspectionNumber { get; set; }
        /// <summary>
        /// 报告抬头
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ReportHeader { get; set; }
        /// <summary>
        /// 车间名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_WorkshopName { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductionName { get; set; }
        /// <summary>
        /// 班组名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_TeamManagementName { get; set; }
        /// <summary>
        /// 检验日期
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_InspectionDate { get; set; }
        #endregion
    }
}