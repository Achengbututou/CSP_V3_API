using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonInfoDTO
    {
        /// <summary>
        /// 产品主键
        /// </summary>
        public string F_ProductId { get; set; }
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        public string F_RouteId { get; set; }
        /// <summary>
        /// 常用状态 1：常用 0：不常用
        /// </summary>
        public int? F_CommonState { get; set; } 
    }
}
