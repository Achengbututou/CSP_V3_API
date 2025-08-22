using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF.ibll;
using System.Collections.Concurrent;
using Org.BouncyCastle.Bcpg.OpenPgp;
namespace HRATTF.bll {
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-10-24 09:19:39
    /// 描 述： 请假申请
    /// </summary>
    public class FHISLeaveHeaderBLL: BLLBase, IFHISLeaveHeaderBLL, BLL {
        private readonly FHISLeaveHeaderService fhisLeaveHeaderService = new FHISLeaveHeaderService();
        private readonly IFHISLeaveDetailBLL _iFHISLeaveDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iFHISLeaveDetailBLL">FHIS请假证明接口</param>
        public FHISLeaveHeaderBLL(IFHISLeaveDetailBLL iFHISLeaveDetailBLL) {
            _iFHISLeaveDetailBLL = iFHISLeaveDetailBLL ??
                throw new ArgumentNullException(nameof(iFHISLeaveDetailBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveHeaderEntity>>GetList(FHISLeaveHeaderEntity queryParams) {
            return fhisLeaveHeaderService.GetList(queryParams);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<FHISLeaveHeaderEntity>>GetPageList(Pagination pagination, FHISLeaveHeaderEntity queryParams) {
            string AuthoritySql = await this.GetDataAuthoritySql("HRATTF003_List");
            if (string.IsNullOrEmpty(AuthoritySql)) {
                AuthoritySql = string.Empty;
            }
            return await fhisLeaveHeaderService.GetPageList(pagination, queryParams, AuthoritySql);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<FHISLeaveHeaderEntity>GetEntity(string keyValue) {
            return fhisLeaveHeaderService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await fhisLeaveHeaderService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new HRATTF001Dto();
            res.FHISLeaveHeaderEntity = await GetEntity(keyValue);
            fhisLeaveHeaderService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.FHISLeaveHeaderEntity != null) {
                    await _iFHISLeaveDetailBLL.DeleteRelateEntity(res.FHISLeaveHeaderEntity.RID);
                }
                fhisLeaveHeaderService.Commit();
            } catch (Exception) {
                fhisLeaveHeaderService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await fhisLeaveHeaderService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, FHISLeaveHeaderEntity entity) {
            entity.Leave_Note_NO = (await GetRuleCodeEx(entity.Leave_Note_NO)).ToString();
            await fhisLeaveHeaderService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, HRATTF001Dto dto) {
            fhisLeaveHeaderService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.FHISLeaveHeaderEntity);
                await _iFHISLeaveDetailBLL.SaveList(dto.FHISLeaveHeaderEntity.RID, dto.FHISLeaveDetailList);
                fhisLeaveHeaderService.Commit();
            } catch (Exception) {
                fhisLeaveHeaderService.Rollback();
                throw;
            }
        }
        #endregion
    }
}