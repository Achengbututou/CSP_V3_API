using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-30 16:25:57
    /// 描 述： 半成品检验报告数据库执行类
    /// </summary>
    public class MesSemifinishedReportService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesSemifinishedReportEntity, bool>> GetExpression(MesSemifinishedReportEntity queryParams)
        {
            var exp = Expressionable.Create<MesSemifinishedReportEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SemifinishedNumber), t => t.F_SemifinishedNumber.Contains(queryParams.F_SemifinishedNumber));
            if (queryParams.F_NumberState != null)
            {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            if (!string.IsNullOrEmpty(queryParams.F_InspectionDateQRange))
            {
                var f_InspectionDate_list = queryParams.F_InspectionDateQRange.Split(" - ");
                DateTime f_InspectionDate = Convert.ToDateTime(f_InspectionDate_list[0]);
                DateTime f_InspectionDate_end = Convert.ToDateTime(f_InspectionDate_list[1]);
                exp = exp.And(t => t.F_InspectionDate >= f_InspectionDate && t.F_InspectionDate <= f_InspectionDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReportHeader), t => t.F_ReportHeader.Contains(queryParams.F_ReportHeader));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Inspector), t => t.F_Inspector.Contains(queryParams.F_Inspector));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SamplingStandard), t => t.F_SamplingStandard.Contains(queryParams.F_SamplingStandard));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SamplesNumber), t => t.F_SamplesNumber.Contains(queryParams.F_SamplesNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DetectionCategoryId), t => t.F_DetectionCategoryId.Contains(queryParams.F_DetectionCategoryId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DetectionItemId), t => t.F_DetectionItemId.Contains(queryParams.F_DetectionItemId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CalibrationStandard), t => t.F_CalibrationStandard.Contains(queryParams.F_CalibrationStandard));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DetectionMethodId), t => t.F_DetectionMethodId.Contains(queryParams.F_DetectionMethodId));
            if (queryParams.F_OveralJudgment != null)
            {
                exp = exp.And(t => t.F_OveralJudgment == queryParams.F_OveralJudgment);
            }
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
        /// 获取半成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedReportEntity>> GetList(MesSemifinishedReportEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSemifinishedReportEntity>(expression);
        }
        /// <summary>
        /// 获取半成品数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedReportEntity>> GetListByIds(List<string> ids)
        {
            return this.BaseRepository().FindList<MesSemifinishedReportEntity>(t => ids.Contains(t.F_Id));
        }
        /// <summary>
        /// 获取半成品检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedReportEntity>> GetPageList(Pagination pagination, MesSemifinishedReportEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSemifinishedReportEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSemifinishedReportEntity> GetEntity(string keyValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
                   SELECT
	                    t.F_Id,
	                    t.F_SemifinishedNumber,
	                    t.F_InspectionDate,
	                    t.F_ReportHeader,
	                    u.F_RealName AS F_InspectorName,
                        t.F_Inspector,
	                    t.F_SamplingStandard,
	                    t.F_SamplesNumber,
	                    t.F_DetectionCategoryId,
	                    t.F_DetectionItemId,
	                    t.F_CalibrationStandard,
	                    t.F_DetectionMethodId,
	                    d.F_ProductCode,
	                    d.F_ProductName,
	                    d.F_SalesOrderNumber,
	                    s.F_WorkshopName AS F_WorkshopId,
	                    t.F_IncomingInspectionNo,
	                    t.F_OveralJudgment,
	                    t.F_ExStates,
	                    t.F_States,
	                    t.F_Remarks,
	                    t.F_CreatUserName,
	                    t.F_CreatUserTime,
	                    t.F_ModifyName,
	                    t.F_ModifyTime 
                    FROM
	                    mes_semifinishreport t
	                    LEFT JOIN lr_base_user u ON t.F_Inspector= u.F_UserId
	                    LEFT JOIN mes_semifinishdetail d ON t.F_Id= d.F_SemifinishedId
	                    LEFT JOIN mes_WorkshopInfo s ON d.F_WorkshopId= s.F_Id
                 ");
            strSql.Append(" WHERE t.F_Id= '" + keyValue + "' ");
            return this.BaseRepository().FindEntity<MesSemifinishedReportEntity>(strSql.ToString());
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
            await this.BaseRepository().Delete<MesSemifinishedReportEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesSemifinishedReportEntity>(keyValuesArr);
        }
        /// <summary>
        /// 批量修改半成品报告
        /// </summary>
        /// <param name="mesSemifinishedReports"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesSemifinishedReportEntity> mesSemifinishedReports)
        {
            await this.BaseRepository().Updates(mesSemifinishedReports);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSemifinishedReportEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_ExStates = 1;
                entity.F_States = 1;
                entity.F_CreatUserId = this.GetUserId();
                entity.F_CreatUserName = this.GetUserName();
                entity.F_CreatUserTime = DateTime.Now;
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_Id = keyValue;
                entity.F_ModifyId = this.GetUserId();
                entity.F_ModifyName = this.GetUserName();
                entity.F_ModifyTime = DateTime.Now;
                await this.BaseRepository().Update(entity);
            }
        }
        /// <summary>
        /// 批量保存数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="mesSemifinishedReports"></param>
        /// <returns></returns>
        public async Task SaveList(string keyValue, List<MesSemifinishedReportEntity> mesSemifinishedReports)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                foreach (var entity in mesSemifinishedReports)
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                    if (entity.F_ExStates == null)
                    {
                        entity.F_ExStates = 1;
                    }
                    if (entity.F_States == null)
                    {
                        entity.F_States = 1;
                    }
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                }
                await this.BaseRepository().Inserts(mesSemifinishedReports);
            }
            else
            {
                foreach (var entity in mesSemifinishedReports)
                {
                    entity.F_Id = keyValue;
                    entity.F_ModifyId = this.GetUserId();
                    entity.F_ModifyName = this.GetUserName();
                    entity.F_ModifyTime = DateTime.Now;
                }
                await this.BaseRepository().Updates(mesSemifinishedReports);
            }
        }
        #endregion
    }
}