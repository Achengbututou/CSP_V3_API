using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-10 10:01:07
    /// 描 述：mes_SchedulingInfo(排期信息)表的实体
    /// </summary>
    [MyTable("mes_SchedulingInfo")]
    public class MesSchedulingInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 排期信息主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 排期编码
        /// </summary>
        public string F_SchedulingNumber { get; set; }
        /// <summary>
        /// 用户输入编码
        /// </summary>
        public string F_IsSysNum { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 排期名称
        /// </summary>
        public string F_SchedulingName { get; set; }
        /// <summary>
        /// 制表人
        /// </summary>
        public string F_Watchmaker { get; set; }
        /// <summary>
        /// 制表日期
        /// </summary>
        public DateTime? F_TabulationDate { get; set; }
        /// <summary>
        /// 发布状态
        /// </summary>
        public int? F_ReleaseStatus { get; set; }
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? F_CompletionStatus { get; set; }
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
        /// 制表日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_TabulationDateQRange { get; set; }
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
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ReleaseStatusName { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CompletionStatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsIgnore = true)]
        public string keyWorld { get; set; }
        #endregion
    }
}