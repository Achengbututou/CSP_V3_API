using learun.database;
using System;

namespace EMEMO.ibll
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：attendance_error_dtl表的实体
    /// </summary>
    [MyTable("EMEMO_dtl_sub")]
    public class EMEMO_dtl_subEntity
    {
        #region 实体成员
        [Column(IsPrimary = true)]
        /// RID
        /// </summary>
        public string rid { get; set; }
        /// RID
        /// </summary>
        public string ememo_hdr_rid { get; set; }
        /// <summary>
        /// 
        /// customer_name
        /// </summary>
        public string customer_name { get; set; }
        /// <summary>
        /// material_type
        /// </summary>
        public string material_type { get; set; }
        /// <summary>
        /// vendor_batch
        /// </summary>
        public string vendor_batch { get; set; }
        /// <summary>
        /// Stock_Category
        /// </summary>
        public string stock_category { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// system_qty
        /// </summary>
        public string system_qty { get; set; }
        /// <summary>
        /// UOM
        /// </summary>
        public string uom { get; set; }
        /// <summary>
        /// MEMO_QTY
        /// </summary>
        public string memo_qty { get; set; }
        /// <summary>
        /// MEMO_UOM
        /// </summary>
        public string memo_uom { get; set; }
        /// <summary>
        /// Sales_Currenct
        /// </summary>
        public string sales_currenct { get; set; }
        /// <summary>
        /// Unit_Price
        /// </summary>
        public string unit_price { get; set; }
        /// <summary>
        /// Sales_Amount
        /// </summary>
        public string sales_amount { get; set; }
        /// <summary>
        /// Local_NBV
        /// </summary>
        public string local_nbv { get; set; }
        /// <summary>
        /// Local_Other_Expense
        /// </summary>
        public string local_other_expense { get; set; }
        /// <summary>
        /// Local_Impact
        /// </summary>
        public string local_impact { get; set; }
        /// <summary>
        /// USD_Sales_Amount
        /// </summary>
        public string usd_sales_amount { get; set; }
        /// <summary>
        /// USD_NBV
        /// </summary>
        public string usd_nbv { get; set; }
        /// <summary>
        /// USD_Other_Expense
        /// </summary>
        public string usd_other_expense { get; set; }
        /// <summary>
        /// USD_Impact
        /// </summary>
        public string usd_impact { get; set; }

        #endregion

        #region 扩展属性

        #endregion
    }
}