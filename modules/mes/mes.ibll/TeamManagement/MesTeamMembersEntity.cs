using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-08 14:33:08
    /// 描 述：mes_TeamMembers(班组人员)表的实体
    /// </summary>
    [MyTable("mes_TeamMembers")]
    public class MesTeamMembersEntity
    {
        #region 实体成员
        /// <summary>
        /// 班组人员主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 班组主键
        /// </summary>
        public string F_TeamManagementId { get; set; }
        /// <summary>
        /// 人员账号
        /// </summary>
        public string F_AccountNumber { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string F_UserName { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string F_Tel { get; set; }
        /// <summary>
        /// 是否班组长
        /// </summary>
        public int? F_IsTeamLeader { get; set; }
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