using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-05 17:17:28
    /// 描 述：入库管理表单提交参数
    /// </summary>
    public class WarehousingInfoDto
    {
        /// <summary>
        /// mes_WarehousingInfo(入库信息)表的实体
        /// </summary>
        public MesWarehousingInfoEntity MesWarehousingInfoEntity { get; set; }
        /// <summary>
        /// mes_warehousingde(入库物品明细)表的实体
        /// </summary>
        public IEnumerable<MesWarehousingDetailsEntity> MesWarehousingDetailsList { get; set; }

    }
}