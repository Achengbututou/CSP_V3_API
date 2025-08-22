using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-10 10:15:58
    /// 描 述：mes_ScheduleDetails(排期详情)表的实体
    /// </summary>
    [MyTable("mes_ScheduleDetails")]
    public class MesScheduleDetailsEntity
    {
        #region 实体成员
        /// <summary>
        /// 排期详情主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 排期信息主键
        /// </summary>
        public string F_SchedulingId { get; set; }
        /// <summary>
        /// 详情编码
        /// </summary>
        public string F_DetailNumber { get; set; }
        /// <summary>
        /// 上线日期
        /// </summary>
        public DateTime? F_LaunchDate { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string F_ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 排期数量
        /// </summary>
        public int? F_NumberSchedules { get; set; }
        /// <summary>
        /// 制表日期
        /// </summary>
        public DateTime? F_TabulationDate { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? F_OrderDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Remarks { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string F_CreatUserName { get; set; }
        /// <summary>
        /// 创建人主键
        /// </summary>
        public string F_CreatUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_CreatUserTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string F_ModifyName { get; set; }
        /// <summary>
        /// 修改人主键
        /// </summary>
        public string F_ModifyId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? F_ModifyTime { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public string F_TenantId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 上线日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_LaunchDateQRange { get; set; }
        /// <summary>
        /// 制表日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_TabulationDateQRange { get; set; }
        /// <summary>
        /// 制单日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_OrderDateQRange { get; set; }
        /// <summary>
        /// 创建时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreatUserTimeQRange { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyTimeQRange { get; set; }
        /// <summary>
        /// 查询关键字
        /// </summary>
        [Column(IsIgnore = true)]
        public string KeyWord { get; set; }
        #endregion
    }
}