using learun.database;
using System;

namespace oa.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：邮件内容
    /// </summary>
    [MyTable("oa_email_content")]
    public class EmailContentEntity
    {
        #region 实体成员
        /// <summary>
        /// 邮件信息主键
        /// </summary>
        /// <returns></returns>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 邮件分类主键
        /// </summary>
        /// <returns></returns>
        public string F_CategoryId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        public string F_ParentId { get; set; }
        /// <summary>
        /// 邮件主题
        /// </summary>
        /// <returns></returns>
        public string F_Theme { get; set; }
        /// <summary>
        /// 邮件主题色彩
        /// </summary>
        /// <returns></returns>
        public string F_ThemeColor { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        /// <returns></returns>
        public string F_EmailContent { get; set; }
        /// <summary>
        /// 邮件附件
        /// </summary>
        public string F_Files { get; set; }
        /// <summary>
        /// 邮件类型（1-内部2-外部）
        /// </summary>
        /// <returns></returns>
        public int? F_EmailType { get; set; }
        /// <summary>
        /// 发件人Id
        /// </summary>
        /// <returns></returns>
        public string F_SenderId { get; set; }
        /// <summary>
        /// 发件人
        /// </summary>
        /// <returns></returns>
        public string F_SenderName { get; set; }
        /// <summary>
        /// 发件日期
        /// </summary>
        /// <returns></returns>
        public DateTime? F_SenderTime { get; set; }
        /// <summary>
        /// 设置红旗
        /// </summary>
        /// <returns></returns>
        public int? F_IsHighlight { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        /// <returns></returns>
        public string F_SendPriority { get; set; }
        /// <summary>
        /// 短信提醒
        /// </summary>
        /// <returns></returns>
        public int? F_IsSmsReminder { get; set; }
        /// <summary>
        /// 已读回执
        /// </summary>
        /// <returns></returns>
        public int? F_IsReceipt { get; set; }
        /// <summary>
        /// 发送状态（1-已发送0-草稿）
        /// </summary>
        /// <returns></returns>
        public int? F_SendState { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        /// <returns></returns>
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string F_Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public string F_ModifyUserName { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        /// <returns></returns>
        public string F_AddresssHtml { get; set; }
        /// <summary>
        /// 抄送人
        /// </summary>
        /// <returns></returns>
        public string F_CopysendHtml { get; set; }
        /// <summary>
        /// 密送人
        /// </summary>
        /// <returns></returns>
        public string F_BccsendHtml { get; set; }
        #endregion


        #region 多租户
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        #endregion
    }
}