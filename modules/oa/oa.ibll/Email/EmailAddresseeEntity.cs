using learun.database;
using System;

namespace oa.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：邮件收件人
    /// </summary>
    [MyTable("oa_email_addressee")]
    public class EmailAddresseeEntity
    {
        #region 实体成员
        /// <summary>
        /// 邮箱收件人主键
        /// </summary>
        /// <returns></returns>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 邮件信息主键
        /// </summary>
        /// <returns></returns>
        public string F_ContentId { get; set; }
        /// <summary>
        /// 邮件分类主键
        /// </summary>
        /// <returns></returns>
        public string F_CategoryId { get; set; }
        /// <summary>
        /// 收件人Id
        /// </summary>
        /// <returns></returns>
        public string F_RecipientId { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        /// <returns></returns>
        public string F_RecipientName { get; set; }
        /// <summary>
        /// 收件状态（0-收件1-抄送2-密送）
        /// </summary>
        /// <returns></returns>
        public int? F_RecipientState { get; set; }
        /// <summary>
        /// 是否阅读
        /// </summary>
        /// <returns></returns>
        public int? F_IsRead { get; set; }
        /// <summary>
        /// 阅读次数
        /// </summary>
        /// <returns></returns>
        public int? F_ReadCount { get; set; }
        /// <summary>
        /// 最后阅读日期
        /// </summary>
        /// <returns></returns>
        public DateTime? F_ReadDate { get; set; }
        /// <summary>
        /// 设置红旗
        /// </summary>
        /// <returns></returns>
        public int? F_IsHighlight { get; set; }
        /// <summary>
        /// 设置待办
        /// </summary>
        /// <returns></returns>
        public int? F_Backlog { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        public int? F_DeleteMark { get; set; }
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
        #endregion


        #region 多租户
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        #endregion
    }
}