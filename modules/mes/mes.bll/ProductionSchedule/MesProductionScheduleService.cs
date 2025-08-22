using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using NPOI.POIFS.Properties;
using System.Linq;
using TencentCloud.Cme.V20191029.Models;
using NPOI.SS.Formula.Functions;
using OpenXmlPowerTools;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-15 09:40:10
    /// 描 述： 生产计划单数据库执行类
    /// </summary>
    public class MesProductionScheduleService : ServiceBase
    {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProductionScheduleEntity, bool>> GetExpression(MesProductionScheduleEntity queryParams)
        {
            var exp = Expressionable.Create<MesProductionScheduleEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionOrderId), t => t.F_ProductionOrderId.Contains(queryParams.F_ProductionOrderId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionScheNumber), t => t.F_ProductionScheNumber.Contains(queryParams.F_ProductionScheNumber));
            if (!string.IsNullOrEmpty(queryParams.F_LaunchDateQRange))
            {
                var f_LaunchDate_list = queryParams.F_LaunchDateQRange.Split(" - ");
                DateTime f_LaunchDate = Convert.ToDateTime(f_LaunchDate_list[0]);
                DateTime f_LaunchDate_end = Convert.ToDateTime(f_LaunchDate_list[1]);
                exp = exp.And(t => t.F_LaunchDate >= f_LaunchDate && t.F_LaunchDate <= f_LaunchDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            if (queryParams.F_States != null)
            {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Priority), t => t.F_Priority.Contains(queryParams.F_Priority));
            if (queryParams.F_PlannedOutput != null)
            {
                exp = exp.And(t => t.F_PlannedOutput == queryParams.F_PlannedOutput);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionOrderNumber), t => t.F_ProductionOrderNumber.Contains(queryParams.F_ProductionOrderNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number), t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkshopId), t => t.F_WorkshopId.Contains(queryParams.F_WorkshopId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionLineId), t => t.F_ProductionLineId.Contains(queryParams.F_ProductionLineId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessRoute), t => t.F_ProcessRoute.Contains(queryParams.F_ProcessRoute));
            if (!string.IsNullOrEmpty(queryParams.F_PlanStartDateQRange))
            {
                var f_PlanStartDate_list = queryParams.F_PlanStartDateQRange.Split(" - ");
                DateTime f_PlanStartDate = Convert.ToDateTime(f_PlanStartDate_list[0]);
                DateTime f_PlanStartDate_end = Convert.ToDateTime(f_PlanStartDate_list[1]);
                exp = exp.And(t => t.F_PlanStartDate >= f_PlanStartDate && t.F_PlanStartDate <= f_PlanStartDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_PlanEndDateQRange))
            {
                var f_PlanEndDate_list = queryParams.F_PlanEndDateQRange.Split(" - ");
                DateTime f_PlanEndDate = Convert.ToDateTime(f_PlanEndDate_list[0]);
                DateTime f_PlanEndDate_end = Convert.ToDateTime(f_PlanEndDate_list[1]);
                exp = exp.And(t => t.F_PlanEndDate >= f_PlanEndDate && t.F_PlanEndDate <= f_PlanEndDate_end);
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
        /// 获取生产计划单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionScheduleEntity>> GetList(MesProductionScheduleEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProductionScheduleEntity>(expression);
        }
        /// <summary>
        /// 根据主键集合获取计划单数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionScheduleEntity>> GetList(List<string> ids)
        {
            var exp = Expressionable.Create<MesProductionScheduleEntity>();
            exp = exp.And(t => ids.Contains(t.F_Id));
            return this.BaseRepository().FindList<MesProductionScheduleEntity>(exp.ToExpression());
        }
        /// <summary>
        /// 获取待计划产品信息
        /// </summary>
        /// <param name="materialId">物料主键</param>
        /// <param name="productDetailsId">订单详细主键</param>
        /// <returns></returns>
        public List<MesProductionScheduleEntity> GetToBeplannedList(string materialId, string productDetailsId)
        {
            var bomList = this.BaseRepository().ORM.Queryable<CaseErpBomEntity>().ToChildList(it => it.F_PId, materialId);
            var productList = bomList.Select(t => t.F_Number).ToList();
            var query = this.BaseRepository().ORM.Queryable<CaseErpMaterialEntity>()
                .LeftJoin<CaseErpMaterialclassesEntity>((t, t1) => t.F_Type == t1.F_Id)
                .LeftJoin<CaseErpMaterialpropertyEntity>((t, t1, t2) => t.F_Property == t2.F_Id)
                .LeftJoin<CaseErpUnitEntity>((t, t1, t2, t3) => t.F_Unit == t3.F_Id)
                .Where(t => productList.Contains(t.F_Number));
            return query.Select((t, t1, t2, t3) => new MesProductionScheduleEntity
            {
                F_ProductNumber = t.F_Number,
                F_ProductName = t.F_Name,
                F_SpecificationsModel = t.F_Model,
                F_MaterialType = t1.F_Type,
                F_MaterialProperty = t2.F_Type,
                F_Unit = t3.F_Name
            }).ToList();
        }
        /// <summary>
        /// 获取生产计划单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionScheduleEntity>> GetPageList(Pagination pagination, MesProductionScheduleEntity queryParams)
        {


            return this.BaseRepository().FindListByQueryable<MesProductionScheduleEntity>(q =>
            {
                var queryable = q.LeftJoin<MesWorkshopInfoEntity>((t, t1) => t.F_WorkshopId == t1.F_Id)
                 .LeftJoin<MesProductionLineEntity>((t, t1, t2) => t.F_ProductionLineId == t2.F_Id)
                 .LeftJoin<MesProcessRouteEntity>((t, t1, t2, t3) => t.F_ProcessRoute == t3.F_Id);
                var exp = GetExpression(queryParams);
                queryable = queryable.Where(exp);
                return queryable.Select((t, t1, t2, t3) => new MesProductionScheduleEntity()
                {
                    F_Id = t.F_Id,
                    F_ProductionDetailId = t.F_ProductionDetailId,
                    F_ProductionOrderId = t.F_ProductionOrderId,
                    F_ProductionScheNumber = t.F_ProductionScheNumber,
                    F_LaunchDate = t.F_LaunchDate,
                    F_ProductNumber = t.F_ProductNumber,
                    F_ProductName = t.F_ProductName,
                    F_States = t.F_States,
                    F_Priority = t.F_Priority,
                    F_PlannedOutput = t.F_PlannedOutput,
                    F_Unit = t.F_Unit,
                    F_SpecificationsModel = t.F_SpecificationsModel,
                    F_MaterialType = t.F_MaterialType,
                    F_MaterialProperty = t.F_MaterialProperty,
                    F_Level = t.F_Level,
                    F_ProductionOrderNumber = t.F_ProductionOrderNumber,
                    F_Number = t.F_Number,
                    F_WorkshopId = t.F_WorkshopId,
                    F_WorkshopName = t1.F_WorkshopName,
                    F_ProductionLineId = t.F_ProductionLineId,
                    F_ProductionLineName = t2.F_ProductionName,
                    F_ProcessRoute = t.F_ProcessRoute,
                    F_ProcessRouteName = t3.F_RouteName,
                    F_PlanStartDate = t.F_PlanStartDate,
                    F_PlanEndDate = t.F_PlanEndDate,
                    F_ReasonInvalidation = t.F_ReasonInvalidation,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionScheduleEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesProductionScheduleEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesProductionScheduleEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProductionScheduleEntity>(keyValuesArr);
        }

        /// <summary>
        /// 作废生产计划单
        /// </summary>
        /// <param name="cancelProductOrder"></param>
        /// <returns></returns>
        public async Task CancelEntity(CancelProductOrderDto cancelProductOrder)
        {
            List<string> keyValues = cancelProductOrder.F_Ids.Split(",").ToList();
            var datas = await this.GetList(keyValues);
            foreach (var item in datas)
            {
                if (item.F_States == 2)
                {
                    item.F_States = 4;
                }
                else if (item.F_States == 4)
                {
                    item.F_States = 4;
                }
                else
                {
                    item.F_States = 3;
                }
                item.F_ReasonInvalidation = cancelProductOrder.F_ReasonInvalidation;
            }
            await this.BaseRepository().Updates<MesProductionScheduleEntity>(datas.ToList());
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProductionScheduleEntity entity)
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
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task SaveListEntity(List<MesProductionScheduleEntity> mesProductionSchedules, string code)
        {
            await this.BaseRepository().Delete<MesProductionScheduleEntity>(t => t.F_ProductionScheNumber == code);
            foreach (var item in mesProductionSchedules)
            {
                if (string.IsNullOrEmpty(item.F_Id))
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_States = 1;
                    item.F_ProductionScheNumber = code;
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                }
            }
            await this.BaseRepository().Inserts(mesProductionSchedules);
        }
        /// <summary>
        /// 修改生产计划单状态
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesProductionScheduleEntity> mesProductionSchedules)
        {
            string code = mesProductionSchedules[0].F_ProductionScheNumber;
            await this.BaseRepository().Delete<MesProductionScheduleEntity>(t => t.F_ProductionScheNumber == code);
            foreach (var item in mesProductionSchedules)
            {
                item.F_Id = Guid.NewGuid().ToString();
                item.F_States = 1;
                item.F_ProductionScheNumber = code;
                item.F_CreatUserId = this.GetUserId();
                item.F_CreatUserName = this.GetUserName();
                item.F_CreatUserTime = DateTime.Now;
            }
            await this.BaseRepository().Inserts(mesProductionSchedules);
        }
        /// <summary>
        /// /生产工单数据修改
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task creatdGDuP(List<MesProductionScheduleEntity> mesProductionSchedules)
        {
            await this.BaseRepository().Updates(mesProductionSchedules);
        }
        #endregion
    }
}