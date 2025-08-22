using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using NPOI.SS.Formula.Functions;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-30 16:25:57
    /// 描 述： 半成品检验报告数据库执行类
    /// </summary>
    public class MesSemifinishedDetailService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesSemifinishedDetailEntity, bool>>GetExpression(MesSemifinishedDetailEntity queryParams) {
            var exp = Expressionable.Create<MesSemifinishedDetailEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_SemifinishedId)) {
                exp = exp.And(t => t.F_SemifinishedId == queryParams.F_SemifinishedId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TicketNumber), t => t.F_TicketNumber.Contains(queryParams.F_TicketNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductCode), t => t.F_ProductCode.Contains(queryParams.F_ProductCode));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SalesOrderNumber), t => t.F_SalesOrderNumber.Contains(queryParams.F_SalesOrderNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkshopId), t => t.F_WorkshopId.Contains(queryParams.F_WorkshopId));
            if (queryParams.F_BenchmarkValue != null) {
                exp = exp.And(t => t.F_BenchmarkValue == queryParams.F_BenchmarkValue);
            }
            if (queryParams.F_UpperTolerance != null) {
                exp = exp.And(t => t.F_UpperTolerance == queryParams.F_UpperTolerance);
            }
            if (queryParams.F_LowerTolerance != null) {
                exp = exp.And(t => t.F_LowerTolerance == queryParams.F_LowerTolerance);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MeasuredValue), t => t.F_MeasuredValue.Contains(queryParams.F_MeasuredValue));
            if (queryParams.F_BadNumber != null) {
                exp = exp.And(t => t.F_BadNumber == queryParams.F_BadNumber);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_BadHandling), t => t.F_BadHandling.Contains(queryParams.F_BadHandling));
            if (queryParams.F_States != null) {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Remarks), t => t.F_Remarks.Contains(queryParams.F_Remarks));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserName), t => t.F_CreatUserName.Contains(queryParams.F_CreatUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserId), t => t.F_CreatUserId.Contains(queryParams.F_CreatUserId));
            if (!string.IsNullOrEmpty(queryParams.F_CreatUserTimeQRange)) {
                var f_CreatUserTime_list = queryParams.F_CreatUserTimeQRange.Split(" - ");
                DateTime f_CreatUserTime = Convert.ToDateTime(f_CreatUserTime_list[0]);
                DateTime f_CreatUserTime_end = Convert.ToDateTime(f_CreatUserTime_list[1]);
                exp = exp.And(t => t.F_CreatUserTime >= f_CreatUserTime && t.F_CreatUserTime <= f_CreatUserTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyName), t => t.F_ModifyName.Contains(queryParams.F_ModifyName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyId), t => t.F_ModifyId.Contains(queryParams.F_ModifyId));
            if (!string.IsNullOrEmpty(queryParams.F_ModifyTimeQRange)) {
                var f_ModifyTime_list = queryParams.F_ModifyTimeQRange.Split(" - ");
                DateTime f_ModifyTime = Convert.ToDateTime(f_ModifyTime_list[0]);
                DateTime f_ModifyTime_end = Convert.ToDateTime(f_ModifyTime_list[1]);
                exp = exp.And(t => t.F_ModifyTime >= f_ModifyTime && t.F_ModifyTime <= f_ModifyTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取半成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedDetailEntity>>GetList(MesSemifinishedDetailEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSemifinishedDetailEntity>(expression);
        }
        /// <summary>
        /// 获取半成品报告
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedDetailEntity>> GetListByIds(List<string> ids)
        {
            return this.BaseRepository().FindList<MesSemifinishedDetailEntity>(t=>ids.Contains(t.F_Id));
        }
        /// <summary>
        /// 获取半成品检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedDetailEntity>>GetPageList(Pagination pagination, MesSemifinishedDetailEntity queryParams) {
            return this.BaseRepository().FindListByQueryable<MesSemifinishedDetailEntity>(q => {
                var queryable = q.InnerJoin<MesSemifinishedReportEntity>((t, t1) => t.F_SemifinishedId == t1.F_Id);
                var expression = Expressionable.Create<MesSemifinishedDetailEntity, MesSemifinishedReportEntity>();
                expression = expression.AndIF(!string.IsNullOrEmpty(queryParams.F_SemifinishedNumber), (t, t1) => t1.F_SemifinishedNumber == queryParams.F_SemifinishedNumber);
                if (!string.IsNullOrEmpty(queryParams.F_InspectionDateQRange))
                {
                    var f_InspectionDate_list = queryParams.F_InspectionDateQRange.Split(" - ");
                    DateTime f_InspectionDate = Convert.ToDateTime(f_InspectionDate_list[0]);
                    DateTime f_InspectionDate_end = Convert.ToDateTime(f_InspectionDate_list[1]);
                    expression = expression.And((t, t1) => t1.F_InspectionDate >= f_InspectionDate && t1.F_InspectionDate <= f_InspectionDate_end);
                }
                queryable = queryable.Where(expression.ToExpression());
                return queryable.Select((t, t1) => new MesSemifinishedDetailEntity()
                {
                    F_Id = t.F_Id,
                    F_SemifinishedId = t.F_SemifinishedId,
                    F_TicketNumber = t.F_TicketNumber,
                    F_ProductCode = t.F_ProductCode,
                    F_ProductName = t.F_ProductName,
                    F_BenchmarkValue = t.F_BenchmarkValue,
                    F_SalesOrderNumber = t.F_SalesOrderNumber,
                    F_WorkshopId = t.F_WorkshopId,
                    F_UpperTolerance = t.F_UpperTolerance,
                    F_LowerTolerance = t.F_LowerTolerance,
                    F_MeasuredValue = t.F_MeasuredValue,
                    F_BadNumber = t.F_BadNumber,
                    F_BadHandling = t.F_BadHandling,
                    F_Annex=t.F_Annex,
                    F_Remarks = t1.F_Remarks,
                    F_States = t1.F_States,
                    F_ExStates = t1.F_ExStates,
                    F_CreatUserName = t1.F_CreatUserName,
                    F_CreatUserTime = t1.F_CreatUserTime,
                    F_SemifinishedNumber=t1.F_SemifinishedNumber,
                    F_InspectionDate=t1.F_InspectionDate,
                    F_ReportHeader = t1.F_ReportHeader,
                    F_Inspector = t1.F_Inspector,
                    F_SamplingStandard = t1.F_SamplingStandard,
                    F_SamplesNumber = t1.F_SamplesNumber    
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSemifinishedDetailEntity>GetEntity(string keyValue) {

            return this.BaseRepository().FindEntityByKey<MesSemifinishedDetailEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesSemifinishedDetailEntity>(keyValue);
        }
        /// <summary>
        /// 删除半成品检验报告的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository().Delete<MesSemifinishedDetailEntity>(t => t.F_SemifinishedId == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesSemifinishedDetailEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSemifinishedDetailEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                await this.BaseRepository().Insert(entity);
            } else {
                entity.F_Id = keyValue;
                await this.BaseRepository().Update(entity);
            }
        }
        /// <summary>
        /// 批量修改半成品检验报告的数据
        /// </summary>
        /// <param name="mesSemifinishedDetails"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesSemifinishedDetailEntity> mesSemifinishedDetails)
        {
            await this.BaseRepository().Updates(mesSemifinishedDetails);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesSemifinishedDetailEntity>list) {
            var addList = new List<MesSemifinishedDetailEntity>();
            var db = this.BaseRepository().BeginTrans();
            try {
                await db.Delete<MesSemifinishedDetailEntity>(t => t.F_SemifinishedId == key);
                foreach(var item in list) {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_ExStates = 1;
                    item.F_SemifinishedId = key;
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