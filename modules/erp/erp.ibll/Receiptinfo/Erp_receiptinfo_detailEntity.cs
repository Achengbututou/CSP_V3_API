using learun.database;
using System;

namespace erp.ibll
{
    /// <summary>
    /// Quartz
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:39:23
    /// 描 述：lr_erp_receiptinfodetail(收款单详细)表的实体
    /// </summary>
    [MyTable("erp_receiptinfo_detail")]
    public class Erp_receiptinfo_detailEntity
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
        /// 删除标记0否1是
        /// </summary>
        public Int32? F_DeleteMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public Int32? F_Description { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        public Int32? F_EnabledMark { get; set; }
        /// <summary>
        /// 编辑日期(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_ModifyDate { get; set; }
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
        /// F_RId
        /// </summary>
        public String F_RId { get; set; }
        /// <summary>
        /// F_Specification
        /// </summary>
        public String F_Specification { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Int32? F_Status { get; set; }
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
        /// 创建时间(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_CreateDate_end { get; set; }
        /// <summary>
        /// 编辑日期(做为条件字段为结束时间)
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