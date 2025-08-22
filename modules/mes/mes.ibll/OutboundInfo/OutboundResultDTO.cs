using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    public class OutboundResultDTO
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        public string MessageInfo { get; set; }
        /// <summary>
        /// 操作状态
        /// </summary>
        public bool IsSuccess { get; set; } 
    }
}
