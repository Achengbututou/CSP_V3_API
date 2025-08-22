using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace hrattf.ibll.HRATTF001
{
    public class LeaveInputDto
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string ActionType { get; set; }
        /// <summary>
        /// RID
        /// </summary>
        public string RID { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string Leave_Note_NO { get; set; }
        /// <summary>
        /// 批核状态
        /// </summary>
        public string Approve_Status { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string Emp_No { get; set; }
        /// <summary>
        /// 请假类型
        /// </summary>
        public string Leave_Type { get; set; }
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
        /// 受限请假RID
        /// </summary>
        public string Leave_List_RID { get; set; }
        /// <summary>
        /// 工伤日期
        /// </summary>
        public DateTime? Industrial_injury_Date { get; set; }
        /// <summary>
        /// 受限请假类别代码
        /// </summary>
        public string Category_Code { get; set; }
        /// <summary>
        /// 受限请假年份代码Record_Code
        /// </summary>
        public string Record_Code { get; set; }
        /// <summary>
        /// 取消受限
        /// </summary>
        public bool? Cancel_Limit_Flag { get; set; }
        /// <summary>
        /// 间断请假
        /// </summary>
        public bool? Not_Continu_Leave_Flag { get; set; }


    }
}
