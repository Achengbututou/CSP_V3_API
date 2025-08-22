using learun.database;
using System;

namespace HRATTF.ibll
{
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-10-24 09:19:39
    /// 描 述：FHIS_Leave_Detail(FHIS请假证明)表的实体
    /// </summary>
    [MyTable("FHIS_Leave_Detail")]
    public class FHISLeaveDetailEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        /// <summary>
        /// 请假单RID
        /// </summary>
        public string Leave_Header_RID { get; set; }
        /// <summary>
        /// 凭证类型
        /// </summary>
        public string Voucher_Type { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string File_Url { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string File_Type { get; set; }
        /// <summary>
        /// 文件后缀
        /// </summary>
        public string File_suffix { get; set; }

        #endregion

        #region 扩展属性
        
        #endregion
    }
}