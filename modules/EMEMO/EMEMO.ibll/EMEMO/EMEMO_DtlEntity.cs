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
    [MyTable("EMEMO_dtl")]
    public class EMEMO_dtlEntity
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
        /// customer_code
        /// </summary>
        public string Customer_Code { get; set; }
        /// <summary>
        /// 
        /// customer_name
        /// </summary>
        public string customer_name { get; set; }
        /// <summary>
        /// so_no
        /// </summary>
        public string so_no { get; set; }
        /// <summary>
        /// customer_dept
        /// </summary>
        public string customer_dept { get; set; }
        /// <summary>
        /// storage_location
        /// </summary>
        public string storage_location { get; set; }
        /// <summary>
        /// material_code
        /// </summary>
        public string material_code { get; set; }
        /// <summary>
        /// material_desc
        /// </summary>
        public string material_desc { get; set; }
        /// <summary>
        /// grid
        /// </summary>
        public string grid { get; set; }
        /// <summary>
        /// grid_Name
        /// </summary>
        public string grid_Name { get; set; }
        /// <summary>
        /// customer_style_no
        /// </summary>
        public string customer_style_no { get; set; }
        /// <summary>
        /// system_batch
        /// </summary>
        public string system_batch { get; set; }
        /// <summary>
        /// vendor_batch
        /// </summary>
        public string vendor_batch { get; set; }
        /// <summary>
        /// valuation_type
        /// </summary>
        public string valuation_type { get; set; }
        /// <summary>
        /// uom
        /// </summary>
        public string uom { get; set; }
        /// <summary>
        /// so_plant
        /// </summary>
        public string so_plant { get; set; }
        /// <summary>
        /// company_code
        /// </summary>
        public string company_code { get; set; }
        /// <summary>
        /// plant
        /// </summary>
        public string plant { get; set; }
        /// <summary>
        /// factory
        /// </summary>
        public string factory { get; set; }
        /// <summary>
        /// material_type
        /// </summary>
        public string material_type { get; set; }
        /// <summary>
        /// currency
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// customer_season
        /// </summary>
        public string customer_season { get; set; }
        /// <summary>
        /// total_on_hand_qty
        /// </summary>
        public long? total_on_hand_qty { get; set; }
        /// <summary>
        /// total_on_hand_amt
        /// </summary>
        public long? total_on_hand_amt { get; set; }
        /// <summary>
        /// total_on_hand_amt_trading
        /// </summary>
        public long? total_on_hand_amt_trading { get; set; }

        #endregion

        #region 扩展属性

        #endregion
    }
}