using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-30 17:03:50
    /// 描 述： 半成品检测报告数据库执行类
    /// </summary>
    public class MesSemifinishedExDetailService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesSemifinishedExDetailEntity, bool>> GetExpression(MesSemifinishedExDetailEntity queryParams)
        {
            var exp = Expressionable.Create<MesSemifinishedExDetailEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_SemifinishedExId))
            {
                exp = exp.And(t => t.F_SemifinishedExId == queryParams.F_SemifinishedExId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TicketNumber), t => t.F_TicketNumber.Contains(queryParams.F_TicketNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductCode), t => t.F_ProductCode.Contains(queryParams.F_ProductCode));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SalesOrderNumber), t => t.F_SalesOrderNumber.Contains(queryParams.F_SalesOrderNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkshopId), t => t.F_WorkshopId.Contains(queryParams.F_WorkshopId));
            if (queryParams.F_BenchmarkValue != null)
            {
                exp = exp.And(t => t.F_BenchmarkValue == queryParams.F_BenchmarkValue);
            }
            if (queryParams.F_UpperTolerance != null)
            {
                exp = exp.And(t => t.F_UpperTolerance == queryParams.F_UpperTolerance);
            }
            if (queryParams.F_LowerTolerance != null)
            {
                exp = exp.And(t => t.F_LowerTolerance == queryParams.F_LowerTolerance);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MeasuredValue), t => t.F_MeasuredValue.Contains(queryParams.F_MeasuredValue));
            if (queryParams.F_BadNumber != null)
            {
                exp = exp.And(t => t.F_BadNumber == queryParams.F_BadNumber);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_BadHandling), t => t.F_BadHandling.Contains(queryParams.F_BadHandling));
            if (queryParams.F_States != null)
            {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Remarks), t => t.F_Remarks.Contains(queryParams.F_Remarks));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserName), t => t.F_CreatUserName.Contains(queryParams.F_CreatUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserId), t => t.F_CreatUserId.Contains(queryParams.F_CreatUserId));
            if (!string.IsNullOrEmpty(queryParams.F_CreatUserTimeQRange))
            {
                var f_CreatUserTime_list = queryParams.F_CreatUserTimeQRange.Split(" - ");
                DateTime f_CreatUserTime = Convert.ToDateTime(f_CreatUserTime_list[0]);
                DateTime f_CreatUserTime_end = Convert.ToDateTime(f_CreatUserTime_list[1]);
                exp = exp.And(t => t.F_CreatUserTime >= f_CreatUserTime && t.F_CreatUserTime <= f_CreatUserTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyName), t => t.F_ModifyName.Contains(queryParams.F_ModifyName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyId), t => t.F_ModifyId.Contains(queryParams.F_ModifyId));
            if (!string.IsNullOrEmpty(queryParams.F_ModifyTimeQRange))
            {
                var f_ModifyTime_list = queryParams.F_ModifyTimeQRange.Split(" - ");
                DateTime f_ModifyTime = Convert.ToDateTime(f_ModifyTime_list[0]);
                DateTime f_ModifyTime_end = Convert.ToDateTime(f_ModifyTime_list[1]);
                exp = exp.And(t => t.F_ModifyTime >= f_ModifyTime && t.F_ModifyTime <= f_ModifyTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取半成品检测报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedExDetailEntity>> GetList(MesSemifinishedExDetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSemifinishedExDetailEntity>(expression);
        }
        /// <summary>
        /// 获取半成品检测报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedExDetailEntity>> GetPageList(Pagination pagination, MesSemifinishedExDetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSemifinishedExDetailEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSemifinishedExDetailEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesSemifinishedExDetailEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesSemifinishedExDetailEntity>(keyValue);
        }
        /// <summary>
        /// 删除半成品检测报告的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key)
        {
            await this.BaseRepository().Delete<MesSemifinishedExDetailEntity>(t => t.F_SemifinishedExId == key);
        }
        /// <summary>
        /// 删除半成品检测报告的数据
        /// </summary>
        /// <param name="keys">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelates(List<string> keys)
        {
            await this.BaseRepository().Delete<MesSemifinishedExDetailEntity>(t => keys.Contains(t.F_SemifinishedExId));
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesSemifinishedExDetailEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSemifinishedExDetailEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_Id = keyValue;
                await this.BaseRepository().Update(entity);
            }
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesSemifinishedExDetailEntity> list)
        {
            var addList = new List<MesSemifinishedExDetailEntity>();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesSemifinishedExDetailEntity>(t => t.F_SemifinishedExId == key);
                foreach (var item in list)
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_SemifinishedExId = key;
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