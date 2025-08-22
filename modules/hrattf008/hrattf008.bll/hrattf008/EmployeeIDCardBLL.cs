using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF008.ibll;
using NPOI.HSSF.Record.Chart;
using System.Linq;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
namespace HRATTF008.bll {
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：FHIS_Empoyee_All_ID_Card(身份证)
    /// </summary>
    public class EmployeeIDCardBLL : BLLBase, IEmployeeIDCardBLL, BLL {
        private readonly EmployeeIDCardService employeeIDCardService = new EmployeeIDCardService();

        #region 获取数据

        /// <summary>
        /// 获取身份证号码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<string> GetIDNO(string company_Code,string emp_No) 
        {
            EmployeeIDCardEntity entity = new EmployeeIDCardEntity
            {
                Company_Code = company_Code,
                Emp_No = emp_No,
            };

            Pagination pagination = new Pagination()
            {
                page = 1,
                rows = 1,
            };

            var list = await employeeIDCardService.GetPageList(pagination, entity);

            //存在代表验证有效
            if (list != null && list.Count() > 0)
            {
                return list.ToList()[0].ID_NO;
            }
            return null;
        }

        /// <summary>
        /// 验证员工信息是否正确
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResponseDto<string>> CheckEmployee(EmployeeDto dto)
        {
            EmployeeIDCardEntity entity = new EmployeeIDCardEntity
            {
                Company_Code = dto.Company_Code,
                Emp_No = dto.Emp_No,
                ID_NO = dto.ID_Card_No
            };

            Pagination pagination = new Pagination()
            {
                page = 1,
                rows = 1,
            };

            var list = await employeeIDCardService.GetPageList(pagination, entity);
            
            //存在代表验证有效
            if (list != null && list.Count() > 0)
            {
                return Success("成功!/Succeeded!", "ok");
            }

            return Fail<string>("身份证&公司&工号不匹配！！");
        }

        #endregion
    }
}