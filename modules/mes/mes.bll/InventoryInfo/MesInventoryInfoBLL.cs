using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-06 10:30:31
    /// 描 述： 盘点管理
    /// </summary>
    public class MesInventoryInfoBLL : BLLBase, IMesInventoryInfoBLL, BLL
    {
        private readonly MesInventoryInfoService mesInventoryInfoService = new MesInventoryInfoService();
        private readonly IMesInventoryDetailsBLL _iMesInventoryDetailsBLL;
        private readonly IMesInventoryLedgerBLL _iMesInventoryLedgerBLL;
        private readonly IMesOperationLogInfoBLL _iMesOperationLogInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInventoryDetailsBLL">盘点物品明细接口</param>
        public MesInventoryInfoBLL(IMesInventoryDetailsBLL iMesInventoryDetailsBLL, IMesInventoryLedgerBLL iMesInventoryLedgerBLL, IMesOperationLogInfoBLL iMesOperationLogInfoBLL)
        {
            _iMesInventoryDetailsBLL = iMesInventoryDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesInventoryDetailsBLL));
            _iMesInventoryLedgerBLL = iMesInventoryLedgerBLL ?? throw new ArgumentNullException(nameof(iMesInventoryLedgerBLL));
            _iMesOperationLogInfoBLL = iMesOperationLogInfoBLL ?? throw new ArgumentNullException(nameof(iMesOperationLogInfoBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取盘点管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInventoryInfoEntity>> GetList(MesInventoryInfoEntity queryParams)
        {
            return mesInventoryInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取盘点管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<MesInventoryInfoEntity>> GetPageList(Pagination pagination, MesInventoryInfoEntity queryParams)
        {
            return await mesInventoryInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesInventoryInfoEntity> GetEntity(string keyValue)
        {
            #region 添加操作记录
            await _iMesOperationLogInfoBLL.SaveLog(keyValue, "查询盘点详细数据");
            #endregion
            return await mesInventoryInfoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue)
        {
            await mesInventoryInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new InventoryInfoDto();
            res.MesInventoryInfoEntity = await GetEntity(keyValue);
            mesInventoryInfoService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if (res.MesInventoryInfoEntity != null)
                {
                    await _iMesInventoryDetailsBLL.DeleteRelateEntity(res.MesInventoryInfoEntity.F_Id);
                }
                #region 添加操作记录
                await _iMesOperationLogInfoBLL.SaveLog(keyValue, "删除盘点数据");
                #endregion
                mesInventoryInfoService.Commit();
            }
            catch (Exception)
            {
                mesInventoryInfoService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await mesInventoryInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues)
        {
            var keyValuelist = keyValues.Split(",");
            foreach (var keyValue in keyValuelist)
            {
                await DeleteAll(keyValue);
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInventoryInfoEntity entity)
        {
            #region 添加操作记录
            string info = "新增盘点数据";
            if (!string.IsNullOrEmpty(keyValue))
            {
                info = "编辑盘点数据";
            }
            await _iMesOperationLogInfoBLL.SaveLog(keyValue, info);
            #endregion
            entity.F_InventoryNumber = (await GetRuleCodeEx(entity.F_InventoryNumber)).ToString();
            await mesInventoryInfoService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, InventoryInfoDto dto)
        {
            mesInventoryInfoService.BeginTrans();
            try
            {
                await SaveEntity(keyValue, dto.MesInventoryInfoEntity);
                await _iMesInventoryDetailsBLL.SaveList(dto.MesInventoryInfoEntity.F_Id, dto.MesInventoryDetailsList);
                mesInventoryInfoService.Commit();
            }
            catch (Exception)
            {
                mesInventoryInfoService.Rollback();
                throw;
            }
        }
        #endregion

        #region 扩展 盘点操作
        /// <summary>
        /// 盘点
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<OutboundResultDTO> InventoryInfo(string keyValue)
        {
            OutboundResultDTO outboundResultDTO = new OutboundResultDTO();
            outboundResultDTO.IsSuccess = true;
            var mesInventoryInfo = await this.GetEntity(keyValue);
            if (mesInventoryInfo == null)
            {
                outboundResultDTO.IsSuccess = false;
                outboundResultDTO.MessageInfo = "盘点数据缺失，请刷新界面重试！";
            }
            //盘点详细
            var mesInventoryDetailsList = await _iMesInventoryDetailsBLL.GetList(new MesInventoryDetailsEntity { F_InventoryInfoId = mesInventoryInfo.F_Id });
            //获取仓库库存信息
            var mesInventoryLedgerList = await _iMesInventoryLedgerBLL.GetLedgerList(mesInventoryInfo.F_WarehouseInfoId);
            List<MesInventoryLedgerEntity> mesInventoryLedgers = new List<MesInventoryLedgerEntity>();
            foreach (var item in mesInventoryDetailsList)
            {
                var mesInventoryLedger = mesInventoryLedgerList.ToList().Where(t => t.F_ProductNumber == item.F_ProductNumber && t.F_ReservoirAreaId == item.F_ReservoirAreaId && t.F_LibraryLocationId == item.F_LibraryLocationId).FirstOrDefault();
                if (mesInventoryLedger == null)//首次入库
                {
                    outboundResultDTO.IsSuccess = false;
                    outboundResultDTO.MessageInfo = item.F_ProductNumber + "库存数据缺失，请重新盘点！";
                    break;
                }
                else //再次入库同类商品
                {
                    mesInventoryLedger.F_librariesNumber += item.F_ProfitOrLoss;
                    mesInventoryLedgers.Add(mesInventoryLedger);
                }
            }
            if (!outboundResultDTO.IsSuccess)
            {
                return outboundResultDTO;
            }
            mesInventoryInfo.F_States = 2;
            try
            {
                await SaveEntity(keyValue, mesInventoryInfo);
                await _iMesInventoryLedgerBLL.Warehousing(mesInventoryLedgers);
                #region 添加操作记录
                await _iMesOperationLogInfoBLL.SaveLog(keyValue, "结束盘点");
                #endregion
                mesInventoryInfoService.Commit();
                return outboundResultDTO;
            }
            catch (Exception)
            {
                mesInventoryInfoService.Rollback();
                throw;
            }
        }
        #endregion
    }
}