using ce.autofac.extension;
using learun.iapplication;
using learun.util;
using oa.ibll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oa.bll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：邮件内容
    /// </summary>
    public class EmailBLL:BLLBase, IEmailBLL, BLL
    {
        private readonly EmailService service = new EmailService();

        #region 获取数据
        /// <summary>
        /// 草稿箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetDraftMail(Pagination pagination, string keyword)
        {
            return service.GetDraftMail(pagination, keyword);
        }
        /// <summary>
        /// 回收箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetRecycleMail(Pagination pagination, string keyword)
        {
            return service.GetRecycleMail(pagination, keyword);
        }
        /// <summary>
        /// 收件箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetAddresseeMail(Pagination pagination, string keyword)
        {
            return service.GetAddresseeMail(pagination, keyword);
        }
        /// <summary>
        /// 已发送
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetSentMail(Pagination pagination, string keyword)
        {
            return service.GetSentMail(pagination, keyword);
        }
        /// <summary>
        /// 邮件实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<EmailContentEntity> GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        /// <summary>
        /// 收件人邮件明细
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<EmailAddresseeEntity> GetAddresseeEntity(string keyValue)
        {
            return service.GetAddresseeEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除邮件
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="emailType">邮件类型：unreadMail  starredMail  draftMail  recycleMail  addresseeMail  sendMail</param>
        public async Task RemoveForm(string keyValue, string emailType)
        {
            switch (emailType)
            {
                case "unreadMail":          //未读
                    break;
                case "starredMail":         //星标
                    break;
                case "draftMail":           //草稿
                    await service.RemoveDraftForm(keyValue);
                    break;
                case "recycleMail":         //回收
                    break;
                case "addresseeMail":       //收件
                    await service.RemoveAddresseeForm(keyValue);
                    break;
                case "sendMail":            //已发
                    await service.RemoveSentForm(keyValue);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 彻底删除邮件
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="emailType">邮件类型：unreadMail  starredMail  draftMail  recycleMail  addresseeMail  sendMail</param>
        public async Task ThoroughRemoveForm(string keyValue, string emailType)
        {
            switch (emailType)
            {
                case "unreadMail":
                    break;
                case "starredMail":
                    break;
                case "draftMail":
                    await service.RemoveDraftForm(keyValue);
                    break;
                case "recycleMail":
                    EmailContentEntity emailcontententity = await this.GetEntity(keyValue);
                    if (emailcontententity == null)
                    {
                        await service.ThoroughRemoveAddresseeForm(keyValue);
                    }
                    else
                    {
                        await service.ThoroughRemoveSentForm(keyValue);
                    }
                    break;
                case "addresseeMail":
                    await service.ThoroughRemoveAddresseeForm(keyValue);
                    break;
                case "sendMail":
                    await service.ThoroughRemoveSentForm(keyValue);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 保存邮件表单（发送、存入草稿、草稿编辑）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="emailContentEntity">邮件实体</param>
        /// <param name="addresssIds">收件人</param>
        /// <param name="copysendIds">抄送人</param>
        /// <param name="bccsendIds">密送人</param>
        /// <returns></returns>
        public async Task SaveForm(string keyValue, EmailContentEntity emailContentEntity, List<string> addresssIds, List<string> copysendIds, List<string> bccsendIds)
        {
            await service.SaveForm(keyValue, emailContentEntity, addresssIds, copysendIds, bccsendIds);
        }
        /// <summary>
        /// 设置邮件已读/未读
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="IsRead">是否已读：0-未读1-已读</param>
        public async Task ReadEmail(string keyValue, int IsRead = 1)
        {
            await service.ReadEmail(keyValue, IsRead);
        }
        /// <summary>
        /// 设置邮件星标/取消星标
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="sterisk">星标：0-取消星标1-星标</param>
        public async Task SteriskEmail(string keyValue, int sterisk = 1)
        {
            await service.SteriskEmail(keyValue, sterisk);
        }
        #endregion
    }
}
