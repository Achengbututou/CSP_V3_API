using DocumentFormat.OpenXml.Office2010.ExcelAc;
using learun.database;
using System;
using System.Collections.Generic;

namespace HRATTF008.ibll
{
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：Password_History(查询密码)表的实体
    /// </summary>
    [MyTable("Password_History")]
    public class PasswordHistoryEntity
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
        public string Password { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime Effect_Date { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? End_Date { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? Last_Update_Date { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 开始日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string Effect_DateQRange { get; set; }
        /// <summary>
        /// 结束日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string End_DateQRange { get; set; }
        /// <summary>
        /// 查询密码(查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public List<string> PasswordQRangeList { get; set; }
        #endregion
    }
}