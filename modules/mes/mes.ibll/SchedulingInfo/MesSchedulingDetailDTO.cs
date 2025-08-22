using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll.SchedulingInfo
{
    /// <summary>
    /// 排期详细
    /// </summary>
    public class MesSchedulingDetailDTO
    {
        /// <summary>
        /// 排期主键
        /// </summary>
        public string F_SchedulingId { get; set; }
        /// <summary>
        /// mes_ScheduleDetails(排期详情)表的实体
        /// </summary>
        public IEnumerable<MesScheduleDetailsEntity> mesScheduleDetailsEntities { get; set; }
        /// <summary>
        /// mes_scheduleorddeta(排期订单详情)表的实体
        /// </summary>
        public IEnumerable<MesScheduleOrderDetailsEntity> mesScheduleOrderDetails { get; set; }
    }
}
