using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 09:56:11
    /// 描 述：出库管理表单提交参数
    /// </summary>
    public class OutboundInfoDto
    {
        /// <summary>
        /// mes_OutboundInfo(出库信息)表的实体
        /// </summary>
        public MesOutboundInfoEntity MesOutboundInfoEntity { get; set; }
        /// <summary>
        /// mes_OutboundDetails(出库物品)表的实体
        /// </summary>
        public IEnumerable<MesOutboundDetailsEntity> MesOutboundDetailsList { get; set; }

    }
}