using System;

namespace HRATTF008.ibll
{
    public class PayrollEnDto
    {
        public string ActionType { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company_Code{ get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string Emp_No { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 粮期
        /// </summary>
        public string Period_Code { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime From_Date { get; set; }
        public string User_ID { get; set; }
        public string User_Company_Code { get; set; }
        public int Type { get; set; }
        public string Year { get; set; }
    }
}
