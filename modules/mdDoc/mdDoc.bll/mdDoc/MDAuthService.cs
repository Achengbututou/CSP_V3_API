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
    public class MDAuthService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MDAuthEntity, bool>> GetExpression(MDAuthEntity queryParams)
        {
            var exp = Expressionable.Create<MDAuthEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Md_document_Rid), t => t.Md_document_Rid.Contains(queryParams.Md_document_Rid));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDAuthEntity>> GetList(MDAuthEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<MDAuthEntity>(expression);
        }

        public Task<IEnumerable<MDAuthEntity>> GetListByMdID(string mdDocument_Rid)
        {
            return this.BaseRepository("OA").FindList<MDAuthEntity>(t => t.Md_document_Rid == mdDocument_Rid);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MDAuthEntity>> GetPageList(Pagination pagination, MDAuthEntity queryParams, string AuthoritySql = null)
        {
            return this.BaseRepository("OA").FindList<MDAuthEntity>(t => t.Md_document_Rid == queryParams.Md_document_Rid, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MDAuthEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<MDAuthEntity>(keyValue);
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
            await this.BaseRepository("OA").Delete<MDAuthEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<MDAuthEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MDAuthEntity entity)
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
        /// 批量保存
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MDAuthEntity> list)
        {
            var addList = new List<MDAuthEntity>();
            var db = this.BaseRepository("OA").BeginTrans();
            try
            {
                await db.Delete<MDAuthEntity>(t => t.Md_document_Rid == key);
                foreach (var item in list)
                {
                    if (string.IsNullOrEmpty(item.RID))
                    {
                        item.RID = Guid.NewGuid().ToString();
                    }
                    item.Md_document_Rid = key;
                    addList.Add(item);
                }
                if (addList.Count > 0)
                {
                    await db.Inserts(addList);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}