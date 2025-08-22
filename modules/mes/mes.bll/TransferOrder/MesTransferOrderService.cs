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
    /// 日 期： 2023-09-18 15:09:45
    /// 描 述： 调拨列表数据库执行类
    /// </summary>
    public class MesTransferOrderService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesTransferOrderEntity, bool>>GetExpression(MesTransferOrderEntity queryParams) {
            var exp = Expressionable.Create<MesTransferOrderEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TransferOrderNumber), t => t.F_TransferOrderNumber.Contains(queryParams.F_TransferOrderNumber));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplicationId), t => t.F_ApplicationId.Contains(queryParams.F_ApplicationId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplicationNumber), t => t.F_ApplicationNumber.Contains(queryParams.F_ApplicationNumber));
            if (queryParams.F_IsRelated != null) {
                exp = exp.And(t => t.F_IsRelated == queryParams.F_IsRelated);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TransferTheme), t => t.F_TransferTheme.Contains(queryParams.F_TransferTheme));
            if (!string.IsNullOrEmpty(queryParams.F_TransferDateQRange)) {
                var f_TransferDate_list = queryParams.F_TransferDateQRange.Split(" - ");
                DateTime f_TransferDate = Convert.ToDateTime(f_TransferDate_list[0]);
                DateTime f_TransferDate_end = Convert.ToDateTime(f_TransferDate_list[1]);
                exp = exp.And(t => t.F_TransferDate >= f_TransferDate && t.F_TransferDate <= f_TransferDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ApplicationDepartment), t => t.F_ApplicationDepartment.Contains(queryParams.F_ApplicationDepartment));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Applicant), t => t.F_Applicant.Contains(queryParams.F_Applicant));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ContactNumber), t => t.F_ContactNumber.Contains(queryParams.F_ContactNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TransferWarehouse), t => t.F_TransferWarehouse.Contains(queryParams.F_TransferWarehouse));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CallOutWarehouse), t => t.F_CallOutWarehouse.Contains(queryParams.F_CallOutWarehouse));
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
        /// 获取调拨列表的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferOrderEntity>>GetList(MesTransferOrderEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesTransferOrderEntity>(expression);
        }
        /// <summary>
        /// 获取调拨列表的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferOrderEntity>>GetPageList(Pagination pagination, MesTransferOrderEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesTransferOrderEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTransferOrderEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesTransferOrderEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesTransferOrderEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesTransferOrderEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesTransferOrderEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                if (entity.F_States == null)
                {
                    entity.F_States = 1;
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
        #endregion
    }
}