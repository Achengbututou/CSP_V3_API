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
    /// 日 期： 2023-09-05 15:51:41
    /// 描 述： 库存台账数据库执行类
    /// </summary>
    public class MesInventoryLedgerService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesInventoryLedgerEntity, bool>>GetExpression(MesInventoryLedgerEntity queryParams) {
            var exp = Expressionable.Create<MesInventoryLedgerEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialType), t => t.F_MaterialType.Contains(queryParams.F_MaterialType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SpecificationsModels), t => t.F_SpecificationsModels.Contains(queryParams.F_SpecificationsModels));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId), t => t.F_WarehouseInfoId.Contains(queryParams.F_WarehouseInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ReservoirAreaId), t => t.F_ReservoirAreaId.Contains(queryParams.F_ReservoirAreaId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_LibraryLocationId), t => t.F_LibraryLocationId.Contains(queryParams.F_LibraryLocationId));
            if (queryParams.F_librariesNumber != null) {
                exp = exp.And(t => t.F_librariesNumber == queryParams.F_librariesNumber);
            }
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
        /// 获取库存台账的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInventoryLedgerEntity>>GetList(MesInventoryLedgerEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInventoryLedgerEntity>(expression);
        }
        /// <summary>
        /// 获取库存台账的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInventoryLedgerEntity>>GetPageList(Pagination pagination, MesInventoryLedgerEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInventoryLedgerEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesInventoryLedgerEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesInventoryLedgerEntity>(keyValue);
        }
        /// <summary>
        /// 根据仓库获取库存情况
        /// </summary>
        /// <param name="F_WarehouseInfoId"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesInventoryLedgerEntity>> GetLedgerList(string F_WarehouseInfoId)
        {
            return this.BaseRepository().FindList<MesInventoryLedgerEntity>(t => t.F_WarehouseInfoId == F_WarehouseInfoId);
        }
        #endregion


        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesInventoryLedgerEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesInventoryLedgerEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInventoryLedgerEntity entity) {
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
        /// <summary>
        /// 入库操作
        /// </summary>
        /// <param name="mesInventoryLedgers"></param>
        /// <returns></returns>
        public async Task Warehousing(List<MesInventoryLedgerEntity> mesInventoryLedgers)
        {
            List<MesInventoryLedgerEntity> Addlist = new List<MesInventoryLedgerEntity>(); 
            List<MesInventoryLedgerEntity> Updatelist = new List<MesInventoryLedgerEntity>();
            foreach (MesInventoryLedgerEntity entity in mesInventoryLedgers)
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                    Addlist.Add(entity);
                }
                else
                {
                    entity.F_ModifyId = this.GetUserId();
                    entity.F_ModifyName = this.GetUserName();
                    entity.F_ModifyTime = DateTime.Now;
                    Updatelist.Add(entity);
                }
            }
            if(Addlist.Count > 0)
            {
                await this.BaseRepository().Inserts(Addlist);
            }
            if(Updatelist.Count > 0)
            {
                await this.BaseRepository().Updates(Updatelist);
            }
        }
        #endregion
    }
}