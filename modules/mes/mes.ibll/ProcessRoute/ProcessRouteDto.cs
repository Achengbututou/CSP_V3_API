using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-07 13:29:09
    /// 描 述：工艺路线管理表单提交参数
    /// </summary>
    public class ProcessRouteDto
    {
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        public string F_ProcessRouteId  { get; set; }
        /// <summary>
        /// mes_ProceNodeRoute表的实体
        /// </summary>
        public IEnumerable<MesProceNodeRouteEntity> nodes { get; set; }
        /// <summary>
        /// mes_ProcessLineRoute(工艺路线线条)表的实体
        /// </summary>
        public IEnumerable<MesProcessLineRouteEntity> edges { get; set; }

    }
}