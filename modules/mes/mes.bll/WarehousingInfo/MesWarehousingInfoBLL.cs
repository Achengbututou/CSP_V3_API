using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using SqlSugar;
using System.Linq;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-05 17:17:28
    /// 描 述： 入库管理
    /// </summary>
    public class MesWarehousingInfoBLL: BLLBase, IMesWarehousingInfoBLL, BLL {
        private readonly MesWarehousingInfoService mesWarehousingInfoService = new MesWarehousingInfoService();
        private readonly IMesWarehousingDetailsBLL _iMesWarehousingDetailsBLL;
        private readonly IMesInventoryLedgerBLL _iMesInventoryLedgerBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesWarehousingDetailsBLL">入库物品明细接口</param>
        public MesWarehousingInfoBLL(IMesWarehousingDetailsBLL iMesWarehousingDetailsBLL, IMesInventoryLedgerBLL iMesInventoryLedgerBLL) {
            _iMesWarehousingDetailsBLL = iMesWarehousingDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesWarehousingDetailsBLL));
            _iMesInventoryLedgerBLL = iMesInventoryLedgerBLL ?? throw new ArgumentNullException(nameof(iMesInventoryLedgerBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取入库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehousingInfoEntity>>GetList(MesWarehousingInfoEntity queryParams) {
            return mesWarehousingInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取入库管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehousingInfoEntity>>GetPageList(Pagination pagination, MesWarehousingInfoEntity queryParams) {
            return mesWarehousingInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesWarehousingInfoEntity>GetEntity(string keyValue) {
            return mesWarehousingInfoService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesWarehousingInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new WarehousingInfoDto();
            res.MesWarehousingInfoEntity = await GetEntity(keyValue);
            mesWarehousingInfoService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesWarehousingInfoEntity != null) {
                    await _iMesWarehousingDetailsBLL.DeleteRelateEntity(res.MesWarehousingInfoEntity.F_Id);
                }
                mesWarehousingInfoService.Commit();
            } catch (Exception) {
                mesWarehousingInfoService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesWarehousingInfoService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesWarehousingInfoEntity entity) {
            entity.F_WarehousingNumber = (await GetRuleCodeEx(entity.F_WarehousingNumber)).ToString();
            await mesWarehousingInfoService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, WarehousingInfoDto dto) {
            mesWarehousingInfoService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesWarehousingInfoEntity);
                await _iMesWarehousingDetailsBLL.SaveList(dto.MesWarehousingInfoEntity.F_Id, dto.MesWarehousingDetailsList);
                mesWarehousingInfoService.Commit();
            } catch (Exception) {
                mesWarehousingInfoService.Rollback();
                throw;
            }
        }
        #endregion

        #region 扩展入库操作
        /// <summary>
        /// 入库操作
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task Warehousing(string keyValues)
        {
            //获取入库实体信息
            MesWarehousingInfoEntity mesWarehousing = await this.GetEntity(keyValues);
            if (mesWarehousing == null)
            {
                throw new ArgumentNullException("入库操作", "找不到入库信息");
            }
            //获取入详细信息
            var warehousingDetailList = await _iMesWarehousingDetailsBLL.GetList(new MesWarehousingDetailsEntity { F_WarehousingInfoId = keyValues });
            //获取仓库库存状况
            var mesInventoryLedgerList = await _iMesInventoryLedgerBLL.GetLedgerList(mesWarehousing.F_WarehouseInfoId);
            List<MesInventoryLedgerEntity> mesInventoryLedgers = new List<MesInventoryLedgerEntity>();
            foreach(var item in warehousingDetailList)
            {
                //判断是否在库
                var mesInventoryLedger = mesInventoryLedgerList.ToList().Where(t => t.F_ProductNumber == item.F_ProductNumber && t.F_ReservoirAreaId == item.F_ReservoirAreaId && t.F_LibraryLocationId == item.F_LibraryLocationId).FirstOrDefault();
                if (mesInventoryLedger == null)//首次入库
                {
                    MesInventoryLedgerEntity mesInventory = new MesInventoryLedgerEntity();
                    mesInventory.F_WarehouseInfoId = mesWarehousing.F_WarehouseInfoId;
                    mesInventory.F_ProductName = item.F_ProductName;
                    mesInventory.F_ProductNumber = item.F_ProductNumber;
                    mesInventory.F_SpecificationsModels=item.F_SpecificationsModels;
                    mesInventory.F_Unit=item.F_Unit;
                    mesInventory.F_ReservoirAreaId = item.F_ReservoirAreaId;
                    mesInventory.F_LibraryLocationId = item.F_LibraryLocationId;
                    mesInventory.F_librariesNumber = item.F_ThisQuantity;
                    mesInventoryLedgers.Add(mesInventory);
                }
                else //再次入库同类商品
                {
                    mesInventoryLedger.F_librariesNumber += item.F_ThisQuantity;
                    mesInventoryLedgers.Add(mesInventoryLedger);
                }
            }
            mesWarehousing.F_States = 2;
            mesWarehousingInfoService.BeginTrans();
            try
            {
                await SaveEntity(keyValues, mesWarehousing);
                await _iMesInventoryLedgerBLL.Warehousing(mesInventoryLedgers);
                mesWarehousingInfoService.Commit();
            }
            catch (Exception)
            {
                mesWarehousingInfoService.Rollback();
                throw;
            }
        }
        #endregion
    }
}