using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    public class InspectionExReportReDto
    {
        /// <summary>
        /// mes_inspectexreport(巡检异常报告)表的实体
        /// </summary>
        public MesInspectionExReportEntity MesInspectionExReportEntity { get; set; }
        /// <summary>
        /// mes_inspectreport(巡检报告)表的实体
        /// </summary>
        public MesInspectionReportEntity MesInspectionReportEntity { get; set; }
        /// <summary>
        /// mes_inspectexdetail(异常巡检报告巡检数据)表的实体
        /// </summary>
        public IEnumerable<MesInspectionExDetailEntity> MesInspectionExDetailList { get; set; }
    }
}
