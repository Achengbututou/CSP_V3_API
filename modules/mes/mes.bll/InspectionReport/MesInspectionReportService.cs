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
    /// 日 期： 2023-08-29 16:23:56
    /// 描 述： 巡检报告数据库执行类
    /// </summary>
    public class MesInspectionReportService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesInspectionReportEntity, bool>>GetExpression(MesInspectionReportEntity queryParams) {
            var exp = Expressionable.Create<MesInspectionReportEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_InspectionNumber), t => t.F_InspectionNumber.Contains(queryParams.F_InspectionNumber));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            if (!string.IsNullOrEmpty(queryParams.F_InspectionDateQRange)) {
                var f_InspectionDate_list = queryParams.F_InspectionDateQRange.Split(" - ");
                DateTime f_InspectionDate = Convert.ToDateTime(f_InspectionDate_list[0]);
                DateTime f_InspectionDate_end = Convert.ToDateTime(f_InspectionDate_list[1]);
                exp = exp.And(t => t.F_InspectionDate >= f_InspectionDate && t.F_InspectionDate <= f_InspectionDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReportHeader), t => t.F_ReportHeader.Contains(queryParams.F_ReportHeader));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkshopId), t => t.F_WorkshopId.Contains(queryParams.F_WorkshopId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionLineId), t => t.F_ProductionLineId.Contains(queryParams.F_ProductionLineId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TeamManagementId), t => t.F_TeamManagementId.Contains(queryParams.F_TeamManagementId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Inspector), t => t.F_Inspector.Contains(queryParams.F_Inspector));
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
        /// 获取巡检报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionReportEntity>>GetList(MesInspectionReportEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInspectionReportEntity>(expression);
        }
        /// <summary>
        /// 根据主键集合获取巡检报告数据
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionReportEntity>> GetListByIds(List<string> ids)
        {
            return this.BaseRepository().FindList<MesInspectionReportEntity>(t => ids.Contains(t.F_Id));
        }
        /// <summary>
        /// 获取巡检报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionReportEntity>>GetPageList(Pagination pagination, MesInspectionReportEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInspectionReportEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesInspectionReportEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesInspectionReportEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesInspectionReportEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesInspectionReportEntity>(keyValuesArr);
        }
        /// <summary>
        /// 批量修改巡检报告
        /// </summary>
        /// <param name="mesInspectionReports"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesInspectionReportEntity> mesInspectionReports)
        {
            await this.BaseRepository().Updates(mesInspectionReports);
        }
       
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInspectionReportEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
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