using learun.database;
using System;

namespace ADMF005.ibll
{
    /// <summary>
    /// 访客申请-访客出入厂
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2024-05-03 16:04:51
    /// 描 述：Visitors_Enter(访客出入厂表)表的实体
    /// </summary>
    [MyTable("Visitors_Enter")]
    public class VisitorsEnterEntity
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
        public string Visitors_Note_No { get; set; }
        /// <summary>
        /// 访客姓名
        /// </summary>
        public string Visitors_Name { get; set; }
        /// <summary>
        /// 居住地
        /// </summary>
        public string Visitors_living { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string Visitors_ID_No { get; set; }
        /// <summary>
        /// 访客类型
        /// </summary>
        public string Visitors_type { get; set; }
        /// <summary>
        /// 来访事由
        /// </summary>
        public string Visit_reason { get; set; }
        /// <summary>
        /// 访客单位
        /// </summary>
        public string Visitors_unit { get; set; }
        /// <summary>
        /// 访客电话
        /// </summary>
        public string Visitors_phone { get; set; }
        /// <summary>
        /// 对接人姓名
        /// </summary>
        public string Receiver_Name { get; set; }
        /// <summary>
        /// 对接人工号
        /// </summary>
        public string Receiver_EMP { get; set; }
        /// <summary>
        /// 对接人公司
        /// </summary>
        public string Receiver_Company { get; set; }
        /// <summary>
        /// 对接人部门
        /// </summary>
        public string Receiver_Dept { get; set; }
        /// <summary>
        /// 对接人电话
        /// </summary>
        public string Receiver_phone { get; set; }
        /// <summary>
        /// 对接人分机
        /// </summary>
        public string Receiver_extension { get; set; }
        /// <summary>
        /// 预计开始时间
        /// </summary>
        public DateTime? Estimated_from_time { get; set; }
        /// <summary>
        /// 预计结束时间
        /// </summary>
        public DateTime? Estimated_end_time { get; set; }
        /// <summary>
        /// 进厂次数
        /// </summary>
        public string In_times { get; set; }
        /// <summary>
        /// 访客证号
        /// </summary>
        public string Visit_No { get; set; }
        /// <summary>
        /// 停车证号
        /// </summary>
        public string Parking_No { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string Car_No { get; set; }
        /// <summary>
        /// 入厂地点
        /// </summary>
        public string In_position { get; set; }
        /// <summary>
        /// 出入厂状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 访客级别
        /// </summary>
        public string Visitors_level { get; set; }
        /// <summary>
        /// 是否验证信息
        /// </summary>
        public string Need_check { get; set; }
        /// <summary>
        /// Action_user
        /// </summary>
        public string Action_user { get; set; }
        /// <summary>
        /// Action_date
        /// </summary>
        public DateTime? Action_date { get; set; }
        /// <summary>
        /// Visit_area
        /// </summary>
        public string Visit_area { get; set; }
        /// <summary>
        /// security_check
        /// </summary>
        public string security_check { get; set; }
        /// <summary>
        /// security_remark
        /// </summary>
        public string security_remark { get; set; }
        /// <summary>
        /// Frame_No
        /// </summary>
        public string Frame_No { get; set; }
        /// <summary>
        /// Container_No
        /// </summary>
        public string Container_No { get; set; }
        /// <summary>
        /// Seal_No
        /// </summary>
        public string Seal_No { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 预计开始时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Estimated_from_timeQRange { get; set; }
        /// <summary>
        /// 预计结束时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Estimated_end_timeQRange { get; set; }
        /// <summary>
        /// Action_date(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Action_dateQRange { get; set; }
        /// <summary>
        /// Enable_enter_time(查询该时间可入厂数据)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Enable_enter_time { get; set; }
        /// <summary>
        /// Enable_enter_time2(判断该时间是否可入厂)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Enable_enter_time2 { get; set; }
        #endregion
    }
}