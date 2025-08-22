using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using EMEMO.ibll;
using learun.database;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.SS.Formula.Functions;

namespace EMEMO.bll {
    /// <summary>
    /// EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： EMEMO数据库执行类
    /// </summary>
    public class EMEMO_dtl_SubService : ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<EMEMO_dtl_subEntity, bool>>GetExpression(EMEMO_dtl_subEntity queryParams) {
            var exp = Expressionable.Create<EMEMO_dtl_subEntity>();
            if (!string.IsNullOrEmpty(queryParams.ememo_hdr_rid)) {
                exp = exp.And(t => t.ememo_hdr_rid == queryParams.ememo_hdr_rid);
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_dtl_subEntity>>GetList(EMEMO_dtl_subEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<EMEMO_dtl_subEntity>(expression);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_dtl_subEntity>>GetPageList(Pagination pagination, EMEMO_dtl_subEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<EMEMO_dtl_subEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EMEMO_dtl_subEntity> GetEntity(string keyValue) {
            return this.BaseRepository("OA").FindEntityByKey<EMEMO_dtl_subEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository("OA").Delete<EMEMO_dtl_subEntity>(keyValue);
        }
        /// <summary>
        /// 删除错误考勤的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository("OA").Delete<EMEMO_dtl_subEntity>(t => t.ememo_hdr_rid == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<EMEMO_dtl_subEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EMEMO_dtl_subEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.rid)) {
                    entity.rid = Guid.NewGuid().ToString();
                }
                await this.BaseRepository("OA").Insert(entity);
            } else {
                entity.rid = keyValue;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<EMEMO_dtl_subEntity> list) {
            var addList = new List<EMEMO_dtl_subEntity>();
            var db = this.BaseRepository("OA").BeginTrans();
            try {
                await db.Delete<EMEMO_dtl_subEntity>(t => t.ememo_hdr_rid == key);
                foreach(var item in list) {
                    if (string.IsNullOrEmpty(item.rid)) {
                        item.rid = Guid.NewGuid().ToString();
                    }
                    item.ememo_hdr_rid = key;
                    addList.Add(item);
                }
                if (addList.Count>0) {
                    await db.Inserts(addList,false);
                }
                db.Commit();
            } catch (Exception) {
                db.Rollback();
                throw;
            }
        }

        #endregion
    }
}