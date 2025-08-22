using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using HRATTF.ibll;
namespace HRATTF.bll {
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-10-24 09:19:39
    /// 描 述： 请假申请数据库执行类
    /// </summary>
    public class FHISLeaveDetailService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<FHISLeaveDetailEntity, bool>>GetExpression(FHISLeaveDetailEntity queryParams) {
            var exp = Expressionable.Create<FHISLeaveDetailEntity>();
            if (!string.IsNullOrEmpty(queryParams.Leave_Header_RID)) {
                exp = exp.And(t => t.Leave_Header_RID == queryParams.Leave_Header_RID);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Voucher_Type), t => t.Voucher_Type.Contains(queryParams.Voucher_Type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.File_Url), t => t.File_Url.Contains(queryParams.File_Url));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.File_Type), t => t.File_Type.Contains(queryParams.File_Type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.File_suffix), t => t.File_suffix.Contains(queryParams.File_suffix));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveDetailEntity>>GetList(FHISLeaveDetailEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<FHISLeaveDetailEntity>(expression);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveDetailEntity>>GetPageList(Pagination pagination, FHISLeaveDetailEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<FHISLeaveDetailEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<FHISLeaveDetailEntity>GetEntity(string keyValue) {
            return this.BaseRepository("OA").FindEntityByKey<FHISLeaveDetailEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository("OA").Delete<FHISLeaveDetailEntity>(keyValue);
        }
        /// <summary>
        /// 删除请假申请的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository("OA").Delete<FHISLeaveDetailEntity>(t => t.Leave_Header_RID == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<FHISLeaveDetailEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, FHISLeaveDetailEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.RID)) {
                    entity.RID = Guid.NewGuid().ToString();
                }
                await this.BaseRepository("OA").Insert(entity);
            } else {
                entity.RID = keyValue;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<FHISLeaveDetailEntity>list) {
            var addList = new List<FHISLeaveDetailEntity>();
            var db = this.BaseRepository("OA").BeginTrans();
            try {
                await db.Delete<FHISLeaveDetailEntity>(t => t.Leave_Header_RID == key);
                foreach(var item in list) {
                    if (string.IsNullOrEmpty(item.RID)) {
                        item.RID = Guid.NewGuid().ToString();
                    }
                    item.Leave_Header_RID = key;
                    addList.Add(item);
                }
                if (addList.Count>0) {
                    await db.Inserts(addList);
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