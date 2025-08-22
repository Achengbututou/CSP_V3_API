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
    /// 日 期： 2023-09-06 11:26:24
    /// 描 述： 调拨管理
    /// </summary>
    public class MesTransferInfoBLL: BLLBase, IMesTransferInfoBLL, BLL {
        private readonly MesTransferInfoService mesTransferInfoService = new MesTransferInfoService();
        private readonly IMesTransferDetailsBLL _iMesTransferDetailsBLL;
        private readonly IMesOperationLogInfoBLL _iMesOperationLogInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTransferDetailsBLL">调拨物品明细接口</param>
        public MesTransferInfoBLL(IMesTransferDetailsBLL iMesTransferDetailsBLL, IMesOperationLogInfoBLL iMesOperationLogInfoBLL) {
            _iMesTransferDetailsBLL = iMesTransferDetailsBLL ??
                throw new ArgumentNullException(nameof(iMesTransferDetailsBLL));
            _iMesOperationLogInfoBLL = iMesOperationLogInfoBLL ?? throw new ArgumentNullException(nameof(iMesOperationLogInfoBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取调拨管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferInfoEntity>>GetList(MesTransferInfoEntity queryParams) {
            return mesTransferInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取调拨管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferInfoEntity>>GetPageList(Pagination pagination, MesTransferInfoEntity queryParams) {
            return mesTransferInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesTransferInfoEntity>GetEntity(string keyValue) {
            #region 添加操作记录
            await _iMesOperationLogInfoBLL.SaveLog(keyValue, "查询调拨申请详细数据");
            #endregion
            return await mesTransferInfoService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesTransferInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new TransferInfoDto();
            res.MesTransferInfoEntity = await GetEntity(keyValue);
            mesTransferInfoService.BeginTrans();
            try {
                await Delete(keyValue);
                #region 添加操作记录
                await _iMesOperationLogInfoBLL.SaveLog(keyValue, "删除调拨数据");
                #endregion
                if (res.MesTransferInfoEntity != null) {
                    await _iMesTransferDetailsBLL.DeleteRelateEntity(res.MesTransferInfoEntity.F_Id);
                }
                mesTransferInfoService.Commit();
            } catch (Exception) {
                mesTransferInfoService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesTransferInfoService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesTransferInfoEntity entity) {

            #region 添加操作记录
            string info = "新增调拨申请数据";
            if (!string.IsNullOrEmpty(keyValue))
            {
                info = "编辑调拨申请数据";
            }
            await _iMesOperationLogInfoBLL.SaveLog(keyValue, info);
            #endregion
            entity.F_TransferNumber = (await GetRuleCodeEx(entity.F_TransferNumber)).ToString();
            await mesTransferInfoService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, TransferInfoDto dto) {
            mesTransferInfoService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesTransferInfoEntity);
                await _iMesTransferDetailsBLL.SaveList(dto.MesTransferInfoEntity.F_Id, dto.MesTransferDetailsList);
                mesTransferInfoService.Commit();
            } catch (Exception) {
                mesTransferInfoService.Rollback();
                throw;
            }
        }
        #endregion
    }
}