using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using NPOI.SS.Formula.Functions;
using System.Linq;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-18 11:31:18
    /// 描 述： 工序派工物料数据库执行类
    /// </summary>
    public class MesProcessMaterialInfoService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProcessMaterialInfoEntity, bool>>GetExpression(MesProcessMaterialInfoEntity queryParams) {
            var exp = Expressionable.Create<MesProcessMaterialInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionTicketId), t => t.F_ProductionTicketId.Contains(queryParams.F_ProductionTicketId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessRouteId), t => t.F_ProcessRouteId.Contains(queryParams.F_ProcessRouteId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductNumber), t => t.F_ProductNumber.Contains(queryParams.F_ProductNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Specifications), t => t.F_Specifications.Contains(queryParams.F_Specifications));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialType), t => t.F_MaterialType.Contains(queryParams.F_MaterialType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialProperties), t => t.F_MaterialProperties.Contains(queryParams.F_MaterialProperties));
            if (queryParams.F_DemandQuantity != null) {
                exp = exp.And(t => t.F_DemandQuantity == queryParams.F_DemandQuantity);
            }
            if (queryParams.F_ReceivedQuantity != null) {
                exp = exp.And(t => t.F_ReceivedQuantity == queryParams.F_ReceivedQuantity);
            }
            if (queryParams.F_LackMaterial != null) {
                exp = exp.And(t => t.F_LackMaterial == queryParams.F_LackMaterial);
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
        /// 获取工序派工物料的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessMaterialInfoEntity>>GetList(MesProcessMaterialInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessMaterialInfoEntity>(expression);
        }
        /// <summary>
        /// 获取本级及下级物料信息
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        public async Task<List<MesProcessMaterialInfoEntity>> GetChildrenList(string KeyValue)
        {

            var bomList = this.BaseRepository().ORM.Queryable<CaseErpBomEntity>().ToChildList(it => it.F_PId, KeyValue);
            var productList = bomList.Select(t => t.F_Number).ToList();
            var query = this.BaseRepository().ORM.Queryable<CaseErpMaterialEntity>()
                .LeftJoin<CaseErpMaterialclassesEntity>((t, t1) => t.F_Type == t1.F_Id)
                .LeftJoin<CaseErpMaterialpropertyEntity>((t, t1, t2) => t.F_Property == t2.F_Id)
                .LeftJoin<CaseErpUnitEntity>((t, t1, t2, t3) => t.F_Unit == t3.F_Id)
                .Where(t => productList.Contains(t.F_Number));
            return await query.Select((t, t1, t2, t3) => new MesProcessMaterialInfoEntity
            {
                F_ProductNumber = t.F_Number,
                F_ProductName = t.F_Name,
                F_Specifications = t.F_Model,
                F_MaterialType = t1.F_Type,
                F_MaterialProperties = t2.F_Type,
                F_Unit = t3.F_Name
            }).ToListAsync();
        }

        /// <summary>
        /// 获取工序派工物料的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessMaterialInfoEntity>>GetPageList(Pagination pagination, MesProcessMaterialInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessMaterialInfoEntity>(expression, pagination);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessMaterialInfoEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesProcessMaterialInfoEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesProcessMaterialInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProcessMaterialInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessMaterialInfoEntity entity) {
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
        #endregion
    }
}