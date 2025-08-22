using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;
using SqlSugar;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-29 17:24:38
    /// 描 述： 巡检异常报告
    /// </summary>
    public class MesInspectionExReportBLL: BLLBase, IMesInspectionExReportBLL, BLL {
        private readonly MesInspectionExReportService mesInspectionExReportService = new MesInspectionExReportService();
        private readonly IMesInspectionExDetailBLL _iMesInspectionExDetailBLL;
        private readonly IMesInspectionReportBLL _iMesInspectionReportBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInspectionExDetailBLL">异常巡检报告巡检数据接口</param>
        public MesInspectionExReportBLL(IMesInspectionExDetailBLL iMesInspectionExDetailBLL, IMesInspectionReportBLL iMesInspectionReportBLL)
        {
            _iMesInspectionExDetailBLL = iMesInspectionExDetailBLL ??
                throw new ArgumentNullException(nameof(iMesInspectionExDetailBLL));
            _iMesInspectionReportBLL = iMesInspectionReportBLL ?? throw new ArgumentNullException(nameof(iMesInspectionReportBLL));
            ; 
        }
        #region 获取数据
        /// <summary>
        /// 获取巡检异常报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionExReportEntity>>GetList(MesInspectionExReportEntity queryParams) {
            return mesInspectionExReportService.GetList(queryParams);
        }
        /// <summary>
        /// 获取巡检异常报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionExReportEntity>>GetPageList(Pagination pagination, MesInspectionExReportEntity queryParams) {
            return mesInspectionExReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesInspectionExReportEntity>GetEntity(string keyValue) {
            return mesInspectionExReportService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesInspectionExReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new InspectionExReportDto();
            res.MesInspectionExReportEntity = await GetEntity(keyValue);
            mesInspectionExReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesInspectionExReportEntity != null) {
                    await _iMesInspectionExDetailBLL.DeleteRelateEntity(res.MesInspectionExReportEntity.F_Id);
                }
                mesInspectionExReportService.Commit();
            } catch (Exception) {
                mesInspectionExReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesInspectionExReportService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues) {
            var keyValuelist = keyValues.Split(",").ToList();
            var exReports = await mesInspectionExReportService.GetListByIds(keyValuelist);
            List<string> reports = exReports.Select(t => t.F_InspectionId).ToList();
            var inspectionReports = await _iMesInspectionReportBLL.GetListByIds(reports);
            List< MesInspectionReportEntity > mesInspections = new List< MesInspectionReportEntity >(); 
            foreach (var report in inspectionReports)
            {
                report.F_ExStates = 1;
                mesInspections.Add(report);
            }
            mesInspectionExReportService.BeginTrans();
            try
            {
                await mesInspectionExReportService.Deletes(keyValues);
                await _iMesInspectionExDetailBLL.DeleteRelates(keyValuelist);
                await _iMesInspectionReportBLL.UpdateList(mesInspections);
                mesInspectionExReportService.Commit();
            }
            catch (Exception)
            {
                mesInspectionExReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInspectionExReportEntity entity) {
            entity.F_ExceptionNumber = (await GetRuleCodeEx(entity.F_ExceptionNumber)).ToString();
            var inspectionReport = await _iMesInspectionReportBLL.GetEntity(entity.F_InspectionId);
            if (inspectionReport != null&&string.IsNullOrEmpty(keyValue))
            {
                inspectionReport.F_ExStates = 2;
                await _iMesInspectionReportBLL.SaveEntity(inspectionReport.F_Id, inspectionReport);
            }
            await mesInspectionExReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, InspectionExReportDto dto) {
            mesInspectionExReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesInspectionExReportEntity);
                await _iMesInspectionExDetailBLL.SaveList(dto.MesInspectionExReportEntity.F_Id, dto.MesInspectionExDetailList);
                mesInspectionExReportService.Commit();
            } catch (Exception) {
                mesInspectionExReportService.Rollback();
                throw;
            }
        }
        #endregion
    }
}