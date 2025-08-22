using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll.SchedulingInfo
{
    /// <summary>
    /// 销售情况查询实体传递
    /// </summary>
    public class CaseSalesDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string f_primarykey { get;set;}  
        /// <summary>
        /// 
        /// </summary>
        public string f_id { get; set; }  
        /// <summary>
        /// 销售编码
        /// </summary>
        public string f_number { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string f_theme { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string f_clientname { get; set; }
        /// <summary>
        /// 销售日期
        /// </summary>
        public DateTime? f_saledate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? f_deliverydate { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string f_productnumber { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string f_productname { get; set; }
        /// <summary>
        /// 订单总数
        /// </summary>
        public decimal? f_count { get; set; }
        /// <summary>
        /// 已使用
        /// </summary>
        public decimal? f_numberschedules { get; set; }
        /// <summary>
        /// 未使用
        /// </summary>
        public decimal? f_noschedules { get; set; }

    }
}
