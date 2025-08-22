using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-29 13:47:39
    /// 描 述：收件确认表单提交参数
    /// </summary>
    public class FirstTestReportDto
    {
        /// <summary>
        /// mes_FirstTestReport(首件检测报告)表的实体
        /// </summary>
        public MesFirstTestReportEntity MesFirstTestReportEntity { get; set; }
        /// <summary>
        /// mes_FirstTestByOrder(首件检测报告检验数据)表的实体
        /// </summary>
        public IEnumerable<MesFirstTestByOrderEntity> MesFirstTestByOrderList { get; set; }

    }
}