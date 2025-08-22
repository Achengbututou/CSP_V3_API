using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using SqlSugar;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-15 09:40:10
    /// 描 述： 生产计划单
    /// </summary>
    public class MesProductionScheduleBLL: BLLBase, IMesProductionScheduleBLL, BLL {
        private readonly MesProductionScheduleService mesProductionScheduleService = new MesProductionScheduleService();
        private readonly IMesProductDetailsBLL _iMesProductDetailsBLL;
        private readonly IMesProductionOrderBLL _iMesProductionOrderBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductDetailsBLL">生产订单产品明细接口</param>
        public MesProductionScheduleBLL(IMesProductDetailsBLL iMesProductDetailsBLL, IMesProductionOrderBLL iMesProductionOrderBLL)
        {
            _iMesProductDetailsBLL = iMesProductDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesProductDetailsBLL));
            _iMesProductionOrderBLL = iMesProductionOrderBLL ?? throw new ArgumentNullException(nameof(iMesProductionOrderBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取生产计划单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionScheduleEntity>>GetList(MesProductionScheduleEntity queryParams) {
            return mesProductionScheduleService.GetList(queryParams);
        }
        /// <summary>
        /// 根据主键集合获取计划单数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MesProductionScheduleEntity>> GetList(List<string> ids)
        {
            return await mesProductionScheduleService.GetList(ids);   
        }
        /// <summary>
        /// 获取生产计划单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionScheduleEntity>>GetPageList(Pagination pagination, MesProductionScheduleEntity queryParams) {
            return mesProductionScheduleService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionScheduleEntity>GetEntity(string keyValue) {
            return mesProductionScheduleService.GetEntity(keyValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="materialId"></param>
        /// <param name="productDetailsId"></param>
        /// <returns></returns>
        public List<MesProductionScheduleEntity> GetToBeplannedList( string materialId, string productDetailsId)
        {
            return  mesProductionScheduleService.GetToBeplannedList(materialId, productDetailsId);
        }
        /// <summary>
        /// 转换列表数据
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <param name="mesProductDetailsEntity"></param>
        /// <returns></returns>
        public List<MesProductionScheduleEntity> ConvertList(IEnumerable<MesProductionScheduleEntity> mesProductionSchedules, MesProductDetailsEntity mesProductDetailsEntity)
        {
            List<MesProductionScheduleEntity> mesProductionScheduleEntities = new List<MesProductionScheduleEntity>();
           foreach (var item in mesProductionSchedules)
            {
                item.F_ProductionOrderId = mesProductDetailsEntity.F_ProductionOrderId;
                item.F_LaunchDate = mesProductDetailsEntity.F_LaunchDate;
                item.F_PlannedOutput = mesProductDetailsEntity.F_PlannedOutput;
                item.F_ProductionOrderNumber = mesProductDetailsEntity.F_ProductionOrderNumber;
                item.F_Number = mesProductDetailsEntity.F_Number;
                item.F_ProductionDetailId = mesProductDetailsEntity.F_Id;
                item.F_Priority = mesProductDetailsEntity.F_Priority;
                mesProductionScheduleEntities.Add(item);            
            }
           return mesProductionScheduleEntities;
        }
        /// <summary>
        /// 获取计划单详细
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<MesProductionScheduleDTO> GetProductionScheduleDetail(string keyValue)
        {
            MesProductionScheduleDTO mesProductionScheduleDTO = new MesProductionScheduleDTO();
            mesProductionScheduleDTO.productDetailsEntity = await _iMesProductDetailsBLL.GetDetailEntity(keyValue);
            MesProductionScheduleEntity scheduleEntity = new MesProductionScheduleEntity();
            scheduleEntity.F_ProductionDetailId = keyValue;
            mesProductionScheduleDTO.productionScheduleEntities = await this.GetList(scheduleEntity);
            return mesProductionScheduleDTO;
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProductionScheduleService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProductionScheduleService.Deletes(keyValues);
        }
        /// <summary>
        /// 作废生产计划单
        /// </summary>
        /// <param name="cancelProductOrder"></param>
        /// <returns></returns>
        public async Task CancelEntity(CancelProductOrderDto cancelProductOrder)
        {
            await mesProductionScheduleService.CancelEntity(cancelProductOrder);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProductionScheduleEntity entity) {
            await mesProductionScheduleService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task SaveListEntity(List<MesProductionScheduleEntity> mesProductionSchedules)
        {

            mesProductionScheduleService.BeginTrans();
            try
            {
                var productOrder = await _iMesProductionOrderBLL.GetEntity(mesProductionSchedules[0].F_ProductionOrderId);
                string numinfo = "learun_code_ProductionScheNumberCode|" + Guid.NewGuid().ToString();
                string code = (await GetRuleCodeEx(numinfo)).ToString();
                if (!string.IsNullOrEmpty(mesProductionSchedules[0].F_ProductionScheNumber))
                {
                    code= mesProductionSchedules[0].F_ProductionScheNumber;
                }
                if (productOrder != null)
                {
                    mesProductionSchedules.ForEach(item =>
                    {
                        item.F_Remarks = productOrder.F_Remarks;
                    });
                }
                await mesProductionScheduleService.SaveListEntity(mesProductionSchedules, code);
                await _iMesProductDetailsBLL.UpdateEntity(mesProductionSchedules[0].F_ProductionDetailId);
                mesProductionScheduleService.Commit();
            }
            catch (Exception)
            {
                mesProductionScheduleService.Rollback();
                throw;
            }
           
        }
        /// <summary>
        /// 修改计划单
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesProductionScheduleEntity> mesProductionSchedules)
        {
            await mesProductionScheduleService.UpdateList(mesProductionSchedules);
        }
        /// <summary>
        /// /生产工单数据修改
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        public async Task creatdGDuP(List<MesProductionScheduleEntity> mesProductionSchedules)
        {
            await mesProductionScheduleService.creatdGDuP(mesProductionSchedules);
        }
        #endregion
    }
}