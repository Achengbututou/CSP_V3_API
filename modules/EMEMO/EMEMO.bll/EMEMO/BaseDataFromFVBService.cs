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

namespace EMEMO.bll
{
    /// <summary>
    /// EMEMO-EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： EMEMO数据库执行类
    /// </summary>
    public class BaseDataFromFVBService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<BaseDataFromFVBEntity, bool>> GetExpression(BaseDataFromFVBEntity queryParams)
        {
            var exp = Expressionable.Create<BaseDataFromFVBEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.company_code), t => t.company_code.Contains(queryParams.company_code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.factory), t => t.factory.Contains(queryParams.factory));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.plant), t => t.plant.Contains(queryParams.plant));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.material_type), t => t.material_type.Contains(queryParams.material_type));

            return exp.ToExpression();
        }
        /// <summary>
        /// 获取EMEMO的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<BaseDataFromFVBEntity>> GetList(BaseDataFromFVBEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<BaseDataFromFVBEntity>(expression);
        }
        /// <summary>
        /// 获取EMEMO的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<BaseDataFromFVBEntity>> GetPageList(Pagination pagination, BaseDataFromFVBEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<BaseDataFromFVBEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<BaseDataFromFVBEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<BaseDataFromFVBEntity>(keyValue);
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
            await this.BaseRepository("OA").Delete<BaseDataFromFVBEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<BaseDataFromFVBEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, BaseDataFromFVBEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.rid))
                {
                    entity.rid = Guid.NewGuid().ToString();
                }
                await this.BaseRepository("OA").Insert(entity);
            }
            else
            {
                entity.rid = keyValue;
                await this.BaseRepository("OA").Update(entity);
            }
        }

        public async Task GetBaseDataFromFVB()
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_GetBaseDataFromFVB";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name);

            //var jsonData = dt_name.ToJson();
            long records = dt_name.Rows.Count;
            long total = 50;
            long page = 50;

            var jsonData = new
            {
                rows = dt_name,
                total,
                page,
                records
            };

        }

        #endregion
    }
}