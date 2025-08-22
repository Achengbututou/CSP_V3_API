using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 查询计划详情
    /// </summary>
    public class MesProductionScheduleDTO
    {
        /// <summary>
        /// 订单详情
        /// </summary>
        public MesProductDetailsEntity productDetailsEntity { get; set; }
        /// <summary>
        /// 生产计划单详细
        /// </summary>
        public IEnumerable<MesProductionScheduleEntity> productionScheduleEntities { get; set; }
    }
}
