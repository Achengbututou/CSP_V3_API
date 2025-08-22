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
    /// 日 期： 2023-08-29 16:23:56
    /// 描 述： 巡检报告
    /// </summary>
    public class MesInspectionReportBLL: BLLBase, IMesInspectionReportBLL, BLL {
        private readonly MesInspectionReportService mesInspectionReportService = new MesInspectionReportService();
        private readonly IMesInspectionDetailBLL _iMesInspectionDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInspectionDetailBLL">巡检报告巡检数据接口</param>
        public MesInspectionReportBLL(IMesInspectionDetailBLL iMesInspectionDetailBLL) {
            _iMesInspectionDetailBLL = iMesInspectionDetailBLL ??
                throw new ArgumentNullException(nameof(iMesInspectionDetailBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取巡检报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionReportEntity>>GetList(MesInspectionReportEntity queryParams) {
            return mesInspectionReportService.GetList(queryParams);
        }
        /// <summary>
        /// 根据主键集合获取巡检报告数据
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionReportEntity>> GetListByIds(List<string> ids)
        {
            return mesInspectionReportService.GetListByIds(ids); 
        }
        /// <summary>
        /// 获取巡检报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionReportEntity>>GetPageList(Pagination pagination, MesInspectionReportEntity queryParams) {
            return mesInspectionReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesInspectionReportEntity>GetEntity(string keyValue) {
            return mesInspectionReportService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesInspectionReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new InspectionReportDto();
            res.MesInspectionReportEntity = await GetEntity(keyValue);
            mesInspectionReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesInspectionReportEntity != null) {
                    await _iMesInspectionDetailBLL.DeleteRelateEntity(res.MesInspectionReportEntity.F_Id);
                }
                mesInspectionReportService.Commit();
            } catch (Exception) {
                mesInspectionReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesInspectionReportService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesInspectionReportEntity entity) {
            entity.F_InspectionNumber = (await GetRuleCodeEx(entity.F_InspectionNumber)).ToString();
            await mesInspectionReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, InspectionReportDto dto) {
            mesInspectionReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesInspectionReportEntity);
                await _iMesInspectionDetailBLL.SaveList(dto.MesInspectionReportEntity.F_Id, dto.MesInspectionDetailList);
                mesInspectionReportService.Commit();
            } catch (Exception) {
                mesInspectionReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量修改巡检报告
        /// </summary>
        /// <param name="mesInspectionReports"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesInspectionReportEntity> mesInspectionReports)
        {
            await mesInspectionReportService.UpdateList(mesInspectionReports);
        }
        #endregion
    }
}