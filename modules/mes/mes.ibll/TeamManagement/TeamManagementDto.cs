using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-08 14:33:08
    /// 描 述：班组管理表单提交参数
    /// </summary>
    public class TeamManagementDto
    {
        /// <summary>
        /// mes_teammanage(班组管理)表的实体
        /// </summary>
        public MesTeamManagementEntity MesTeamManagementEntity { get; set; }
        /// <summary>
        /// mes_TeamMembers(班组人员)表的实体
        /// </summary>
        public IEnumerable<MesTeamMembersEntity> MesTeamMembersList { get; set; }

    }
}