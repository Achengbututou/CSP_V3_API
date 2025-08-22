using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 工单创建实体
    /// </summary>
    public class ProductionTicketSaveDTO
    {
        /// <summary>
        /// 生产计划数据
        /// </summary>
        public List<string> F_Ids { get; set; }
        /// <summary>
        /// 工单数据
        /// </summary>
        public MesProductionTicketEntity mesProductionTicket { get; set; }
    }
}
