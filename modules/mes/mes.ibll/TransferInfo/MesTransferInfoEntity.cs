using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 11:26:24
    /// 描 述：mes_TransferInfo(调拨信息)表的实体
    /// </summary>
    [MyTable("mes_TransferInfo")]
    public class MesTransferInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 调拨主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 调拨编码
        /// </summary>
        public string F_TransferNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 调拨主题
        /// </summary>
        public string F_TransferTheme { get; set; }
        /// <summary>
        /// 调拨日期
        /// </summary>
        public DateTime? F_TransferDate { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        public string F_ApplicationDepartment { get; set; }
        /// <summary>
        /// 申请人员
        /// </summary>
        public string F_Applicant { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string F_ContactNumber { get; set; }
        /// <summary>
        /// 调入仓库
        /// </summary>
        public string F_TransferWarehouse { get; set; }
        /// <summary>
        /// 调出仓库
        /// </summary>
        public string F_CallOutWarehouse { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_Annex { get; set; }
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
        /// 调拨日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_TransferDateQRange { get; set; }
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
        /// 申请部门
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ApplicationDName { get; set; }
        /// <summary>
        /// 申请人员
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ApplicantName { get; set; }
        #endregion
    }
}