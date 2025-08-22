using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 10:30:31
    /// 描 述：mes_InventoryDetails(盘点物品明细)表的实体
    /// </summary>
    [MyTable("mes_InventoryDetails")]
    public class MesInventoryDetailsEntity
    {
        #region 实体成员
        /// <summary>
        /// 盘点明细主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 盘点主键
        /// </summary>
        public string F_InventoryInfoId { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string F_MaterialType { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_SpecificationsModels { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 仓库主键
        /// </summary>
        public string F_WarehouseInfoId { get; set; }
        /// <summary>
        /// 库区主键
        /// </summary>
        public string F_ReservoirAreaId { get; set; }
        /// <summary>
        /// 库位主键
        /// </summary>
        public string F_LibraryLocationId { get; set; }
        /// <summary>
        /// 系统数量
        /// </summary>
        public int? F_SystemsQuantity { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public int? F_ActualQuantity { get; set; }
        /// <summary>
        /// 盈亏数量
        /// </summary>
        public int? F_ProfitOrLoss { get; set; }
        /// <summary>
        /// 盘点结果
        /// </summary>
        public string F_InventoryResults { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Remarks { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string F_CreatUserName { get; set; }
        /// <summary>
        /// 创建人主键
        /// </summary>
        public string F_CreatUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_CreatUserTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string F_ModifyName { get; set; }
        /// <summary>
        /// 修改人主键
        /// </summary>
        public string F_ModifyId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? F_ModifyTime { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public string F_TenantId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 创建时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreatUserTimeQRange { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyTimeQRange { get; set; }

        #endregion
    }
}