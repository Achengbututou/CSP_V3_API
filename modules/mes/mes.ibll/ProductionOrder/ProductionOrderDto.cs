using System.Collections.Generic;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-15 09:12:40
    /// 描 述：生产订单表单提交参数
    /// </summary>
    public class ProductionOrderDto
    {
        /// <summary>
        /// mes_productorder(生产订单)表的实体
        /// </summary>
        public MesProductionOrderEntity MesProductionOrderEntity { get; set; }
        /// <summary>
        /// mes_ProductDetails(生产订单产品明细)表的实体
        /// </summary>
        public IEnumerable<MesProductDetailsEntity> MesProductDetailsList { get; set; }

    }
}