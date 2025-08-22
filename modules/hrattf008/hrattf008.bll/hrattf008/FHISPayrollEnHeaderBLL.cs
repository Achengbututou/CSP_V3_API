using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF008.ibll;
using System.Linq;
using NPOI.POIFS.Crypt;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using TencentCloud.Cme.V20191029.Models;
namespace HRATTF008.bll
{
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：Password_Now(查询密码)
    /// </summary>
    public class FHISPayrollEnHeaderBLL : BLLBase, IFHISPayrollEnHeaderBLL, BLL
    {
        private readonly FHISPayrollEnHeaderService payrollEnHeaderService = new FHISPayrollEnHeaderService();

        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<FHISPayrollEnHeaderEntity>> GetPageList(Pagination pagination, FHISPayrollEnHeaderEntity queryParams)
        {
            //string AuthoritySql = await this.GetDataAuthoritySql("HRATTF003_List");
            //if (string.IsNullOrEmpty(AuthoritySql))
            //{
            //    AuthoritySql = string.Empty;
            //}
            return await payrollEnHeaderService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<FHISPayrollEnHeaderEntity> GetEntity(string keyValue)
        {
            return payrollEnHeaderService.GetEntity(keyValue);
        }
        public async Task<bool> CheckSignature(PayrollEnDto dto)
        {
            string period_code = dto.Period_Code;

            if (period_code.Substring(4, 2) == "01")
            {
                if (period_code.Substring(2, 2).ToInt() - 1 < 10)
                {
                    period_code = period_code.Substring(0, 2) + "0" + (period_code.Substring(2, 2).ToInt() - 1) + "1201";
                }
                else
                {
                    period_code = period_code.Substring(0, 2) + (period_code.Substring(2, 2).ToInt() - 1) + "1201";
                }
            }
            else
            {
                if (period_code.Substring(4, 2).ToInt() - 1 < 10)
                {
                    period_code = period_code.Substring(0, 4) + "0" + (period_code.Substring(4, 2).ToInt() - 1) + "01";
                }
                else
                {
                    period_code = period_code.Substring(0, 4) + (period_code.Substring(4, 2).ToInt() - 1) + "01";
                }
            }

            PayrollEnDto dto1 = new PayrollEnDto
            {
                Emp_No = dto.Emp_No,
                Company_Code = dto.Company_Code,
                Period_Code = period_code
            };

            var list = await payrollEnHeaderService.GetList(dto1);

            //存在代表验证有效
            if (list != null)
            {
                if (list.Count() == 0 || (list.ToList()[0].Signature != null && !"".Equals(list.ToList()[0].Signature)))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task deleteSign(string rid)
        {
            FHISPayrollEnHeaderEntity entity = await payrollEnHeaderService.GetEntity(rid);

            entity.Signature = null;
            entity.Status = 3;

            await payrollEnHeaderService.SaveEntity(rid, entity);
        }
    }
}