using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-18 11:18:30
    /// 描 述： 班组派工
    /// </summary>
    public class MesTeamDispatchBLL: BLLBase, IMesTeamDispatchBLL, BLL {
        private readonly MesTeamDispatchService mesTeamDispatchService = new MesTeamDispatchService();
        private readonly IMesProductionTicketBLL _iMesProductionTicketBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionTicketBLL">生产工单接口</param>
        public MesTeamDispatchBLL(IMesProductionTicketBLL iMesProductionTicketBLL)
        {
            _iMesProductionTicketBLL = iMesProductionTicketBLL ?? throw new ArgumentNullException(nameof(iMesProductionTicketBLL));
        }



        #region 获取数据
        /// <summary>
        /// 获取班组派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamDispatchEntity>>GetList(MesTeamDispatchEntity queryParams) {
            return mesTeamDispatchService.GetList(queryParams);
        }
        /// <summary>
        /// 获取工单班组派工信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamDispatchEntity>> GetTeamDispatchList(string keyValue)
        {
            return mesTeamDispatchService.GetTeamDispatchList(keyValue);
        }
        /// <summary>
        /// 获取班组派工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamDispatchEntity>>GetPageList(Pagination pagination, MesTeamDispatchEntity queryParams) {
            return mesTeamDispatchService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTeamDispatchEntity>GetEntity(string keyValue) {
            return mesTeamDispatchService.GetEntity(keyValue);
        }
        #endregion


        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesTeamDispatchService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesTeamDispatchService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesTeamDispatchEntity entity) {
            await mesTeamDispatchService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 班组派单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task TeamDispatch(MesTeamDispatchEntity entity)
        {
            List<string> ticketids = entity.F_ProductionTicketId.Split(',').ToList<string>();
           var mesProductionTickets = await _iMesProductionTicketBLL.GetListByIds(ticketids);
            List<MesProductionTicketEntity> productionTicketEntities = mesProductionTickets.ToList();
            List<MesTeamDispatchEntity> mesTeams = new List<MesTeamDispatchEntity>();
            foreach (var ticket in productionTicketEntities)
            {
                ticket.F_DispatchType = 1;//班组派单
                ticket.F_States = 2;
                MesTeamDispatchEntity mesTeamDispatch = new MesTeamDispatchEntity();
                mesTeamDispatch.F_ProductionTicketId = ticket.F_Id;
                mesTeamDispatch.F_TeamManagementName = entity.F_TeamManagementName;
                mesTeamDispatch.F_TeamManagementNumber = entity.F_TeamManagementNumber;
                mesTeamDispatch.F_Remarks = entity.F_Remarks;
                mesTeams.Add(mesTeamDispatch);  
            }
            mesTeamDispatchService.BeginTrans();
            try
            {
                await mesTeamDispatchService.Deletes(entity.F_ProductionTicketId);
                await mesTeamDispatchService.SaveListEntity(mesTeams);
                await _iMesProductionTicketBLL.UpdateListEntity(productionTicketEntities);
                mesTeamDispatchService.Commit();
            }
            catch (Exception)
            {
                mesTeamDispatchService.Rollback();
                throw;
            }
        }
        #endregion
    }
}