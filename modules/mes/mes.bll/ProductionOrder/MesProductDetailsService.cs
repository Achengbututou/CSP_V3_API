using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using System.Linq;
using NPOI.SS.Formula.Functions;
using OpenXmlPowerTools;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-15 09:12:40
    /// 描 述： 生产订单数据库执行类
    /// </summary>
    public class MesProductDetailsService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProductDetailsEntity, bool>> GetExpression(MesProductDetailsEntity queryParams)
        {
            var exp = Expressionable.Create<MesProductDetailsEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_ProductionOrderId))
            {
                exp = exp.And(t => t.F_ProductionOrderId == queryParams.F_ProductionOrderId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OrderId), t => t.F_OrderId.Contains(queryParams.F_OrderId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number), t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SpecificationsModels), t => t.F_SpecificationsModels.Contains(queryParams.F_SpecificationsModels));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            if (queryParams.F_PlannedOutput != null)
            {
                exp = exp.And(t => t.F_PlannedOutput == queryParams.F_PlannedOutput);
            }
            if (!string.IsNullOrEmpty(queryParams.F_LaunchDateQRange))
            {
                var f_LaunchDate_list = queryParams.F_LaunchDateQRange.Split(" - ");
                DateTime f_LaunchDate = Convert.ToDateTime(f_LaunchDate_list[0]);
                DateTime f_LaunchDate_end = Convert.ToDateTime(f_LaunchDate_list[1]);
                exp = exp.And(t => t.F_LaunchDate >= f_LaunchDate && t.F_LaunchDate <= f_LaunchDate_end);
            }
            if (queryParams.F_States != null)
            {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReasonInvalidation), t => t.F_ReasonInvalidation.Contains(queryParams.F_ReasonInvalidation));
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
        /// 获取生产订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductDetailsEntity>> GetList(MesProductDetailsEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProductDetailsEntity>(expression);
        }
        /// <summary>
        /// 获取生产订单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductDetailsEntity>> GetPageList(Pagination pagination, MesProductDetailsEntity queryParams)
        {

            return this.BaseRepository().FindListByQueryable<MesProductDetailsEntity>(q =>
            {
                var queryable = q.LeftJoin<MesProductionOrderEntity>((t, t1) => t.F_ProductionOrderId == t1.F_Id);
                var exp = Expressionable.Create<MesProductDetailsEntity, MesProductionOrderEntity>()
                    .AndIF(!string.IsNullOrEmpty(queryParams.F_Number), (t, t1) => t.F_Number.Contains(queryParams.F_Number))
                    .AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionOrderNumber), (t, t1) => t1.F_ProductionOrderNumber.Contains(queryParams.F_ProductionOrderNumber))
                    .AndIF(!string.IsNullOrEmpty(queryParams.F_Priority), (t, t1) => t1.F_Priority == queryParams.F_Priority)
                    .AndIF(queryParams.F_States != null, (t, t1) => t.F_States == queryParams.F_States)
                    .ToExpression();

                queryable = queryable.Where(exp);
                return queryable.Select((t, t1) => new MesProductDetailsEntity()
                {
                    F_Id = t.F_Id,
                    F_ProductionOrderId = t.F_ProductionOrderId,
                    F_Number = t.F_Number,
                    F_OrderId = t.F_OrderId,
                    F_ProductNumber = t.F_ProductNumber,
                    F_ProductName = t.F_ProductName,
                    F_SpecificationsModels = t.F_SpecificationsModels,
                    F_Unit = t.F_Unit,
                    F_PlannedOutput = t.F_PlannedOutput,
                    F_LaunchDate = t.F_LaunchDate,
                    F_States = t.F_States,
                    F_ReasonInvalidation = t.F_ReasonInvalidation,
                    F_Remarks = t1.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime,
                    F_ModifyName = t.F_ModifyName,
                    F_ProductionOrderNumber = t1.F_ProductionOrderNumber,
                    F_Priority = t1.F_Priority
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductDetailsEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesProductDetailsEntity>(keyValue);
        }
        /// <summary>
        /// 获取排期详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<MesProductDetailsEntity> GetDetailEntity(string keyValue)
        {

            var dataList = await this.BaseRepository().ORM.Queryable<MesProductDetailsEntity>()
                .LeftJoin<MesProductionOrderEntity>((t, t1) => t.F_ProductionOrderId == t1.F_Id)
                .LeftJoin<CaseErpMaterialEntity>((t, t1, t2) => t.F_ProductNumber == t2.F_Number)
            .Where(t => t.F_Id == keyValue)
                .Select((t, t1, t2) => new MesProductDetailsEntity
                {
                  F_Id=t.F_Id,
                  F_ProductionOrderId=t.F_ProductionOrderId,
                  F_LaunchDate=t.F_LaunchDate,
                  F_ProductNumber=t.F_ProductNumber,
                  F_ProductName=t.F_ProductName,
                  F_Priority=t1.F_Priority,
                  F_PlannedOutput=t.F_PlannedOutput,
                  F_SpecificationsModels=t.F_SpecificationsModels,
                  F_Unit=t.F_Unit,
                  F_MaterialId=t2.F_Id,
                F_ProductionOrderNumber=t1.F_ProductionOrderNumber,
                F_Number=t.F_Number,
                F_CreatUserName=t.F_CreatUserName,
                F_CreatUserTime=t.F_CreatUserTime,
                F_Remarks=t1.F_Remarks
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
            MesProductDetailsEntity mesProductDetails = await GetEntity(keyValue);
            if (mesProductDetails != null)
            {
                await this.BaseRepository().Delete<MesProductDetailsEntity>(keyValue);
                var tableList = await this.BaseRepository().FindList<MesProductDetailsEntity>(t => t.F_ProductionOrderId == mesProductDetails.F_ProductionOrderId);
                if (tableList.ToList().Count <= 1)
                {
                    await this.BaseRepository().Delete<MesProductionOrderEntity>(t => t.F_Id == mesProductDetails.F_ProductionOrderId);
                }
            }

        }
        /// <summary>
        /// 删除生产订单的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key)
        {
            await this.BaseRepository().Delete<MesProductDetailsEntity>(t => t.F_ProductionOrderId == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProductDetailsEntity>(keyValuesArr);
        }
        /// <summary>
        /// 作废生产订单
        /// </summary>
        /// <param name="cancelProductOrder"></param>
        /// <returns></returns>
        public async Task CancelProductOrder(CancelProductOrderDto cancelProductOrder)
        {
            var exp = Expressionable.Create<MesProductDetailsEntity>();
            string[] keyValuesArr = cancelProductOrder.F_Ids.Split(",");
            List<string> keyList = new List<string>();
            foreach (string key in keyValuesArr)
            {
                keyList.Add(key);
            }
            exp = exp.And(t => keyList.Contains(t.F_Id));
            IEnumerable<MesProductDetailsEntity> mesProductDetails = await this.BaseRepository().FindList<MesProductDetailsEntity>(exp.ToExpression());
            foreach (var item in mesProductDetails)
            {
                item.F_States = 3;
                item.F_ReasonInvalidation = cancelProductOrder.F_ReasonInvalidation;
            }
            List<MesProductDetailsEntity> mesProductDetailsEntities = mesProductDetails.ToList();
            await this.BaseRepository().Updates(mesProductDetailsEntities);

        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProductDetailsEntity entity)
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
        /// 计划生产订单详细
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task UpdateEntity(string keyValue)
        {
            var data = await this.GetEntity(keyValue);
            data.F_States = 2;
            await this.BaseRepository().Update(data);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesProductDetailsEntity> list)
        {
            var addList = new List<MesProductDetailsEntity>();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesProductDetailsEntity>(t => t.F_ProductionOrderId == key);
                foreach (var item in list)
                {

                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;

                    if (item.F_States == null)
                    {
                        item.F_States = 1;
                    }
                    item.F_ProductionOrderId = key;
                    addList.Add(item);
                }
                if (addList.Count > 0)
                {
                    await db.Inserts(addList);
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