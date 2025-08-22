using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-17 16:11:23
    /// 描 述：mes_productticket(生产工单)表的实体
    /// </summary>
    [MyTable("mes_productticket")]
    public class MesProductionTicketEntity
    {
        #region 实体成员
        /// <summary>
        /// 工单主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        public string F_ProcessRouteId { get; set; }  
        /// <summary>
        /// 工单编码
        /// </summary>
        public string F_ProdTicketNumber { get; set; }
        /// <summary>
        /// 用户输入编码
        /// </summary>
        public string F_IsSysNum { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 计划单主键
        /// </summary>
        public string F_ProductionScheduleId { get; set; }
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
        /// 派工方式
        /// </summary>
        public int? F_DispatchType { get; set; }
        /// <summary>
        /// 开工状态
        /// </summary>
        public int? F_StartWork { get; set; }
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
        /// 实际开工日期
        /// </summary>
        public DateTime? F_ActualStartDate { get; set; }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        public DateTime? F_ActualEndDate { get; set; }
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
        /// 实际开工日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ActualStartDateQRange { get; set; }
        /// <summary>
        /// 实际完成日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ActualEndDateQRange { get; set; }
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
        /// <summary>
        /// 已报数量
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_CompletedNumber { get; set; }
        /// <summary>
        /// 产品主键
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductId { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }
        /// <summary>
        /// 物料类别
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_TypeName { get; set; }
        /// <summary>
        /// 规则型号
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_Model { get; set; }
        /// <summary>
        /// 实际产量
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_ProductionQuantity { get; set; }
        /// <summary>
        /// 已入库数量
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_ThisQuantity { get; set; }
        /// <summary>
        /// 合格数量
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_QualifiedQuantity { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_QualifiedRating { get; set; }
        #endregion
    }
}