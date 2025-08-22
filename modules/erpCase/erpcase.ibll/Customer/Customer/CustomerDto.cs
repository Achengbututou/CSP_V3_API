using System.Collections.Generic;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:42:10
    /// 描 述：客户信息表单提交参数
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// case_erp_customer(客户信息【case_erp_customer】)表的实体
        /// </summary>
        public CaseErpCustomerEntity CaseErpCustomerEntity { get; set; }
        /// <summary>
        /// case_erp_customercontacts(客户联系人【case_erp_customercontacts】)表的实体
        /// </summary>
        public IEnumerable<CaseErpCustomercontactsEntity> CaseErpCustomercontactsList { get; set; }

    }
}