using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： 工序管理数据库执行类
    /// </summary>
    public class MesProcessWorkstationService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesProcessWorkstationEntity, bool>> GetExpression(MesProcessWorkstationEntity queryParams)
        {
            var exp = Expressionable.Create<MesProcessWorkstationEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_ProcessManagementId))
            {
                exp = exp.And(t => t.F_ProcessManagementId == queryParams.F_ProcessManagementId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationId), t => t.F_WorkstationId.Contains(queryParams.F_WorkstationId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationNumber), t => t.F_WorkstationNumber.Contains(queryParams.F_WorkstationNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationName), t => t.F_WorkstationName.Contains(queryParams.F_WorkstationName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationPrincipal), t => t.F_WorkstationPrincipal.Contains(queryParams.F_WorkstationPrincipal));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PlantId), t => t.F_PlantId.Contains(queryParams.F_PlantId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkshopId), t => t.F_WorkshopId.Contains(queryParams.F_WorkshopId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionLineId), t => t.F_ProductionLineId.Contains(queryParams.F_ProductionLineId));
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
        /// 获取工序管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessWorkstationEntity>> GetList(MesProcessWorkstationEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessWorkstationEntity>(expression);
        }
        /// <summary>
        /// 获取工序管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessWorkstationEntity>> GetPageList(Pagination pagination, MesProcessWorkstationEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesProcessWorkstationEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessWorkstationEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesProcessWorkstationEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesProcessWorkstationEntity>(keyValue);
        }
        /// <summary>
        /// 删除工序管理的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key)
        {
            await this.BaseRepository().Delete<MesProcessWorkstationEntity>(t => t.F_ProcessManagementId == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesProcessWorkstationEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessWorkstationEntity entity)
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
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesProcessWorkstationEntity> list)
        {
            var addList = new List<MesProcessWorkstationEntity>();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesProcessWorkstationEntity>(t => t.F_ProcessManagementId == key);
                foreach (var item in list)
                {

                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_ModifyId = this.GetUserId();
                    item.F_ModifyName = this.GetUserName();
                    item.F_ModifyTime = DateTime.Now;

                    item.F_ProcessManagementId = key;
                    addList.Add(item);
                }
                if (addList.Count > 0)
                {
                    await db.Inserts(addList);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}