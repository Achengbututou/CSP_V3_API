using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-07 09:53:29
    /// 描 述：工序管理表单提交参数
    /// </summary>
    public class ProcessManagementDto
    {
        /// <summary>
        /// mes_processmanage(工序管理)表的实体
        /// </summary>
        public MesProcessManagementEntity MesProcessManagementEntity { get; set; }
        /// <summary>
        /// mes_processworkstat(工序工位管理)表的实体
        /// </summary>
        public IEnumerable<MesProcessWorkstationEntity> MesProcessWorkstationList { get; set; }
        /// <summary>
        /// mes_processmater(工序物料管理)表的实体
        /// </summary>
        public IEnumerable<MesProcessMaterialEntity> MesProcessMaterialList { get; set; }
        /// <summary>
        /// mes_processtechnol(工序技术参数管理)表的实体
        /// </summary>
        public IEnumerable<MesProcessTechnologyEntity> MesProcessTechnologyList { get; set; }

    }
}