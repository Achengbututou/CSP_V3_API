using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期：2022-12-05 08:54:39
    /// 描 述：case_erp_productlog(生产记录【case_erp_productlog】)表的实体
    /// </summary>
    [MyTable("case_erp_productlog")]
    public class CaseErpProductlogEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 销售订单关联外键(case_erp_sale)
        /// </summary>
        public string F_SaleId { get; set; }
        /// <summary>
        /// 生产编号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 生产主题
        /// </summary>
        public string F_Theme { get; set; }
        /// <summary>
        /// 生产类型
        /// </summary>
        public string F_Type { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime? F_Date { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string F_Person { get; set; }
        /// <summary>
        /// 生产部门
        /// </summary>
        public string F_Dep { get; set; }
        /// <summary>
        /// 状态(0已完成，1未完成)
        /// </summary>
        public int? F_State { get; set; }
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
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 单据日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_DateQRange { get; set; }
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

        #endregion
    }
}