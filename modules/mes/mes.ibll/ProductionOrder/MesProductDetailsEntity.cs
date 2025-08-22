using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-15 09:12:40
    /// 描 述：mes_ProductDetails(生产订单产品明细)表的实体
    /// </summary>
    [MyTable("mes_ProductDetails")]
    public class MesProductDetailsEntity
    {
        #region 实体成员
        /// <summary>
        /// 明细主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 生产订单主键
        /// </summary>
        public string F_ProductionOrderId { get; set; }
        /// <summary>
        /// 订单主键
        /// </summary>
        public string F_OrderId { get; set; }
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_SpecificationsModels { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 计划产量
        /// </summary>
        public int? F_PlannedOutput { get; set; }
        /// <summary>
        /// 上线日期
        /// </summary>
        public DateTime? F_LaunchDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
        /// <summary>
        /// 作废理由
        /// </summary>
        public string F_ReasonInvalidation { get; set; }
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
        /// 上线日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_LaunchDateQRange { get; set; }
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
        /// 生产订单编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductionOrderNumber { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_Priority { get; set; }
        /// <summary>
        /// 物料主键
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_MaterialId { get; set; }
        #endregion
    }
}