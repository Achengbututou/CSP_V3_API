using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-07-26 16:52:42
    /// 描 述：mes_planmanagement(工厂信息维护管理)表的实体
    /// </summary>
    [MyTable("mes_planmanagement")]
    public class MesPlantManagementEntity
    {
        #region 实体成员
        /// <summary>
        /// 工厂主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 工厂编号
        /// </summary>
        public string F_PlantNumber { get; set; }
        /// <summary>
        /// 工厂名称
        /// </summary>
        public string F_PlantName { get; set; }
        /// <summary>
        /// 工厂负责人
        /// </summary>
        public string F_PlantPrincipal { get; set; }
        /// <summary>
        /// 工厂地址
        /// </summary>
        public string F_PlantAddress { get; set; }
        /// <summary>
        /// 所属层级
        /// </summary>
        public int? F_Level { get; set; }
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
        /// 租户ID
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