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
    /// 日 期： 2023-08-30 16:25:57
    /// 描 述： 半成品检验报告
    /// </summary>
    public class MesSemifinishedReportBLL: BLLBase, IMesSemifinishedReportBLL, BLL {
        private readonly MesSemifinishedReportService mesSemifinishedReportService = new MesSemifinishedReportService();
        private readonly IMesSemifinishedDetailBLL _iMesSemifinishedDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesSemifinishedDetailBLL">半成品检验数据接口</param>
        public MesSemifinishedReportBLL(IMesSemifinishedDetailBLL iMesSemifinishedDetailBLL) {
            _iMesSemifinishedDetailBLL = iMesSemifinishedDetailBLL ??
                throw new ArgumentNullException(nameof(iMesSemifinishedDetailBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取半成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedReportEntity>>GetList(MesSemifinishedReportEntity queryParams) {
            return mesSemifinishedReportService.GetList(queryParams);
        }
        /// <summary>
        /// 获取半成品数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedReportEntity>> GetListByIds(List<string> ids)
        {
            return mesSemifinishedReportService.GetListByIds(ids);  
        }
        /// <summary>
        /// 获取半成品检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSemifinishedReportEntity>>GetPageList(Pagination pagination, MesSemifinishedReportEntity queryParams) {
            return mesSemifinishedReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSemifinishedReportEntity>GetEntity(string keyValue) {
            return mesSemifinishedReportService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesSemifinishedReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new SemifinishedReportDto();
            res.MesSemifinishedReportEntity = await GetEntity(keyValue);
            mesSemifinishedReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesSemifinishedReportEntity != null) {
                    await _iMesSemifinishedDetailBLL.DeleteRelateEntity(res.MesSemifinishedReportEntity.F_Id);
                }
                mesSemifinishedReportService.Commit();
            } catch (Exception) {
                mesSemifinishedReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesSemifinishedReportService.Deletes(keyValues);
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
        /// 批量修改半成品报告
        /// </summary>
        /// <param name="mesSemifinishedReports"></param>
        /// <returns></returns>
        public async Task UpdateList(List<MesSemifinishedReportEntity> mesSemifinishedReports)
        {
            await mesSemifinishedReportService.UpdateList(mesSemifinishedReports);  
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSemifinishedReportEntity entity) {
            entity.F_SemifinishedNumber = (await GetRuleCodeEx(entity.F_SemifinishedNumber)).ToString();
            await mesSemifinishedReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, SemifinishedReportDto dto) {
            mesSemifinishedReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesSemifinishedReportEntity);
                await _iMesSemifinishedDetailBLL.SaveList(dto.MesSemifinishedReportEntity.F_Id, dto.MesSemifinishedDetailList);
                mesSemifinishedReportService.Commit();
            } catch (Exception) {
                mesSemifinishedReportService.Rollback();
                throw;
            }
        }
        #endregion

        #region 扩展操作 流程操作
        /// <summary>
        /// 流程修改状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public async Task UpdateStateByWf(string processId, string code, string unitName)
        {
            var mesSemifinishedDeta = await _iMesSemifinishedDetailBLL.GetEntity(processId);
            if (mesSemifinishedDeta != null)
            {
                var entity = await mesSemifinishedReportService.GetEntity(mesSemifinishedDeta.F_SemifinishedId);
                if (entity != null)
                {
                    switch (code)
                    {
                        case "create":
                            entity.F_States =2;
                            break;
                        case "disagree":
                            entity.F_States = 4;
                            break;
                        case "agree":
                            entity.F_States = 3;
                            break;
                        case "revoke":
                            if (unitName == "更新流程发起状态")
                            {
                                entity.F_States = 5;
                            }
                            else
                            {
                                entity.F_States = 5;
                            }
                            break;

                    }
                    await mesSemifinishedReportService.SaveEntity(mesSemifinishedDeta.F_SemifinishedId, entity);
                }

            }
          
        }
        #endregion
    }
}