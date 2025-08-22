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
    /// 日 期： 2023-09-06 10:30:31
    /// 描 述： 盘点管理数据库执行类
    /// </summary>
    public class MesInventoryInfoService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesInventoryInfoEntity, bool>>GetExpression(MesInventoryInfoEntity queryParams) {
            var exp = Expressionable.Create<MesInventoryInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_InventoryNumber), t => t.F_InventoryNumber.Contains(queryParams.F_InventoryNumber));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            if (!string.IsNullOrEmpty(queryParams.F_InventoryDateQRange)) {
                var f_InventoryDate_list = queryParams.F_InventoryDateQRange.Split(" - ");
                DateTime f_InventoryDate = Convert.ToDateTime(f_InventoryDate_list[0]);
                DateTime f_InventoryDate_end = Convert.ToDateTime(f_InventoryDate_list[1]);
                exp = exp.And(t => t.F_InventoryDate >= f_InventoryDate && t.F_InventoryDate <= f_InventoryDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_InventoryTheme), t => t.F_InventoryTheme.Contains(queryParams.F_InventoryTheme));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId), t => t.F_WarehouseInfoId.Contains(queryParams.F_WarehouseInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_InventoryStaff), t => t.F_InventoryStaff.Contains(queryParams.F_InventoryStaff));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Annex), t => t.F_Annex.Contains(queryParams.F_Annex));
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
        /// 获取盘点管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInventoryInfoEntity>>GetList(MesInventoryInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInventoryInfoEntity>(expression);
        }
        /// <summary>
        /// 获取盘点管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInventoryInfoEntity>>GetPageList(Pagination pagination, MesInventoryInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInventoryInfoEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesInventoryInfoEntity>GetEntity(string keyValue)
        {
            var dataList = await this.BaseRepository().ORM.Queryable<MesInventoryInfoEntity>()
                .LeftJoin<BaseUserEntity>((t, t1) => t.F_InventoryStaff == t1.F_UserId)
                .Where(t => t.F_Id == keyValue)
                .Select((t, t1) => new MesInventoryInfoEntity
                {
                    F_Id = t.F_Id,
                    F_InventoryNumber = t.F_InventoryNumber,
                    F_NumberState = t.F_NumberState,
                    F_InventoryDate = t.F_InventoryDate,
                    F_InventoryTheme = t.F_InventoryTheme,
                    F_WarehouseInfoId = t.F_WarehouseInfoId,
                    F_InventoryStaff = t.F_InventoryStaff,
                    F_InventoryStaffName = t1.F_RealName,
                    F_Annex = t.F_Annex,
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
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesInventoryInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesInventoryInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInventoryInfoEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_States = 1;
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