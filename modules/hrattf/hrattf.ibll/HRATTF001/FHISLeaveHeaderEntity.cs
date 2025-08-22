using learun.database;
using System;

namespace HRATTF.ibll
{
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2024-01-09 14:54:39
    /// 描 述：FHIS_Leave_Header(请假主表)表的实体
    /// </summary>
    [MyTable("FHIS_Leave_Header")]
    public class FHISLeaveHeaderEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string Leave_Note_NO { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string Emp_No { get; set; }
        /// <summary>
        /// 间断请假
        /// </summary>
        public bool? Not_Continu_Leave_Flag { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? From_Date { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string From_Time { get; set; }
        /// <summary>
        /// 开始日时间
        /// </summary>
        public int? From_Date_Minute { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? To_Date { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string To_Time { get; set; }
        /// <summary>
        /// 结束日时间
        /// </summary>
        public int? To_Date_Minute { get; set; }
        /// <summary>
        /// 工伤日期
        /// </summary>
        public DateTime? Industrial_injury_Date { get; set; }
        /// <summary>
        /// 请假类型
        /// </summary>
        public string Leave_Type { get; set; }
        /// <summary>
        /// 受限请假
        /// </summary>
        public string Leave_List_RID { get; set; }
        /// <summary>
        /// 取消受限
        /// </summary>
        public bool? Cancel_Limit_Flag { get; set; }
        /// <summary>
        /// 开始日期全天
        /// </summary>
        public bool? From_Date_Full_Flag { get; set; }
        /// <summary>
        /// 结束日期全天
        /// </summary>
        public bool? To_Date_Full_Flag { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string Submit_UserID { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? Leave_Submit_Date { get; set; }
        /// <summary>
        /// 批核状态
        /// </summary>
        public string Approve_Status { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? Last_Update_Date { get; set; }
        /// <summary>
        /// 请假方式
        /// </summary>
        public string Leave_Way { get; set; }
        /// <summary>
        /// 请假时段
        /// </summary>
        public int? Leave_Shift_Item { get; set; }
        /// <summary>
        /// M级批核人
        /// </summary>
        public string M_Approve_UserID { get; set; }
        /// <summary>
        /// M级批核时间
        /// </summary>
        public DateTime? M_Approve_Date { get; set; }
        /// <summary>
        /// M级批核备注
        /// </summary>
        public string M_Approve_remark { get; set; }
        /// <summary>
        /// M级批核状态
        /// </summary>
        public string M_Approve_Status { get; set; }
        /// <summary>
        /// E级批核人
        /// </summary>
        public string E_Approve_UserID { get; set; }
        /// <summary>
        /// E级批核时间
        /// </summary>
        public DateTime? E_Approve_Date { get; set; }
        /// <summary>
        /// E级批核备注
        /// </summary>
        public string E_Approve_remark { get; set; }
        /// <summary>
        /// E级批核状态
        /// </summary>
        public string E_Approve_Status { get; set; }
        /// <summary>
        /// HRD批核人
        /// </summary>
        public string HRD_Approve_UserID { get; set; }
        /// <summary>
        /// HRD批核时间
        /// </summary>
        public DateTime? HRD_Approve_Date { get; set; }
        /// <summary>
        /// HRD批核备注
        /// </summary>
        public string HRD_Approve_remark { get; set; }
        /// <summary>
        /// HRD批核状态
        /// </summary>
        public string HRD_Approve_Status { get; set; }
        /// <summary>
        /// 电子签名
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 请假年份
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// 请假天数
        /// </summary>
        public int? Leave_Day { get; set; }
        /// <summary>
        /// 部门经理是否是E级
        /// </summary>
        public bool? M_is_E { get; set; }
        /// <summary>
        /// 是否需要HRD复核
        /// </summary>
        public bool? Need_HRD { get; set; }
        /// <summary>
        /// 是否已上传全部附件
        /// </summary>
        public bool? Is_All_Voucher { get; set; }
        /// <summary>
        /// 所属公司
        /// </summary>
        public string Company_Id { get; set; }
        /// <summary>
        /// 直属上司
        /// </summary>
        public string Appraiser_UserID { get; set; }
        /// <summary>
        /// 直属上司批核时间
        /// </summary>
        public DateTime? Appraiser_UserDate { get; set; }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int? Synchronous_Status { get; set; }
        /// <summary>
        /// 同步错误内容
        /// </summary>
        public string Synchronous_Message { get; set; }

        /// <summary>
        /// 架构
        /// </summary>
        public string organization_Level { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 开始日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string From_DateQRange { get; set; }
        /// <summary>
        /// 结束日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string To_DateQRange { get; set; }
        /// <summary>
        /// 工伤日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Industrial_injury_DateQRange { get; set; }
        /// <summary>
        /// 申请时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Leave_Submit_DateQRange { get; set; }
        /// <summary>
        /// 最后修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Last_Update_DateQRange { get; set; }
        /// <summary>
        /// M级批核时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string M_Approve_DateQRange { get; set; }
        /// <summary>
        /// E级批核时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string E_Approve_DateQRange { get; set; }
        /// <summary>
        /// HRD批核时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string HRD_Approve_DateQRange { get; set; }
        /// <summary>
        /// 直属上司批核时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Appraiser_UserDateQRange { get; set; }

        /// <summary>
        /// 批核状态
        /// add by kyle on 2024-02-22
        /// </summary>
        [Column(IsIgnore = true)]
        public int? Approve_StatusRange { get; set; }


        #endregion
    }
}