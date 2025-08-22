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
    /// 日 期： 2023-08-18 16:15:01
    /// 描 述： 报工数据库执行类
    /// </summary>
    public class MesProcessReportService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProcessReportEntity, bool>>GetExpression(MesProcessReportEntity queryParams) {
            var exp = Expressionable.Create<MesProcessReportEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionTicketId), t => t.F_ProductionTicketId.Contains(queryParams.F_ProductionTicketId));
            if (queryParams.F_ReportableQuantity != null) {
                exp = exp.And(t => t.F_ReportableQuantity == queryParams.F_ReportableQuantity);
            }
            if (queryParams.F_ReportableNumber != null) {
                exp = exp.And(t => t.F_ReportableNumber == queryParams.F_ReportableNumber);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Specifications), t => t.F_Specifications.Contains(queryParams.F_Specifications));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialType), t => t.F_MaterialType.Contains(queryParams.F_MaterialType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialProperties), t => t.F_MaterialProperties.Contains(queryParams.F_MaterialProperties));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Equipment), t => t.F_Equipment.Contains(queryParams.F_Equipment));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessWorkstation), t => t.F_ProcessWorkstation.Contains(queryParams.F_ProcessWorkstation));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TeamManagementNumber), t => t.F_TeamManagementNumber.Contains(queryParams.F_TeamManagementNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TeamManagementName), t => t.F_TeamManagementName.Contains(queryParams.F_TeamManagementName));
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
        /// 获取报工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessReportEntity>>GetList(MesProcessReportEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessReportEntity>(expression);
        }
        /// <summary>
        /// 获取报工统计情况
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessReportEntity>> GetProcessReportList(Pagination pagination, MesProcessReportEntity queryParams)
        {
            return this.BaseRepository().FindListByQueryable<MesProcessReportEntity>(q =>
            {
                var queryable = q.LeftJoin<MesProductionTicketEntity>((t, t1) => t.F_ProductionTicketId == t1.F_Id)
                 .LeftJoin<CaseErpMaterialEntity>((t, t1, t2) => t1.F_ProductNumber == t2.F_Number)
                 .LeftJoin<BaseUserEntity>((t, t1, t2, t3) => t.F_CreatUserId == t3.F_UserId);
                var exp = GetExpression(queryParams);
                queryable = queryable.Where(exp);
                return queryable.Select((t, t1, t2, t3) => new MesProcessReportEntity()
                {
                    F_Id = t.F_Id,
                    F_Account = t3.F_Account,
                    F_ActualStartDate = t1.F_ActualStartDate,
                    F_ProdTicketNumber = t1.F_ProdTicketNumber,
                    F_ProductName = t1.F_ProductName,
                    F_ProductNumber = t.F_ProductNumber,
                    F_Specifications = t2.F_Model,
                    F_ReportableNumber = t.F_ReportableNumber,
                    F_Unit = t.F_Unit,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime
                });
            }, pagination);
        }
        /// <summary>
        /// 获取报工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessReportEntity>>GetPageList(Pagination pagination, MesProcessReportEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessReportEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessReportEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesProcessReportEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesProcessReportEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProcessReportEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessReportEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_CreatUserId = this.GetUserId();
                entity.F_CreatUserName = this.GetUserName();
                entity.F_CreatUserTime = DateTime.Now;
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