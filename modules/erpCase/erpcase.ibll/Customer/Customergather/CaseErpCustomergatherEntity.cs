using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:43:25
    /// 描 述：case_erp_customergather(客户回款【case_erp_customergather】)表的实体
    /// </summary>
    [MyTable("case_erp_clientgather")]
    public class CaseErpCustomergatherEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 客户信息外键(case_erp_customer)
        /// </summary>
        public string F_CustomerId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 计划回款金额
        /// </summary>
        public decimal? F_WaitAmount { get; set; }
        /// <summary>
        /// 已回款金额----ADD BY SSY 20221207
        /// </summary>
        public decimal? F_AlreadyAmount { get; set; }
        /// <summary>
        /// 未回款金额----ADD BY SSY 20221207
        /// </summary>
        public decimal? F_UnpaidAmount { get; set; }
        /// <summary>
        /// 计划回款日期
        /// </summary>
        public DateTime? F_ReceivedDate { get; set; }
        /// <summary>
        /// 最迟回款日期
        /// </summary>
        public DateTime? F_FinallyDate { get; set; }
        /// <summary>
        /// 合同负责人
        /// </summary>
        public string F_Principal { get; set; }
        /// <summary>
        /// 合同标题
        /// </summary>
        public string F_Title { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_File { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Description { get; set; }
        /// <summary>
        /// 删除标记(0正常，1删除)
        /// </summary>
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 有效标志(0正常，1禁用)
        /// </summary>
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户id(归属)
        /// </summary>
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户id
        /// </summary>
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户名称
        /// </summary>
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        /// <summary>
        /// 订单信息外键(case_erp_sale)----ADD BY SSY 20230111
        /// </summary>
        public string F_SaleId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 计划回款日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ReceivedDateQRange { get; set; }
        /// <summary>
        /// 最迟回款日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_FinallyDateQRange { get; set; }
        /// <summary>
        /// 创建日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreateDateQRange { get; set; }
        /// <summary>
        /// 修改日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyDateQRange { get; set; }
        /// <summary>
        /// 逾期天数
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_OverdueDays { get; set; }
        /// <summary>
        /// 回款状态
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_GatherState { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }

        #endregion
    }
}