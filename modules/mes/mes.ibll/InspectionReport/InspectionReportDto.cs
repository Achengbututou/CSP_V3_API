using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-29 16:23:56
    /// 描 述：巡检报告表单提交参数
    /// </summary>
    public class InspectionReportDto
    {
        /// <summary>
        /// mes_inspectreport(巡检报告)表的实体
        /// </summary>
        public MesInspectionReportEntity MesInspectionReportEntity { get; set; }
        /// <summary>
        /// mes_inspectdetail(巡检报告巡检数据)表的实体
        /// </summary>
        public IEnumerable<MesInspectionDetailEntity> MesInspectionDetailList { get; set; }

    }
}