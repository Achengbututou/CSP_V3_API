using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using TencentCloud.Cme.V20191029.Models;
using NPOI.SS.Formula.Functions;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-07 13:29:09
    /// 描 述： 工艺路线管理数据库执行类
    /// </summary>
    public class MesProcessRouteService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProcessRouteEntity, bool>>GetExpression(MesProcessRouteEntity queryParams) {
            var exp = Expressionable.Create<MesProcessRouteEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RouteNumber), t => t.F_RouteNumber.Contains(queryParams.F_RouteNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IsSysNum), t => t.F_IsSysNum.Contains(queryParams.F_IsSysNum));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RouteName), t => t.F_RouteName.Contains(queryParams.F_RouteName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductId), t => t.F_ProductId.Contains(queryParams.F_ProductId));
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
            if (!string.IsNullOrEmpty(queryParams.Keyword))
            {
                exp = exp.And(t => t.F_RouteNumber.Contains(queryParams.Keyword) || t.F_RouteName.Contains(queryParams.Keyword));
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取工艺路线管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>>GetList(MesProcessRouteEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessRouteEntity>(expression);
        }
        /// <summary>
        /// 根据商品编码获取工艺路线
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>> GETListByCode(string code)
        {
            return this.BaseRepository().FindListByQueryable<MesProcessRouteEntity>(q => {
                var queryable = q.InnerJoin<CaseErpMaterialEntity>((t, t1) => t.F_ProductId == t1.F_Id);
                var expression = Expressionable.Create<MesProcessRouteEntity, CaseErpMaterialEntity>()
                    .AndIF(!string.IsNullOrEmpty(code), (t, t1) => t1.F_Number==code).ToExpression();
                queryable = queryable.Where(expression);
                return queryable.Select((t, t1) => new MesProcessRouteEntity()
                {
                    F_Id = t.F_Id,
                    F_RouteNumber = t.F_RouteNumber,
                    F_RouteName = t.F_RouteName,
                    F_ProductId = t.F_ProductId,
                    F_Remarks = t.F_Remarks,
                    F_CommonState = t.F_CommonState,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime

                });
            });
        }

        /// <summary>
        /// 获取物料工艺路线
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>> GetPageAllList(Pagination pagination, MesProcessRouteEntity queryParams)
        {
            return this.BaseRepository().FindListByQueryable<MesProcessRouteEntity>(q => {
                var queryable = q.InnerJoin<CaseErpMaterialEntity>((t, t1) => t.F_ProductId == t1.F_Id);
                var expression = Expressionable.Create<MesProcessRouteEntity, CaseErpMaterialEntity>()
                     .AndIF(queryParams.F_ProductNumber != null, (t, t1) => t1.F_Number == queryParams.F_ProductNumber)
                     .AndIF(queryParams.F_RouteNumber != null, (t, t1) => t.F_RouteNumber == queryParams.F_RouteNumber)
                     .AndIF(queryParams.F_RouteName != null, (t, t1) => t.F_RouteName == queryParams.F_RouteName)
                        .AndIF(queryParams.F_ProductId != null, (t, t1) => t.F_ProductId == queryParams.F_ProductId)
                    .AndIF(!string.IsNullOrEmpty(queryParams.Keyword), (t, t1) => t.F_RouteName.Contains(queryParams.Keyword)||t.F_RouteNumber.Contains(queryParams.Keyword)).ToExpression();

                queryable = queryable.Where(expression);
                return queryable.Select((t, t1) => new MesProcessRouteEntity()
                {
                    F_Id = t.F_Id,
                    F_RouteNumber = t.F_RouteNumber,
                    F_RouteName = t.F_RouteName,
                    F_ProductId = t.F_ProductId,
                    F_CommonState=t.F_CommonState,
                    F_CreatUserName =t.F_CreatUserName,
                    F_Remarks=t.F_Remarks,
                    F_CreatUserTime =t.F_CreatUserTime
                });
            }, pagination);
          

        }
        /// <summary>
        /// 获取工艺路线管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>>GetPageList(Pagination pagination, MesProcessRouteEntity queryParams) {
            var expression = GetExpression(queryParams);

            return this.BaseRepository().FindList<MesProcessRouteEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessRouteEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesProcessRouteEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesProcessRouteEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProcessRouteEntity>(keyValuesArr);
        }
        /// <summary>
        /// 改变产品下的工艺路线的常用状态
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns></returns>
        public async Task SetCmmon(CommonInfoDTO commonInfo)
        {
            var listData = await this.GetList(new MesProcessRouteEntity { F_ProductId = commonInfo.F_ProductId });
            List<MesProcessRouteEntity> mesProcessRoutes = new List<MesProcessRouteEntity>();
            foreach (var item in listData)
            {
                if (commonInfo.F_CommonState == 1)
                {
                    if (item.F_Id == commonInfo.F_RouteId)
                    {
                        item.F_CommonState = 1;
                    }
                    else
                    {
                        item.F_CommonState = 0;
                    }
                }
                else
                {
                    item.F_CommonState = 0;
                }
                item.F_ModifyId = this.GetUserId();
                item.F_ModifyName = this.GetUserName();
                item.F_ModifyTime = DateTime.Now;
                mesProcessRoutes.Add(item);
            }
           await this.BaseRepository().Updates<MesProcessRouteEntity>(mesProcessRoutes);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessRouteEntity entity) {
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