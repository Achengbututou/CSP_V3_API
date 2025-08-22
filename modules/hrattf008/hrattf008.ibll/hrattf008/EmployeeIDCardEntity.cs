using learun.database;
using System;

namespace HRATTF008.ibll
{
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：FHIS_Empoyee_All_ID_Card(身份证)表的实体
    /// </summary>
    [MyTable("FHIS_Empoyee_All_ID_Card")]
    public class EmployeeIDCardEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company_Code { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string Emp_No { get; set; }
        /// <summary>
        /// 查询密码
        /// </summary>
        public string ID_NO { get; set; }
        /// <summary>
        /// 首次入职日期
        /// </summary>
        public DateTime Fjoin_Date { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? Join_Date { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? Resign_Date {  get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 首次入职日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Fjoin_DateQRange { get; set; }
        /// <summary>
        /// 入职日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Join_DateQRange { get; set; }
        /// <summary>
        /// 离职日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Resign_DateQRange { get; set; }
        #endregion
    }
}