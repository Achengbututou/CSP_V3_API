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
using mes.ibll.WarehousingInfo;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.SS.Formula.Functions;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-06 09:56:11
    /// 描 述： 出库管理数据库执行类
    /// </summary>
    public class MesOutboundDetailsService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesOutboundDetailsEntity, bool>> GetExpression(MesOutboundDetailsEntity queryParams)
        {
            var exp = Expressionable.Create<MesOutboundDetailsEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_OutboundInfoId))
            {
                exp = exp.And(t => t.F_OutboundInfoId == queryParams.F_OutboundInfoId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OutboundBatchNumber), t => t.F_OutboundBatchNumber.Contains(queryParams.F_OutboundBatchNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialType), t => t.F_MaterialType.Contains(queryParams.F_MaterialType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SpecificationsModels), t => t.F_SpecificationsModels.Contains(queryParams.F_SpecificationsModels));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId), t => t.F_WarehouseInfoId.Contains(queryParams.F_WarehouseInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReservoirAreaId), t => t.F_ReservoirAreaId.Contains(queryParams.F_ReservoirAreaId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_LibraryLocationId), t => t.F_LibraryLocationId.Contains(queryParams.F_LibraryLocationId));
            if (queryParams.F_UnitPrice != null)
            {
                exp = exp.And(t => t.F_UnitPrice == queryParams.F_UnitPrice);
            }
            if (queryParams.F_ThisQuantity != null)
            {
                exp = exp.And(t => t.F_ThisQuantity == queryParams.F_ThisQuantity);
            }
            if (queryParams.F_TotalAmount != null)
            {
                exp = exp.And(t => t.F_TotalAmount == queryParams.F_TotalAmount);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ProductionDateQRange))
            {
                var f_ProductionDate_list = queryParams.F_ProductionDateQRange.Split(" - ");
                DateTime f_ProductionDate = Convert.ToDateTime(f_ProductionDate_list[0]);
                DateTime f_ProductionDate_end = Convert.ToDateTime(f_ProductionDate_list[1]);
                exp = exp.And(t => t.F_ProductionDate >= f_ProductionDate && t.F_ProductionDate <= f_ProductionDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ExpirationDateQRange))
            {
                var f_ExpirationDate_list = queryParams.F_ExpirationDateQRange.Split(" - ");
                DateTime f_ExpirationDate = Convert.ToDateTime(f_ExpirationDate_list[0]);
                DateTime f_ExpirationDate_end = Convert.ToDateTime(f_ExpirationDate_list[1]);
                exp = exp.And(t => t.F_ExpirationDate >= f_ExpirationDate && t.F_ExpirationDate <= f_ExpirationDate_end);
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
        /// 获取出库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOutboundDetailsEntity>> GetList(MesOutboundDetailsEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesOutboundDetailsEntity>(expression);
        }
        /// <summary>
        /// 获取出库管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOutboundDetailsEntity>> GetPageList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesOutboundDetailsEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesOutboundDetailsEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesOutboundDetailsEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesOutboundDetailsEntity>(keyValue);
        }
        /// <summary>
        /// 删除出库管理的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key)
        {
            await this.BaseRepository().Delete<MesOutboundDetailsEntity>(t => t.F_OutboundInfoId == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesOutboundDetailsEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesOutboundDetailsEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
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
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesOutboundDetailsEntity> list)
        {
            var addList = new List<MesOutboundDetailsEntity>();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesOutboundDetailsEntity>(t => t.F_OutboundInfoId == key);
                foreach (var item in list)
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                    item.F_OutboundInfoId = key;
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

        #region 扩展操作
        /// <summary>
        /// 获取生产订单物料详情
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GETProductionTicketPList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {

            var queryable = this.BaseRepository().ORM.Queryable<MesProductionTicketEntity>()
                .LeftJoin<CaseErpMaterialEntity>((t, t1) => t.F_ProductNumber == t1.F_Number)
                .LeftJoin<MesInventoryLedgerEntity>((t, t1, t2) => t.F_ProductNumber == t2.F_ProductNumber);
            queryable.GroupBy((t, t1, t2) => new
            {
                t.F_Id,
                t.F_ProdTicketNumber,
                t.F_ProductNumber,
                t.F_ProductName,
                t1.F_Model,
                t1.F_Unit,
                t2.F_librariesNumber,
                t2.F_ReservoirAreaId,
                t2.F_LibraryLocationId,
                t2.F_WarehouseInfoId
            });
            var exp = Expressionable.Create<MesProductionTicketEntity, CaseErpMaterialEntity, MesInventoryLedgerEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId))
            {
                exp = exp.And((t, t1, t2) => t2.F_WarehouseInfoId == queryParams.F_WarehouseInfoId);
            }
            if (!string.IsNullOrEmpty(queryParams.Keyword))
            {
                exp = exp.And((t, t1, t2) => t.F_ProductNumber.Contains(queryParams.Keyword) || t.F_ProductName.Contains(queryParams.Keyword));
            }
            queryable.Where(exp.ToExpression());
            int allRows = 0;
            int index_ = 0;
            var dataList = queryable.Select((t, t1, t2) => new OutBoundProductInfoDTO
            {
                F_Id = SqlFunc.MergeString(t.F_Id, "-", index_.ToString()),
                F_ProdTicketNumber = t.F_ProdTicketNumber,
                F_ProductNumber = t.F_ProductNumber,
                F_ProductName = t.F_ProductName,
                F_SpecificationsModels = t1.F_Model,
                F_Unit = t1.F_Unit,
                F_WarehousedNumber = SqlFunc.AggregateSumNoNull(t2.F_librariesNumber),
                F_ReservoirAreaId = t2.F_ReservoirAreaId,
                F_LibraryLocationId = t2.F_LibraryLocationId
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            return dataList;
        }
        /// <summary>
        /// 获取采购订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GetPurchasedetailList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            var queryable = this.BaseRepository().ORM.Queryable<CaseErpPurchasedetailEntity>()
              .LeftJoin<MesInventoryLedgerEntity>((t, t1) => t.F_Number == t1.F_ProductNumber)
              .LeftJoin<MesOutboundInfoEntity>((t, t1, t2) => t.F_PurchaseId == t2.F_ProductId)
              .LeftJoin<MesOutboundDetailsEntity>((t, t1, t2, t3) => t2.F_Id == t3.F_OutboundInfoId);
            queryable.GroupBy((t, t1, t2, t3) => new
            {
                t.F_Id,
                t.F_Number,
                t.F_Name,
                t.F_Model,
                t.F_Unit,
                t.F_Price,
                t.F_Count,
                t1.F_librariesNumber,
                t1.F_ReservoirAreaId,
                t1.F_LibraryLocationId,
                t1.F_WarehouseInfoId,
                t3.F_ThisQuantity
            });
            var exp = Expressionable.Create<CaseErpPurchasedetailEntity, MesInventoryLedgerEntity, MesOutboundInfoEntity, MesOutboundDetailsEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId))
            {
                exp = exp.And((t, t1, t2, t3) => t1.F_WarehouseInfoId == queryParams.F_WarehouseInfoId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ProductId))
            {
                exp = exp.And((t, t1, t2, t3) => t.F_PurchaseId == queryParams.F_ProductId);
            }
            if (!string.IsNullOrEmpty(queryParams.Keyword))
            {
                exp = exp.And((t, t1, t2, t3) => t.F_Name.Contains(queryParams.Keyword) || t.F_Number.Contains(queryParams.Keyword));
            }
            queryable.Where(exp.ToExpression());
            int allRows = 0;
            int index_ = 0;
            var dataList = queryable.Select((t, t1, t2, t3) => new OutBoundProductInfoDTO
            {
                F_Id = SqlFunc.MergeString(t.F_Id, "-", index_.ToString()),
                F_ProductNumber = t.F_Number,
                F_ProductName = t.F_Name,
                F_SpecificationsModels = t.F_Model,
                F_Unit = t.F_Unit,
                F_UnitPrice = t.F_Price,
                F_Count = t.F_Count,
                F_WarehousedNumber = SqlFunc.AggregateSumNoNull(t1.F_librariesNumber),
                F_ThisQuantity = SqlFunc.AggregateSumNoNull(t3.F_ThisQuantity),
                F_ReservoirAreaId = t1.F_ReservoirAreaId,
                F_LibraryLocationId = t1.F_LibraryLocationId
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            return dataList;
        }
        /// <summary>
        /// 获取销售订单产品详细含已入库数量
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GetSalesDetailList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            var queryable = this.BaseRepository().ORM.Queryable<CaseErpSaledetailEntity>()
            .LeftJoin<MesInventoryLedgerEntity>((t, t1) => t.F_Number == t1.F_ProductNumber)
            .LeftJoin<MesOutboundInfoEntity>((t, t1, t2) => t.F_SaleId == t2.F_ProductId)
            .LeftJoin<MesOutboundDetailsEntity>((t, t1, t2, t3) => t2.F_Id == t3.F_OutboundInfoId);
            queryable.GroupBy((t, t1, t2, t3) => new
            {
                t.F_Id,
                t.F_Number,
                t.F_Name,
                t.F_Model,
                t.F_Unit,
                t.F_Price,
                t.F_Count,
                t1.F_librariesNumber,
                t1.F_ReservoirAreaId,
                t1.F_LibraryLocationId,
                t1.F_WarehouseInfoId,
                t3.F_ThisQuantity
            });
            var exp = Expressionable.Create<CaseErpSaledetailEntity, MesInventoryLedgerEntity, MesOutboundInfoEntity, MesOutboundDetailsEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId))
            {
                exp = exp.And((t, t1, t2, t3) => t1.F_WarehouseInfoId == queryParams.F_WarehouseInfoId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ProductId))
            {
                exp = exp.And((t, t1, t2, t3) => t.F_SaleId == queryParams.F_ProductId);
            }
            if (!string.IsNullOrEmpty(queryParams.Keyword))
            {
                exp = exp.And((t, t1, t2, t3) => t.F_Name.Contains(queryParams.Keyword) || t.F_Number.Contains(queryParams.Keyword));
            }
            queryable.Where(exp.ToExpression());
            int allRows = 0;
            int index_ = 0;
            var dataList = queryable.Select((t, t1, t2, t3) => new OutBoundProductInfoDTO
            {
                F_Id = SqlFunc.MergeString(t.F_Id, "-", index_.ToString()),
                F_ProductNumber = t.F_Number,
                F_ProductName = t.F_Name,
                F_SpecificationsModels = t.F_Model,
                F_Unit = t.F_Unit,
                F_UnitPrice = t.F_Price,
                F_Count = t.F_Count,
                F_WarehousedNumber = SqlFunc.AggregateSumNoNull(t1.F_librariesNumber),
                F_ThisQuantity = SqlFunc.AggregateSumNoNull(t3.F_ThisQuantity),
                F_ReservoirAreaId = t1.F_ReservoirAreaId,
                F_LibraryLocationId = t1.F_LibraryLocationId
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            return dataList;
        }
        /// <summary>
        /// 获取物料带库存
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public List<OutBoundProductInfoDTO> GetProductList(Pagination pagination, MesOutboundDetailsEntity queryParams)
        {
            var queryable = this.BaseRepository().ORM.Queryable<CaseErpMaterialEntity>()
             .LeftJoin<MesInventoryLedgerEntity>((t, t1) => t.F_Number == t1.F_ProductNumber);
            queryable.GroupBy((t, t1) => new
            {
                t.F_Id,
                t.F_Number,
                t.F_Name,
                t.F_Model,
                t.F_Unit,
                t1.F_librariesNumber,
                t1.F_ReservoirAreaId,
                t1.F_LibraryLocationId,
                t1.F_WarehouseInfoId
            });
            var exp = Expressionable.Create<CaseErpMaterialEntity, MesInventoryLedgerEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId))
            {
                exp = exp.And((t, t1) => t1.F_WarehouseInfoId == queryParams.F_WarehouseInfoId);
            }
            if (!string.IsNullOrEmpty(queryParams.Keyword))
            {
                exp = exp.And((t, t1) => t.F_Name.Contains(queryParams.Keyword) || t.F_Number.Contains(queryParams.Keyword));
            }
            queryable.Where(exp.ToExpression());
            int allRows = 0;
            int index_ = 0;
            var dataList = queryable.Select((t, t1) => new OutBoundProductInfoDTO
            {
                F_Id = SqlFunc.MergeString(t.F_Id, "-", index_.ToString()),
                F_ProductNumber = t.F_Number,
                F_ProductName = t.F_Name,
                F_SpecificationsModels = t.F_Model,
                F_Unit = t.F_Unit,
                F_WarehousedNumber = SqlFunc.AggregateSumNoNull(t1.F_librariesNumber),
                F_ReservoirAreaId = t1.F_ReservoirAreaId,
                F_LibraryLocationId = t1.F_LibraryLocationId
            }).ToPageList(pagination.page, pagination.rows, ref allRows);
            pagination.records = allRows;
            return dataList;
        }
        #endregion
    }
}