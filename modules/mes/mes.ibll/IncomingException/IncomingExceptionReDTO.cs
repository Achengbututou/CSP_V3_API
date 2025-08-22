using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 来料异常报告返回值处理
    /// </summary>
    public class IncomingExceptionReDTO
    {
        /// <summary>
        /// 来料异常报告信息
        /// </summary>
        public MesIncomingExceptionEntity mesIncomingException { get; set; }
        /// <summary>
        /// 来料报告信息
        /// </summary>
        public MesIncomingInspectionEntity mesIncomingInspectionEntity { get; set; }
    }
}
