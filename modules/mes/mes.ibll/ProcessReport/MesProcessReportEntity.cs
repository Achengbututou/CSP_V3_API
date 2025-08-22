using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-18 16:15:01
    /// 描 述：mes_ProcessReport(工序报工)表的实体
    /// </summary>
    [MyTable("mes_ProcessReport")]
    public class MesProcessReportEntity
    {
        #region 实体成员
        /// <summary>
        /// 报工主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 工单主键
        /// </summary>
        public string F_ProductionTicketId { get; set; }
        /// <summary>
        /// 可报数量
        /// </summary>
        public int? F_ReportableQuantity { get; set; }
        /// <summary>
        /// 报工数量
        /// </summary>
        public int? F_ReportableNumber { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_Specifications { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 物料类别
        /// </summary>
        public string F_MaterialType { get; set; }
        /// <summary>
        /// 物料属性
        /// </summary>
        public string F_MaterialProperties { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        public string F_Equipment { get; set; }
        /// <summary>
        /// 工位
        /// </summary>
        public string F_ProcessWorkstation { get; set; }
        /// <summary>
        /// 班组编码
        /// </summary>
        public string F_TeamManagementNumber { get; set; }
        /// <summary>
        /// 班组名称
        /// </summary>
        public string F_TeamManagementName { get; set; }
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
        /// 创建时间
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_ActualStartDate { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_Account { get; set; }
        /// <summary>
        /// 生成工单编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProdTicketNumber { get; set; }
        #endregion
    }
}