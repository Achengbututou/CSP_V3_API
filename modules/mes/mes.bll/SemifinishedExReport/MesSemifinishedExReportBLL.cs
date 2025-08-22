using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-30 17:03:50
    /// 描 述： 半成品检测报告
    /// </summary>
    public class MesSemifinishedExReportBLL: BLLBase, IMesSemifinishedExReportBLL, BLL {
        private readonly MesSemifinishedExReportService mesSemifinishedExReportService = new MesSemifinishedExReportService();
        private readonly IMesSemifinishedExDetailBLL _iMesSemifinishedExDetailBLL;
        private readonly IMesSemifinishedReportBLL _iMesSemifinishedReportBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesSemifinishedExDetailBLL">半成品校验异常数据接口</param>
        public MesSemifinishedExReportBLL(IMesSemifinishedExDetailBLL iMesSemifinishedExDetailBLL, IMesSemifinishedReportBLL iMesSemifinishedReportBLL) {
            _iMesSemifinishedExDetailBLL = iMesSemifinishedExDetailBLL ??
                throw new ArgumentNullException(nameof(iMesSemifinishedExDetailBLL));
            _iMesSemifinishedReportBLL = iMesSemifinishedReportBLL ?? throw new ArgumentNullException(nameof(iMesSemifinishedReportBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取半成品检测报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedExReportEntity>>GetList(MesSemifinishedExReportEntity queryParams) {
            return mesSemifinishedExReportService.GetList(queryParams);
        }
        /// <summary>
        /// 获取半成品检测报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedExReportEntity>>GetPageList(Pagination pagination, MesSemifinishedExReportEntity queryParams) {
            return mesSemifinishedExReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSemifinishedExReportEntity>GetEntity(string keyValue) {
            return mesSemifinishedExReportService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesSemifinishedExReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new SemifinishedExReportDto();
            res.MesSemifinishedExReportEntity = await GetEntity(keyValue);
            mesSemifinishedExReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesSemifinishedExReportEntity != null) {
                    await _iMesSemifinishedExDetailBLL.DeleteRelateEntity(res.MesSemifinishedExReportEntity.F_Id);
                }
                mesSemifinishedExReportService.Commit();
            } catch (Exception) {
                mesSemifinishedExReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesSemifinishedExReportService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues) {
            var keyValuelist = keyValues.Split(",").ToList();
            var exreportList= await mesSemifinishedExReportService.GetListBtIds(keyValuelist);
            List<string> exIds= exreportList.Select(t=>t.F_SemifinishedReportId).ToList();
            //获取半成品报告
            var mesSemifinishedReportList = await _iMesSemifinishedReportBLL.GetListByIds(exIds);
            List<MesSemifinishedReportEntity> mesSemifinishedReports = new List<MesSemifinishedReportEntity>();
            foreach(var item in mesSemifinishedReportList)
            {
                item.F_ExStates = 1;
                mesSemifinishedReports.Add(item);
            }
            mesSemifinishedExReportService.BeginTrans();
            try
            {
                await _iMesSemifinishedReportBLL.UpdateList(mesSemifinishedReports);
                await _iMesSemifinishedExDetailBLL.DeleteRelates(exIds);
                await mesSemifinishedExReportService.Deletes(keyValues);

                mesSemifinishedExReportService.Commit();
            }
            catch (Exception)
            {
                mesSemifinishedExReportService.Rollback();
                throw;
            }
          
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSemifinishedExReportEntity entity) {
            entity.F_ExceptionNumber = (await GetRuleCodeEx(entity.F_ExceptionNumber)).ToString();
            //获取半成品报告
            var mesSemifinishedReport =await  _iMesSemifinishedReportBLL.GetEntity(entity.F_SemifinishedReportId);
            if (mesSemifinishedReport!=null)
            {
                mesSemifinishedReport.F_ExStates = 2;
                await _iMesSemifinishedReportBLL.SaveEntity(mesSemifinishedReport.F_Id, mesSemifinishedReport);
            }
            await mesSemifinishedExReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, SemifinishedExReportDto dto) {
            mesSemifinishedExReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesSemifinishedExReportEntity);
                await _iMesSemifinishedExDetailBLL.SaveList(dto.MesSemifinishedExReportEntity.F_Id, dto.MesSemifinishedExDetailList);
                mesSemifinishedExReportService.Commit();
            } catch (Exception) {
                mesSemifinishedExReportService.Rollback();
                throw;
            }
        }
        #endregion
    }
}