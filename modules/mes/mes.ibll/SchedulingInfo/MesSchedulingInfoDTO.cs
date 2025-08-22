using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    public class MesSchedulingInfoDTO
    {
        /// <summary>
        /// mes_SchedulingInfo(排期信息)表的实体
        /// </summary>
        public MesSchedulingInfoEntity MesSchedulingInfoEntity { get; set; }
        /// <summary>
        /// mes_ScheduleDetails(排期详情)表的实体
        /// </summary>
        public IEnumerable<MesScheduleDetailsEntity> MesScheduleDetailsEntities { get; set; }
    }
}
