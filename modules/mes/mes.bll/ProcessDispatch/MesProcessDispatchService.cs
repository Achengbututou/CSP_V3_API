using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using TencentCloud.Cat.V20180409.Models;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-18 11:24:51
    /// 描 述： 工序派工数据库执行类
    /// </summary>
    public class MesProcessDispatchService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProcessDispatchEntity, bool>> GetExpression(MesProcessDispatchEntity queryParams)
        {
            var exp = Expressionable.Create<MesProcessDispatchEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionTicketId), t => t.F_ProductionTicketId.Contains(queryParams.F_ProductionTicketId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessRouteId), t => t.F_ProcessRouteId.Contains(queryParams.F_ProcessRouteId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProdTicketNumber), t => t.F_ProdTicketNumber.Contains(queryParams.F_ProdTicketNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessMaNumber), t => t.F_ProcessMaNumber.Contains(queryParams.F_ProcessMaNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProcessMaName), t => t.F_ProcessMaName.Contains(queryParams.F_ProcessMaName));
            if (queryParams.F_PlannedOutput != null)
            {
                exp = exp.And(t => t.F_PlannedOutput == queryParams.F_PlannedOutput);
            }
            if (queryParams.F_ProcessUnitprice != null)
            {
                exp = exp.And(t => t.F_ProcessUnitprice == queryParams.F_ProcessUnitprice);
            }
            if (queryParams.F_States != null)
            {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            if (queryParams.F_QuantityIndicated != null)
            {
                exp = exp.And(t => t.F_QuantityIndicated == queryParams.F_QuantityIndicated);
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
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>> GetList(MesProcessDispatchEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessDispatchEntity>(expression);
        }

        /// <summary>
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>> GetDispatchList(string keyValue)
        {
            var exp = Expressionable.Create<MesProcessDispatchEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(keyValue), t => t.F_ProductionTicketId.Contains(keyValue));
            exp = exp.And(t => t.F_States == 2 || t.F_States == 3);
            return this.BaseRepository().FindList<MesProcessDispatchEntity>(exp.ToExpression());
        }
        /// <summary>
        /// 根据主键集合获取数据
        /// </summary>
        /// <param name="productionTicketIds"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>> GetListByIds(List<string> ids, string ProductionTicketId)
        {
            return this.BaseRepository().FindList<MesProcessDispatchEntity>(t => ids.Contains(t.F_ProcessManagementId) && t.F_ProductionTicketId == ProductionTicketId);
        }
        /// <summary>
        /// 获取工序派工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>> GetPageList(Pagination pagination, MesProcessDispatchEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessDispatchEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessDispatchEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesProcessDispatchEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesProcessDispatchEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProcessDispatchEntity>(keyValuesArr);
        }
        /// <summary>
        /// 根据工单主键删除所有的工序派工信息
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task DeleteAllById(string keyValues)
        {
            await this.BaseRepository().Delete<MesProcessDispatchEntity>(t => t.F_ProductionTicketId == keyValues);
        }
        /// <summary>
        /// 批量保存工序派工信息
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        public async Task SaveList(List<MesProcessDispatchEntity> mesProcessDispatches)
        {
            bool IsAdd = false;
            foreach (var item in mesProcessDispatches)
            {
                if (string.IsNullOrEmpty(item.F_Id))
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                    IsAdd = true;
                }
                else
                {
                    item.F_ModifyId = this.GetUserId();
                    item.F_ModifyName = this.GetUserName();
                    item.F_ModifyTime = DateTime.Now;
                }
            }
            if (IsAdd)
            {
                await this.BaseRepository().Inserts<MesProcessDispatchEntity>(mesProcessDispatches);
            }
            else
            {
                await this.BaseRepository().Updates<MesProcessDispatchEntity>(mesProcessDispatches);
            }
        }
        /// <summary>
        /// 批量保存工序派工信息
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        public async Task AddList(List<MesProcessDispatchEntity> mesProcessDispatches)
        {
            foreach (var item in mesProcessDispatches)
            {

                item.F_Id = Guid.NewGuid().ToString();

                item.F_CreatUserId = this.GetUserId();
                item.F_CreatUserName = this.GetUserName();
                item.F_CreatUserTime = DateTime.Now;
            }
            await this.BaseRepository().Inserts<MesProcessDispatchEntity>(mesProcessDispatches);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessDispatchEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
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
        /// 多工序派工
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        public async Task DispatchEntity(List<string> ids)
        {
            var mesProcessDispatches = await this.BaseRepository().FindList<MesProcessDispatchEntity>(t => ids.Contains(t.F_Id));
            List<MesProcessDispatchEntity> mesProcessDispatchEntities = new List<MesProcessDispatchEntity>();
            foreach (var item in mesProcessDispatches)
            {
                item.F_States = 2;
                item.F_ModifyId = this.GetUserId();
                item.F_ModifyName = this.GetUserName();
                item.F_ModifyTime = DateTime.Now;
                mesProcessDispatchEntities.Add(item);
            }
            await this.BaseRepository().Updates<MesProcessDispatchEntity>(mesProcessDispatchEntities);
        }
        #endregion
    }
}