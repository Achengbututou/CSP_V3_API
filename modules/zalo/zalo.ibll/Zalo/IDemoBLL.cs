using ce.autofac.extension;
using learun.iapplication;
using learun.util;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace zalo.ibll 
{
    /// <summary>
    /// 
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：
    /// 日 期： 
    /// 描 述： 
    /// </summary>
    public interface IDemoBLL : IBLL 
    {
        #region 获取数据
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<DemoEntity>>GetList(DemoEntity queryParams);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<DemoEntity>>GetPageList(Pagination pagination, DemoEntity queryParams);
        /// <summary>
        /// 根据表主键获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<DemoEntity> GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, DemoEntity entity);
        #endregion
        #region 供参考
        Task<ResponseDto<LoginOutputDto>> OpenIdLoginQY(string openid);
        #endregion
    }
}