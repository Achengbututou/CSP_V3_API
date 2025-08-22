using ce.autofac.extension;
using learun.util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oa.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：邮件内容
    /// </summary>
    public interface IEmailBLL:IBLL
    {
        #region 提交数据
        /// <summary>
        /// 收件箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        Task<IEnumerable<EmailContentEntity>> GetAddresseeMail(Pagination pagination, string keyword);
        /// <summary>
        /// 草稿箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        Task<IEnumerable<EmailContentEntity>> GetDraftMail(Pagination pagination, string keyword);
        /// <summary>
        /// 已发送
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        Task<IEnumerable<EmailContentEntity>> GetSentMail(Pagination pagination, string keyword);
        /// <summary>
        /// 回收箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        Task<IEnumerable<EmailContentEntity>> GetRecycleMail(Pagination pagination, string keyword);

        /// <summary>
        /// 邮件实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Task<EmailContentEntity> GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存邮件表单（发送、存入草稿、草稿编辑）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="emailContentEntity">邮件实体</param>
        /// <param name="addresssIds">收件人</param>
        /// <param name="copysendIds">抄送人</param>
        /// <param name="bccsendIds">密送人</param>
        /// <returns></returns>
        Task SaveForm(string keyValue, EmailContentEntity emailContentEntity, List<string> addresssIds, List<string> copysendIds, List<string> bccsendIds);

        /// <summary>
        /// 彻底删除邮件
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="emailType">邮件类型：unreadMail  starredMail  draftMail  recycleMail  addresseeMail  sendMail</param>
        Task ThoroughRemoveForm(string keyValue, string emailType);

        /// <summary>
        /// 删除邮件
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="emailType">邮件类型：unreadMail  starredMail  draftMail  recycleMail  addresseeMail  sendMail</param>
        Task RemoveForm(string keyValue, string emailType);
        #endregion
    }
}
