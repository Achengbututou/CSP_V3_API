using learun.iapplication;
using learun.util;
using oa.ibll;
using System;
using System.Collections.Generic;
using System.Text;
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
    public class EmailService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 草稿箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetDraftMail(Pagination pagination, string keyword)
        {
            var expression = LinqExtensions.True<EmailContentEntity>();
            expression = expression.And(t => t.F_SendState == 0 && t.F_DeleteMark == 0 && t.F_CreateUserId == this.GetUserId());
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Theme.Contains(keyword));
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 回收箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetRecycleMail(Pagination pagination, string keyword)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    t.F_Id,
                                                c.F_Theme ,
                                                c.F_ThemeColor ,
                                                c.F_SenderId ,
                                                c.F_SenderName ,
                                                c.F_SenderTime ,
                                                t.F_CreateDate,
                                                t.F_ContentId as F_ParentId,
                                                1 as F_EnabledMark
                                      FROM      oa_email_addressee t
                                                LEFT JOIN oa_email_content c ON c.F_Id = t.F_ContentId
                                      WHERE     t.F_RecipientId = @userId
                                                AND t.F_DeleteMark = 1 {LEARUN_SASSID}
                                      UNION
                                      SELECT    t.F_Id ,
                                                t.F_Theme ,
                                                t.F_ThemeColor ,
                                                t.F_SenderId ,
                                                t.F_SenderName ,
                                                t.F_SenderTime ,
                                                t.F_CreateDate,
                                                t.F_ParentId,
                                                0 as F_EnabledMark
                                      FROM      oa_email_content t
                                      WHERE     t.F_CreateUserId = @userId
                                                AND t.F_DeleteMark = 1 {LEARUN_SASSID}
                                    ) t WHERE 1=1");
            string theme = "";
            if (!keyword.IsEmpty())
            {
                strSql.Append(" AND F_Theme like @theme");
                theme = '%' + keyword + '%';
            }
            return this.BaseRepository().FindList<EmailContentEntity>(strSql.ToString(), new { userId = this.GetUserId() , theme }, pagination);
        }
        /// <summary>
        /// 收件箱
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetAddresseeMail(Pagination pagination, string keyword)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  t.F_Id AS F_ContentId ,
                                    c.F_Theme ,
                                    c.F_ThemeColor ,
                                    c.F_SenderId ,
                                    c.F_SenderName ,
                                    c.F_SenderTime ,
                                    c.F_CreateDate,
                                    t.F_ContentId as F_ParentId
                            FROM    oa_email_addressee t
                                    LEFT JOIN oa_email_content c ON c.F_Id = t.F_ContentId
                            WHERE   t.F_RecipientId = @userId");
            strSql.Append(" AND t.F_DeleteMark = 0 {LEARUN_SASSID} ");
            string theme = "";
            if (!keyword.IsEmpty())
            {
                strSql.Append(" AND c.F_Theme like @theme");
                theme = '%' + keyword + '%';
            }
            return this.BaseRepository().FindList<EmailContentEntity>(strSql.ToString(), new { userId = this.GetUserId(), theme }, pagination);
        }
        /// <summary>
        /// 已发送
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public Task<IEnumerable<EmailContentEntity>> GetSentMail(Pagination pagination, string keyword)
        {
            var expression = LinqExtensions.True<EmailContentEntity>();
            expression = expression.And(t => t.F_SendState == 1 && t.F_DeleteMark == 0 && t.F_CreateUserId == this.GetUserId());
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Theme.Contains(keyword));
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 邮件实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<EmailContentEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<EmailContentEntity>(keyValue);
        }
        /// <summary>
        /// 收件邮件实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<EmailAddresseeEntity> GetAddresseeEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<EmailAddresseeEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除草稿
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task RemoveDraftForm(string keyValue)
        {
            await this.BaseRepository().Delete<EmailContentEntity>(keyValue);
        }
        /// <summary>
        /// 删除未读、星标、收件
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task RemoveAddresseeForm(string keyValue)
        {
            EmailAddresseeEntity emailAddresseeEntity = new EmailAddresseeEntity();
            emailAddresseeEntity.F_Id = keyValue;
            emailAddresseeEntity.F_DeleteMark = 1;
            await this.BaseRepository().Update(emailAddresseeEntity,true);
        }
        /// <summary>
        /// 彻底删除未读、星标、收件
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task ThoroughRemoveAddresseeForm(string keyValue)
        {
            await this.BaseRepository().Delete<EmailAddresseeEntity>(keyValue);
        }
        /// <summary>
        /// 删除已发
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task RemoveSentForm(string keyValue)
        {
            EmailContentEntity emailContentEntity = new EmailContentEntity();
            emailContentEntity.F_Id = keyValue;
            emailContentEntity.F_DeleteMark = 1;
            await this.BaseRepository().Update(emailContentEntity, true);
        }
        /// <summary>
        /// 彻底删除已发
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task ThoroughRemoveSentForm(string keyValue)
        {
            EmailContentEntity emailContentEntity = new EmailContentEntity();
            emailContentEntity.F_Id = keyValue;
            emailContentEntity.F_DeleteMark = 2;
            await this.BaseRepository().Update(emailContentEntity,true);
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
            if (emailContentEntity.F_SendState == 0)
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    emailContentEntity.F_Id = keyValue;
                    emailContentEntity.F_ModifyDate = DateTime.Now;
                    emailContentEntity.F_ModifyUserId = this.GetUserId();
                    emailContentEntity.F_ModifyUserName = this.GetUserName();

                    await this.BaseRepository().Update(emailContentEntity);
                }
                else
                {
                    emailContentEntity.F_Id = Guid.NewGuid().ToString();
                    emailContentEntity.F_CreateDate = DateTime.Now;
                    emailContentEntity.F_CreateUserId = this.GetUserId();
                    emailContentEntity.F_CreateUserName = this.GetUserName();
                    emailContentEntity.F_SenderTime = DateTime.Now;
                    emailContentEntity.F_SenderId = this.GetUserId();
                    emailContentEntity.F_SenderName = this.GetUserName() + "（" + this.GetUserAccount() + "）";
                    emailContentEntity.F_DeleteMark = 0;
                    emailContentEntity.F_EnabledMark = 1;

                    await this.BaseRepository().Insert(emailContentEntity);
                }
            }
            else
            {
                var db = this.BaseRepository().BeginTrans();
                try
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        emailContentEntity.F_Id = keyValue;
                        emailContentEntity.F_ModifyDate = DateTime.Now;
                        emailContentEntity.F_ModifyUserId = this.GetUserId();
                        emailContentEntity.F_ModifyUserName = this.GetUserName();

                        await db.Update(emailContentEntity);
                    }
                    else
                    {
                        emailContentEntity.F_Id = Guid.NewGuid().ToString();
                        emailContentEntity.F_CreateDate = DateTime.Now;
                        emailContentEntity.F_CreateUserId = this.GetUserId();
                        emailContentEntity.F_CreateUserName = this.GetUserName();
                        emailContentEntity.F_SenderTime = DateTime.Now;
                        emailContentEntity.F_SenderId = this.GetUserId();
                        emailContentEntity.F_SenderName = this.GetUserName() + "（" + this.GetUserAccount() + "）";
                        emailContentEntity.F_DeleteMark = 0;
                        emailContentEntity.F_EnabledMark = 1;

                        await db.Insert(emailContentEntity);
                    }

                    #region 收件人
                    foreach (var item in addresssIds)
                    {
                        EmailAddresseeEntity emailAddresseeEntity = new EmailAddresseeEntity();
                        emailAddresseeEntity.F_Id = Guid.NewGuid().ToString();
                        emailAddresseeEntity.F_CreateDate = DateTime.Now;
                        emailAddresseeEntity.F_CreateUserId = this.GetUserId();
                        emailAddresseeEntity.F_CreateUserName = this.GetUserName();
                        emailAddresseeEntity.F_DeleteMark = 0;
                        emailAddresseeEntity.F_ReadCount = 0;
                        emailAddresseeEntity.F_IsRead = 0;

                        emailAddresseeEntity.F_ContentId = emailContentEntity.F_Id;
                        emailAddresseeEntity.F_RecipientId = item;
                        emailAddresseeEntity.F_RecipientState = 0;
                        await db.Insert(emailAddresseeEntity);
                    }
                    #endregion

                    #region 抄送人
                    foreach (var item in copysendIds)
                    {
                        EmailAddresseeEntity emailAddresseeEntity = new EmailAddresseeEntity();
                        emailAddresseeEntity.F_Id = Guid.NewGuid().ToString();
                        emailAddresseeEntity.F_CreateDate = DateTime.Now;
                        emailAddresseeEntity.F_CreateUserId = this.GetUserId();
                        emailAddresseeEntity.F_CreateUserName = this.GetUserName();
                        emailAddresseeEntity.F_DeleteMark = 0;
                        emailAddresseeEntity.F_ReadCount = 0;
                        emailAddresseeEntity.F_IsRead = 0;

                        emailAddresseeEntity.F_ContentId = emailContentEntity.F_Id;
                        emailAddresseeEntity.F_RecipientId = item;
                        emailAddresseeEntity.F_RecipientState = 1;
                        await db.Insert(emailAddresseeEntity);
                    }
                    #endregion

                    #region  密送人
                    foreach (var item in bccsendIds)
                    {
                        EmailAddresseeEntity emailAddresseeEntity = new EmailAddresseeEntity();
                        emailAddresseeEntity.F_Id = Guid.NewGuid().ToString();
                        emailAddresseeEntity.F_CreateDate = DateTime.Now;
                        emailAddresseeEntity.F_CreateUserId = this.GetUserId();
                        emailAddresseeEntity.F_CreateUserName = this.GetUserName();
                        emailAddresseeEntity.F_DeleteMark = 0;
                        emailAddresseeEntity.F_ReadCount = 0;
                        emailAddresseeEntity.F_IsRead = 0;

                        emailAddresseeEntity.F_ContentId = emailContentEntity.F_Id;
                        emailAddresseeEntity.F_RecipientId = item;
                        emailAddresseeEntity.F_RecipientState = 2;
                        await db.Insert(emailAddresseeEntity);
                    }
                    #endregion

                    db.Commit();
                }
                catch (Exception)
                {
                    db.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 设置邮件已读/未读
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="IsRead">是否已读：0-未读1-已读</param>
        public async Task ReadEmail(string keyValue, int IsRead = 1)
        {
            EmailAddresseeEntity emailAddresseeEntity = new EmailAddresseeEntity();
            emailAddresseeEntity.F_Id = keyValue;
            emailAddresseeEntity.F_IsRead = IsRead;
            emailAddresseeEntity.F_ReadCount = emailAddresseeEntity.F_ReadCount + 1;
            emailAddresseeEntity.F_ReadDate = DateTime.Now;
            await this.BaseRepository().Update(emailAddresseeEntity);
        }
        /// <summary>
        /// 设置邮件星标/取消星标
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="sterisk">星标：0-取消星标1-星标</param>
        public async Task SteriskEmail(string keyValue, int sterisk = 1)
        {
            EmailAddresseeEntity emailAddresseeEntity = new EmailAddresseeEntity();
            emailAddresseeEntity.F_Id = keyValue;
            emailAddresseeEntity.F_IsHighlight = sterisk;
            await this.BaseRepository().Update(emailAddresseeEntity);
        }
        #endregion
    }
}
