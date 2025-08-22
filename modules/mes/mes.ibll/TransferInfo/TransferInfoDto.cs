using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 11:26:24
    /// 描 述：调拨管理表单提交参数
    /// </summary>
    public class TransferInfoDto
    {
        /// <summary>
        /// mes_TransferInfo(调拨信息)表的实体
        /// </summary>
        public MesTransferInfoEntity MesTransferInfoEntity { get; set; }
        /// <summary>
        /// mes_TransferDetails(调拨物品明细)表的实体
        /// </summary>
        public IEnumerable<MesTransferDetailsEntity> MesTransferDetailsList { get; set; }

    }
}