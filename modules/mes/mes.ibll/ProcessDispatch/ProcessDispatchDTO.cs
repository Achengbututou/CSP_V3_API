using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 工序派工保存诗句实体
    /// </summary>
    public class ProcessDispatchDTO
    {
        /// <summary>
        /// 工单主键
        /// </summary>
        public string F_ProductionTicketId { get; set; }  
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        public string F_ProcessRouteId { get; set; }
        /// <summary>
        /// 工序派工数据
        /// </summary>
       public  List<MesProcessDispatchEntity> mesProcessDispatches { get; set; }
    }
}
