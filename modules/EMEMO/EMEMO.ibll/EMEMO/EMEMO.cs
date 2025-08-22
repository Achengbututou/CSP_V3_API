using System;
using System.Collections.Generic;

namespace EMEMO.ibll
{
    /// <summary>
    /// EMEMO-EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期：2023-11-02 16:14:06
    /// 描 述：EMEMO表单提交参数
    /// </summary>
    public class EMEMODto
    {
        /// <summary>
        /// attendance_error_hdr表的实体
        /// </summary>

        public BaseDataFromFVBEntity BaseDataFromFVBEntity { get; set; }
        public EMEMO_hdrEntity EMEMO_hdrEntity { get; set; }
        public IEnumerable<EMEMO_dtlEntity> EMEMO_dtlList { get; set; }

        public IEnumerable<EMEMO_dtl_subEntity> EMEMO_dtl_subList { get; set; }

    }

    public class BaseDataFromFVBDto
    {
        /// RID
        /// </summary>
        public string rid { get; set; }
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

    }

    public class EMEMO_hdrDto
    {
        /// <summary>
        /// RID
        /// </summary>
        public string rid { get; set; }
        /// <summary>
        /// Note_No
        /// </summary>
        public string note_no { get; set; }
        /// <summary>
        /// Note_No
        /// </summary>
        public string memo_no { get; set; }
        /// <summary>
        /// factory
        /// </summary>
        public string factory { get; set; }
        /// <summary>
        /// company_code
        /// </summary>
        public string company_code { get; set; }
        /// <summary>
        /// Cggroup
        /// </summary>
        public string cggroup { get; set; }
        /// <summary>
        /// Mattype
        /// </summary>
        public string mattype { get; set; }
        /// <summary>
        /// so_plant
        /// </summary>
        public string so_plant { get; set; }
        /// <summary>
        /// memo_category
        /// </summary>
        public string memo_category { get; set; }
        /// <summary>
        /// application_plant
        /// </summary>
        public string application_plant { get; set; }
        /// <summary>
        /// season
        /// </summary>
        public string season { get; set; }
        /// <summary>
        /// disposal_method
        /// </summary>
        public string disposal_method { get; set; }
        /// <summary>
        /// shiptocountry
        /// </summary>
        public string shiptocountry { get; set; }
        /// <summary>
        /// buyerjobber
        /// </summary>
        public string buyerjobber { get; set; }
        /// <summary>
        /// disposal_subject
        /// </summary>
        public string disposal_subject { get; set; }
        /// <summary>
        /// disposal_reason
        /// </summary>
        public string disposal_reason { get; set; }
        /// <summary>
        /// Submit_UserID
        /// </summary>
        public string submit_userid { get; set; }
        /// <summary>
        /// Submit_Date
        /// </summary>
        public DateTime? submit_date { get; set; }
        /// <summary>
        /// Approve_userid
        /// </summary>
        public string approve_userid { get; set; }
        /// <summary>
        /// Approve_date
        /// </summary>
        public DateTime? approve_date { get; set; }
        /// <summary>
        /// Approve_status
        /// </summary>
        public string approve_status { get; set; }
        /// <summary>
        /// last_update_userid
        /// </summary>
        public string last_update_userid { get; set; }
        /// <summary>
        /// last_update_date
        /// </summary>
        public DateTime? last_update_date { get; set; }


    }

    public class EMEMO_dtlDto
    {
        /// <summary>
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
    }

    public class EMEMO_dtl_subDto
    {
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
    }

}