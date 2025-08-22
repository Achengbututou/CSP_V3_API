using learun.database;
using System;

namespace HRATTF004.ibll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：attendance_error_dtl表的实体
    /// </summary>
    [MyTable("attendance_error_dtl")]
    public class AttendanceErrorDtlEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string rid { get; set; }
        /// <summary>
        /// Attendance_error_RID
        /// </summary>
        public string attendance_error_rid { get; set; }
        /// <summary>
        /// userid
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// Use_flag
        /// </summary>
        public string use_flag { get; set; }
        /// <summary>
        /// Organization_level
        /// </summary>
        public string organization_level { get; set; }
        /// <summary>
        /// Emp_No
        /// </summary>
        public string emp_no { get; set; }
        /// <summary>
        /// Emp_name
        /// </summary>
        public string emp_name { get; set; }
        /// <summary>
        /// Position_Name
        /// </summary>
        public string position_name { get; set; }
        /// <summary>
        /// Att_date
        /// </summary>
        public string att_date { get; set; }
        /// <summary>
        /// Att_Name
        /// </summary>
        public string att_name { get; set; }
        /// <summary>
        /// Shift_Code
        /// </summary>
        public string shift_code { get; set; }
        /// <summary>
        /// From_Time1
        /// </summary>
        public string from_time1 { get; set; }
        /// <summary>
        /// To_Time1
        /// </summary>
        public string to_time1 { get; set; }
        /// <summary>
        /// From_Time2
        /// </summary>
        public string from_time2 { get; set; }
        /// <summary>
        /// To_Time2
        /// </summary>
        public string to_time2 { get; set; }
        /// <summary>
        /// From_Time3
        /// </summary>
        public string from_time3 { get; set; }
        /// <summary>
        /// To_Time3
        /// </summary>
        public string to_time3 { get; set; }
        /// <summary>
        /// Normal_Minute
        /// </summary>
        public int? normal_minute { get; set; }
        /// <summary>
        /// Absent_minute
        /// </summary>
        public int? absent_minute { get; set; }
        /// <summary>
        /// OT_Minute
        /// </summary>
        public int? ot_minute { get; set; }
        /// <summary>
        /// OT_App_Minute
        /// </summary>
        public int? ot_app_minute { get; set; }
        /// <summary>
        /// Leave_App_Minute
        /// </summary>
        public int? leave_app_minute { get; set; }
        /// <summary>
        /// Pay_Leave_Minute
        /// </summary>
        public int? pay_leave_minute { get; set; }
        /// <summary>
        /// Nopay_leave_minute
        /// </summary>
        public int? nopay_leave_minute { get; set; }
        /// <summary>
        /// Layoff_Minute
        /// </summary>
        public int? layoff_minute { get; set; }
        /// <summary>
        /// Error_Desc
        /// </summary>
        public string error_desc { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public bool? from_error_flag1 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public bool? from_error_flag2 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public bool? from_error_flag3 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public bool? to_error_flag1 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public bool? to_error_flag2 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public bool? to_error_flag3 { get; set; }


        /// <summary>
        /// from_error_flag1
        /// </summary>
        public string? from_error_desc1 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public string? from_error_desc2 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public string? from_error_desc3 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public string? to_error_desc1 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public string? to_error_desc2 { get; set; }

        /// <summary>
        /// from_error_flag1
        /// </summary>
        public string? to_error_desc3 { get; set; }



        /// <summary>
        /// id
        /// </summary>
        public int? id { get; set; }


        #endregion

        #region 扩展属性

        #endregion
    }
}