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
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： 工序管理数据库执行类
    /// </summary>
    public class MesProcessManagementService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProcessManagementEntity, bool>>GetExpression(MesProcessManagementEntity queryParams) {
            var exp = Expressionable.Create<MesProcessManagementEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessMaNumber), t => t.F_ProcessMaNumber.Contains(queryParams.F_ProcessMaNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IsSysNum), t => t.F_IsSysNum.Contains(queryParams.F_IsSysNum));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessMaName), t => t.F_ProcessMaName.Contains(queryParams.F_ProcessMaName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessTypeId), t => t.F_ProcessTypeId.Contains(queryParams.F_ProcessTypeId));
            if (queryParams.F_PreparationHours != null) {
                exp = exp.And(t => t.F_PreparationHours == queryParams.F_PreparationHours);
            }
            if (queryParams.F_AuxiliaryHours != null) {
                exp = exp.And(t => t.F_AuxiliaryHours == queryParams.F_AuxiliaryHours);
            }
            if (queryParams.F_ProcessCost != null) {
                exp = exp.And(t => t.F_ProcessCost == queryParams.F_ProcessCost);
            }
            if (queryParams.F_ProcessUnitprice != null) {
                exp = exp.And(t => t.F_ProcessUnitprice == queryParams.F_ProcessUnitprice);
            }
            if (queryParams.F_ProcessState != null) {
                exp = exp.And(t => t.F_ProcessState == queryParams.F_ProcessState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Annex), t => t.F_Annex.Contains(queryParams.F_Annex));
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
            if (!string.IsNullOrEmpty(queryParams.Keyword))
            {
                exp = exp.And(t => t.F_ProcessMaNumber.Contains(queryParams.Keyword) || t.F_ProcessMaName.Contains(queryParams.Keyword));
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取工序管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>>GetList(MesProcessManagementEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessManagementEntity>(expression);
        }
        /// <summary>
        /// 获取工序
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>> GetProductNumberList(MesProcessManagementEntity queryParams)
        {
            return this.BaseRepository().FindListByQueryable<MesProcessManagementEntity>(q => {
                var queryable = q.InnerJoin<MesProceNodeRouteEntity>((t, t1) => t.F_Id == t1.fid);
                var expression = Expressionable.Create<MesProcessManagementEntity, MesProceNodeRouteEntity>()
                    .AndIF(queryParams.F_ProcessMaName != null, (t, t1) => t.F_ProcessMaName == queryParams.F_ProcessMaName)
                     .AndIF(queryParams.F_ProcessRouteId != null, (t, t1) => t1.F_ProcessRouteId == queryParams.F_ProcessRouteId)
                    .AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessMaNumber), (t, t1) => t.F_ProcessMaNumber.Contains(queryParams.F_ProcessMaNumber)).ToExpression();
                queryable = queryable.Where(expression);
                return queryable.Select((t, t1) => new MesProcessManagementEntity()
                {
                    F_Id = t.F_Id,
                    F_ProcessManagementId = t.F_Id,
                    F_ProcessMaNumber = t.F_ProcessMaNumber,
                    F_ProcessMaName = t.F_ProcessMaName,
                    F_PreparationHours = t.F_PreparationHours,
                    F_AuxiliaryHours = t.F_AuxiliaryHours,
                    F_ProcessCost = t.F_ProcessCost,
                    F_ProcessUnitprice = t.F_ProcessUnitprice,
                    F_CreatUserName = t1.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime

                });
            });
        }
        /// <summary>
        /// 获取工单工序数据工序
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>> GetProdTicketList(MesProcessManagementEntity queryParams)
        {
            return this.BaseRepository().FindListByQueryable<MesProcessManagementEntity>(q => {
                var queryable = q.InnerJoin<MesProcessDispatchEntity>((t, t1) => t.F_ProcessMaNumber == t1.F_ProcessMaNumber);
                var expression = Expressionable.Create<MesProcessManagementEntity, MesProcessDispatchEntity>()
                    .AndIF(queryParams.F_ProductionTicketId != null, (t, t1) => t1.F_ProductionTicketId == queryParams.F_ProductionTicketId)
                    .AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessMaNumber), (t, t1) => t1.F_ProcessMaNumber.Contains(queryParams.F_ProcessMaNumber)).ToExpression();
                queryable = queryable.Where(expression);
                return queryable.Select((t, t1) => new MesProcessManagementEntity()
                {
                    F_Id = t1.F_Id,
                    F_ProcessManagementId = t1.F_ProcessManagementId,
                    F_ProductionTicketId = t1.F_ProductionTicketId, 
                    F_ProcessMaNumber = t1.F_ProcessMaNumber,
                    F_ProcessMaName = t1.F_ProcessMaName,
                    F_ProdTicketNumber = t1.F_ProdTicketNumber,
                    F_PlannedOutput = t1.F_PlannedOutput,
                    F_ProcessUnitprice = t1.F_ProcessUnitprice,
                    F_States = t1.F_States,
                    F_QuantityIndicated=t1.F_QuantityIndicated, 
                    F_CreatUserName = t1.F_CreatUserName,
                    F_CreatUserTime = t1.F_CreatUserTime
                });
            });
        }
        /// <summary>
        /// 获取工序管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>>GetPageList(Pagination pagination, MesProcessManagementEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessManagementEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessManagementEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesProcessManagementEntity>(keyValue);
        }
        /// <summary>
        /// 获取排期详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<MesProcessManagementEntity> GetDetailEntity(string keyValue)
        {
            var dataList = await this.BaseRepository().ORM.Queryable<MesProcessManagementEntity>()
                .LeftJoin<MesProcessTypeEntity>((t, t1) => t.F_ProcessTypeId == t1.F_Id)
                .Where(t => t.F_Id == keyValue)
                .Select((t, t1) => new MesProcessManagementEntity
                {
                    F_Id = t.F_Id,
                    F_ProcessMaNumber = t.F_ProcessMaNumber,
                    F_ProcessMaName = t.F_ProcessMaName,
                    F_ProcessTypeId = t1.F_ProcessName,
                    F_PreparationHours = t.F_PreparationHours,
                    F_AuxiliaryHours = t.F_AuxiliaryHours,
                    F_ProcessCost = t.F_ProcessCost,
                    F_ProcessUnitprice = t.F_ProcessUnitprice,
                    F_Annex = t.F_Annex,
                    F_States = t.F_ProcessState,
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
            await this.BaseRepository().Delete<MesProcessManagementEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProcessManagementEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessManagementEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
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