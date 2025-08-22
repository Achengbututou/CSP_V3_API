using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-18 15:09:45
    /// 描 述：调拨列表表单提交参数
    /// </summary>
    public class TransferOrderDto
    {
        /// <summary>
        /// mes_TransferOrder(调拨单信息)表的实体
        /// </summary>
        public MesTransferOrderEntity MesTransferOrderEntity { get; set; }
        /// <summary>
        /// mes_transferorderde(调拨物品明细)表的实体
        /// </summary>
        public IEnumerable<MesTransferOrderDetailsEntity> MesTransferOrderDetailsList { get; set; }

    }
}