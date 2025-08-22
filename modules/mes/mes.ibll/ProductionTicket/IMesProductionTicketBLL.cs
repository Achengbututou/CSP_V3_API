using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
using mes.ibll.WarehousingInfo;

namespace mes.ibll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-17 16:11:23
    /// 描 述： 生产工单
    /// </summary>
    public interface IMesProductionTicketBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取生产工单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionTicketEntity>>GetList(MesProductionTicketEntity queryParams);
        /// <summary>
        /// 根据主键获取工单信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionTicketEntity>> GetListByIds(List<string> ids);
        /// <summary>
        /// 获取生产工单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionTicketEntity>>GetPageList(Pagination pagination, MesProductionTicketEntity queryParams);
        /// <summary>
        /// 获取完成的工单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionTicketEntity>> GetPageListInprogress(Pagination pagination, MesProductionTicketEntity queryParams);
        /// <summary>
        /// 获取完成的成品工单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionTicketEntity>> GetPageListProgress(Pagination pagination, MesProductionTicketEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProductionTicketEntity>GetEntity(string keyValue);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProductionTicketEntity> GetEntityBySchedule(string keyValue);
        /// <summary>
        /// 获取生成统计情况
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        IEnumerable<MesProductionTicketEntity> GetProductionList(Pagination pagination, MesProductionTicketEntity queryParams);
        /// <summary>
        /// 获取生成订单入库情况
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        QueryReturnWareDTO GetWarehousingTicketList(Pagination pagination, MesProductionTicketEntity queryParams);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesProductionTicketEntity entity);
        /// <summary>
        /// 生产工单开工
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Task StartWork(StartWorkDTO startWorkDTO);
        /// <summary>
        /// 完成报告
        /// </summary>
        /// <param name="startWorkDTO"></param>
        /// <returns></returns>
        Task EndWork(StartWorkDTO startWorkDTO);
        /// <summary>
        /// 工单暂停
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task PauseTicket(string keyValue);
        /// <summary>
        /// 工单关闭
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task CloseTicket(string keyValue);
        /// <summary>
        /// 生产工单恢复
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Task RestoreWork(string keyValue);
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        Task SaveListEntity(List<MesProductionTicketEntity> mesProductionTickets);
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        Task UpdateListEntity(List<MesProductionTicketEntity> mesProductionTickets);
        /// <summary>
        /// 创建生产工单
        /// </summary>
        /// <param name="ticketSaveDTO"></param>
        /// <returns></returns>
        Task CreateTicket(ProductionTicketSaveDTO ticketSaveDTO);
        #endregion
    }
}