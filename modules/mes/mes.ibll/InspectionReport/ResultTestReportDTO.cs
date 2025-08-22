using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll.InspectionReport
{
    /// <summary>
    /// 检测报告返回实体类
    /// </summary>
    public class ResultTestReportDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public List<InpertionReportAllDTO> inpertionReport { get; set; }
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Total { get; set; }  
    }
}
