using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMEMO.ibll;
namespace EMEMO.bll {
    /// <summary>
    /// EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤
    /// </summary>
    public class EMEMO_hdrBLL : BLLBase, IEMEMO_hdrBLL, BLL {
        private readonly EMEMO_hdrService EMEMO_hdrService = new EMEMO_hdrService();
        private readonly IEMEMO_dtlBLL _iEMEMO_dtlBLL;
        private readonly IEMEMO_dtl_subBLL _iEMEMO_dtl_subBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iAttendanceErrorDtlBLL">null接口</param>
        public EMEMO_hdrBLL(IEMEMO_dtlBLL iEMEMO_dtlBLL, IEMEMO_dtl_subBLL iEMEMO_dtl_subBLL)
        {
            _iEMEMO_dtlBLL = iEMEMO_dtlBLL ??
                throw new ArgumentNullException(nameof(iEMEMO_dtlBLL));
            _iEMEMO_dtl_subBLL = iEMEMO_dtl_subBLL ??
                throw new ArgumentNullException(nameof(iEMEMO_dtl_subBLL));

        }
        #region 获取数据
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_hdrEntity>>GetList(EMEMO_hdrEntity queryParams) {
            return EMEMO_hdrService.GetList(queryParams);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_hdrEntity>>GetPageList(Pagination pagination, EMEMO_hdrEntity queryParams) {
            return EMEMO_hdrService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EMEMO_hdrEntity> GetEntity(string keyValue) {
            return EMEMO_hdrService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await EMEMO_hdrService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new EMEMODto();
            res.EMEMO_hdrEntity = await GetEntity(keyValue);
            EMEMO_hdrService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.EMEMO_hdrEntity != null) {
                    await _iEMEMO_dtlBLL.DeleteRelateEntity(res.EMEMO_hdrEntity.rid);
                    await _iEMEMO_dtl_subBLL.DeleteRelateEntity(res.EMEMO_hdrEntity.rid);
                }
                EMEMO_hdrService.Commit();
            } catch (Exception) {
                EMEMO_hdrService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await EMEMO_hdrService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, EMEMO_hdrEntity entity) {
            entity.note_no = (await GetRuleCodeEx(entity.note_no)).ToString();
            await EMEMO_hdrService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, EMEMODto dto)  {
            EMEMO_hdrService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.EMEMO_hdrEntity);
                await _iEMEMO_dtlBLL.SaveList(dto.EMEMO_hdrEntity.rid, dto.EMEMO_dtlList);
                await _iEMEMO_dtl_subBLL.SaveList(dto.EMEMO_hdrEntity.rid, dto.EMEMO_dtl_subList);
                EMEMO_hdrService.Commit();
            } catch (Exception) {
                EMEMO_hdrService.Rollback();
                throw;
            }
        }
        #endregion
    }
}