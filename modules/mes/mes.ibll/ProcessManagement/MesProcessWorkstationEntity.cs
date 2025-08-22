using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-07 09:53:29
    /// 描 述：mes_processworkstat(工序工位管理)表的实体
    /// </summary>
    [MyTable("mes_processworkstat")]
    public class MesProcessWorkstationEntity
    {
        #region 实体成员
        /// <summary>
        /// 工序管理主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 工序类型主键
        /// </summary>
        public string F_ProcessManagementId { get; set; }
        /// <summary>
        /// 工位主键
        /// </summary>
        public string F_WorkstationId { get; set; }
        /// <summary>
        /// 工位编码
        /// </summary>
        public string F_WorkstationNumber { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string F_WorkstationName { get; set; }
        /// <summary>
        /// 工位负责人
        /// </summary>
        public string F_WorkstationPrincipal { get; set; }
        /// <summary>
        /// 所属工厂
        /// </summary>
        public string F_PlantId { get; set; }
        /// <summary>
        /// 所属车间
        /// </summary>
        public string F_WorkshopId { get; set; }
        /// <summary>
        /// 所属产线
        /// </summary>
        public string F_ProductionLineId { get; set; }
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