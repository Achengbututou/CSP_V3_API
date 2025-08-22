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
    /// 日 期： 2023-09-06 09:56:11
    /// 描 述： 出库管理
    /// </summary>
    public class MesOutboundInfoBLL: BLLBase, IMesOutboundInfoBLL, BLL {
        private readonly MesOutboundInfoService mesOutboundInfoService = new MesOutboundInfoService();
        private readonly IMesOutboundDetailsBLL _iMesOutboundDetailsBLL;
        private readonly IMesInventoryLedgerBLL _iMesInventoryLedgerBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesOutboundDetailsBLL">出库物品接口</param>
        public MesOutboundInfoBLL(IMesOutboundDetailsBLL iMesOutboundDetailsBLL, IMesInventoryLedgerBLL iMesInventoryLedgerBLL) {
            _iMesOutboundDetailsBLL = iMesOutboundDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesOutboundDetailsBLL));
            _iMesInventoryLedgerBLL = iMesInventoryLedgerBLL ?? throw new ArgumentNullException(nameof(iMesInventoryLedgerBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取出库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOutboundInfoEntity>>GetList(MesOutboundInfoEntity queryParams) {
            return mesOutboundInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取出库管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesOutboundInfoEntity>>GetPageList(Pagination pagination, MesOutboundInfoEntity queryParams) {
            return mesOutboundInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesOutboundInfoEntity>GetEntity(string keyValue) {
            return mesOutboundInfoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesOutboundInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new OutboundInfoDto();
            res.MesOutboundInfoEntity = await GetEntity(keyValue);
            mesOutboundInfoService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesOutboundInfoEntity != null) {
                    await _iMesOutboundDetailsBLL.DeleteRelateEntity(res.MesOutboundInfoEntity.F_Id);
                }
                mesOutboundInfoService.Commit();
            } catch (Exception) {
                mesOutboundInfoService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesOutboundInfoService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesOutboundInfoEntity entity) {
            entity.F_OutboundNumber = (await GetRuleCodeEx(entity.F_OutboundNumber)).ToString();
            await mesOutboundInfoService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, OutboundInfoDto dto) {
            mesOutboundInfoService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesOutboundInfoEntity);
                await _iMesOutboundDetailsBLL.SaveList(dto.MesOutboundInfoEntity.F_Id, dto.MesOutboundDetailsList);
                mesOutboundInfoService.Commit();
            } catch (Exception) {
                mesOutboundInfoService.Rollback();
                throw;
            }
        }
        #endregion

        #region 扩展 出库操作
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<OutboundResultDTO> OutboundInfo(string keyValue)
        {
            OutboundResultDTO outboundResult = new OutboundResultDTO();
            outboundResult.IsSuccess = true;    
            var mesOutboundInfo = await this.GetEntity(keyValue);
            if (mesOutboundInfo == null)
            {
                outboundResult.MessageInfo = "出库数据缺失，请刷新界面重试";
                outboundResult.IsSuccess = false;
                return outboundResult;  
            }
            //获取仓库库存信息
            var mesInventoryLedgerList = await _iMesInventoryLedgerBLL.GetLedgerList(mesOutboundInfo.F_WarehouseInfoId);
            //获取出库详细信息
            var mesOutboundDetailsList = await _iMesOutboundDetailsBLL.GetList(new MesOutboundDetailsEntity { F_OutboundInfoId = mesOutboundInfo.F_Id });
            List<MesInventoryLedgerEntity> mesInventoryLedgers = new List<MesInventoryLedgerEntity>();
            
            foreach (var item in mesOutboundDetailsList)
            {
                //判断是否在库
                var mesInventoryLedger = mesInventoryLedgerList.ToList().Where(t => t.F_ProductNumber == item.F_ProductNumber && t.F_ReservoirAreaId == item.F_ReservoirAreaId && t.F_LibraryLocationId == item.F_LibraryLocationId).FirstOrDefault();
                if (mesInventoryLedger == null)
                {
                    continue;
                }
                else //再次出库同类商品
                {
                    if(mesInventoryLedger.F_librariesNumber> item.F_ThisQuantity)
                    {
                        mesInventoryLedger.F_librariesNumber -= item.F_ThisQuantity;
                        mesInventoryLedgers.Add(mesInventoryLedger);
                    }
                    else
                    {
                        outboundResult.IsSuccess = false;
                        outboundResult.MessageInfo =item.F_ProductName+"<<"+item.F_ProductNumber+">>"+"出库数量"+item.F_ThisQuantity+"大于库存"+ mesInventoryLedger.F_librariesNumber;
                        break;
                    }
                }
            }
            if (!outboundResult.IsSuccess)
            {
                return outboundResult;
            }
            mesOutboundInfo.F_States = 2;
            mesOutboundInfoService.BeginTrans();
            try
            {
                await SaveEntity(keyValue,mesOutboundInfo);
                await _iMesInventoryLedgerBLL.Warehousing(mesInventoryLedgers);
                mesOutboundInfoService.Commit();
                return outboundResult;
            }
            catch (Exception)
            {
                mesOutboundInfoService.Rollback();
                throw;
            }
        }
        #endregion
    }
}