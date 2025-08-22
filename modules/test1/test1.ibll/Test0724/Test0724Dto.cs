using System.Collections.Generic;

namespace Test1.ibll
{
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：
    /// 日 期：2024-07-24 16:39:53
    /// 描 述：测试代码生成表单提交参数
    /// </summary>
    public class Test0724Dto
    {
        /// <summary>
        /// f_parent表的实体
        /// </summary>
        public F_parentEntity F_parentEntity { get; set; }
        /// <summary>
        /// f_children表的实体
        /// </summary>
        public IEnumerable<F_childrenEntity> F_childrenList { get; set; }

    }
}