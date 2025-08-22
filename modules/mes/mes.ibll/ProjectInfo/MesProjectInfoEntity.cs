using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-01 16:31:16
    /// 描 述：mes_ProjectInfo(项目信息)表的实体
    /// </summary>
    [MyTable("mes_ProjectInfo")]
    public class MesProjectInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 项目主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string F_ProjectCode { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string F_ProjectName { get; set; }
        /// <summary>
        /// 项目分类
        /// </summary>
        public string F_ProjectType { get; set; }
        /// <summary>
        /// 项目来源
        /// </summary>
        public string F_ProjectSource { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public string F_ProjectState { get; set; }
        /// <summary>
        /// 项目阶段
        /// </summary>
        public string F_ProjectPhase { get; set; }
        /// <summary>
        /// 预计费用
        /// </summary>
        public decimal? F_EstimatedCost { get; set; }
        /// <summary>
        /// 项目总额
        /// </summary>
        public decimal? F_TotalProject { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string F_Principal { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
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
        /// 负责人名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_PrincipalName { get; set; }
        #endregion
    }
}