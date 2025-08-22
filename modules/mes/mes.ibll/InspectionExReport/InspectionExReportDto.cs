using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-29 17:24:38
    /// 描 述：巡检异常报告表单提交参数
    /// </summary>
    public class InspectionExReportDto
    {
        /// <summary>
        /// mes_inspectexreport(巡检异常报告)表的实体
        /// </summary>
        public MesInspectionExReportEntity MesInspectionExReportEntity { get; set; }
        /// <summary>
        /// mes_inspectexdetail(异常巡检报告巡检数据)表的实体
        /// </summary>
        public IEnumerable<MesInspectionExDetailEntity> MesInspectionExDetailList { get; set; }

    }
}