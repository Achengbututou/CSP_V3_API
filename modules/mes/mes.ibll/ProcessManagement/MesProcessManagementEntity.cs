using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-07 09:53:29
    /// 描 述：mes_ProcessManagement(工序管理)表的实体
    /// </summary>
    [MyTable("mes_processmanage")]
    public class MesProcessManagementEntity
    {
        #region 实体成员
        /// <summary>
        /// 工序管理主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 工序编码
        /// </summary>
        public string F_ProcessMaNumber { get; set; }
        /// <summary>
        /// 用户输入编码
        /// </summary>
        public string F_IsSysNum { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 工序类型名称
        /// </summary>
        public string F_ProcessMaName { get; set; }
        /// <summary>
        /// 工序类型
        /// </summary>
        public string F_ProcessTypeId { get; set; }
        /// <summary>
        /// 准备工时
        /// </summary>
        public int? F_PreparationHours { get; set; }
        /// <summary>
        /// 辅助工时
        /// </summary>
        public int? F_AuxiliaryHours { get; set; }
        /// <summary>
        /// 工序成本
        /// </summary>
        public decimal? F_ProcessCost { get; set; }
        /// <summary>
        /// 工序单价
        /// </summary>
        public decimal? F_ProcessUnitprice { get; set; }
        /// <summary>
        /// 工序状态
        /// </summary>
        public int? F_ProcessState { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_Annex { get; set; }
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
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProcessRouteId { get; set; }
        /// <summary>
        /// 工单主键
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductionTicketId { get; set; }
        /// <summary>
        /// 任务总量
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_PlannedOutput { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_States { get; set; }
        /// <summary>
        /// 已指数量
        /// </summary>
        [Column(IsIgnore = true)]
        public int? F_QuantityIndicated { get; set; }
        /// <summary>
        /// 工单编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProdTicketNumber { get; set; }
        /// <summary>
        /// 工序主键
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProcessManagementId { get; set; }
        /// <summary>
        /// 查询关键词
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }
        #endregion
    }
}