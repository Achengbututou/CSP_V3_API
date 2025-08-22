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
using TencentCloud.Cme.V20191029.Models;
using TencentCloud.Dts.V20211206.Models;
using mes.ibll.WarehousingInfo;
using System.Linq;
using OpenXmlPowerTools;
using DocumentFormat.OpenXml.Wordprocessing;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-17 16:11:23
    /// 描 述： 生产工单数据库执行类
    /// </summary>
    public class MesProductionTicketService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProductionTicketEntity, bool>> GetExpression(MesProductionTicketEntity queryParams)
        {
            var exp = Expressionable.Create<MesProductionTicketEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProdTicketNumber), t => t.F_ProdTicketNumber.Contains(queryParams.F_ProdTicketNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IsSysNum), t => t.F_IsSysNum.Contains(queryParams.F_IsSysNum));
            if (queryParams.F_NumberState != null)
            {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionScheduleId), t => t.F_ProductionScheduleId.Contains(queryParams.F_ProductionScheduleId));
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
            if (!string.IsNullOrEmpty(queryParams.F_ActualStartDateQRange))
            {
                var f_ActualStartDate_list = queryParams.F_ActualStartDateQRange.Split(" - ");
                DateTime f_ActualStartDate = Convert.ToDateTime(f_ActualStartDate_list[0]);
                DateTime f_ActualStartDate_end = Convert.ToDateTime(f_ActualStartDate_list[1]);
                exp = exp.And(t => t.F_ActualStartDate >= f_ActualStartDate && t.F_ActualStartDate <= f_ActualStartDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ActualEndDateQRange))
            {
                var f_ActualEndDate_list = queryParams.F_ActualEndDateQRange.Split(" - ");
                DateTime f_ActualEndDate = Convert.ToDateTime(f_ActualEndDate_list[0]);
                DateTime f_ActualEndDate_end = Convert.ToDateTime(f_ActualEndDate_list[1]);
                exp = exp.And(t => t.F_ActualEndDate >= f_ActualEndDate && t.F_ActualEndDate <= f_ActualEndDate_end);
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
        /// 获取生产工单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetList(MesProductionTicketEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProductionTicketEntity>(expression);
        }
        /// <summary>
        /// 获取生成订单入库情况
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public QueryReturnWareDTO GetWarehousingTicketList(Pagination pagination, MesProductionTicketEntity queryParams)
        {
            QueryReturnWareDTO queryReturnWare = new QueryReturnWareDTO();
            var queryAble = this.BaseRepository().ORM.Queryable<MesProductionTicketEntity>()
                .LeftJoin<CaseErpMaterialEntity>((t, t1) => t.F_ProductNumber == t1.F_Number)
                .LeftJoin<MesWarehousingInfoEntity>((t, t1, t2) => t.F_Id == t2.F_PurchaseOrderId)
                .LeftJoin<MesWarehousingDetailsEntity>((t, t1, t2, t3) => t2.F_Id == t3.F_WarehouseInfoId)
                .GroupBy((t, t1, t2, t3) => new
                {
                    t.F_Id,
                    t.F_ProdTicketNumber,
                    t.F_ProductName,
                    t.F_ProductNumber,
                    t.F_Number,
                    t1.F_Model,
                    t1.F_Unit,
                    t.F_PlannedOutput,
                    t3.F_ThisQuantity
                });
            var exp = Expressionable.Create<MesProductionTicketEntity>();

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_ProductName.Contains(queryParams.F_Number) || t.F_ProductNumber.Contains(queryParams.Keyword));

            queryAble.Where(exp.ToExpression());
            int allRows = 0;
            var dataList = queryAble.Select((t, t1, t2, t3) => new WarehousingDetailsDTO
            {
                F_Id = t.F_Id,
                F_ProductNumber = t.F_ProductNumber,
                F_ProductName = t.F_ProductName,
                F_SpecificationsModels = t1.F_Model,
                F_Number = t.F_Number,
                F_Unit = t1.F_Unit,
                F_UnitPrice = 0,
                F_PlannedOutput = t.F_PlannedOutput,
                F_WarehousedNumber = SqlFunc.AggregateSumNoNull(t3.F_ThisQuantity),
                F_ProdTicketNumber = t.F_ProdTicketNumber
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            queryReturnWare.warehousingDetailsDTO = dataList;
            return queryReturnWare;
        }
        /// <summary>
        /// 获取生成统计情况
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public IEnumerable<MesProductionTicketEntity> GetProductionList(Pagination pagination, MesProductionTicketEntity queryParams)
        {
            var queryAble = this.BaseRepository().ORM.Queryable<MesProductionTicketEntity>()
                  .LeftJoin<CaseErpMaterialEntity>((t, t1) => t.F_ProductNumber == t1.F_Number)
                  .LeftJoin<MesProcessReportEntity>((t, t1, t2) => t.F_Id == t2.F_ProductionTicketId)
                  .LeftJoin<MesFinishedDetailEntity>((t, t1, t2, t3) => t.F_ProdTicketNumber == t3.F_TicketNumber)
                  .GroupBy((t, t1, t2, t3) => new
                  {
                      t.F_ActualStartDate,
                      t.F_ProductNumber,
                      t.F_ProductName,
                      t1.F_Model,
                      t1.F_Unit,
                      t.F_PlannedOutput,
                      t2.F_ReportableNumber,
                      t3.F_BadNumber
                  });
            var exp = Expressionable.Create<MesProductionTicketEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName) || t.F_ProductNumber.Contains(queryParams.F_ProductName));
            if (!string.IsNullOrEmpty(queryParams.F_PlanStartDateQRange))
            {
                var f_PlanStartDate_list = queryParams.F_PlanStartDateQRange.Split(",");
                DateTime f_PlanStartDate = Convert.ToDateTime(f_PlanStartDate_list[0]);
                DateTime f_PlanStartDate_end = Convert.ToDateTime(f_PlanStartDate_list[1]);
                exp = exp.And(t => t.F_ActualStartDate >= f_PlanStartDate && t.F_ActualStartDate <= f_PlanStartDate_end);
            }
            queryAble.Where(exp.ToExpression());
            int allRows = 0;
            var dataList = queryAble.Select((t, t1, t2, t3) => new MesProductionTicketEntity
            {
                F_ActualStartDate = t.F_ActualStartDate,
                F_ProductNumber = t.F_ProductNumber,
                F_ProductName = t.F_ProductName,
                F_Model = t1.F_Model,
                F_Unit = t1.F_Unit,
                F_PlannedOutput = t.F_PlannedOutput,
                F_ProductionQuantity = SqlFunc.AggregateSumNoNull(t2.F_ReportableNumber),
                F_QualifiedQuantity = SqlFunc.AggregateSumNoNull(t3.F_BadNumber)
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            foreach (var item in dataList)
            {
                decimal productionQuantity = item.F_ProductionQuantity.ToDecimal();
                decimal qualifiedQuantity = item.F_QualifiedQuantity.ToDecimal();
                item.F_QualifiedQuantity = item.F_ProductionQuantity - item.F_QualifiedQuantity;
                if (productionQuantity != 0)
                {
                    item.F_QualifiedRating = decimal.Round(((productionQuantity - qualifiedQuantity) / productionQuantity) * 100, 2).ToString();
                }
               
            }
            return dataList;
        }
        /// <summary>
        /// 根据主键获取工单信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetListByIds(List<string> ids)
        {
            var exp = Expressionable.Create<MesProductionTicketEntity>();
            exp = exp.And(t => ids.Contains(t.F_Id));
            return this.BaseRepository().FindList<MesProductionTicketEntity>(exp.ToExpression());
        }
        /// <summary>
        /// 获取生产工单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetPageList(Pagination pagination, MesProductionTicketEntity queryParams)
        {

            return this.BaseRepository().FindListByQueryable<MesProductionTicketEntity>(q =>
            {
                var queryable = q.LeftJoin<MesWorkshopInfoEntity>((t, t1) => t.F_WorkshopId == t1.F_Id)
                 .LeftJoin<MesProductionLineEntity>((t, t1, t2) => t.F_ProductionLineId == t2.F_Id)
                 .LeftJoin<MesProcessRouteEntity>((t, t1, t2, t3) => t.F_ProcessRoute == t3.F_Id);
                var exp = GetExpression(queryParams);
                queryable = queryable.Where(exp);
                return queryable.Select((t, t1, t2, t3) => new MesProductionTicketEntity()
                {
                    F_Id = t.F_Id,
                    F_ProdTicketNumber = t.F_ProdTicketNumber,
                    F_ProductionScheduleId = t.F_ProductionScheduleId,
                    F_ProductionOrderId = t.F_ProductionOrderId,
                    F_ProductionScheNumber = t.F_ProductionScheNumber,
                    F_LaunchDate = t.F_LaunchDate,
                    F_ProductNumber = t.F_ProductNumber,
                    F_ProductName = t.F_ProductName,
                    F_States = t.F_States,
                    F_Priority = t.F_Priority,
                    F_PlannedOutput = t.F_PlannedOutput,
                    F_Unit = t.F_Unit,
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
                    F_ActualStartDate = t.F_ActualStartDate,
                    F_ActualEndDate = t.F_ActualEndDate,
                    F_DispatchType = t.F_DispatchType,
                    F_StartWork = t.F_StartWork,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime
                });
            }, pagination);
        }
        /// <summary>
        /// 获取完成的半成品工单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetPageListInprogress(Pagination pagination, MesProductionTicketEntity queryParams)
        {

            return this.BaseRepository().FindListByQueryable<MesProductionTicketEntity>(q =>
            {
                var queryable = q.LeftJoin<MesWorkshopInfoEntity>((t, t1) => t.F_WorkshopId == t1.F_Id)
                 .LeftJoin<MesProductionLineEntity>((t, t1, t2) => t.F_ProductionLineId == t2.F_Id)
                 .LeftJoin<MesProcessRouteEntity>((t, t1, t2, t3) => t.F_ProcessRoute == t3.F_Id)
                 .LeftJoin<CaseErpMaterialEntity>((t, t1, t2, t3, t4) => t.F_ProductNumber == t4.F_Number)
                 .LeftJoin<CaseErpMaterialclassesEntity>((t, t1, t2, t3, t4, t5) => t4.F_Type == t5.F_Id);
                queryable.Where((t, t1, t2, t3, t4, t5) => t.F_States == 4 && t5.F_Type.Contains("半成品"));
                return queryable.Select((t, t1, t2, t3, t4, t5) => new MesProductionTicketEntity()
                {
                    F_Id = t.F_Id,
                    F_ProdTicketNumber = t.F_ProdTicketNumber,
                    F_ProductionScheduleId = t.F_ProductionScheduleId,
                    F_ProductionOrderId = t.F_ProductionOrderId,
                    F_ProductionScheNumber = t.F_ProductionScheNumber,
                    F_LaunchDate = t.F_LaunchDate,
                    F_ProductNumber = t.F_ProductNumber,
                    F_ProductName = t.F_ProductName,
                    F_States = t.F_States,
                    F_Priority = t.F_Priority,
                    F_PlannedOutput = t.F_PlannedOutput,
                    F_Unit = t.F_Unit,
                    F_ProductionOrderNumber = t.F_ProductionOrderNumber,
                    F_Number = t.F_Number,
                    F_WorkshopId = t.F_WorkshopId,
                    F_WorkshopName = t1.F_WorkshopName,
                    F_ProductionLineId = t.F_ProductionLineId,
                    F_ProcessRoute = t.F_ProcessRoute,
                    F_ProcessRouteName = t3.F_RouteName,
                    F_PlanStartDate = t.F_PlanStartDate,
                    F_PlanEndDate = t.F_PlanEndDate,
                    F_ActualStartDate = t.F_ActualStartDate,
                    F_ActualEndDate = t.F_ActualEndDate,
                    F_DispatchType = t.F_DispatchType,
                    F_StartWork = t.F_StartWork,
                    F_Remarks = t.F_Remarks,
                    F_TypeName = t5.F_Type,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime
                });
            }, pagination);
        }
        /// <summary>
        /// 获取完成的成品工单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetPageListProgress(Pagination pagination, MesProductionTicketEntity queryParams)
        {
            return this.BaseRepository().FindListByQueryable<MesProductionTicketEntity>(q =>
            {
                var queryable = q.LeftJoin<MesWorkshopInfoEntity>((t, t1) => t.F_WorkshopId == t1.F_Id)
                 .LeftJoin<MesProductionLineEntity>((t, t1, t2) => t.F_ProductionLineId == t2.F_Id)
                 .LeftJoin<MesProcessRouteEntity>((t, t1, t2, t3) => t.F_ProcessRoute == t3.F_Id)
                 .LeftJoin<CaseErpMaterialEntity>((t, t1, t2, t3, t4) => t.F_ProductNumber == t4.F_Number)
                 .LeftJoin<CaseErpMaterialclassesEntity>((t, t1, t2, t3, t4, t5) => t4.F_Type == t5.F_Id);
                queryable.Where((t, t1, t2, t3, t4, t5) => t.F_States == 4 && t5.F_Type.Contains("成品"));
                return queryable.Select((t, t1, t2, t3, t4, t5) => new MesProductionTicketEntity()
                {
                    F_Id = t.F_Id,
                    F_ProdTicketNumber = t.F_ProdTicketNumber,
                    F_ProductionScheduleId = t.F_ProductionScheduleId,
                    F_ProductionOrderId = t.F_ProductionOrderId,
                    F_ProductionScheNumber = t.F_ProductionScheNumber,
                    F_LaunchDate = t.F_LaunchDate,
                    F_ProductNumber = t.F_ProductNumber,
                    F_ProductName = t.F_ProductName,
                    F_States = t.F_States,
                    F_Priority = t.F_Priority,
                    F_PlannedOutput = t.F_PlannedOutput,
                    F_Unit = t.F_Unit,
                    F_ProductionOrderNumber = t.F_ProductionOrderNumber,
                    F_Number = t.F_Number,
                    F_WorkshopId = t.F_WorkshopId,
                    F_WorkshopName = t1.F_WorkshopName,
                    F_ProductionLineId = t.F_ProductionLineId,
                    F_ProcessRoute = t.F_ProcessRoute,
                    F_ProcessRouteName = t3.F_RouteName,
                    F_PlanStartDate = t.F_PlanStartDate,
                    F_PlanEndDate = t.F_PlanEndDate,
                    F_ActualStartDate = t.F_ActualStartDate,
                    F_ActualEndDate = t.F_ActualEndDate,
                    F_DispatchType = t.F_DispatchType,
                    F_StartWork = t.F_StartWork,
                    F_Remarks = t.F_Remarks,
                    F_TypeName = t5.F_Type,
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
        public async Task<MesProductionTicketEntity> GetEntity(string keyValue)
        {

            var dataList = await this.BaseRepository().ORM.Queryable<MesProductionTicketEntity>()
                   .LeftJoin<MesWorkshopInfoEntity>((t, t1) => t.F_WorkshopId == t1.F_Id)
                    .LeftJoin<MesProductionLineEntity>((t, t1, t2) => t.F_ProductionLineId == t2.F_Id)
                 .LeftJoin<MesProcessRouteEntity>((t, t1, t2, t3) => t.F_ProcessRoute == t3.F_Id)
                 .LeftJoin<CaseErpMaterialEntity>((t, t1, t2, t3, t4) => t.F_ProductNumber == t4.F_Number)
                  .LeftJoin<MesProcessReportEntity>((t, t1, t2, t3, t4, t5) => t.F_Id == t5.F_ProductionTicketId)
                  .GroupBy((t, t1, t2, t3, t4, t5) => new
                  {
                      t.F_Id,
                      t.F_ProdTicketNumber,
                      t.F_ProductionScheduleId,
                      t.F_ProductionOrderId,
                      t.F_ProductionScheNumber,
                      t.F_LaunchDate,
                      t.F_ProductNumber,
                      F_ProductId = t4.F_Id,
                      t.F_ProductName,
                      t.F_States,
                      t.F_Priority,
                      t.F_PlannedOutput,
                      t.F_Unit,
                      t.F_ProductionOrderNumber,
                      t.F_Number,
                      t.F_WorkshopId,
                      t1.F_WorkshopName,
                      t.F_ProductionLineId,
                      t2.F_ProductionName,
                      t.F_ProcessRoute,
                      t3.F_RouteName,
                      t.F_PlanStartDate,
                      t.F_PlanEndDate,
                      t.F_ActualStartDate,
                      t.F_ActualEndDate,
                      t.F_DispatchType,
                      t.F_StartWork,
                      t.F_Remarks,
                      t.F_CreatUserName,
                      t.F_CreatUserTime,
                      t5.F_ReportableNumber
                  })
                  .Where(t => t.F_Id == keyValue)
                  .Select((t, t1, t2, t3, t4, t5) => new MesProductionTicketEntity
                  {
                     F_Id=  t.F_Id,
                      F_ProdTicketNumber= t.F_ProdTicketNumber,
                      F_ProductionScheduleId=t.F_ProductionScheduleId,
                      F_ProductionOrderId= t.F_ProductionOrderId,
                      F_ProductionScheNumber=t.F_ProductionScheNumber,
                      F_LaunchDate=  t.F_LaunchDate,
                      F_ProductNumber= t.F_ProductNumber,
                      F_ProductId = t4.F_Id,
                      F_ProductName= t.F_ProductName,
                      F_States= t.F_States,
                      F_Priority= t.F_Priority,
                      F_PlannedOutput= t.F_PlannedOutput,
                      F_Unit= t.F_Unit,
                      F_ProductionOrderNumber= t.F_ProductionOrderNumber,
                      F_Number= t.F_Number,
                      F_WorkshopId= t.F_WorkshopId,
                      F_WorkshopName= t1.F_WorkshopName,
                      F_ProductionLineId= t.F_ProductionLineId,
                      F_ProcessRoute= t.F_ProcessRoute,
                      F_ProcessRouteName = t3.F_RouteName,
                      F_PlanStartDate= t.F_PlanStartDate,
                      F_PlanEndDate= t.F_PlanEndDate,
                      F_ActualStartDate=  t.F_ActualStartDate,
                      F_ActualEndDate= t.F_ActualEndDate,
                      F_DispatchType= t.F_DispatchType,
                      F_StartWork= t.F_StartWork,
                      F_Remarks= t.F_Remarks,
                      F_CreatUserName= t.F_CreatUserName,
                      F_CreatUserTime= t.F_CreatUserTime,
                      F_CompletedNumber = SqlFunc.AggregateSumNoNull(t5.F_ReportableNumber)

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
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionTicketEntity> GetEntityBySchedule(string keyValue)
        {
            return this.BaseRepository().FindEntity<MesProductionTicketEntity>(t => t.F_ProductionScheduleId == keyValue);
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
            await this.BaseRepository().Delete<MesProductionTicketEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProductionTicketEntity>(keyValuesArr);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProductionTicketEntity entity)
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
        public async Task SaveListEntity(List<MesProductionTicketEntity> mesProductionTickets)
        {
            foreach (var item in mesProductionTickets)
            {
                if (string.IsNullOrEmpty(item.F_Id))
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_States = 1;
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                }
            }
            await this.BaseRepository().Inserts(mesProductionTickets);
        }
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task UpdateListEntity(List<MesProductionTicketEntity> mesProductionTickets)
        {
            foreach (var item in mesProductionTickets)
            {
                item.F_ModifyId = this.GetUserId();
                item.F_ModifyName = this.GetUserName();
                item.F_ModifyTime = DateTime.Now;
            }
            await this.BaseRepository().Updates(mesProductionTickets);
        }
        #endregion
    }
}