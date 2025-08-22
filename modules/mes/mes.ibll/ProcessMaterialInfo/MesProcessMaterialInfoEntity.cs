using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-18 11:31:18
    /// 描 述：mes_processmaterinfo(工序派工物料信息)表的实体
    /// </summary>
    [MyTable("mes_processmaterinfo")]
    public class MesProcessMaterialInfoEntity
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
        /// 工序路线主键
        /// </summary>
        public string F_ProcessRouteId { get; set; }
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
        /// 需求数量
        /// </summary>
        public int? F_DemandQuantity { get; set; }
        /// <summary>
        /// 已领数量
        /// </summary>
        public int? F_ReceivedQuantity { get; set; }
        /// <summary>
        /// 已生产数量
        /// </summary>
        public int? F_LackMaterial { get; set; }
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