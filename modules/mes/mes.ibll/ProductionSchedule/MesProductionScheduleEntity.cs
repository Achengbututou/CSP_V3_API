using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-15 09:40:10
    /// 描 述：mes_productschedu(生产计划单)表的实体
    /// </summary>
    [MyTable("mes_productschedu")]
    public class MesProductionScheduleEntity
    {
        #region 实体成员
        /// <summary>
        /// 计划单主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 生产订单详情主键
        /// </summary>
        public string F_ProductionDetailId { get; set; }
        /// <summary>
        /// 生产订单主键
        /// </summary>
        public string F_ProductionOrderId { get; set; }
        /// <summary>
        /// 生产计划编号
        /// </summary>
        public string F_ProductionScheNumber { get; set; }
        /// <summary>
        /// 上线日期
        /// </summary>
        public DateTime? F_LaunchDate { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public string F_Priority { get; set; }
        /// <summary>
        /// 计划产量
        /// </summary>
        public int? F_PlannedOutput { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_SpecificationsModel { get; set; }
        /// <summary>
        /// 物料类别
        /// </summary>
        public string F_MaterialType { get; set; }
        /// <summary>
        /// 物料属性
        /// </summary>
        public string F_MaterialProperty { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public int? F_Level { get; set; }
        /// <summary>
        /// 生产订单编码
        /// </summary>
        public string F_ProductionOrderNumber { get; set; }
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 所属车间
        /// </summary>
        public string F_WorkshopId { get; set; }
        /// <summary>
        /// 所属产线
        /// </summary>
        public string F_ProductionLineId { get; set; }
        /// <summary>
        /// 生产工艺
        /// </summary>
        public string F_ProcessRoute { get; set; }
        /// <summary>
        /// 计划开工日期
        /// </summary>
        public DateTime? F_PlanStartDate { get; set; }
        /// <summary>
        /// 计划完成日期
        /// </summary>
        public DateTime? F_PlanEndDate { get; set; }
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
        /// 计划开工日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_PlanStartDateQRange { get; set; }
        /// <summary>
        /// 计划完成日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_PlanEndDateQRange { get; set; }
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
        /// 所属车间
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_WorkshopName { get; set; }
        /// <summary>
        /// 所属产线
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductionLineName { get; set; }
        /// <summary>
        /// 生产工艺
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProcessRouteName { get; set; }
        #endregion
    }
}