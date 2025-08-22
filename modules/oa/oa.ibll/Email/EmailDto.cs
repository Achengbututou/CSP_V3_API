using System.Collections.Generic;

namespace oa.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：邮件内容
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        /// 邮件内容
        /// </summary>
        public EmailContentEntity Content { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public List<string> AddresssIds { get; set; }

        /// <summary>
        /// 抄送人
        /// </summary>
        public List<string> CopysendIds { get; set; }
        /// <summary>
        /// 秘密抄手人
        /// </summary>
        public List<string> BccsendIds { get; set; }
    }
}
