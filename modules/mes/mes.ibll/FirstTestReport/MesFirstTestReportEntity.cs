using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-29 13:47:39
    /// 描 述：mes_FirstTestReport(首件检测报告)表的实体
    /// </summary>
    [MyTable("mes_FirstTestReport")]
    public class MesFirstTestReportEntity
    {
        #region 实体成员
        /// <summary>
        /// 首件报告主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 首件报告编号
        /// </summary>
        public string F_FirstTestNumber { get; set; }
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
        /// 销售单号
        /// </summary>
        public string F_SalesOrderNumber { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string F_ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_MaterialCoding { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_MaterialName { get; set; }
        /// <summary>
        /// 检测报告编号
        /// </summary>
        public string F_IncomingInspectionNo { get; set; }
        /// <summary>
        /// 整体判定
        /// </summary>
        public int? F_OveralJudgment { get; set; }
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

        #endregion
    }
}