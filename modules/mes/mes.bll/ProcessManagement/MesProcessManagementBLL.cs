using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： 工序管理
    /// </summary>
    public class MesProcessManagementBLL: BLLBase, IMesProcessManagementBLL, BLL {
        private readonly MesProcessManagementService mesProcessManagementService = new MesProcessManagementService();
        private readonly IMesProcessWorkstationBLL _iMesProcessWorkstationBLL;
        private readonly IMesProcessMaterialBLL _iMesProcessMaterialBLL;
        private readonly IMesProcessTechnologyBLL _iMesProcessTechnologyBLL;
        private readonly IMesProcessDispatchBLL _iMesProcessDispatchBLL;
        private readonly IMesProceNodeRouteBLL _iMesProceNodeRouteBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessWorkstationBLL">工序工位管理接口</param>
        /// <param name="iMesProcessMaterialBLL">工序物料管理接口</param>
        /// <param name="iMesProcessTechnologyBLL">工序技术参数管理接口</param>
        public MesProcessManagementBLL(IMesProcessWorkstationBLL iMesProcessWorkstationBLL, IMesProcessMaterialBLL iMesProcessMaterialBLL, IMesProcessTechnologyBLL iMesProcessTechnologyBLL, IMesProcessDispatchBLL iMesProcessDispatchBLL, IMesProceNodeRouteBLL iMesProceNodeRouteBLL)
        {
            _iMesProcessWorkstationBLL = iMesProcessWorkstationBLL ??
                throw new ArgumentNullException(nameof(iMesProcessWorkstationBLL));
            _iMesProcessMaterialBLL = iMesProcessMaterialBLL ??
                throw new ArgumentNullException(nameof(iMesProcessMaterialBLL));
            _iMesProcessTechnologyBLL = iMesProcessTechnologyBLL ??
                throw new ArgumentNullException(nameof(iMesProcessTechnologyBLL));
            _iMesProcessDispatchBLL = iMesProcessDispatchBLL ??
                throw new ArgumentNullException(nameof(iMesProcessDispatchBLL));
            _iMesProceNodeRouteBLL = iMesProceNodeRouteBLL ??
              throw new ArgumentNullException(nameof(iMesProceNodeRouteBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取工序管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>>GetList(MesProcessManagementEntity queryParams) {
            return mesProcessManagementService.GetList(queryParams);
        }
        /// <summary>
        /// 获取工序
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>> GetProductNumberList(MesProcessManagementEntity queryParams)
        {

            return mesProcessManagementService.GetProductNumberList(queryParams);   
        }
        /// <summary>
        /// 获取工单工序
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>> GetProdTicketList(MesProcessManagementEntity queryParams)
        {

            return mesProcessManagementService.GetProdTicketList(queryParams);
        }
        /// <summary>
        /// 获取工序管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessManagementEntity>>GetPageList(Pagination pagination, MesProcessManagementEntity queryParams) {
            return mesProcessManagementService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessManagementEntity>GetEntity(string keyValue) {
            return mesProcessManagementService.GetEntity(keyValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>

        public Task<MesProcessManagementEntity> GetDetailEntity(string keyValue)
        {
              return mesProcessManagementService.GetDetailEntity(keyValue);
        }

        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessManagementService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<OutboundResultDTO> DeleteAll(string keyValue) {
            OutboundResultDTO outboundResult = new OutboundResultDTO();
            if (_iMesProceNodeRouteBLL.GetIsProceRoute(keyValue))
            {
                outboundResult.IsSuccess = false;
                outboundResult.MessageInfo = "该工序已经被工艺路线使用，禁止删除！";
            }
            var res = new ProcessManagementDto();
            res.MesProcessManagementEntity = await GetEntity(keyValue);
            mesProcessManagementService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesProcessManagementEntity != null) {
                    await _iMesProcessWorkstationBLL.DeleteRelateEntity(res.MesProcessManagementEntity.F_Id);
                    await _iMesProcessMaterialBLL.DeleteRelateEntity(res.MesProcessManagementEntity.F_Id);
                    await _iMesProcessTechnologyBLL.DeleteRelateEntity(res.MesProcessManagementEntity.F_Id);
                }
                mesProcessManagementService.Commit();
                outboundResult.IsSuccess = true;
                outboundResult.MessageInfo = "删除成功！";
                return outboundResult;  
            } catch (Exception) {
                mesProcessManagementService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessManagementService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues) {
            var keyValuelist = keyValues.Split(",");
            foreach(var keyValue in keyValuelist) {
                await DeleteAll(keyValue);
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessManagementEntity entity) {
            entity.F_ProcessMaNumber = (await GetRuleCodeEx(entity.F_ProcessMaNumber)).ToString();
            await mesProcessManagementService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, ProcessManagementDto dto) {
            mesProcessManagementService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesProcessManagementEntity);
                await _iMesProcessWorkstationBLL.SaveList(dto.MesProcessManagementEntity.F_Id, dto.MesProcessWorkstationList);
                await _iMesProcessMaterialBLL.SaveList(dto.MesProcessManagementEntity.F_Id, dto.MesProcessMaterialList);
                await _iMesProcessTechnologyBLL.SaveList(dto.MesProcessManagementEntity.F_Id, dto.MesProcessTechnologyList);
                mesProcessManagementService.Commit();
            } catch (Exception) {
                mesProcessManagementService.Rollback();
                throw;
            }
        }
        #endregion
    }
}