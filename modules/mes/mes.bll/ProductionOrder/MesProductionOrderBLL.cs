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
    /// 日 期： 2023-08-15 09:12:40
    /// 描 述： 生产订单
    /// </summary>
    public class MesProductionOrderBLL: BLLBase, IMesProductionOrderBLL, BLL {
        private readonly MesProductionOrderService mesProductionOrderService = new MesProductionOrderService();
        private readonly IMesProductDetailsBLL _iMesProductDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductDetailsBLL">生产订单产品明细接口</param>
        public MesProductionOrderBLL(IMesProductDetailsBLL iMesProductDetailsBLL) {
            _iMesProductDetailsBLL = iMesProductDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesProductDetailsBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取生产订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionOrderEntity>>GetList(MesProductionOrderEntity queryParams) {
            return mesProductionOrderService.GetList(queryParams);
        }
        /// <summary>
        /// 获取生产订单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionOrderEntity>>GetPageList(Pagination pagination, MesProductionOrderEntity queryParams) {
            return mesProductionOrderService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取mes_ProductDetails的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductDetailsEntity>> GetDetailPageList(Pagination pagination, MesProductDetailsEntity queryParams)
        {
            return _iMesProductDetailsBLL.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionOrderEntity>GetEntity(string keyValue) {
            return mesProductionOrderService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProductionOrderService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new ProductionOrderDto();
            res.MesProductionOrderEntity = await GetEntity(keyValue);
            mesProductionOrderService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesProductionOrderEntity != null) {
                    await _iMesProductDetailsBLL.DeleteRelateEntity(res.MesProductionOrderEntity.F_Id);
                }
                mesProductionOrderService.Commit();
            } catch (Exception) {
                mesProductionOrderService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 作废生产订单
        /// </summary>
        /// <param name="cancelProductOrder"></param>
        /// <returns></returns>
        public async Task CancelProductOrder(CancelProductOrderDto cancelProductOrder)
        {
          await  _iMesProductDetailsBLL.CancelProductOrder(cancelProductOrder);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProductionOrderService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesProductionOrderEntity entity) {
            entity.F_ProductionOrderNumber = (await GetRuleCodeEx(entity.F_ProductionOrderNumber)).ToString();
            await mesProductionOrderService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, ProductionOrderDto dto) {
            mesProductionOrderService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesProductionOrderEntity);
                await _iMesProductDetailsBLL.SaveList(dto.MesProductionOrderEntity.F_Id, dto.MesProductDetailsList);
                mesProductionOrderService.Commit();
            } catch (Exception) {
                mesProductionOrderService.Rollback();
                throw;
            }
        }
        #endregion
    }
}