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
    public class MDHistoryBLL : BLLBase, IMDHistoryBLL, BLL
    {
        private readonly MDHistoryService mDHistoryService = new MDHistoryService();
        #region 获取数据
        /// <summary>
        /// 获取FHIS_Leave_Detail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDHistoryEntity>> GetList(MDHistoryEntity queryParams)
        {
            return mDHistoryService.GetList(queryParams);
        }
        /// <summary>
        /// 获取FHIS_Leave_Detail的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDHistoryEntity>> GetPageList(Pagination pagination,string id)
        {
            return mDHistoryService.GetPageList(pagination, id);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MDHistoryEntity> GetEntity(string keyValue)
        {
            return mDHistoryService.GetEntity(keyValue);
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
            await mDHistoryService.Delete(keyValue);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await mDHistoryService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MDHistoryEntity entity)
        {
            await mDHistoryService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}