using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 10:30:31
    /// 描 述：盘点管理表单提交参数
    /// </summary>
    public class InventoryInfoDto
    {
        /// <summary>
        /// mes_InventoryInfo(盘点信息)表的实体
        /// </summary>
        public MesInventoryInfoEntity MesInventoryInfoEntity { get; set; }
        /// <summary>
        /// mes_InventoryDetails(盘点物品明细)表的实体
        /// </summary>
        public IEnumerable<MesInventoryDetailsEntity> MesInventoryDetailsList { get; set; }


    }
}