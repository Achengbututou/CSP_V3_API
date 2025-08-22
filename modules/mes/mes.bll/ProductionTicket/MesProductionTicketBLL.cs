using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using TencentCloud.Cme.V20191029.Models;
using SqlSugar;
using mes.ibll.WarehousingInfo;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-17 16:11:23
    /// 描 述： 生产工单
    /// </summary>
    public class MesProductionTicketBLL: BLLBase, IMesProductionTicketBLL, BLL {
        private readonly MesProductionTicketService mesProductionTicketService = new MesProductionTicketService();

        private readonly IMesProductionScheduleBLL _iMesProductionScheduleBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionScheduleBLL">生产计划单接口</param>
        public MesProductionTicketBLL(IMesProductionScheduleBLL iMesProductionScheduleBLL)
        {
            _iMesProductionScheduleBLL = iMesProductionScheduleBLL ?? throw new ArgumentNullException(nameof(iMesProductionScheduleBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取生产工单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>>GetList(MesProductionTicketEntity queryParams) {
            return mesProductionTicketService.GetList(queryParams);
        }
        /// <summary>
        /// 根据主键获取工单信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetListByIds(List<string> ids)
        {
            return mesProductionTicketService.GetListByIds(ids);
        }
        /// <summary>
        /// 获取生产工单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>>GetPageList(Pagination pagination, MesProductionTicketEntity queryParams) {
            return mesProductionTicketService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取完成的工单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetPageListInprogress(Pagination pagination, MesProductionTicketEntity queryParams)
        {
            return mesProductionTicketService.GetPageListInprogress(pagination, queryParams);
        }
        /// <summary>
        /// 获取完成的成品工单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionTicketEntity>> GetPageListProgress(Pagination pagination, MesProductionTicketEntity queryParams)
        {
            return mesProductionTicketService.GetPageListProgress(pagination, queryParams);
        }
        /// <summary>
        /// 获取生成订单入库情况
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public QueryReturnWareDTO GetWarehousingTicketList(Pagination pagination, MesProductionTicketEntity queryParams)
        {
            return mesProductionTicketService.GetWarehousingTicketList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionTicketEntity>GetEntity(string keyValue) {
            return mesProductionTicketService.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionTicketEntity> GetEntityBySchedule(string keyValue)
        {
            return mesProductionTicketService.GetEntityBySchedule(keyValue);    
        }
        /// <summary>
        /// 获取生成统计情况
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public IEnumerable<MesProductionTicketEntity> GetProductionList(Pagination pagination, MesProductionTicketEntity queryParams)
        {
             return  mesProductionTicketService.GetProductionList(pagination, queryParams);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProductionTicketService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProductionTicketService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProductionTicketEntity entity) {
            await mesProductionTicketService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 生产工单开工
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task StartWork(StartWorkDTO startWorkDTO)
        {
            var entity = await  this.GetEntity(startWorkDTO.fid);
            entity.F_ActualStartDate= startWorkDTO.dateTime;
            entity.F_StartWork = 2;
            entity.F_States = 3;
            await this.SaveEntity(startWorkDTO.fid, entity);    
        }

        /// <summary>
        /// 生产工单完成
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task EndWork(StartWorkDTO startWorkDTO)
        {
            var entity = await this.GetEntity(startWorkDTO.fid);
            entity.F_ActualEndDate = startWorkDTO.dateTime;
            entity.F_States = 4;//已完成
            entity.F_Remarks = startWorkDTO.F_Remarks;
            await this.SaveEntity(startWorkDTO.fid, entity);
        }
        /// <summary>
        /// 工单暂停
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task PauseTicket(string keyValue)
        {
            var entity = await this.GetEntity(keyValue);
            entity.F_States = 6;//暂停
            await this.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 工单关闭
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task CloseTicket(string keyValue)
        {
            var entity = await this.GetEntity(keyValue);
            entity.F_States = 5;//已关闭
            await this.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 生产工单恢复
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task RestoreWork(string keyValue)
        {
            var entity = await this.GetEntity(keyValue);
            entity.F_States = 3;//生成中
            await this.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task SaveListEntity(List<MesProductionTicketEntity> mesProductionTickets)
        {
            await mesProductionTicketService.SaveListEntity(mesProductionTickets);
        }
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task UpdateListEntity(List<MesProductionTicketEntity> mesProductionTickets)
        {
            await mesProductionTicketService.UpdateListEntity(mesProductionTickets);
        }
        /// <summary>
        /// 创建生产工单
        /// </summary>
        /// <param name="ticketSaveDTO"></param>
        /// <returns></returns>
        public async Task CreateTicket(ProductionTicketSaveDTO ticketSaveDTO)
        {
            MesProductionTicketEntity mesProductionTicket = ticketSaveDTO.mesProductionTicket;
            mesProductionTicket.F_ProdTicketNumber = (await GetRuleCodeEx(mesProductionTicket.F_ProdTicketNumber)).ToString();
            IEnumerable<MesProductionScheduleEntity> mesProductionSchedules = await _iMesProductionScheduleBLL.GetList(ticketSaveDTO.F_Ids);
            List<MesProductionScheduleEntity> list = new List<MesProductionScheduleEntity>();   
            List<MesProductionTicketEntity> productionTicketEntities = new List<MesProductionTicketEntity>();
            foreach (var item in mesProductionSchedules)
            {
                MesProductionTicketEntity productionTicketEntity = new MesProductionTicketEntity();
                productionTicketEntity.F_ProductionScheduleId = item.F_Id;
                productionTicketEntity.F_ProductionOrderId = item.F_ProductionOrderId;
                productionTicketEntity.F_ProductionScheNumber=item.F_ProductionScheNumber;
                productionTicketEntity.F_LaunchDate = item.F_LaunchDate;
                productionTicketEntity.F_ProductNumber = item.F_ProductNumber;
                productionTicketEntity.F_ProductName=item.F_ProductName;
                productionTicketEntity.F_States = 1;
                productionTicketEntity.F_Priority = item.F_Priority;
                productionTicketEntity.F_Unit = item.F_Unit;
                productionTicketEntity.F_ProductionOrderNumber = item.F_ProductionOrderNumber;
                productionTicketEntity.F_Number = item.F_Number;
                productionTicketEntity.F_WorkshopId = item.F_WorkshopId;
                productionTicketEntity.F_ProductionLineId = item.F_ProductionLineId;
                productionTicketEntity.F_ProcessRoute = item.F_ProcessRoute;
                productionTicketEntity.F_PlanStartDate = mesProductionTicket.F_PlanStartDate;
                item.F_PlanStartDate = mesProductionTicket.F_PlanStartDate;
                productionTicketEntity.F_PlanEndDate = mesProductionTicket.F_PlanEndDate;
                item.F_PlanEndDate = mesProductionTicket.F_PlanEndDate; 
                productionTicketEntity.F_PlannedOutput = item.F_PlannedOutput;
                productionTicketEntity.F_ProdTicketNumber = mesProductionTicket.F_ProdTicketNumber;
                productionTicketEntity.F_Remarks = mesProductionTicket.F_Remarks;
                productionTicketEntity.F_DispatchType = 0;
                productionTicketEntities.Add(productionTicketEntity);
                item.F_States = 2;
                list.Add(item);
            }
            mesProductionTicketService.BeginTrans();
            try
            {
                await this.SaveListEntity(productionTicketEntities);
                await _iMesProductionScheduleBLL.creatdGDuP(list);
                mesProductionTicketService.Commit();
            }
            catch (Exception)
            {
                mesProductionTicketService.Rollback();
                throw;
            }
        }
        #endregion
    }
}