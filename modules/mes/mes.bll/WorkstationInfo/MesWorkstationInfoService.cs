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
    /// 日 期： 2023-07-27 15:35:03
    /// 描 述： 工位信息维护数据库执行类
    /// </summary>
    public class MesWorkstationInfoService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesWorkstationInfoEntity, bool>>GetExpression(MesWorkstationInfoEntity queryParams) {
            var exp = Expressionable.Create<MesWorkstationInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationNumber), t => t.F_WorkstationNumber.Contains(queryParams.F_WorkstationNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationName), t => t.F_WorkstationName.Contains(queryParams.F_WorkstationName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationPrincipal), t => t.F_WorkstationPrincipal.Contains(queryParams.F_WorkstationPrincipal));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PlantId), t => t.F_PlantId.Contains(queryParams.F_PlantId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkshopId), t => t.F_WorkshopId.Contains(queryParams.F_WorkshopId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionLineId), t => t.F_ProductionLineId.Contains(queryParams.F_ProductionLineId));
            if (queryParams.F_Level != null) {
                exp = exp.And(t => t.F_Level == queryParams.F_Level);
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
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_WorkstationNumber.Contains(queryParams.Keyword));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取工位信息维护的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWorkstationInfoEntity>>GetList(MesWorkstationInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesWorkstationInfoEntity>(expression);
        }
        /// <summary>
        /// 获取工位信息维护的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWorkstationInfoEntity>>GetPageList(Pagination pagination, MesWorkstationInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesWorkstationInfoEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取工位信息包含数据转换
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesWorkstationInfoEntity>> GetPageAllList(Pagination pagination, MesWorkstationInfoEntity queryParams)
        {
            return this.BaseRepository().FindListByQueryable<MesWorkstationInfoEntity>(q =>
            {
                var queryable = q.LeftJoin<MesPlantManagementEntity>((t, t1) => t.F_PlantId == t1.F_Id)
                 .LeftJoin<MesWorkshopInfoEntity>((t, t1, t2) => t.F_WorkshopId == t2.F_Id)
                 .LeftJoin<MesProductionLineEntity>((t, t1, t2, t3) => t.F_ProductionLineId == t3.F_Id);
                var exp = GetExpression(queryParams);
                queryable = queryable.Where(exp);
                return queryable.Select((t, t1, t2, t3) => new MesWorkstationInfoEntity()
                {
                    F_Id = t.F_Id,
                    F_WorkstationNumber = t.F_WorkstationNumber,
                    F_WorkstationName = t.F_WorkstationName,
                    F_PlantId = t.F_PlantId,
                    F_PlantName = t1.F_PlantName,
                    F_WorkshopId = t.F_WorkshopId,
                    F_ProductNumber = t2.F_WorkshopNumber,
                    F_WorkshopName = t2.F_WorkshopName,
                    F_ProductionLineId = t.F_ProductionLineId,
                    F_ProductionName = t3.F_ProductionName,
                    F_CreatUserTime = t.F_CreatUserTime
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesWorkstationInfoEntity>GetEntity(string keyValue) 
        {
            
            return this.BaseRepository().FindEntityByKey<MesWorkstationInfoEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesWorkstationInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesWorkstationInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesWorkstationInfoEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_Level = 4;
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