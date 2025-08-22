using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 09:56:11
    /// 描 述：mes_OutboundDetails(出库物品)表的实体
    /// </summary>
    [MyTable("mes_OutboundDetails")]
    public class MesOutboundDetailsEntity
    {
        #region 实体成员
        /// <summary>
        /// 出库明细主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 出库主键
        /// </summary>
        public string F_OutboundInfoId { get; set; }
        /// <summary>
        /// 出库批次号
        /// </summary>
        public string F_OutboundBatchNumber { get; set; }
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
        /// 单价
        /// </summary>
        public decimal? F_UnitPrice { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        public int? F_ThisQuantity { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal? F_TotalAmount { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? F_ProductionDate { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? F_ExpirationDate { get; set; }
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
        /// 生产日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductionDateQRange { get; set; }
        /// <summary>
        /// 到期日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ExpirationDateQRange { get; set; }
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
        /// <summary>
        /// 弹窗查询条件
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }
        /// <summary>
        /// 选择单据主键
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductId { get; set; }
        #endregion
    }
}