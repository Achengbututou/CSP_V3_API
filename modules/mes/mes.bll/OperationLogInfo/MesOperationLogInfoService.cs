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
    /// 日 期： 2023-09-15 15:37:57
    /// 描 述： 仓库操作日志数据库执行类
    /// </summary>
    public class MesOperationLogInfoService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesOperationLogInfoEntity, bool>>GetExpression(MesOperationLogInfoEntity queryParams) {
            var exp = Expressionable.Create<MesOperationLogInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FunctionModule), t => t.F_FunctionModule.Contains(queryParams.F_FunctionModule));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Operation), t => t.F_Operation.Contains(queryParams.F_Operation));
            if (!string.IsNullOrEmpty(queryParams.F_OperationTimeQRange)) {
                var f_OperationTime_list = queryParams.F_OperationTimeQRange.Split(" - ");
                DateTime f_OperationTime = Convert.ToDateTime(f_OperationTime_list[0]);
                DateTime f_OperationTime_end = Convert.ToDateTime(f_OperationTime_list[1]);
                exp = exp.And(t => t.F_OperationTime >= f_OperationTime && t.F_OperationTime <= f_OperationTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OperationInfo), t => t.F_OperationInfo.Contains(queryParams.F_OperationInfo));
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
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_OperationInfo.Contains(queryParams.Keyword)||t.F_Operation.Contains(queryParams.Keyword));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取仓库操作日志的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOperationLogInfoEntity>>GetList(MesOperationLogInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesOperationLogInfoEntity>(expression);
        }
        /// <summary>
        /// 获取仓库操作日志的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOperationLogInfoEntity>>GetPageList(Pagination pagination, MesOperationLogInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesOperationLogInfoEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesOperationLogInfoEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesOperationLogInfoEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesOperationLogInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesOperationLogInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesOperationLogInfoEntity entity) {
            entity.F_OperationTime = DateTime.Now;
            entity.F_Operation = this.GetUserName();
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                }
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