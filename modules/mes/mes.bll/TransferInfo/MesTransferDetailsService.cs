using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-06 11:26:24
    /// 描 述： 调拨管理数据库执行类
    /// </summary>
    public class MesTransferDetailsService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesTransferDetailsEntity, bool>> GetExpression(MesTransferDetailsEntity queryParams)
        {
            var exp = Expressionable.Create<MesTransferDetailsEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_TransferInfoId))
            {
                exp = exp.And(t => t.F_TransferInfoId == queryParams.F_TransferInfoId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialType), t => t.F_MaterialType.Contains(queryParams.F_MaterialType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SpecificationsModels), t => t.F_SpecificationsModels.Contains(queryParams.F_SpecificationsModels));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TWarehouseInfoId), t => t.F_TWarehouseInfoId.Contains(queryParams.F_TWarehouseInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TReservoirAreaId), t => t.F_TReservoirAreaId.Contains(queryParams.F_TReservoirAreaId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TLibraryLocationId), t => t.F_TLibraryLocationId.Contains(queryParams.F_TLibraryLocationId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OWarehouseInfoId), t => t.F_OWarehouseInfoId.Contains(queryParams.F_OWarehouseInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OReservoirAreaId), t => t.F_OReservoirAreaId.Contains(queryParams.F_OReservoirAreaId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OLibraryLocationId), t => t.F_OLibraryLocationId.Contains(queryParams.F_OLibraryLocationId));
            if (queryParams.F_TransferQuantity != null)
            {
                exp = exp.And(t => t.F_TransferQuantity == queryParams.F_TransferQuantity);
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
        /// 获取调拨管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferDetailsEntity>> GetList(MesTransferDetailsEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesTransferDetailsEntity>(expression);
        }
        /// <summary>
        /// 获取调拨管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferDetailsEntity>> GetPageList(Pagination pagination, MesTransferDetailsEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesTransferDetailsEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTransferDetailsEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesTransferDetailsEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesTransferDetailsEntity>(keyValue);
        }
        /// <summary>
        /// 删除调拨管理的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key)
        {
            await this.BaseRepository().Delete<MesTransferDetailsEntity>(t => t.F_TransferInfoId == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesTransferDetailsEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesTransferDetailsEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                
                entity.F_Id = Guid.NewGuid().ToString();
                
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
        public async Task SaveList(string key, IEnumerable<MesTransferDetailsEntity> list)
        {
            var addList = new List<MesTransferDetailsEntity>();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesTransferDetailsEntity>(t => t.F_TransferInfoId == key);
                foreach (var item in list)
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                    item.F_TransferInfoId = key;
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