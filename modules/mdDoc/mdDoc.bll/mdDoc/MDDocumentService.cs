using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MDDoc.ibll;
using System.Linq;
namespace MDDoc.bll
{
    /// <summary>
    /// MD文档
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期： 2024-10-21 16:06
    /// 描 述： 数据库执行类
    /// </summary>
    public class MDDocumentService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MDDocumentEntity, bool>> GetExpression(MDDocumentEntity queryParams)
        {
            var exp = Expressionable.Create<MDDocumentEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Name), t => t.Name.Contains(queryParams.Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Category), t => t.Category.Contains(queryParams.Category));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDDocumentEntity>> GetList(MDDocumentEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList(expression);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<MDDocumentEntity>> GetPageList(Pagination pagination, MDDocumentEntity queryParams, string userId, List<string> postIds, List<string> roleIds)
        {
            /*
            return await this.BaseRepository().FindList<WFSchemeInfoEntity>(t=> schemeinfoIds.ToArray().Contains(t.F_Id) || t.F_MonitorAuthType == 1);
             */
            //List<string> ids = new List<string>();
            //if (!string.IsNullOrEmpty(userId))
            //{
            //    ids.Add(userId);
            //}
            //ids.AddRange(postIds);
            //ids.AddRange(roleIds);
            //var list = await this.BaseRepository().FindList<WFSchemeAuthEntity>(t => ids.ToArray().Contains(t.F_ObjId) && t.F_Type == 2);
            //List<string> schemeinfoIds = new List<string>();
            //foreach (var item in list)
            //{
            //    schemeinfoIds.Add(item.F_SchemeInfoId);
            //}

            return await this.BaseRepository("OA").FindListByQueryable<MDDocumentEntity>(q => {
                var queryable = q.InnerJoin<MDAuthEntity>((t, t1) => t.RID == t1.Md_document_Rid)
                                .LeftJoin<MDHistoryEntity>((t, t1, t2) => t.Md_history_rid == t2.RID);
                var exp = Expressionable.Create<MDDocumentEntity, MDAuthEntity>()
                .AndIF(!string.IsNullOrEmpty(queryParams.Name), (t, t1) => t.Name.Contains(queryParams.Name))
                .AndIF(!string.IsNullOrEmpty(queryParams.Category), (t, t1) => t.Category.Contains(queryParams.Category))
                .And((t, t1) => (postIds.Contains(t1.ObjId) && t1.ObjType == 1) 
                                || (roleIds.Contains(t1.ObjId) && t1.ObjType == 2)
                                || (userId.Equals(t1.ObjId) && t1.ObjType == 3))
                .ToExpression();

                return queryable.Where(exp).Select((t, t1, t2) => new MDDocumentEntity()
                {
                    RID = t.RID,
                    Name = t.Name,
                    Category = t.Category,
                    Md_history_rid = t.Md_history_rid,
                    EnabledMark = t.EnabledMark,

                    DocumentData = t2.DocumentData,
                    CreateDate = t2.CreateDate,
                    CreateUserID = t2.CreateUserID,
                    CreateUserName = t2.CreateUserName,
                    isEdit = t1.editAuth
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MDDocumentEntity> GetEntity(string keyValue)
        {
            var mDDocuments = await this.BaseRepository("OA").FindListByQueryable<MDDocumentEntity>(q => {
                var queryable = q.LeftJoin<MDHistoryEntity>((t, t1) => t.Md_history_rid == t1.RID);
                var exp = Expressionable.Create<MDDocumentEntity, MDHistoryEntity>()
                .AndIF(!string.IsNullOrEmpty(keyValue), (t, t1) => t.RID.Contains(keyValue))
                .ToExpression();

                return queryable.Where(exp).Select((t, t1) => new MDDocumentEntity()
                {
                    RID = t.RID,
                    Name = t.Name,
                    Category = t.Category,
                    Md_history_rid = t.Md_history_rid,
                    EnabledMark = t.EnabledMark,

                    DocumentData = t1.DocumentData,
                    CreateDate = t1.CreateDate,
                    CreateUserID = t1.CreateUserID,
                    CreateUserName = t1.CreateUserName,
                });
            });
            List<MDDocumentEntity> list = mDDocuments.ToList();
            if (list.Count() > 0)
            {
                return list[0];
            }
            return null;
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
            await this.BaseRepository("OA").Delete<MDDocumentEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<MDDocumentEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MDDocumentEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                await this.BaseRepository("OA").Insert(entity);
            }
            else
            {
                entity.RID = keyValue;

                //entity.Last_Update_Date = DateTime.Now;
                await this.BaseRepository("OA").Update(entity);
            }
        }

        /// <summary>
        /// 更新历史模板
        /// </summary>
        /// <param name="id">文档主键</param>
        /// <param name="historyId">历史主键</param>
        public async Task UpdateHistory(string id, string historyId)
        {
            MDDocumentEntity entity = await GetEntity(id);
            entity.Md_history_rid = historyId;
            await this.BaseRepository("OA").Update(entity);
        }
        #endregion
    }
}