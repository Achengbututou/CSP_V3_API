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
    /// 日 期： 2023-08-31 10:20:45
    /// 描 述： 成品异常报告
    /// </summary>
    public class MesFinishedExReportBLL: BLLBase, IMesFinishedExReportBLL, BLL {
        private readonly MesFinishedExReportService mesFinishedExReportService = new MesFinishedExReportService();
        private readonly IMesFinishedExDetailBLL _iMesFinishedExDetailBLL;
        private readonly IMesFinishedReportBLL _iMesFinishedReportBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFinishedExDetailBLL">成品校验异常数据接口</param>
        public MesFinishedExReportBLL(IMesFinishedExDetailBLL iMesFinishedExDetailBLL, IMesFinishedReportBLL iMesFinishedReportBLL)
        {
            _iMesFinishedExDetailBLL = iMesFinishedExDetailBLL ??
                throw new ArgumentNullException(nameof(iMesFinishedExDetailBLL));
            _iMesFinishedReportBLL = iMesFinishedReportBLL ?? throw new ArgumentNullException(nameof(iMesFinishedReportBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取成品异常报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedExReportEntity>>GetList(MesFinishedExReportEntity queryParams) {
            return mesFinishedExReportService.GetList(queryParams);
        }
        /// <summary>
        /// 获取成品异常报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedExReportEntity>>GetPageList(Pagination pagination, MesFinishedExReportEntity queryParams) {
            return mesFinishedExReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesFinishedExReportEntity>GetEntity(string keyValue) {
            return mesFinishedExReportService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesFinishedExReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new FinishedExReportDto();
            res.MesFinishedExReportEntity = await GetEntity(keyValue);
            mesFinishedExReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesFinishedExReportEntity != null) {
                    await _iMesFinishedExDetailBLL.DeleteRelateEntity(res.MesFinishedExReportEntity.F_Id);
                }
                mesFinishedExReportService.Commit();
            } catch (Exception) {
                mesFinishedExReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesFinishedExReportService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues)
        {
            var ExReportList = await mesFinishedExReportService.GetListByIds(keyValues.Split(',').ToList());
            var finishIds = ExReportList.Select(t => t.F_FinishedId).ToList();
            var finishReportList =await _iMesFinishedReportBLL.GetListByIds(finishIds);
            List<MesFinishedReportEntity> mesFinishedReports = new List<MesFinishedReportEntity>();
            foreach(var item in finishReportList)
            {
                item.F_ExStates = 1;
                mesFinishedReports.Add(item);
            }
            mesFinishedExReportService.BeginTrans();
            try
            {
                await mesFinishedExReportService.Deletes(keyValues);
                await _iMesFinishedReportBLL.UpdateList(mesFinishedReports);
                await _iMesFinishedExDetailBLL.DeleteRelates(keyValues.Split(',').ToList());
                mesFinishedExReportService.Commit();
            }
            catch (Exception)
            {
                mesFinishedExReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesFinishedExReportEntity entity) {
            entity.F_ExceptionNumber = (await GetRuleCodeEx(entity.F_ExceptionNumber)).ToString();
            var finishReportInfo = await _iMesFinishedReportBLL.GetEntity(entity.F_FinishedId);
            if (finishReportInfo != null)
            {
                finishReportInfo.F_ExStates = 2;
                await _iMesFinishedReportBLL.SaveEntity(finishReportInfo.F_Id, finishReportInfo);
            }
            await mesFinishedExReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, FinishedExReportDto dto) {
            mesFinishedExReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesFinishedExReportEntity);
                await _iMesFinishedExDetailBLL.SaveList(dto.MesFinishedExReportEntity.F_Id, dto.MesFinishedExDetailList);
                mesFinishedExReportService.Commit();
            } catch (Exception) {
                mesFinishedExReportService.Rollback();
                throw;
            }
        }
        #endregion
    }
}