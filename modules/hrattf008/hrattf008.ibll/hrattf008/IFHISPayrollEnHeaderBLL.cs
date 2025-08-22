using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace HRATTF008.ibll
{
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：Password_Now(查询密码)
    /// </summary>
    public interface IFHISPayrollEnHeaderBLL : IBLL
    {
        #region 获取数据
        Task<IEnumerable<FHISPayrollEnHeaderEntity>> GetPageList(Pagination pagination, FHISPayrollEnHeaderEntity queryParams);

        Task<FHISPayrollEnHeaderEntity> GetEntity(string keyValue);

        /// <summary>
        /// 检查是否签名
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> CheckSignature(PayrollEnDto dto);
        #endregion

        Task deleteSign(string rid);

    }
}