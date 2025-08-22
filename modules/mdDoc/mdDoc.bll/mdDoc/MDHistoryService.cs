using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MDDoc.ibll;
namespace MDDoc.bll
{
    /// <summary>
    /// MD文档
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期： 2024-10-21 16:06
    /// 描 述： 数据库执行类
    /// </summary>
    public class MDHistoryService : ServiceBase
    {
        //MDDocumentService mDDocumentService = new MDDocumentService();

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MDHistoryEntity, bool>> GetExpression(MDHistoryEntity queryParams)
        {
            var exp = Expressionable.Create<MDHistoryEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Md_document_Rid), t => t.Md_document_Rid.Contains(queryParams.Md_document_Rid));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDHistoryEntity>> GetList(MDHistoryEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<MDHistoryEntity>(expression);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDHistoryEntity>> GetPageList(Pagination pagination, string mdDocument_Rid)
        {
            return this.BaseRepository("OA").FindList<MDHistoryEntity>(t => t.Md_document_Rid == mdDocument_Rid, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MDHistoryEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<MDHistoryEntity>(keyValue);
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
            await this.BaseRepository("OA").Delete<MDHistoryEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<MDHistoryEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MDHistoryEntity entity)
        {
            //if (string.IsNullOrEmpty(keyValue))
            //{
                if (string.IsNullOrEmpty(entity.RID))
                {
                    entity.RID = keyValue;
                }
                entity.CreateUserID = this.GetUserId();
                entity.CreateDate = DateTime.Now;
                entity.CreateUserName = this.GetUserName();
                await this.BaseRepository("OA").Insert(entity);
            //await mDDocumentService.UpdateHistory(entity.Md_document_Rid, entity.RID);
            //}
            //else
            //{
            //    entity.RID = keyValue;
            //    //entity.Last_Update_Date = DateTime.Now;
            //    await this.BaseRepository("OA").Update(entity);
            //}
        }
        #endregion
    }
}