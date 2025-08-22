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
    /// 描 述：Password_Now(查询密码)
    /// </summary>
    public interface IPasswordNowBLL : IBLL {
        #region 获取数据

        /// <summary>
        /// 获取密码的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<PasswordNowEntity>> GetList(PasswordNowEntity queryParams);
        /// <summary>
        /// 获取密码的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<PasswordNowEntity>>GetPageList(Pagination pagination, PasswordNowEntity queryParams);
        Task<ResponseDto<string>> CheckPassword(EmployeePasswordDto dto); 
        Task<ResponseDto<string>> HasPassword(EmployeePasswordDto dto);
        #endregion
        #region 提交数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, PasswordNowEntity entity);
        #endregion
    }
}