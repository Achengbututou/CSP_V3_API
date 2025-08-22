using System.Collections.Generic;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-11-30 15:26:32
    /// 描 述：采购申请表单提交参数
    /// </summary>
    public class ApplyDto
    {
        /// <summary>
        /// case_erp_apply(采购申请信息【case_erp_apply】)表的实体
        /// </summary>
        public CaseErpApplyEntity CaseErpApplyEntity { get; set; }
        /// <summary>
        /// case_erp_applydetail(采购申请详情【case_erp_applydetail】)表的实体
        /// </summary>
        public IEnumerable<CaseErpApplydetailEntity> CaseErpApplydetailList { get; set; }

    }

    /// <summary>
    /// 物品概要
    /// </summary>
    public class ApplySynopsis
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 物料数量
        /// </summary>
        public decimal? Count { get; set; }

    }
}