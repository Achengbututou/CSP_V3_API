using learun.database;
using System;

namespace HRATTF004.ibll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：attendance_error_hdr表的实体
    /// </summary>
    [MyTable("attendance_error_hdr")]
    public class AttendanceErrorHdrEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string rid { get; set; }
        /// <summary>
        /// Note_No
        /// </summary>
        public string note_no { get; set; }
        /// <summary>
        /// Submit_UserID
        /// </summary>
        public string submit_userid { get; set; }
        /// <summary>
        /// Submit_Date
        /// </summary>
        public DateTime? submit_date { get; set; }
        /// <summary>
        /// Approve_status
        /// </summary>
        public string approve_status { get; set; }
        /// <summary>
        /// Approve_userid
        /// </summary>
        public string approve_userid { get; set; }
        /// <summary>
        /// Approve_date
        /// </summary>
        public DateTime? approve_date { get; set; }
        /// <summary>
        /// Sys_date
        /// </summary>
        public DateTime? sys_date { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// Submit_Date(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string submit_dateqrange { get; set; }
        /// <summary>
        /// Approve_date(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string approve_dateqrange { get; set; }
        /// <summary>
        /// Sys_date(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string sys_dateqrange { get; set; }

        #endregion
    }
}