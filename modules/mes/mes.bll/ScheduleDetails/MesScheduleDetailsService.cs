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
    /// 日 期： 2023-08-10 10:15:58
    /// 描 述： 排期详情数据库执行类
    /// </summary>
    public class MesScheduleDetailsService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesScheduleDetailsEntity, bool>>GetExpression(MesScheduleDetailsEntity queryParams) {
            var exp = Expressionable.Create<MesScheduleDetailsEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SchedulingId), t => t.F_SchedulingId.Contains(queryParams.F_SchedulingId));
            if (!string.IsNullOrEmpty(queryParams.F_LaunchDateQRange)) {
                var f_LaunchDate_list = queryParams.F_LaunchDateQRange.Split(" - ");
                DateTime f_LaunchDate = Convert.ToDateTime(f_LaunchDate_list[0]);
                DateTime f_LaunchDate_end = Convert.ToDateTime(f_LaunchDate_list[1]);
                exp = exp.And(t => t.F_LaunchDate >= f_LaunchDate && t.F_LaunchDate <= f_LaunchDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductCode), t => t.F_ProductCode.Contains(queryParams.F_ProductCode));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            if (queryParams.F_NumberSchedules != null) {
                exp = exp.And(t => t.F_NumberSchedules == queryParams.F_NumberSchedules);
            }
            if (!string.IsNullOrEmpty(queryParams.F_TabulationDateQRange)) {
                var f_TabulationDate_list = queryParams.F_TabulationDateQRange.Split(" - ");
                DateTime f_TabulationDate = Convert.ToDateTime(f_TabulationDate_list[0]);
                DateTime f_TabulationDate_end = Convert.ToDateTime(f_TabulationDate_list[1]);
                exp = exp.And(t => t.F_TabulationDate >= f_TabulationDate && t.F_TabulationDate <= f_TabulationDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_OrderDateQRange)) {
                var f_OrderDate_list = queryParams.F_OrderDateQRange.Split(" - ");
                DateTime f_OrderDate = Convert.ToDateTime(f_OrderDate_list[0]);
                DateTime f_OrderDate_end = Convert.ToDateTime(f_OrderDate_list[1]);
                exp = exp.And(t => t.F_OrderDate >= f_OrderDate && t.F_OrderDate <= f_OrderDate_end);
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
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.KeyWord), t => t.F_ProductCode.Contains(queryParams.KeyWord) || t.F_ProductName.Contains(queryParams.KeyWord));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取排期详情的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesScheduleDetailsEntity>>GetList(MesScheduleDetailsEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesScheduleDetailsEntity>(expression);
        }
        /// <summary>
        /// 获取排期详情的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesScheduleDetailsEntity>>GetPageList(Pagination pagination, MesScheduleDetailsEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesScheduleDetailsEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesScheduleDetailsEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesScheduleDetailsEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesScheduleDetailsEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {

            string[] keyValuesArr = keyValues.Split(",");
           
            await this.BaseRepository().Delete<MesScheduleDetailsEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesScheduleDetailsEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_TabulationDate = DateTime.Now;   
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