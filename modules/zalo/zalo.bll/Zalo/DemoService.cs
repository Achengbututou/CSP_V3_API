using learun.iapplication;
using learun.util;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zalo.ibll;
namespace zalo.bll 
{
    /// <summary>
    /// 
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：
    /// 日 期： 
    /// 描 述： 数据库执行类
    /// </summary>
    public class DemoService: ServiceBase 
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<DemoEntity, bool>>GetExpression(DemoEntity queryParams) {
            var exp = Expressionable.Create<DemoEntity>();
            //if (!string.IsNullOrEmpty(queryParams.Leave_Header_RID)) {
            //    exp = exp.And(t => t.Leave_Header_RID == queryParams.Leave_Header_RID);
            //}
            //exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Voucher_Type), t => t.Voucher_Type.Contains(queryParams.Voucher_Type));
            //exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.File_Url), t => t.File_Url.Contains(queryParams.File_Url));
            //exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.File_Type), t => t.File_Type.Contains(queryParams.File_Type));
            //exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.File_suffix), t => t.File_suffix.Contains(queryParams.File_suffix));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<DemoEntity>>GetList(DemoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<DemoEntity>(expression);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<DemoEntity>>GetPageList(Pagination pagination, DemoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<DemoEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<DemoEntity>GetEntity(string keyValue) {
            return this.BaseRepository("OA").FindEntityByKey<DemoEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository("OA").Delete<DemoEntity>(keyValue);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, DemoEntity entity) {
            //if (string.IsNullOrEmpty(keyValue)) {
            //    if (string.IsNullOrEmpty(entity.RID)) {
            //        entity.RID = Guid.NewGuid().ToString();
            //    }
            //    await this.BaseRepository("OA").Insert(entity);
            //} else {
            //    entity.RID = keyValue;
            //    await this.BaseRepository("OA").Update(entity);
            //}
        }
        #endregion
    }
}