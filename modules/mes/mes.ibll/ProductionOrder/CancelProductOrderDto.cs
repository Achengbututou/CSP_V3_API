using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 作废实体传递DTO
    /// </summary>
    public class CancelProductOrderDto
    {
        /// <summary>
        /// 选中的订单主键
        /// </summary>
        public string F_Ids { get; set; }
        /// <summary>
        /// 作废理由
        /// </summary>
        public string F_ReasonInvalidation { get; set; }
    }
}
