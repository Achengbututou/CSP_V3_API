using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using mes.ibll.InspectionReport;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-23 09:44:54
    /// 描 述： 来料检验报告
    /// </summary>
    public class MesIncomingInspectionBLL: BLLBase, IMesIncomingInspectionBLL, BLL {
        private readonly MesIncomingInspectionService mesIncomingInspectionService = new MesIncomingInspectionService();
        private readonly IMesIncomingByOrderBLL _iMesIncomingByOrderBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesIncomingByOrderBLL">来料检验报告按单检验接口</param>
        public MesIncomingInspectionBLL(IMesIncomingByOrderBLL iMesIncomingByOrderBLL) {
            _iMesIncomingByOrderBLL = iMesIncomingByOrderBLL ??
                throw new ArgumentNullException(nameof(iMesIncomingByOrderBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取来料检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingInspectionEntity>>GetList(MesIncomingInspectionEntity queryParams) {
            return mesIncomingInspectionService.GetList(queryParams);
        }
        /// <summary>
        /// 获取来料报告数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingInspectionEntity>> GetList(List<string> ids)
        {
            return mesIncomingInspectionService.GetList(ids);   
        }
        /// <summary>
        /// 获取来料检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingInspectionEntity>>GetPageList(Pagination pagination, MesIncomingInspectionEntity queryParams) {
            return mesIncomingInspectionService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesIncomingInspectionEntity>GetEntity(string keyValue) {
            return mesIncomingInspectionService.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取检测报表数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public ResultTestReportDTO GetReportList(Pagination pagination, MesIncomingInspectionEntity queryParams)
        {
            return mesIncomingInspectionService.GetReportList(pagination, queryParams); 
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesIncomingInspectionService.Delete(keyValue);
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="mesIncomingInspections"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesIncomingInspectionEntity> mesIncomingInspections)
        {
            await mesIncomingInspectionService.UpdateList(mesIncomingInspections);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new IncomingInspectionDto();
            res.MesIncomingInspectionEntity = await GetEntity(keyValue);
            mesIncomingInspectionService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesIncomingInspectionEntity != null) {
                    await _iMesIncomingByOrderBLL.DeleteRelateEntity(res.MesIncomingInspectionEntity.F_Id);
                }
                mesIncomingInspectionService.Commit();
            } catch (Exception) {
                mesIncomingInspectionService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesIncomingInspectionService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesIncomingInspectionEntity entity)
        {
            entity.F_ReportNumber = (await GetRuleCodeEx(entity.F_ReportNumber)).ToString();
            if (entity.F_ReportNumber == null)
            {
                entity.F_States = 1;
            }
            await mesIncomingInspectionService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, IncomingInspectionDto dto) {
            mesIncomingInspectionService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesIncomingInspectionEntity);
                await _iMesIncomingByOrderBLL.SaveList(dto.MesIncomingInspectionEntity.F_Id, dto.MesIncomingByOrderList);
                mesIncomingInspectionService.Commit();
            } catch (Exception) {
                mesIncomingInspectionService.Rollback();
                throw;
            }
        }
        #endregion
    }
}