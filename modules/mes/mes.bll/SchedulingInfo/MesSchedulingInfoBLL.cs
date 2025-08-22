using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Data;
using mes.ibll.SchedulingInfo;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-10 10:01:07
    /// 描 述： 排期信息
    /// </summary>
    public class MesSchedulingInfoBLL: BLLBase, IMesSchedulingInfoBLL, BLL {
        private readonly MesSchedulingInfoService mesSchedulingInfoService = new MesSchedulingInfoService();
        private readonly MesScheduleDetailsService mesScheduleDetailsService = new MesScheduleDetailsService();
        #region 获取数据
        /// <summary>
        /// 获取排期信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSchedulingInfoEntity>>GetList(MesSchedulingInfoEntity queryParams) {
            return mesSchedulingInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取排期信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesSchedulingInfoEntity>>GetPageList(Pagination pagination, MesSchedulingInfoEntity queryParams) {
            return mesSchedulingInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaleEntity>> GetERPPageList(Pagination pagination, CaseErpSaleEntity queryParams)
        {
            return mesSchedulingInfoService.GetERPPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesSchedulingInfoEntity>GetEntity(string keyValue) {
            return mesSchedulingInfoService.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取排期信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Task<MesSchedulingInfoEntity> GetDetailEntity(string keyValue)
        {
            return mesSchedulingInfoService.GetDetailEntity(keyValue);
        }
        /// <summary>
        /// 获取排期详情（带排期信息列表）
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task<MesSchedulingInfoDTO> GetMesSchedulingDetail(string keyValue)
        {
            MesSchedulingInfoDTO mesSchedulingInfoDTO = new MesSchedulingInfoDTO();
            mesSchedulingInfoDTO.MesSchedulingInfoEntity =await this.GetDetailEntity(keyValue);
            mesSchedulingInfoDTO.MesScheduleDetailsEntities = await mesScheduleDetailsService.GetList(new MesScheduleDetailsEntity { F_SchedulingId = keyValue });
            return mesSchedulingInfoDTO;
        }
        /// <summary>
        /// 获取销售清单详情
        /// </summary>
        /// <returns></returns>
        public List<CaseSalesDTO> GetTableDataList(Pagination pagination, string Keyword)
        {
            return this.mesSchedulingInfoService.GetTableDataList(pagination,Keyword);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesSchedulingInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesSchedulingInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesSchedulingInfoEntity entity) {
            entity.F_SchedulingNumber = (await GetRuleCodeEx(entity.F_SchedulingNumber)).ToString();
            await mesSchedulingInfoService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 删除排期详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task deleteDetail(string keyValue)
        {
            await mesSchedulingInfoService.deleteDetail(keyValue);
        }
        /// <summary>
        /// 排期工具排期情况保存
        /// </summary>
        /// <returns></returns>
        public async Task SaveDetail(MesSchedulingDetailDTO mesSchedulingDetail)
        {
            await mesSchedulingInfoService.SaveDetail(mesSchedulingDetail); 
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task PublishScheduling(string keyValue)
        {
            var entity=await this.GetEntity(keyValue);
            entity.F_ReleaseStatus = 2;
            entity.F_CompletionStatus = 1;
            await mesSchedulingInfoService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}