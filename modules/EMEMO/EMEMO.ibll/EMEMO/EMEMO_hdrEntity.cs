using learun.database;
using System;
using static log4net.Appender.RollingFileAppender;

namespace EMEMO.ibll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：attendance_error_hdr表的实体
    /// </summary>
    [MyTable("EMEMO_hdr")]
    public class EMEMO_hdrEntity
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
        /// Note_No
        /// </summary>
        public string memo_no { get; set; }
        /// <summary>
        /// factory
        /// </summary>
        public string factory { get; set; }
        /// <summary>
        /// company_code
        /// </summary>
        public string company_code { get; set; }
        /// <summary>
        /// Cggroup
        /// </summary>
        public string cggroup { get; set; }
        /// <summary>
        /// Mattype
        /// </summary>
        public string mattype { get; set; }
        /// <summary>
        /// so_plant
        /// </summary>
        public string so_plant { get; set; }
        /// <summary>
        /// memo_category
        /// </summary>
        public string memo_category { get; set; }
        /// <summary>
        /// application_plant
        /// </summary>
        public string application_plant { get; set; }
        /// <summary>
        /// season
        /// </summary>
        public string season { get; set; }
        /// <summary>
        /// disposal_method
        /// </summary>
        public string disposal_method { get; set; }
        /// <summary>
        /// shiptocountry
        /// </summary>
        public string shiptocountry { get; set; }
        /// <summary>
        /// buyerjobber
        /// </summary>
        public string buyerjobber { get; set; }
        /// <summary>
        /// disposal_subject
        /// </summary>
        public string disposal_subject { get; set; }
        /// <summary>
        /// disposal_reason
        /// </summary>
        public string disposal_reason { get; set; }
        /// <summary>
        /// Submit_UserID
        /// </summary>
        public string submit_userid { get; set; }
        /// <summary>
        /// Submit_Date
        /// </summary>
        public DateTime? submit_date { get; set; }
        /// <summary>
        /// Approve_userid
        /// </summary>
        public string approve_userid { get; set; }
        /// <summary>
        /// Approve_date
        /// </summary>
        public DateTime? approve_date { get; set; }
        /// <summary>
        /// Approve_status
        /// </summary>
        public string approve_status { get; set; }
        /// <summary>
        /// last_update_userid
        /// </summary>
        public string last_update_userid { get; set; }
        /// <summary>
        /// last_update_date
        /// </summary>
        public DateTime? last_update_date { get; set; }
        /// <summary>
        /// ARNo
        /// </summary>
        public string ARNo { get; set; }
        /// <summary>
        /// ARDate
        /// </summary>
        public DateTime? ARDate {  get; set; }
        /// <summary>
        /// GoodsIssueDate
        /// </summary>
        public DateTime? GoodsIssueDate {  get; set; }

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

        #endregion
    }
}