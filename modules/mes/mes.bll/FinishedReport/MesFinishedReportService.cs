using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using DocumentFormat.OpenXml.Drawing;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-30 17:20:47
    /// 描 述： 成品检验报告数据库执行类
    /// </summary>
    public class MesFinishedReportService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesFinishedReportEntity, bool>> GetExpression(MesFinishedReportEntity queryParams)
        {
            var exp = Expressionable.Create<MesFinishedReportEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FinishedNumber), t => t.F_FinishedNumber.Contains(queryParams.F_FinishedNumber));
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
            if (queryParams.F_SamplesNumber != null)
            {
                exp = exp.And(t => t.F_SamplesNumber == queryParams.F_SamplesNumber);
            }
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
        /// 获取成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedReportEntity>> GetList(MesFinishedReportEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesFinishedReportEntity>(expression);
        }
        /// <summary>
        /// 根据主键集合获取成品检验报告数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedReportEntity>> GetListByIds(List<string> ids)
        {
            return this.BaseRepository().FindList<MesFinishedReportEntity>(t => ids.Contains(t.F_Id));
        }

        /// <summary>
        /// 获取成品检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedReportEntity>> GetPageList(Pagination pagination, MesFinishedReportEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesFinishedReportEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesFinishedReportEntity> GetEntity(string keyValue)
        {
            var dataList = await  this.BaseRepository().ORM.Queryable<MesFinishedReportEntity>()
                 .LeftJoin<BaseUserEntity>((t, t1) => t.F_Inspector == t1.F_UserId)
                 .LeftJoin< MesFinishedDetailEntity >((t,t1,t2)=>t.F_Id==t2.F_FinishedId)
                 .LeftJoin< MesWorkshopInfoEntity >((t,t1,t2,t3)=>t2.F_WorkshopId==t3.F_Id)
                 .Where(t => t.F_Id == keyValue)
                 .Select((t, t1, t2, t3) => new MesFinishedReportEntity
                 {
                     F_Id=t.F_Id,
                     F_FinishedNumber=t.F_FinishedNumber,
                     F_InspectionDate=t.F_InspectionDate,
                     F_ReportHeader=t.F_ReportHeader,
                     F_InspectorName=t1.F_RealName,
                     F_Inspector=t.F_Inspector,
                     F_SamplingStandard=t.F_SamplingStandard,
                     F_SamplesNumber=t.F_SamplesNumber,
                     F_DetectionCategoryId=t.F_DetectionCategoryId,
                     F_DetectionItemId=t.F_DetectionItemId,
                     F_CalibrationStandard=t.F_CalibrationStandard,
                     F_DetectionMethodId=t.F_DetectionMethodId,
                     F_OveralJudgment=t.F_OveralJudgment,
                     F_IncomingInspectionNo=t.F_IncomingInspectionNo,
                     F_ExStates=t.F_ExStates,
                     F_States=t.F_States,
                     F_Remarks= t.F_Remarks,
                     F_CreatUserName=t.F_CreatUserName,
                     F_CreatUserTime= t.F_CreatUserTime,
                     F_ModifyName= t.F_ModifyName,
                     F_ModifyTime=t.F_ModifyTime,
                     F_TicketNumber= t2.F_TicketNumber,
                     F_ProductCode=t2.F_ProductCode,
                     F_ProductName=t2.F_ProductName,
                     F_SalesOrderNumber=t2.F_SalesOrderNumber,
                     F_WorkshopId=t3.F_WorkshopName
                 }).ToListAsync();
            if (dataList.Count > 0)
            {
                return dataList[0];
            }
            else
            {
                return null;
            }
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
            await this.BaseRepository().Delete<MesFinishedReportEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesFinishedReportEntity>(keyValuesArr);
        }
        /// <summary>
        /// 批量修改成品检验报告数据
        /// </summary>
        /// <param name="mesFinishedReports"></param>
        /// <returns></returns>

        public async Task UpdateList(List<MesFinishedReportEntity> mesFinishedReports)
        {
            await this.BaseRepository().Updates(mesFinishedReports);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesFinishedReportEntity entity)
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
        #endregion
    }
}