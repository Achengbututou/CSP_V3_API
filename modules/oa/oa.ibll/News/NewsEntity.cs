using learun.database;
using System;

namespace oa.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：新闻公告
    /// </summary>
    [MyTable("oa_news")]
    public class NewsEntity
    {
        #region 实体成员
        /// <summary>
        /// 新闻主键
        /// </summary>
        /// <returns></returns>
        [Column(IsPrimary = true)]
        public string F_NewsId { get; set; }
        /// <summary>
        /// 类型（1-新闻2-公告）
        /// </summary>
        /// <returns></returns>
        public int? F_TypeId { get; set; }
        /// <summary>
        /// 所属类别主键
        /// </summary>
        /// <returns></returns>
        public string F_CategoryId { get; set; }
        /// <summary>
        /// 所属类别
        /// </summary>
        /// <returns></returns>
        public string F_Category { get; set; }
        /// <summary>
        /// 完整标题
        /// </summary>
        /// <returns></returns>
        public string F_FullHead { get; set; }
        /// <summary>
        /// 标题颜色
        /// </summary>
        /// <returns></returns>
        public string F_FullHeadColor { get; set; }
        /// <summary>
        /// 简略标题
        /// </summary>
        /// <returns></returns>
        public string F_BriefHead { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        /// <returns></returns>
        public string F_AuthorName { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public string F_CompileName { get; set; }
        /// <summary>
        /// Tag词
        /// </summary>
        /// <returns></returns>
        public string F_TagWord { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        /// <returns></returns>
        public string F_Keyword { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        /// <returns></returns>
        public string F_SourceName { get; set; }
        /// <summary>
        /// 来源地址
        /// </summary>
        /// <returns></returns>
        public string F_SourceAddress { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        /// <returns></returns>
        public string F_NewsContent { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        /// <returns></returns>
        public int? F_PV { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        /// <returns></returns>
        public DateTime? F_ReleaseTime { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        public int? F_SortCode { get; set; }
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
        #endregion


        #region 多租户
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        #endregion

        #region 密级
        /// <summary>
        ///  密级(0公开，1内部，2秘密，3机密，4绝密)
        /// </summary>
        public int? F_SecretLevel { get; set; }
        #endregion
    }
}
