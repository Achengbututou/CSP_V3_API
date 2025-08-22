using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-18 11:24:51
    /// 描 述：mes_ProcessDispatch(工序派工)表的实体
    /// </summary>
    [MyTable("mes_ProcessDispatch")]
    public class MesProcessDispatchEntity
    {
        #region 实体成员
        /// <summary>
        /// 工单主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 工单主键
        /// </summary>
        public string F_ProductionTicketId { get; set; }
        /// <summary>
        /// 工序主键
        /// </summary>
        public string F_ProcessManagementId { get; set; }
        /// <summary>
        /// 工序路线主键
        /// </summary>
        public string F_ProcessRouteId { get; set; }
        /// <summary>
        /// 工单编码
        /// </summary>
        public string F_ProdTicketNumber { get; set; }
        /// <summary>
        /// 工序编码
        /// </summary>
        public string F_ProcessMaNumber { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string F_ProcessMaName { get; set; }
        /// <summary>
        /// 任务总量
        /// </summary>
        public int? F_PlannedOutput { get; set; }
        /// <summary>
        /// 工序单价
        /// </summary>
        public decimal? F_ProcessUnitprice { get; set; }
        /// <summary>
        /// 已完成数量
        /// </summary>
        public int? F_CompletedNumber { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
        /// <summary>
        /// 已指数量
        /// </summary>
        public int? F_QuantityIndicated { get; set; }
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