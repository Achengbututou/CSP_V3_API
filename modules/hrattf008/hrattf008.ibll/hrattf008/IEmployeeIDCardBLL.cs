using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace HRATTF008.ibll {
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：FHIS_Empoyee_All_ID_Card(身份证)
    /// </summary>
    public interface IEmployeeIDCardBLL : IBLL {
        #region 获取数据
        /// <summary>
        /// 获取身份证号码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<string> GetIDNO(string company_code, string emp_no);
        /// <summary>
        /// 验证员工信息是否正确
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResponseDto<string>> CheckEmployee(EmployeeDto dto);
        #endregion
        
    }
}