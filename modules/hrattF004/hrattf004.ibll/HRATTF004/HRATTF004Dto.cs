using System;
using System.Collections.Generic;

namespace HRATTF004.ibll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：错误考勤表单提交参数
    /// </summary>
    public class HRATTF004Dto
    {
        /// <summary>
        /// attendance_error_hdr表的实体
        /// </summary>
        public AttendanceErrorHdrEntity AttendanceErrorHdrEntity { get; set; }
        /// <summary>
        /// attendance_error_dtl表的实体
        /// </summary>
        public IEnumerable<AttendanceErrorDtlEntity> AttendanceErrorDtlList { get; set; }

        public attendance_error_MasterEntity attendance_error_MasterEntity { get; set; }

    }

    public class attendance_errorDto
    {
        /// RID
        /// </summary>
        public string rid { get; set; }
        /// <summary>
        /// 
        /// 明细RID
        /// </summary>
        public string attendance_error_rid { get; set; }
        /// <summary>
        /// 
        /// 单号
        /// </summary>
        public string note_no { get; set; }
        /// <summary>
        /// 批核状态
        /// </summary>
        public string approve_status { get; set; }
        /// <summary>
        /// 批核ID
        /// </summary>
        public string approve_userid { get; set; }
        /// <summary>
        /// 批核时间
        /// </summary>
        public DateTime? approve_date { get; set; }
        /// <summary>
        /// userid
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 调用标记
        /// </summary>
        public bool? use_flag { get; set; }
        /// <summary>
        /// 架构
        /// </summary>
        public string organization_level { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string emp_no { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string emp_name { get; set; }
        /// <summary>
        /// 职位名
        /// </summary>
        public string position_name { get; set; }
        /// <summary>
        /// 考勤日期
        /// </summary>
        public DateTime? att_date { get; set; }
        /// <summary>
        /// 星期几
        /// </summary>
        public string att_name { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        public string shift_code { get; set; }
        /// <summary>
        /// 进卡1
        /// </summary>
        public string from_time1 { get; set; }
        /// <summary>
        /// 出卡1
        /// </summary>
        public string to_time1 { get; set; }
        /// <summary>
        /// 进卡2
        /// </summary>
        public string from_time2 { get; set; }
        /// <summary>
        /// 出卡2
        /// </summary>
        public string to_time2 { get; set; }
        /// <summary>
        /// 进卡3
        /// </summary>
        public string from_time3 { get; set; }
        /// <summary>
        /// 出卡3
        /// </summary>
        public string to_time3 { get; set; }
        /// <summary>
        /// 上班时间
        /// </summary>
        public int? normal_minute { get; set; }
        /// <summary>
        /// 缺勤时间
        /// </summary>
        public int? absent_minute { get; set; }
        /// <summary>
        /// 加班时间
        /// </summary>
        public int? ot_minute { get; set; }
        /// <summary>
        /// 加班申请时间
        /// </summary>
        public int? ot_app_minute { get; set; }
        /// <summary>
        /// 请假时间
        /// </summary>
        public int? leave_app_minute { get; set; }
        /// <summary>
        /// 有薪请假时间
        /// </summary>
        public int? pay_leave_minute { get; set; }
        /// <summary>
        /// 无薪请假时间
        /// </summary>
        public int? nopay_leave_minute { get; set; }
        /// <summary>
        /// 回工时间
        /// </summary>
        public int? layoff_minute { get; set; }

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
        /// 错误考勤原因
        /// </summary>
        public string error_desc { get; set; }

    }
}