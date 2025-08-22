using System.Collections.Generic;

namespace demo.ibll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2022-06-13 10:53:49
    /// 描 述：配车单表单提交参数
    /// </summary>
    public class MatecardetailDto
    {
        /// <summary>
        /// ew_matecardetail(【苏州益维鑫】配车单子表)表的实体
        /// </summary>
        public EwMatecardetailEntity EwMatecardetailEntity { get; set; }
        /// <summary>
        /// ew_curm(【苏州益维鑫】现存量表)表的实体
        /// </summary>
        public IEnumerable<EwCurmEntity> EwCurmList { get; set; }

    }
}