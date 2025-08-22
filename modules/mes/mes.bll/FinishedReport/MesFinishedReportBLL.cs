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
    /// 日 期： 2023-08-30 17:20:47
    /// 描 述： 成品检验报告
    /// </summary>
    public class MesFinishedReportBLL: BLLBase, IMesFinishedReportBLL, BLL {
        private readonly MesFinishedReportService mesFinishedReportService = new MesFinishedReportService();
        private readonly IMesFinishedDetailBLL _iMesFinishedDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFinishedDetailBLL">成品检验数据接口</param>
        public MesFinishedReportBLL(IMesFinishedDetailBLL iMesFinishedDetailBLL) {
            _iMesFinishedDetailBLL = iMesFinishedDetailBLL ??
                throw new ArgumentNullException(nameof(iMesFinishedDetailBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedReportEntity>>GetList(MesFinishedReportEntity queryParams) {
            return mesFinishedReportService.GetList(queryParams);
        }
        /// <summary>
        /// 根据主键集合获取成品检验报告数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedReportEntity>> GetListByIds(List<string> ids)
        {
            return mesFinishedReportService.GetListByIds(ids);  
        }
        /// <summary>
        /// 获取成品检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFinishedReportEntity>>GetPageList(Pagination pagination, MesFinishedReportEntity queryParams) {
            return mesFinishedReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesFinishedReportEntity>GetEntity(string keyValue) {
            return mesFinishedReportService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesFinishedReportService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new FinishedReportDto();
            res.MesFinishedReportEntity = await GetEntity(keyValue);
            mesFinishedReportService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesFinishedReportEntity != null) {
                    await _iMesFinishedDetailBLL.DeleteRelateEntity(res.MesFinishedReportEntity.F_Id);
                }
                mesFinishedReportService.Commit();
            } catch (Exception) {
                mesFinishedReportService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesFinishedReportService.Deletes(keyValues);
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
        /// 批量修改成品检验报告数据
        /// </summary>
        /// <param name="mesFinishedReports"></param>
        /// <returns></returns>

        public async Task UpdateList(List<MesFinishedReportEntity> mesFinishedReports)
        {
            await mesFinishedReportService.UpdateList(mesFinishedReports);  
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesFinishedReportEntity entity) {
            entity.F_FinishedNumber = (await GetRuleCodeEx(entity.F_FinishedNumber)).ToString();
            await mesFinishedReportService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, FinishedReportDto dto) {
            mesFinishedReportService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesFinishedReportEntity);
                await _iMesFinishedDetailBLL.SaveList(dto.MesFinishedReportEntity.F_Id, dto.MesFinishedDetailList);
                mesFinishedReportService.Commit();
            } catch (Exception) {
                mesFinishedReportService.Rollback();
                throw;
            }
        }
        #endregion

        #region 扩展操作 流程状态更改
        /// <summary>
        /// 流程修改状态
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="code"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public async Task UpdateStateByWf(string processId, string code, string unitName)
        {
            var finishedDetail = await _iMesFinishedDetailBLL.GetEntity(processId);
            if (finishedDetail != null)
            {
                var entity = await mesFinishedReportService.GetEntity(finishedDetail.F_FinishedId);
                if (entity != null)
                {
                    switch (code)
                    {
                        case "create":
                            entity.F_States = 2;
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
                    await mesFinishedReportService.SaveEntity(finishedDetail.F_FinishedId, entity);
                }

            }

        }
        #endregion
    }
}