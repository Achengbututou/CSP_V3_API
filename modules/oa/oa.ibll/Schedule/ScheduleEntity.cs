using learun.database;
using System;

namespace oa.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：日程管理
    /// </summary>
    [MyTable("oa_schedule")]
    public class ScheduleEntity
    {
        #region 实体成员
        /// <summary>
        /// 日程主键
        /// </summary>
        /// <returns></returns>
        [Column(IsPrimary = true)]
        public string F_ScheduleId { get; set; }
        /// <summary>
        /// 日程名称
        /// </summary>
        /// <returns></returns>
        public string F_ScheduleName { get; set; }
        /// <summary>
        /// 日程内容
        /// </summary>
        /// <returns></returns>
        public string F_ScheduleContent { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        /// <returns></returns>
        public string F_Category { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        /// <returns></returns>
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <returns></returns>
        public string F_StartTime { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        /// <returns></returns>
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <returns></returns>
        public string F_EndTime { get; set; }
        /// <summary>
        /// 提前提醒
        /// </summary>
        /// <returns></returns>
        public int? F_Early { get; set; }
        /// <summary>
        /// 邮件提醒
        /// </summary>
        /// <returns></returns>
        public int? F_IsMailAlert { get; set; }
        /// <summary>
        /// 手机提醒
        /// </summary>
        /// <returns></returns>
        public int? F_IsMobileAlert { get; set; }
        /// <summary>
        /// 微信提醒
        /// </summary>
        /// <returns></returns>
        public int? F_IsWeChatAlert { get; set; }
        /// <summary>
        /// 日程状态
        /// </summary>
        /// <returns></returns>
        public int? F_ScheduleState { get; set; }
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
    }
}
