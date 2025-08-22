using System.Collections.Generic;

namespace demo.ibll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2022-06-13 10:55:59
    /// 描 述：配车单表单提交参数
    /// </summary>
    public class MatecarbasicDto
    {
        /// <summary>
        /// ew_matecarbasic(【苏州益维鑫】配车单主表)表的实体
        /// </summary>
        public EwMatecarbasicEntity EwMatecarbasicEntity { get; set; }
        /// <summary>
        /// ew_matecardetail(【苏州益维鑫】配车单子表)表的实体
        /// </summary>
        public IEnumerable<EwMatecardetailEntity> EwMatecardetailList { get; set; }

    }
}