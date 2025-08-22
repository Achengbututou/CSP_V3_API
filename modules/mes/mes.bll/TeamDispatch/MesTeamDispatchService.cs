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
using System.Linq;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-18 11:18:30
    /// 描 述： 班组派工数据库执行类
    /// </summary>
    public class MesTeamDispatchService : ServiceBase
    {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesTeamDispatchEntity, bool>> GetExpression(MesTeamDispatchEntity queryParams)
        {
            var exp = Expressionable.Create<MesTeamDispatchEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionTicketId), t => t.F_ProductionTicketId.Contains(queryParams.F_ProductionTicketId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TeamManagementNumber), t => t.F_TeamManagementNumber.Contains(queryParams.F_TeamManagementNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TeamManagementName), t => t.F_TeamManagementName.Contains(queryParams.F_TeamManagementName));
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
        /// 获取班组派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamDispatchEntity>> GetList(MesTeamDispatchEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesTeamDispatchEntity>(expression);
        }
        /// <summary>
        /// 获取工单班组派工信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamDispatchEntity>> GetTeamDispatchList(string keyValue)
        {

            return this.BaseRepository().FindListByQueryable<MesTeamDispatchEntity>(q => {
                var queryable = q.InnerJoin<MesTeamManagementEntity>((t, t1) => t.F_TeamManagementNumber == t1.F_TeamManagementNumber)
                .LeftJoin<MesTeamMembersEntity>((t, t1, t2) => t1.F_Id == t2.F_TeamManagementId && t2.F_IsTeamLeader == 1)
                .LeftJoin<MesWorkshopInfoEntity>((t, t1, t2, t3) => t1.F_WorkshopId == t3.F_Id)
                .LeftJoin<MesProductionLineEntity>((t, t1, t2, t3, t4) => t1.F_ProductionId == t4.F_Id)
                .Where(t => t.F_ProductionTicketId == keyValue);
                return queryable.Select((t, t1, t2, t3, t4) => new MesTeamDispatchEntity()
                {
                    F_Id = t.F_Id,
                    F_ProductionTicketId = t.F_ProductionTicketId,
                    F_TeamManagementName = t.F_TeamManagementName,
                    F_TeamManagementNumber = t.F_TeamManagementNumber,
                    F_WorkshopName = t3.F_WorkshopName,
                    F_ProductionName = t4.F_ProductionName,
                    F_TeamLeader = t2.F_UserName,
                    F_TeamPhone = t2.F_Tel,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime
                });
            });
        }

        /// <summary>
        /// 获取班组派工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamDispatchEntity>> GetPageList(Pagination pagination, MesTeamDispatchEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesTeamDispatchEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTeamDispatchEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesTeamDispatchEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesTeamDispatchEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            List<string> keyValuesArr = keyValues.Split(",").ToList();
            await this.BaseRepository().Delete<MesTeamDispatchEntity>(t => keyValuesArr.Contains(t.F_ProductionTicketId));
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesTeamDispatchEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_Id = keyValue;
                await this.BaseRepository().Update(entity);
            }
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="mesTeams"></param>
        /// <returns></returns>
        public async Task SaveListEntity(List<MesTeamDispatchEntity> mesTeams)
        {
            foreach (var item in mesTeams)
            {
                if (string.IsNullOrEmpty(item.F_Id))
                {
                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                }
            }
            await this.BaseRepository().Inserts(mesTeams);

        }
        #endregion
    }
}