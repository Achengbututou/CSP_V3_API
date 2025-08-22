using learun.database;
using System;
using System.Collections.Generic;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-11-30 15:20:23
    /// 描 述：case_erp_purchase(采购订单信息【case_erp_purchase】)表的实体
    /// </summary>
    [MyTable("case_erp_purch")]
    public class CaseErpPurchaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 采购单号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 关联申请单外键(case_erp_apply)
        /// </summary>
        public string F_ApplyId { get; set; }
        /// <summary>
        /// 关联申请单号
        /// </summary>
        public string F_ApplyNumber { get; set; }
        /// <summary>
        /// 订单主题
        /// </summary>
        public string F_Theme { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? F_PurchaseDate { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string F_SupplierName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string F_SupplierPerson { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string F_SupplierWay { get; set; }
        /// <summary>
        /// 采购部门
        /// </summary>
        public string F_PurchaseDep { get; set; }
        /// <summary>
        /// 采购人员
        /// </summary>
        public string F_PurchasePerson { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string F_PurchasePhone { get; set; }
        /// <summary>
        /// 关联项目
        /// </summary>
        public string F_RelatedProject { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string F_PayType { get; set; }
        /// <summary>
        /// 支付地址
        /// </summary>
        public string F_PayAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Description { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_File { get; set; }
        /// <summary>
        /// 订单总量
        /// </summary>
        public decimal? F_CountSum { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal? F_AmountSum { get; set; }
        /// <summary>
        /// 订单优惠金额
        /// </summary>
        public decimal? F_Discount { get; set; }
        /// <summary>
        /// 已付金额
        /// </summary>
        public decimal? F_AlreadyAmount { get; set; }
        /// <summary>
        /// 已到票金额
        /// </summary>
        public decimal? F_AlreadyTicket { get; set; }
        /// <summary>
        /// 订单状态-审批状态 1 未提交 2 审批中 3 已驳回 4 通过
        /// </summary>
        public int? F_AuditState { get; set; }
        /// <summary>
        /// 订单状态-保存状态(0正式,1草稿)
        /// </summary>
        public int? F_SaveState { get; set; }
        /// <summary>
        /// 入库状态(0已完成，1未完成)
        /// </summary>
        public int? F_InStoreState { get; set; }
        /// <summary>
        /// 到票状态(0已完成，1未完成)
        /// </summary>
        public int? F_TicketState { get; set; }
        /// <summary>
        /// 付款状态(0已完成，1未完成)
        /// </summary>
        public int? F_PayState { get; set; }
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
        /// 创建用户id
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
        /// 是否系统编号(0是，1否)----ADD BY SSY 20221205
        /// </summary>
        public int? F_IsSysNum { get; set; }
        /// <summary>
        /// 是否关联(0是，1否)----ADD BY SSY 20221205
        /// </summary>
        public int? F_IsRelated { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        /// <summary>
        /// 采购物品----ADD BY SSY 20221221
        /// </summary>
        public string F_PurchaseSynopsis { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 采购日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_PurchaseDateQRange { get; set; }
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
        /// 关键字段
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }
        #endregion
    }
}