using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-31 10:20:45
    /// 描 述：成品异常报告表单提交参数
    /// </summary>
    public class FinishedExReportDto
    {
        /// <summary>
        /// mes_FinishedExReport(成品校验异常报告)表的实体
        /// </summary>
        public MesFinishedExReportEntity MesFinishedExReportEntity { get; set; }
        /// <summary>
        /// mes_FinishedExDetail(成品校验异常数据)表的实体
        /// </summary>
        public IEnumerable<MesFinishedExDetailEntity> MesFinishedExDetailList { get; set; }

    }
}