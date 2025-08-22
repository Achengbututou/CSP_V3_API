using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-31 10:20:45
    /// 描 述：mes_FinishedExReport(成品校验异常报告)表的实体
    /// </summary>
    [MyTable("mes_FinishedExReport")]
    public class MesFinishedExReportEntity
    {
        #region 实体成员
        /// <summary>
        /// 异常报告主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 成品报告主键
        /// </summary>
        public string F_FinishedId { get; set; }
        /// <summary>
        /// 异常报告编号
        /// </summary>
        public string F_ExceptionNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 异常描述
        /// </summary>
        public string F_ExceptionDescription { get; set; }
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
        /// 成品报告编号
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_FinishedNumber { get; set; }
        /// <summary>
        /// 报告抬头
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ReportHeader { get; set; }
        #endregion
    }
}