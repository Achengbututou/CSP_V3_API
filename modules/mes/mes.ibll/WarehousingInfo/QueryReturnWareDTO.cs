using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll.WarehousingInfo
{
    /// <summary>
    /// 订单查询返货类
    /// </summary>
    public class QueryReturnWareDTO
    {
        public List<WarehousingDetailsDTO> warehousingDetailsDTO { get; set; }
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Total { get; set; }
    }
}
