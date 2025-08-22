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
    /// 日 期： 2023-08-29 13:47:39
    /// 描 述： 收件确认
    /// </summary>
    public class MesFirstTestReportBLL: BLLBase, IMesFirstTestReportBLL, BLL {
        private readonly MesFirstTestReportService mesFirstTestReportService = new MesFirstTestReportService();
        private readonly IMesFirstTestByOrderBLL _iMesFirstTestByOrderBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFirstTestByOrderBLL">首件检测报告检验数据接口</param>
        public MesFirstTestReportBLL(IMesFirstTestByOrderBLL iMesFirstTestByOrderBLL) {
            _iMesFirstTestByOrderBLL = iMesFirstTestByOrderBLL ??
                throw new ArgumentNullException(nameof(iMesFirstTestByOrderBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取收件确认的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFirstTestReportEntity>>GetList(MesFirstTestReportEntity queryParams) {
            return mesFirstTestReportService.GetList(queryParams);
        }
        /// <summary>
        /// 获取收件确认的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFirstTestReportEntity>>GetPageList(Pagination pagination, MesFirstTestReportEntity queryParams) {
            return mesFirstTestReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesFirstTestReportEntity>GetEntity(string keyValue) {
            return mesFirstTestReportService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesFirstTestReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new FirstTestReportDto();
            res.MesFirstTestReportEntity = await GetEntity(keyValue);
            mesFirstTestReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesFirstTestReportEntity != null) {
                    await _iMesFirstTestByOrderBLL.DeleteRelateEntity(res.MesFirstTestReportEntity.F_Id);
                }
                mesFirstTestReportService.Commit();
            } catch (Exception) {
                mesFirstTestReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesFirstTestReportService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesFirstTestReportEntity entity) {
            entity.F_FirstTestNumber = (await GetRuleCodeEx(entity.F_FirstTestNumber)).ToString();
            await mesFirstTestReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, FirstTestReportDto dto) {
            mesFirstTestReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesFirstTestReportEntity);
                await _iMesFirstTestByOrderBLL.SaveList(dto.MesFirstTestReportEntity.F_Id, dto.MesFirstTestByOrderList);
                mesFirstTestReportService.Commit();
            } catch (Exception) {
                mesFirstTestReportService.Rollback();
                throw;
            }
        }
        #endregion
    }
}