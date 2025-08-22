using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 开工实体
    /// </summary>
    public class StartWorkDTO
    {
        /// <summary>
        /// 工单主键
        /// </summary>
        public string fid { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        public DateTime? dateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Remarks { get; set; }
    }
}
