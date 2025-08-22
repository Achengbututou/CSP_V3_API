using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-18 11:24:51
    /// 描 述： 工序派工
    /// </summary>
    public class MesProcessDispatchBLL: BLLBase, IMesProcessDispatchBLL, BLL {
        private readonly MesProcessDispatchService mesProcessDispatchService = new MesProcessDispatchService();

        private readonly IMesProductionTicketBLL _iMesProductionTicketBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionTicketBLL">生产工单接口</param>
        public MesProcessDispatchBLL(IMesProductionTicketBLL iMesProductionTicketBLL)
        {
            _iMesProductionTicketBLL = iMesProductionTicketBLL ?? throw new ArgumentNullException(nameof(iMesProductionTicketBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>>GetList(MesProcessDispatchEntity queryParams) {
            return mesProcessDispatchService.GetList(queryParams);
        }
        /// <summary>
        /// 获取工序派工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>>GetPageList(Pagination pagination, MesProcessDispatchEntity queryParams) {
            return mesProcessDispatchService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessDispatchEntity>GetEntity(string keyValue) {
            return mesProcessDispatchService.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>> GetDispatchList(string keyValue)
        {
            return mesProcessDispatchService.GetDispatchList(keyValue);
        }
        /// <summary>
        /// 根据主键集合获取数据
        /// </summary>
        /// <param name="productionTicketIds"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessDispatchEntity>> GetListByIds(List<string> ids, string ProductionTicketId)
        {
            return mesProcessDispatchService.GetListByIds(ids,ProductionTicketId);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessDispatchService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessDispatchService.Deletes(keyValues);
        }
        /// <summary>
        /// 工序派工
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mesProcessDispatch(ProcessDispatchDTO processDispatch)
        {
            //判断是否改变工艺路线
            var productionTicket =await _iMesProductionTicketBLL.GetEntity(processDispatch.F_ProductionTicketId);
            if (productionTicket == null)
            {
                throw new ArgumentException("数据异常，找不到工单信息");
            }
            foreach(var item in processDispatch.mesProcessDispatches)
            {
                item.F_ProductionTicketId=processDispatch.F_ProductionTicketId; 
                item.F_ProcessRouteId=processDispatch.F_ProcessRouteId; 
            }

            if (processDispatch.F_ProcessRouteId == productionTicket.F_ProcessRouteId)//同一工艺路线
            {
                mesProcessDispatchService.BeginTrans();
                try
                {
                    //修改工艺路线
                    await mesProcessDispatchService.SaveList(processDispatch.mesProcessDispatches);
                    mesProcessDispatchService.Commit();
                }
                catch (Exception)
                {
                    mesProcessDispatchService.Rollback();
                    throw;
                }
            }
            else
            {
                //不同工艺路线
               
                mesProcessDispatchService.BeginTrans();
                try
                {
                    //1.0 删除原工单下面的工序派单信息
                    await mesProcessDispatchService.DeleteAllById(processDispatch.F_ProductionTicketId);
                    productionTicket.F_ProcessRouteId = processDispatch.F_ProcessRouteId;
                    productionTicket.F_DispatchType = 2;//工序派工
                    await _iMesProductionTicketBLL.SaveEntity(productionTicket.F_Id, productionTicket);
                    await mesProcessDispatchService.AddList(processDispatch.mesProcessDispatches);
                    mesProcessDispatchService.Commit();
                }
                catch (Exception)
                {
                    mesProcessDispatchService.Rollback();
                    throw;
                }

            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessDispatchEntity entity) {
            await mesProcessDispatchService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        public async Task SaveList(List<MesProcessDispatchEntity> mesProcessDispatches)
        {
            await mesProcessDispatchService.SaveList(mesProcessDispatches);
        }
        /// <summary>
        /// 多工序派工
        /// </summary>
        /// <param name="mesProcessDispatches"></param>
        /// <returns></returns>
        public async Task DispatchEntity(List<string> ids)
        {
            await mesProcessDispatchService.DispatchEntity(ids);
        }
        #endregion
    }
}