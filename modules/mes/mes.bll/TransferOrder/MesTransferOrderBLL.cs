using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-18 15:09:45
    /// 描 述： 调拨列表
    /// </summary>
    public class MesTransferOrderBLL: BLLBase, IMesTransferOrderBLL, BLL {
        private readonly MesTransferOrderService mesTransferOrderService = new MesTransferOrderService();
        private readonly IMesInventoryLedgerBLL _iMesInventoryLedgerBLL;
        private readonly IMesTransferOrderDetailsBLL _iMesTransferOrderDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTransferOrderDetailsBLL">调拨物品明细接口</param>
        public MesTransferOrderBLL(IMesTransferOrderDetailsBLL iMesTransferOrderDetailsBLL, IMesInventoryLedgerBLL iMesInventoryLedgerBLL) {
            _iMesTransferOrderDetailsBLL = iMesTransferOrderDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesTransferOrderDetailsBLL));
            _iMesInventoryLedgerBLL = iMesInventoryLedgerBLL ?? throw new ArgumentNullException(nameof(iMesInventoryLedgerBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取调拨列表的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferOrderEntity>>GetList(MesTransferOrderEntity queryParams) {
            return mesTransferOrderService.GetList(queryParams);
        }
        /// <summary>
        /// 获取调拨列表的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferOrderEntity>>GetPageList(Pagination pagination, MesTransferOrderEntity queryParams) {
            return mesTransferOrderService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTransferOrderEntity>GetEntity(string keyValue) {
            return mesTransferOrderService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesTransferOrderService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new TransferOrderDto();
            res.MesTransferOrderEntity = await GetEntity(keyValue);
            mesTransferOrderService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesTransferOrderEntity != null) {
                    await _iMesTransferOrderDetailsBLL.DeleteRelateEntity(res.MesTransferOrderEntity.F_Id);
                }
                mesTransferOrderService.Commit();
            } catch (Exception) {
                mesTransferOrderService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesTransferOrderService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesTransferOrderEntity entity) {

            entity.F_TransferOrderNumber = (await GetRuleCodeEx(entity.F_TransferOrderNumber)).ToString();
            await mesTransferOrderService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, TransferOrderDto dto) {
            mesTransferOrderService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesTransferOrderEntity);
                await _iMesTransferOrderDetailsBLL.SaveList(dto.MesTransferOrderEntity.F_Id, dto.MesTransferOrderDetailsList);
                mesTransferOrderService.Commit();
            } catch (Exception) {
                mesTransferOrderService.Rollback();
                throw;
            }
        }
        #endregion

        #region 扩展操作 确认调拨
        /// <summary>
        ///  确认调拨
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<OutboundResultDTO> Transfer(string keyValue)
        {
            OutboundResultDTO outboundResultDTO = new OutboundResultDTO();
            outboundResultDTO.IsSuccess = true;
            var transferOrder = await this.GetEntity(keyValue);
            if (transferOrder == null)
            {
                outboundResultDTO.IsSuccess = false;
                outboundResultDTO.MessageInfo = "调拨数据缺失，请刷新界面重试！";
            }
            //调拨详细
            var mesTransferOrderDetails = await _iMesTransferOrderDetailsBLL.GetList(new MesTransferOrderDetailsEntity { F_TransferInfoId = transferOrder.F_Id });
            //获取调入仓库库存信息
            var mesInventoryLedgerList = await _iMesInventoryLedgerBLL.GetLedgerList(transferOrder.F_TransferWarehouse);
            //获取调出仓库的库存信息
            var outmesInventoryLedgerList = await _iMesInventoryLedgerBLL.GetLedgerList(transferOrder.F_CallOutWarehouse);
            List<MesInventoryLedgerEntity> mesInventoryLedgers = new List<MesInventoryLedgerEntity>();
            foreach (var item in mesTransferOrderDetails)
            {
                //判断调出仓库库存
                var outmesInventoryLedger= outmesInventoryLedgerList.ToList().Where(t=>t.F_ProductNumber== item.F_ProductNumber&&t.F_ReservoirAreaId==item.F_OReservoirAreaId && t.F_LibraryLocationId==item.F_OLibraryLocationId).FirstOrDefault();
                if (outmesInventoryLedger==null)
                {
                    outboundResultDTO.IsSuccess = false;
                    outboundResultDTO.MessageInfo = item.F_ProductNumber + "库存数据缺失，请重新盘点！";
                    break;
                }
                //判断库存与调出数量
                if (outmesInventoryLedger.F_librariesNumber < item.F_TransferQuantity)
                {
                    outboundResultDTO.IsSuccess = false;
                    outboundResultDTO.MessageInfo = item.F_ProductNumber + "库存数据为" + outmesInventoryLedger.F_librariesNumber + "小于调拨" + item.F_TransferQuantity;
                    break;
                }
                else
                {
                    outmesInventoryLedger.F_librariesNumber -=item.F_TransferQuantity;//调出产品减库存
                    mesInventoryLedgers.Add(outmesInventoryLedger);
                }
                var mesInventoryLedger = mesInventoryLedgerList.ToList().Where(t => t.F_ProductNumber == item.F_ProductNumber && t.F_ReservoirAreaId == item.F_TReservoirAreaId && t.F_LibraryLocationId == item.F_TLibraryLocationId).FirstOrDefault();
                if (mesInventoryLedger == null)//首次入库
                {
                    MesInventoryLedgerEntity mesInventory = new MesInventoryLedgerEntity();
                    mesInventory.F_WarehouseInfoId = transferOrder.F_TransferWarehouse;
                    mesInventory.F_ProductName = item.F_ProductName;
                    mesInventory.F_ProductNumber = item.F_ProductNumber;
                    mesInventory.F_SpecificationsModels = item.F_SpecificationsModels;
                    mesInventory.F_Unit = item.F_Unit;
                    mesInventory.F_ReservoirAreaId = item.F_TReservoirAreaId;
                    mesInventory.F_LibraryLocationId = item.F_TLibraryLocationId;
                    mesInventory.F_librariesNumber = item.F_TransferQuantity;
                    mesInventoryLedgers.Add(mesInventory);
                }
                else //再次入库同类商品
                {
                    mesInventoryLedger.F_librariesNumber += item.F_TransferQuantity;
                    mesInventoryLedgers.Add(mesInventoryLedger);
                }
            }
            if (!outboundResultDTO.IsSuccess)
            {
                return outboundResultDTO;
            }
            transferOrder.F_States = 2;
            try
            {
                await SaveEntity(keyValue, transferOrder);
                await _iMesInventoryLedgerBLL.Warehousing(mesInventoryLedgers);
                mesTransferOrderService.Commit();
                return outboundResultDTO;
            }
            catch (Exception)
            {
                mesTransferOrderService.Rollback();
                throw;
            }
        }

        #endregion
    }
}