using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-29 17:24:38
    /// 描 述： 巡检异常报告数据库执行类
    /// </summary>
    public class MesInspectionExReportService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesInspectionExReportEntity, bool>>GetExpression(MesInspectionExReportEntity queryParams) {
            var exp = Expressionable.Create<MesInspectionExReportEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ExceptionNumber), t => t.F_ExceptionNumber.Contains(queryParams.F_ExceptionNumber));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ExceptionDescriptio), t => t.F_ExceptionDescriptio.Contains(queryParams.F_ExceptionDescriptio));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ExceptionLevel), t => t.F_ExceptionLevel.Contains(queryParams.F_ExceptionLevel));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DisposalJudgment), t => t.F_DisposalJudgment.Contains(queryParams.F_DisposalJudgment));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_JudgmentBase), t => t.F_JudgmentBase.Contains(queryParams.F_JudgmentBase));
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
        /// 获取巡检异常报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionExReportEntity>>GetList(MesInspectionExReportEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInspectionExReportEntity>(expression);
        }

        /// <summary>
        /// 获取巡检异常报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionExReportEntity>> GetListByIds(List<string> ids)
        {
            return this.BaseRepository().FindList<MesInspectionExReportEntity>(t=>ids.Contains(t.F_Id));
        }
        /// <summary>
        /// 获取巡检异常报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionExReportEntity>>GetPageList(Pagination pagination, MesInspectionExReportEntity queryParams) {
            return this.BaseRepository().FindListByQueryable<MesInspectionExReportEntity>(q => {
                var queryable = q.LeftJoin<MesInspectionReportEntity>((t, t1) => t.F_InspectionId == t1.F_Id)
                .LeftJoin<MesWorkshopInfoEntity>((t, t1, t2) => t1.F_WorkshopId == t2.F_Id)
                .LeftJoin<MesProductionLineEntity>((t, t1, t2, t3) => t1.F_ProductionLineId == t3.F_Id)
                .LeftJoin<MesTeamManagementEntity>((t, t1, t2, t3, t4) => t1.F_TeamManagementId == t4.F_Id);
                var exp = GetExpression(queryParams);
                queryable = queryable.Where(exp);
                return queryable.Select((t, t1, t2, t3, t4) => new MesInspectionExReportEntity()
                {
                    F_Id = t.F_Id,
                    F_ExceptionNumber = t.F_ExceptionNumber,
                    F_NumberState = t.F_NumberState,
                    F_InspectionId = t.F_InspectionId,
                    F_ExceptionDescriptio = t.F_ExceptionDescriptio,
                    F_ExceptionLevel = t.F_ExceptionLevel,
                    F_DisposalJudgment = t.F_DisposalJudgment,
                    F_JudgmentBase = t.F_JudgmentBase,
                    F_States = t.F_States,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime,
                    F_InspectionNumber = t1.F_InspectionNumber,
                    F_ReportHeader = t1.F_ReportHeader,
                    F_WorkshopName=t2.F_WorkshopName,
                    F_ProductionName=t3.F_ProductionName,
                    F_TeamManagementName=t4.F_TeamManagementName,
                    F_InspectionDate=t1.F_InspectionDate
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesInspectionExReportEntity>GetEntity(string keyValue)
        {
            var dataList = await this.BaseRepository().ORM.Queryable<MesInspectionExReportEntity>()
                .LeftJoin<MesInspectionReportEntity>((t, t1) => t.F_InspectionId == t1.F_Id)
                .LeftJoin<MesWorkshopInfoEntity>((t, t1,t2) => t1.F_WorkshopId == t2.F_Id)
                .LeftJoin<MesProductionLineEntity>((t, t1, t2,t3) => t1.F_ProductionLineId == t3.F_Id)
                .LeftJoin<MesTeamManagementEntity>((t, t1, t2, t3,t4) => t1.F_TeamManagementId == t4.F_Id)
                .Where(t => t.F_Id == keyValue)
                .Select((t, t1, t2, t3, t4) => new MesInspectionExReportEntity
                {
                    F_Id = t.F_Id,
                    F_ExceptionNumber = t.F_ExceptionNumber,
                    F_NumberState = t.F_NumberState,
                    F_InspectionId = t.F_InspectionId,
                    F_ExceptionDescriptio = t.F_ExceptionDescriptio,
                    F_ExceptionLevel = t.F_ExceptionLevel,
                    F_DisposalJudgment = t.F_DisposalJudgment,
                    F_JudgmentBase = t.F_JudgmentBase,
                    F_InspectionNumber = t1.F_InspectionNumber,
                    F_ReportHeader = t1.F_ReportHeader,
                    F_InspectionDate = t1.F_InspectionDate,
                    F_WorkshopName = t2.F_WorkshopName,
                    F_ProductionName = t3.F_ProductionName,
                    F_TeamManagementName = t4.F_TeamManagementName,
                    F_States = t.F_States,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserId = t.F_CreatUserId,
                    F_CreatUserTime = t.F_CreatUserTime,
                    F_ModifyId = t.F_ModifyId,
                    F_ModifyName = t.F_ModifyName,
                    F_ModifyTime = t.F_ModifyTime
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
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesInspectionExReportEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesInspectionExReportEntity>(keyValuesArr);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInspectionExReportEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                    if (entity.F_States == null)
                    {
                        entity.F_States = 1;
                    }
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                }
                await this.BaseRepository().Insert(entity);
            } else {
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