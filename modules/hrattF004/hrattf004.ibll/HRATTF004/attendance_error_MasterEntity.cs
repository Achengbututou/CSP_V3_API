using learun.database;
using System;

namespace HRATTF004.ibll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：attendance_error_Master表的实体
    /// </summary>
    [MyTable("attendance_error_Master")]
    public class attendance_error_MasterEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        /// <summary>
        /// UserID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// use_flag
        /// </summary>
        public string use_flag { get; set; }
        /// <summary>
        /// organization_level
        /// </summary>
        public string organization_level { get; set; }
        /// <summary>
        /// Emp_No
        /// </summary>
        public string Emp_No { get; set; }
        /// <summary>
        /// emp_name
        /// </summary>
        public string emp_name { get; set; }
        /// <summary>
        /// Position_Name
        /// </summary>
        public string Position_Name { get; set; }
        /// <summary>
        /// Att_date
        /// </summary>
        public DateTime? Att_date { get; set; }
        /// <summary>
        /// Att_Name
        /// </summary>
        public string Att_Name { get; set; }
        /// <summary>
        /// Shift_Code
        /// </summary>
        public string Shift_Code { get; set; }
        /// <summary>
        /// From_Time1
        /// </summary>
        public string From_Time1 { get; set; }
        /// <summary>
        /// From_Error_Desc1
        /// </summary>
        public string From_Error_Desc1 { get; set; }
        /// <summary>
        /// To_Time1
        /// </summary>
        public string To_Time1 { get; set; }
        /// <summary>
        /// To_Error_Desc1
        /// </summary>
        public string To_Error_Desc1 { get; set; }
        /// <summary>
        /// From_Time2
        /// </summary>
        public string From_Time2 { get; set; }
        /// <summary>
        /// From_Error_Desc2
        /// </summary>
        public string From_Error_Desc2 { get; set; }
        /// <summary>
        /// To_Time2
        /// </summary>
        public string To_Time2 { get; set; }
        /// <summary>
        /// To_Error_Desc2
        /// </summary>
        public string To_Error_Desc2 { get; set; }
        /// <summary>
        /// From_Time3
        /// </summary>
        public string From_Time3 { get; set; }
        /// <summary>
        /// From_Error_Desc3
        /// </summary>
        public string From_Error_Desc3 { get; set; }
        /// <summary>
        /// To_Time3
        /// </summary>
        public string To_Time3 { get; set; }
        /// <summary>
        /// To_Error_Desc3
        /// </summary>
        public string To_Error_Desc3 { get; set; }
        /// <summary>
        /// Normal_Minute
        /// </summary>
        public string Normal_Minute { get; set; }
        /// <summary>
        /// absent_minute
        /// </summary>
        public string absent_minute { get; set; }
        /// <summary>
        /// OT_Minute
        /// </summary>
        public string OT_Minute { get; set; }
        /// <summary>
        /// OT_App_Minute
        /// </summary>
        public string OT_App_Minute { get; set; }
        /// <summary>
        /// Leave_App_Minute
        /// </summary>
        public string Leave_App_Minute { get; set; }
        /// <summary>
        /// Pay_Leave_Minute
        /// </summary>
        public string Pay_Leave_Minute { get; set; }
        /// <summary>
        /// nopay_leave_minute
        /// </summary>
        public string nopay_leave_minute { get; set; }
        /// <summary>
        /// Layoff_Minute
        /// </summary>
        public string Layoff_Minute { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// Att_Date(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Att_DateQRange { get; set; }
        /// <summary>
        /// Emp_No(Emp_No查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Emp_NoQRange { get; set; }


        #endregion
    }
}