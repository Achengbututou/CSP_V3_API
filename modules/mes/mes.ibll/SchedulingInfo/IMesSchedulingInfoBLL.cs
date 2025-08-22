using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
using mes.ibll.SchedulingInfo;

namespace mes.ibll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-10 10:01:07
    /// 描 述： 排期信息
    /// </summary>
    public interface IMesSchedulingInfoBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取排期信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesSchedulingInfoEntity>>GetList(MesSchedulingInfoEntity queryParams);
        /// <summary>
        /// 获取排期信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesSchedulingInfoEntity>>GetPageList(Pagination pagination, MesSchedulingInfoEntity queryParams);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSaleEntity>> GetERPPageList(Pagination pagination, CaseErpSaleEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesSchedulingInfoEntity>GetEntity(string keyValue);
        /// <summary>
        /// 获取排期信息详细（已进行数据转换）
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<MesSchedulingInfoEntity> GetDetailEntity(string keyValue);

        /// <summary>
        /// 获取排期详情（带排期信息列表）
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<MesSchedulingInfoDTO> GetMesSchedulingDetail(string keyValue);
        /// <summary>
        /// 获取排期详情
        /// </summary>
        /// <returns></returns>
        List<CaseSalesDTO> GetTableDataList(Pagination pagination, string Keyword);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 删除排期详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task deleteDetail(string keyValue);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesSchedulingInfoEntity entity);
        /// <summary>
        /// 排期工具排期情况保存
        /// </summary>
        /// <returns></returns>
        Task SaveDetail(MesSchedulingDetailDTO mesSchedulingDetail);
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task PublishScheduling(string keyValue);
        #endregion
    }
}