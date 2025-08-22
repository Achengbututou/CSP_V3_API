using learun.database;
using System;

namespace HRATTF008.ibll
{

    [MyTable("FHIS_Payroll_En_Header")]
    public class FHISPayrollEnHeaderEntity
    {
        #region 实体成员
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        public string Emp_No { get; set; }
        public string Emp_Name { get; set; }
        public string Period_Code { get; set; }
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set;}
        public string Company_Code { get; set; }
        public string Company_Name { get;set; }
        public string Dept_Code { get; set; }
        public string Sect_Code { get; set; }
        public string Line_Code { get; set; }
        public string Sub_Line_Code { get; set; }
        public string Position_Code { get; set; }
        public string Position_Name1 { get; set; }
        public string ID_NO { get; set; }
        public string Signature {  get; set; }
        public int Status { get; set; }
        public DateTime? Signature_Date {  get; set; }
        public DateTime? Resign_Date { get; set; }
        #endregion

        #region 扩展属性
        [Column(IsIgnore = true)]
        public int Resign_Status { get; set; }
        #endregion
    }
}
