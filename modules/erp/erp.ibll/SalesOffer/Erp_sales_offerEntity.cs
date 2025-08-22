using learun.database;
using System;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:36:08
    /// 描 述：lr_erp_salesoffer(销售报价)表的实体
    /// </summary>
    [MyTable("erp_sales_offer")]
    public class Erp_sales_offerEntity
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column(IsPrimary = true)]
        public String F_Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? F_Amount { get; set; }
        /// <summary>
        /// F_Appler
        /// </summary>
        public String F_Appler { get; set; }
        /// <summary>
        /// 申请日期(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_ApplyDate { get; set; }
        /// <summary>
        /// F_BarCode
        /// </summary>
        public String F_BarCode { get; set; }
        /// <summary>
        /// F_Code
        /// </summary>
        public String F_Code { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Decimal? F_Count { get; set; }
        /// <summary>
        /// 创建时间(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// F_Department
        /// </summary>
        public String F_Department { get; set; }
        /// <summary>
        /// F_Description
        /// </summary>
        public String F_Description { get; set; }
        /// <summary>
        /// F_File
        /// </summary>
        public String F_File { get; set; }
        /// <summary>
        /// F_ModifyDate(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// F_ModifyUserName
        /// </summary>
        public String F_ModifyUserName { get; set; }
        /// <summary>
        /// F_Name
        /// </summary>
        public String F_Name { get; set; }
        /// <summary>
        /// F_Number
        /// </summary>
        public String F_Number { get; set; }
        /// <summary>
        /// F_Place
        /// </summary>
        public String F_Place { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public Decimal? F_Price { get; set; }
        /// <summary>
        /// F_PurchaseNo
        /// </summary>
        public String F_PurchaseNo { get; set; }
        /// <summary>
        /// F_PurchaseType
        /// </summary>
        public String F_PurchaseType { get; set; }
        /// <summary>
        /// F_Specification
        /// </summary>
        public String F_Specification { get; set; }
        /// <summary>
        /// F_Status
        /// </summary>
        public String F_Status { get; set; }
        /// <summary>
        /// F_Theme
        /// </summary>
        public String F_Theme { get; set; }
        /// <summary>
        /// F_Type
        /// </summary>
        public String F_Type { get; set; }
        /// <summary>
        /// F_Unit
        /// </summary>
        public String F_Unit { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 申请日期(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_ApplyDate_end { get; set; }
        /// <summary>
        /// 创建时间(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_CreateDate_end { get; set; }
        /// <summary>
        /// F_ModifyDate(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_ModifyDate_end { get; set; }

        #endregion


        #region 多租户
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        #endregion
    }
}