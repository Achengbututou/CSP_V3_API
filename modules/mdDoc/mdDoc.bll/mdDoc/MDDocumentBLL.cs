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
    public class MDDocumentBLL : BLLBase, IMDDocumentBLL, BLL
    {
        private readonly MDDocumentService mDDocumentService = new MDDocumentService();
        private readonly MDHistoryService mDHistoryService = new MDHistoryService();
        private readonly MDAuthService mDAuthService = new MDAuthService();
        #region 获取数据
        /// <summary>
        /// 获取FHIS_Leave_Detail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDDocumentEntity>> GetList(MDDocumentEntity queryParams)
        {
            return mDDocumentService.GetList(queryParams);
        }
        /// <summary>
        /// 获取FHIS_Leave_Detail的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<MDDocumentEntity>> GetPageList(Pagination pagination, MDDocumentEntity queryParams)
        {
            var userInfo = await this.CurrentUser();
            var postIds = await this.CurrentUserPostIds(userInfo.F_UserId);
            var roleIds = await this.CurrentUserRoleIds(userInfo.F_UserId);
            return await mDDocumentService.GetPageList(pagination, queryParams, userInfo.F_UserId, postIds, roleIds);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MDDocumentEntity> GetEntity(string keyValue)
        {
            return mDDocumentService.GetEntity(keyValue);
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
            MDHistoryEntity mDHistoryEntity = new MDHistoryEntity()
            {
                Md_document_Rid = keyValue
            };
            var list = await mDHistoryService.GetList(mDHistoryEntity);
            string historyRids = "";
            foreach (MDHistoryEntity entity in list)
            {
                historyRids += entity.RID + ",";
            }

            MDAuthEntity mDAuthEntity = new MDAuthEntity()
            {
                Md_document_Rid = keyValue
            };
            var listAuth = await mDAuthService.GetList(mDAuthEntity);
            string authRids = "";
            foreach (MDAuthEntity entity in listAuth)
            {
                authRids += entity.RID + ",";
            }
            await mDDocumentService.Delete(keyValue);
            await mDHistoryService.Deletes(historyRids);
            await mDAuthService.Deletes(authRids);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await mDDocumentService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MDDocumentEntity entity)
        {
            if (string.IsNullOrEmpty(entity.RID))
            {
                entity.RID = System.Guid.NewGuid().ToString();
            }
            entity.Md_history_rid = System.Guid.NewGuid().ToString();

            MDHistoryEntity historyEntity = new MDHistoryEntity()
            {
                RID = entity.Md_history_rid,
                DocumentData = entity.DocumentData,
                Md_document_Rid = entity.RID
            };

            MDAuthEntity authEntity = new MDAuthEntity()
            {
                RID = System.Guid.NewGuid().ToString(),
                Md_document_Rid = entity.RID,
                ObjId = this.GetUserId(),
                ObjName = this.GetUserName(),
                ObjType = 3,
                readAuth = true,
                editAuth = true
            };

            await mDDocumentService.SaveEntity(keyValue, entity);
            await mDHistoryService.SaveEntity(historyEntity.RID, historyEntity);
            //新增时，插入权限
            if (string.IsNullOrEmpty(keyValue)) {
                await mDAuthService.SaveEntity(null, authEntity);
            }
        }

        public async Task UpdateHistory(string id, string historyId)
        {
            await mDDocumentService.UpdateHistory(id, historyId);
        }
        #endregion
    }
}