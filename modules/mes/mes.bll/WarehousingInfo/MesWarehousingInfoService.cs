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
    /// 日 期： 2023-09-05 17:17:28
    /// 描 述： 入库管理数据库执行类
    /// </summary>
    public class MesWarehousingInfoService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesWarehousingInfoEntity, bool>>GetExpression(MesWarehousingInfoEntity queryParams) {
            var exp = Expressionable.Create<MesWarehousingInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehousingNumber), t => t.F_WarehousingNumber.Contains(queryParams.F_WarehousingNumber));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehousingType), t => t.F_WarehousingType.Contains(queryParams.F_WarehousingType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_InboundTheme), t => t.F_InboundTheme.Contains(queryParams.F_InboundTheme));
            if (!string.IsNullOrEmpty(queryParams.F_WarehousingDateQRange)) {
                var f_WarehousingDate_list = queryParams.F_WarehousingDateQRange.Split(" - ");
                DateTime f_WarehousingDate = Convert.ToDateTime(f_WarehousingDate_list[0]);
                DateTime f_WarehousingDate_end = Convert.ToDateTime(f_WarehousingDate_list[1]);
                exp = exp.And(t => t.F_WarehousingDate >= f_WarehousingDate && t.F_WarehousingDate <= f_WarehousingDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchaseOrderNo), t => t.F_PurchaseOrderNo.Contains(queryParams.F_PurchaseOrderNo));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Supplier), t => t.F_Supplier.Contains(queryParams.F_Supplier));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ContactPerson), t => t.F_ContactPerson.Contains(queryParams.F_ContactPerson));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ContactNumber), t => t.F_ContactNumber.Contains(queryParams.F_ContactNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchasingDe), t => t.F_PurchasingDe.Contains(queryParams.F_PurchasingDe));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PurchasingStaff), t => t.F_PurchasingStaff.Contains(queryParams.F_PurchasingStaff));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehouseInfoId), t => t.F_WarehouseInfoId.Contains(queryParams.F_WarehouseInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WarehousingStaff), t => t.F_WarehousingStaff.Contains(queryParams.F_WarehousingStaff));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RelatedItems), t => t.F_RelatedItems.Contains(queryParams.F_RelatedItems));
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
        /// 获取入库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehousingInfoEntity>>GetList(MesWarehousingInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesWarehousingInfoEntity>(expression);
        }
        /// <summary>
        /// 获取入库管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehousingInfoEntity>>GetPageList(Pagination pagination, MesWarehousingInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesWarehousingInfoEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesWarehousingInfoEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesWarehousingInfoEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesWarehousingInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesWarehousingInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesWarehousingInfoEntity entity) {
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