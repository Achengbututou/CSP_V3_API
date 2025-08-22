using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using mes.ibll.WarehousingInfo;
using System.Linq;
using mes.ibll.InspectionReport;
using NPOI.SS.Formula.Functions;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-23 09:44:54
    /// 描 述： 来料检验报告数据库执行类
    /// </summary>
    public class MesIncomingInspectionService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesIncomingInspectionEntity, bool>> GetExpression(MesIncomingInspectionEntity queryParams)
        {
            var exp = Expressionable.Create<MesIncomingInspectionEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReportNumber), t => t.F_ReportNumber.Contains(queryParams.F_ReportNumber));
            if (queryParams.F_NumberState != null)
            {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReportName), t => t.F_ReportName.Contains(queryParams.F_ReportName));
            if (!string.IsNullOrEmpty(queryParams.F_DeliveryDateQRange))
            {
                var f_DeliveryDate_list = queryParams.F_DeliveryDateQRange.Split(" - ");
                DateTime f_DeliveryDate = Convert.ToDateTime(f_DeliveryDate_list[0]);
                DateTime f_DeliveryDate_end = Convert.ToDateTime(f_DeliveryDate_list[1]);
                exp = exp.And(t => t.F_DeliveryDate >= f_DeliveryDate && t.F_DeliveryDate <= f_DeliveryDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_InspectionDateQRange))
            {
                var f_InspectionDate_list = queryParams.F_InspectionDateQRange.Split(" - ");
                DateTime f_InspectionDate = Convert.ToDateTime(f_InspectionDate_list[0]);
                DateTime f_InspectionDate_end = Convert.ToDateTime(f_InspectionDate_list[1]);
                exp = exp.And(t => t.F_InspectionDate >= f_InspectionDate && t.F_InspectionDate <= f_InspectionDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Inspector), t => t.F_Inspector.Contains(queryParams.F_Inspector));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierName), t => t.F_SupplierName.Contains(queryParams.F_SupplierName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchaseOrderNo), t => t.F_PurchaseOrderNo.Contains(queryParams.F_PurchaseOrderNo));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ShippingNumber), t => t.F_ShippingNumber.Contains(queryParams.F_ShippingNumber));
            if (queryParams.F_ReportType != null)
            {
                exp = exp.And(t => t.F_ReportType == queryParams.F_ReportType);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SamplingStandard), t => t.F_SamplingStandard.Contains(queryParams.F_SamplingStandard));
            if (queryParams.F_DeliveriesNumber != null)
            {
                exp = exp.And(t => t.F_DeliveriesNumber == queryParams.F_DeliveriesNumber);
            }
            if (queryParams.F_SamplesNumber != null)
            {
                exp = exp.And(t => t.F_SamplesNumber == queryParams.F_SamplesNumber);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IncomingInspectionNo), t => t.F_IncomingInspectionNo.Contains(queryParams.F_IncomingInspectionNo));
            if (queryParams.F_OveralJudgment != null)
            {
                exp = exp.And(t => t.F_OveralJudgment == queryParams.F_OveralJudgment);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_GoodsMethod), t => t.F_GoodsMethod.Contains(queryParams.F_GoodsMethod));
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
        /// 获取来料检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingInspectionEntity>> GetList(MesIncomingInspectionEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesIncomingInspectionEntity>(expression);
        }
        /// <summary>
        /// 获取来料检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingInspectionEntity>> GetPageList(Pagination pagination, MesIncomingInspectionEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesIncomingInspectionEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取来料报告数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingInspectionEntity>> GetList(List<string> ids)
        {
            var exp = Expressionable.Create<MesIncomingInspectionEntity>();
            exp = exp.And(t => ids.Contains(t.F_Id));
            return this.BaseRepository().FindList<MesIncomingInspectionEntity>(exp.ToExpression());
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesIncomingInspectionEntity> GetEntity(string keyValue)
        {
            var dataList = await this.BaseRepository().ORM.Queryable<MesIncomingInspectionEntity>()
                .LeftJoin<BaseUserEntity>((t, t1) => t.F_Inspector == t1.F_UserId)
                .Where(t => t.F_Id == keyValue)
                .Select((t, t1) => new MesIncomingInspectionEntity
                {
                    F_Id = t.F_Id,
                    F_ReportNumber = t.F_ReportNumber,
                    F_NumberState = t.F_NumberState,
                    F_ReportName = t.F_ReportName,
                    F_DeliveryDate = t.F_DeliveryDate,
                    F_InspectionDate = t.F_InspectionDate,
                    F_Inspector = t.F_Inspector,
                    F_InspectorName = t1.F_RealName,
                    F_SupplierName = t.F_SupplierName,
                    F_PurchaseOrderNo = t.F_PurchaseOrderNo,
                    F_ShippingNumber = t.F_ShippingNumber,
                    F_ReportType = t.F_ReportType,
                    F_SamplingStandard = t.F_SamplingStandard,
                    F_DeliveriesNumber = t.F_DeliveriesNumber,
                    F_SamplesNumber = t.F_SamplesNumber,
                    F_IncomingInspectionNo = t.F_IncomingInspectionNo,
                    F_OveralJudgment = t.F_OveralJudgment,
                    F_GoodsMethod = t.F_GoodsMethod,
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
        public async Task Delete(string keyValue)
        {
            await this.BaseRepository().Delete<MesIncomingInspectionEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesIncomingInspectionEntity>(keyValuesArr);
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="mesIncomingInspections"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesIncomingInspectionEntity> mesIncomingInspections)
        {
            await this.BaseRepository().Updates(mesIncomingInspections);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesIncomingInspectionEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                }
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

        #region 扩展 获取检测报表统计数据
        /// <summary>
        /// 获取检测报表数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public ResultTestReportDTO GetReportList(Pagination pagination, MesIncomingInspectionEntity queryParams)
        {
            ResultTestReportDTO queryReturnWare = new ResultTestReportDTO();
            var queryAble = this.BaseRepository().ORM.Queryable<MesIncomingByOrderEntity>()
                .LeftJoin<MesIncomingInspectionEntity>((t, t1) => t.F_IncomingInspectionId == t1.F_Id)
                .LeftJoin<CaseErpMaterialEntity>((t, t1, t2) => t.F_ProductNumber == t2.F_Number)
                .LeftJoin<CaseErpMaterialpropertyEntity>((t, t1, t2, t3) => t2.F_Property == t3.F_Id)
                .LeftJoin<CaseErpUnitEntity>((t, t1, t2, t3, t4) => t2.F_Unit == t4.F_Id);
            var exp = Expressionable.Create<MesIncomingByOrderEntity, MesIncomingInspectionEntity, CaseErpMaterialEntity, CaseErpMaterialpropertyEntity, CaseErpUnitEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_InspectionDateQRange))
            {
                var f_PlanStartDate_list = queryParams.F_InspectionDateQRange.Split(",");
                DateTime f_PlanStartDate = Convert.ToDateTime(f_PlanStartDate_list[0]);
                DateTime f_PlanStartDate_end = Convert.ToDateTime(f_PlanStartDate_list[1]);
                exp = exp.And((t, t1, t2, t3, t4) => t1.F_InspectionDate >= f_PlanStartDate && t1.F_InspectionDate <= f_PlanStartDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReportName), (t, t1, t2, t3, t4) => t.F_ProductNumber.Contains(queryParams.F_ReportName) || t.F_ProductName.Contains(queryParams.F_ReportName));
            queryAble.Where(exp.ToExpression());
            
            int allRows = 0;
           var dataList=  queryAble.Select((t, t1, t2, t3, t4) => new InpertionReportAllDTO
            {
                F_TestType = "来料检验",
                F_InspectionDate = t1.F_InspectionDate,
                F_Inspector = t1.F_CreatUserName,
                F_OveralJudgment = SqlFunc.IF(t.F_OveralJudgment == 1)
                                  .Return("合格").End("不合格"),
                F_ProductNumber = t.F_ProductNumber,
                F_ProductName = t.F_ProductName,
                F_ProductType = t3.F_Type,
                F_Model = t2.F_Model,
                F_Unit = t4.F_Name,
                F_QualifiedNumber = t.F_SamplesNumber
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            queryReturnWare.inpertionReport = dataList;
            queryReturnWare.Total = allRows;
            pagination.records = allRows;
            return queryReturnWare;
        }
        #endregion
    }
}