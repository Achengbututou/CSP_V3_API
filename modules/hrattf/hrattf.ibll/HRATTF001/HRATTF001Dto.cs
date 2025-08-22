using System.Collections.Generic;

namespace HRATTF.ibll
{
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-10-24 09:19:39
    /// 描 述：请假申请表单提交参数
    /// </summary>
    public class HRATTF001Dto
    {
        /// <summary>
        /// FHIS_Leave_Header(请假主表)表的实体
        /// </summary>
        public FHISLeaveHeaderEntity FHISLeaveHeaderEntity { get; set; }
        /// <summary>
        /// FHIS_Leave_Detail(FHIS请假证明)表的实体
        /// </summary>
        public IEnumerable<FHISLeaveDetailEntity> FHISLeaveDetailList { get; set; }

    }
}