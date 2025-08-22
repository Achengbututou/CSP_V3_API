using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-30 17:03:50
    /// 描 述：半成品检测报告表单提交参数
    /// </summary>
    public class SemifinishedExReportDto
    {
        /// <summary>
        /// mes_semifinishexrep(半成品校验异常报告)表的实体
        /// </summary>
        public MesSemifinishedExReportEntity MesSemifinishedExReportEntity { get; set; }
        /// <summary>
        /// mes_semifinishexdeta(半成品校验异常数据)表的实体
        /// </summary>
        public IEnumerable<MesSemifinishedExDetailEntity> MesSemifinishedExDetailList { get; set; }

    }
}