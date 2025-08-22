using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll.InventoryInfo
{
    /// <summary>
    /// 盘点信息详细
    /// </summary>
    public class InventoryResultDto
    {
        /// <summary>
        /// mes_InventoryInfo(盘点信息)表的实体
        /// </summary>
        public MesInventoryInfoEntity MesInventoryInfoEntity { get; set; }
        /// <summary>
        /// mes_InventoryDetails(盘点物品明细)表的实体
        /// </summary>
        public IEnumerable<MesInventoryDetailsEntity> MesInventoryDetailsList { get; set; }
        /// <summary>
        /// 操作日志
        /// </summary>
        public IEnumerable<MesOperationLogInfoEntity> mesOperationLogInfos { get; set; }
    }
}
