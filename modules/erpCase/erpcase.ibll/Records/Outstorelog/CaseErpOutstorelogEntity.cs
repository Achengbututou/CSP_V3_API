using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期：2022-12-05 09:07:38
    /// 描 述：case_erp_outstorelog(出库记录【case_erp_outstorelog】)表的实体
    /// </summary>
    [MyTable("case_erp_outstorelog")]
    public class CaseErpOutstorelogEntity
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
        /// 出库单号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 出库订单主题
        /// </summary>
        public string F_Theme { get; set; }
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? F_Date { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 出库总量
        /// </summary>
        public decimal? F_Count { get; set; }
        /// <summary>
        /// 出库人员
        /// </summary>
        public string F_Person { get; set; }
        /// <summary>
        /// 出库仓库外键(case_erp_warehouselog)
        /// </summary>
        public string F_Store { get; set; }
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
        /// <summary>
        /// 物料信息关联外键(case_erp_material)----ADD BY SSY 20221212
        /// </summary>
        public string F_MaterialId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 出库日期(时间查询范围)
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
        /// <summary>
        /// 出库总量
        /// </summary>
        [Column(IsIgnore = true)]
        public decimal? SumOutStore { get; set; }

        #endregion
    }
}