using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using EMEMO.ibll;
namespace EMEMO.bll {
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤数据库执行类
    /// </summary>
    public class EMEMO_hdrService : ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<EMEMO_hdrEntity, bool>>GetExpression(EMEMO_hdrEntity queryParams) {
            var exp = Expressionable.Create<EMEMO_hdrEntity>();

            return exp.ToExpression();
        }
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_hdrEntity>>GetList(EMEMO_hdrEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<EMEMO_hdrEntity>(expression);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_hdrEntity>>GetPageList(Pagination pagination, EMEMO_hdrEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<EMEMO_hdrEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EMEMO_hdrEntity> GetEntity(string keyValue) {
            return this.BaseRepository("OA").FindEntityByKey<EMEMO_hdrEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository("OA").Delete<EMEMO_hdrEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<EMEMO_hdrEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EMEMO_hdrEntity entity) {
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
        #endregion
    }
}