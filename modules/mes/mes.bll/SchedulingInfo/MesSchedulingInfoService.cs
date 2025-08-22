using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using Microsoft.Extensions.Primitives;
using System.Data;
using mes.ibll.SchedulingInfo;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using TencentCloud.Ic.V20190307.Models;
using System.Linq;
using DocumentFormat.OpenXml.Math;
using StackExchange.Redis;
using NPOI.SS.Formula.Functions;
using OpenXmlPowerTools;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-10 10:01:07
    /// 描 述： 排期信息数据库执行类
    /// </summary>
    public class MesSchedulingInfoService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesSchedulingInfoEntity, bool>> GetExpression(MesSchedulingInfoEntity queryParams)
        {
            var exp = Expressionable.Create<MesSchedulingInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SchedulingNumber), t => t.F_SchedulingNumber.Contains(queryParams.F_SchedulingNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IsSysNum), t => t.F_IsSysNum.Contains(queryParams.F_IsSysNum));
            if (queryParams.F_NumberState != null)
            {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SchedulingName), t => t.F_SchedulingName.Contains(queryParams.F_SchedulingName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Watchmaker), t => t.F_Watchmaker.Contains(queryParams.F_Watchmaker));
            if (!string.IsNullOrEmpty(queryParams.F_TabulationDateQRange))
            {
                var f_TabulationDate_list = queryParams.F_TabulationDateQRange.Split(" - ");
                DateTime f_TabulationDate = Convert.ToDateTime(f_TabulationDate_list[0]);
                DateTime f_TabulationDate_end = Convert.ToDateTime(f_TabulationDate_list[1]);
                exp = exp.And(t => t.F_TabulationDate >= f_TabulationDate && t.F_TabulationDate <= f_TabulationDate_end);
            }
            if (queryParams.F_ReleaseStatus != null)
            {
                exp = exp.And(t => t.F_ReleaseStatus == queryParams.F_ReleaseStatus);
            }
            if (queryParams.F_CompletionStatus != null)
            {
                exp = exp.And(t => t.F_CompletionStatus == queryParams.F_CompletionStatus);
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
        /// 获取排期信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSchedulingInfoEntity>> GetList(MesSchedulingInfoEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSchedulingInfoEntity>(expression);
        }
        /// <summary>
        /// 获取排期信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSchedulingInfoEntity>> GetPageList(Pagination pagination, MesSchedulingInfoEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesSchedulingInfoEntity>(expression, pagination);
        }

        /// <summary>
        /// 获取排期信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaleEntity>> GetERPPageList(Pagination pagination, CaseErpSaleEntity queryParams)
        {
            //var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSaleEntity>(pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSchedulingInfoEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesSchedulingInfoEntity>(keyValue);
        }
        /// <summary>
        /// 获取排期详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<MesSchedulingInfoEntity> GetDetailEntity(string keyValue)
        {
            var dataList = await this.BaseRepository().ORM.Queryable<MesSchedulingInfoEntity>()
               .LeftJoin<BaseUserEntity>((t, t1) => t.F_Watchmaker == t1.F_UserId)
               .Where(t => t.F_Id == keyValue)
               .Select((t, t1) => new MesSchedulingInfoEntity
               {
                   F_Id = t.F_Id,
                   F_SchedulingNumber = t.F_SchedulingNumber,
                   F_SchedulingName = t.F_SchedulingName,
                   F_Watchmaker = t1.F_RealName,
                   F_TabulationDate = t.F_TabulationDate,
                   F_ReleaseStatus = t.F_ReleaseStatus,
                   F_ReleaseStatusName = SqlFunc.IF(t.F_ReleaseStatus == 1).Return("未发布").End("已发布"),
                   F_CompletionStatus = t.F_CompletionStatus,
                   F_CompletionStatusName = SqlFunc.IF(t.F_CompletionStatus == 1).Return("未完成").End("已完成"),
                   F_Remarks = t.F_Remarks,
                   F_CreatUserName = t.F_CreatUserName,
                   F_CreatUserTime = t.F_CreatUserTime,
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
        /// <summary>
        /// 获取销售清单详情
        /// </summary>
        /// <returns></returns>
        public List<CaseSalesDTO> GetTableDataList(Pagination pagination, string Keyword)
        {
            var queryAble = this.BaseRepository().ORM.Queryable<CaseErpSaleEntity>()
                .LeftJoin<CaseErpSaledetailEntity>((t, t1) => t.F_Id == t1.F_SaleId)
                .LeftJoin<CaseErpCustomerEntity>((t, t1, t2) => t.F_ClientName == t2.F_Id)
                .LeftJoin<MesScheduleOrderDetailsEntity>((t, t1, t2, t3) => t.F_Number == t3.F_Number && t1.F_Number == t3.F_ProductNumber)
                .GroupBy((t, t1, t2, t3) => new
                {
                    t.F_Id,
                    t.F_Number,
                    t.F_Theme,
                    t2.F_Name,
                    t.F_SaleDate,
                    t1.F_DeliveryDate,
                    F_ProductNumber = t1.F_Number,
                    F_ProductName = t1.F_Name,
                    t1.F_Count,
                    t3.F_NumberSchedules
                });
            var exp = Expressionable.Create<CaseErpSaleEntity, CaseErpSaledetailEntity, CaseErpCustomerEntity, MesScheduleOrderDetailsEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(Keyword), (t, t1, t2, t3) => t.F_Number.Contains(Keyword)||t1.F_Number.Contains(Keyword)||t1.F_Name.Contains(Keyword)||t.F_Theme.Contains(Keyword)||t2.F_Name.Contains(Keyword));
            queryAble= queryAble.Where(exp.ToExpression());

            int allRows = 0;
            var dataList = queryAble.Select((t, t1, t2, t3) => new CaseSalesDTO
            {
                f_id = t.F_Id,
                f_number = t.F_Number,
                f_theme = t.F_Theme,
                f_clientname = t2.F_Name,
                f_saledate = t.F_SaleDate,
                f_deliverydate = t1.F_DeliveryDate,
                f_productnumber = t1.F_Number,
                f_productname = t1.F_Name,
                f_count = t1.F_Count,
                f_numberschedules = SqlFunc.AggregateSumNoNull(t3.F_NumberSchedules)

            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            foreach(var item in dataList)
            {
                item.f_noschedules = item.f_count - item.f_numberschedules;
            }
            return dataList;
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
            await this.BaseRepository().Delete<MesSchedulingInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesSchedulingInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSchedulingInfoEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CompletionStatus = null;
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                }
                entity.F_ReleaseStatus = 1;
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
        /// 删除排期详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task deleteDetail(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesScheduleDetailsEntity>(t => t.F_Id == keyValue);
                await db.Delete<MesScheduleOrderDetailsEntity>(t => t.F_SchedulingDetailId == keyValue);
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 排期工具排期情况保存
        /// 此处实际场景中需要验证订单的订单数量，按照使用方具体需求进行控制
        /// </summary>
        /// <returns></returns>
        public async Task SaveDetail(MesSchedulingDetailDTO mesSchedulingDetail)
        {
            var db = this.BaseRepository().BeginTrans();
            string F_SchedulingId = mesSchedulingDetail.F_SchedulingId;
            try
            {
                //await db.Delete<MesScheduleDetailsEntity>(t => t.F_SchedulingId == F_SchedulingId);
                //await db.Delete<MesScheduleOrderDetailsEntity>(t => t.F_SchedulingId == F_SchedulingId);
                List<MesScheduleDetailsEntity> mesScheduleDetails = new List<MesScheduleDetailsEntity>();
                List<MesScheduleOrderDetailsEntity> mesScheduleOrders = new List<MesScheduleOrderDetailsEntity>();
                var myDictionary = new Dictionary<string, string>();
                foreach (var item in mesSchedulingDetail.mesScheduleDetailsEntities)
                {
                    if (string.IsNullOrEmpty(item.F_Id))
                    {
                        item.F_Id = Guid.NewGuid().ToString();
                    }
                    item.F_SchedulingId = F_SchedulingId;
                    myDictionary.Add(item.F_DetailNumber, item.F_Id);
                    mesScheduleDetails.Add(item);
                }
                if (mesScheduleDetails.Count > 0)
                {
                    await db.Inserts(mesScheduleDetails);
                }
                foreach (var order in mesSchedulingDetail.mesScheduleOrderDetails)
                {
                    if (string.IsNullOrEmpty(order.F_Id))
                    {
                        order.F_Id = Guid.NewGuid().ToString();
                    }
                    order.F_SchedulingId = F_SchedulingId;
                    order.F_SchedulingDetailId = myDictionary.GetValueOrDefault(order.F_DetailNumber);
                    mesScheduleOrders.Add(order);
                }
                if (mesScheduleOrders.Count > 0)
                {
                    await db.Inserts(mesScheduleOrders);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}