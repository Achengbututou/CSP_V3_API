using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-07 13:29:09
    /// 描 述：mes_ProceNodeRoute表的实体
    /// </summary>
    [MyTable("mes_ProceNodeRoute")]
    public class MesProceNodeRouteEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string Id { get; set; }
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        public string F_ProcessRouteId { get; set; }
        /// <summary>
        /// 工序主键
        /// </summary>
        public string fid { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public string Properties { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 横坐标
        /// </summary>
        public int? X { get; set; }
        /// <summary>
        /// 纵坐标
        /// </summary>
        public int? Y { get; set; }
        /// <summary>
        /// 前置数量
        /// </summary>
        public int? prepositionnum { get; set; }
        /// <summary>
        /// 静置数量
        /// </summary>
        public int? stewingnum { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string needprocess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string colorInfo { get; set; }
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