using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-30 17:20:47
    /// 描 述：成品检验报告表单提交参数
    /// </summary>
    public class FinishedReportDto
    {
        /// <summary>
        /// mes_FinishedReport(成品检验报告)表的实体
        /// </summary>
        public MesFinishedReportEntity MesFinishedReportEntity { get; set; }
        /// <summary>
        /// mes_FinishedDetail(成品检验数据)表的实体
        /// </summary>
        public IEnumerable<MesFinishedDetailEntity> MesFinishedDetailList { get; set; }

    }
}