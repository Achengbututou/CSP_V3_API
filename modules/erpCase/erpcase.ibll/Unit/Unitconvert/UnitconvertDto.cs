using System.Collections.Generic;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:54:57
    /// 描 述：单位换算表单提交参数
    /// </summary>
    public class UnitconvertDto
    {
        /// <summary>
        /// case_erp_unitconvert(单位换算【case_erp_unitconvert】)表的实体
        /// </summary>
        public CaseErpUnitconvertEntity CaseErpUnitconvertEntity { get; set; }
        /// <summary>
        /// case_erp_unitconvertdetail(单位换算详情【case_erp_unitconvertdetail】)表的实体
        /// </summary>
        public IEnumerable<CaseErpUnitconvertdetailEntity> CaseErpUnitconvertdetailList { get; set; }

    }
}