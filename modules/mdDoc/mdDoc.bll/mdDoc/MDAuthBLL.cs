using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System.Collections.Generic;
using System.Threading.Tasks;
using MDDoc.ibll;
namespace MDDoc.bll
{
    /// <summary>
    /// MD文档
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期： 2024-10-21 16:06
    /// 描 述： MD 文档
    /// </summary>
    public class MDAuthBLL : BLLBase, IMDAuthBLL, BLL
    {
        private readonly MDAuthService mDAuthService = new MDAuthService();
        #region 获取数据
        /// <summary>
        /// 获取FHIS_Leave_Detail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDAuthEntity>> GetList(string mdId)
        {
            return mDAuthService.GetListByMdID(mdId);
        }
        /// <summary>
        /// 获取FHIS_Leave_Detail的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDAuthEntity>> GetPageList(Pagination pagination, MDAuthEntity queryParams)
        {
            return mDAuthService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MDAuthEntity> GetEntity(string keyValue)
        {
            return mDAuthService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue)
        {
            await mDAuthService.Delete(keyValue);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await mDAuthService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MDAuthEntity entity)
        {
            await mDAuthService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MDAuthEntity> list)
        {
            await mDAuthService.SaveList(key, list);
        }

        #endregion
    }
}