namespace HRATTF008.ibll
{
    public class EmployeePasswordDto
    {
        /// <summary>
        /// 公司
        /// </summary>
        public string Company_Code { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string Emp_No { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        
        public string User_ID { get; set; }
        public int Type { get; set; }
    }
}
