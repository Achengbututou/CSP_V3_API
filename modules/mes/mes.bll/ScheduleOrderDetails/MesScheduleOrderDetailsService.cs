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

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-10 10:23:21
    /// 描 述： 排期订单详情数据库执行类
    /// </summary>
    public class MesScheduleOrderDetailsService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesScheduleOrderDetailsEntity, bool>> GetExpression(MesScheduleOrderDetailsEntity queryParams) {
            var exp = Expressionable.Create<MesScheduleOrderDetailsEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SchedulingDetailId), t => t.F_SchedulingDetailId.Contains(queryParams.F_SchedulingDetailId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OrderId), t => t.F_OrderId.Contains(queryParams.F_OrderId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number), t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Theme), t => t.F_Theme.Contains(queryParams.F_Theme));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ClientName), t => t.F_ClientName.Contains(queryParams.F_ClientName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.KeyWord), t => t.F_Number.Contains(queryParams.KeyWord) || t.F_ProductNumber.Contains(queryParams.KeyWord)
            ||t.F_ProductName.Contains(queryParams.KeyWord)||t.F_Theme.Contains(queryParams.KeyWord));
            if (queryParams.F_OrderNumber != null) {
                exp = exp.And(t => t.F_OrderNumber == queryParams.F_OrderNumber);
            }
            if (queryParams.F_NumberSchedules != null) {
                exp = exp.And(t => t.F_NumberSchedules == queryParams.F_NumberSchedules);
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
        /// 获取排期订单详情的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesScheduleOrderDetailsEntity>>GetList(MesScheduleOrderDetailsEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesScheduleOrderDetailsEntity>(expression);
        }
        /// <summary>
        /// 获取排期订单详情的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesScheduleOrderDetailsEntity>>GetPageList(Pagination pagination, MesScheduleOrderDetailsEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesScheduleOrderDetailsEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesScheduleOrderDetailsEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesScheduleOrderDetailsEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesScheduleOrderDetailsEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesScheduleOrderDetailsEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesScheduleOrderDetailsEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                await this.BaseRepository().Insert(entity);
            } else {
                entity.F_Id = keyValue;
                await this.BaseRepository().Update(entity);
            }
        }
        #endregion
    }
}