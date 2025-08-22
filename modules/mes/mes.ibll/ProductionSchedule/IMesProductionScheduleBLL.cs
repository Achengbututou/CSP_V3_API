using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;
namespace mes.ibll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-15 09:40:10
    /// 描 述： 生产计划单
    /// </summary>
    public interface IMesProductionScheduleBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取生产计划单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionScheduleEntity>>GetList(MesProductionScheduleEntity queryParams);
        /// <summary>
        /// 根据主键集合获取计划单数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionScheduleEntity>> GetList(List<string> ids);
        /// <summary>
        /// 获取生产计划单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProductionScheduleEntity>>GetPageList(Pagination pagination, MesProductionScheduleEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProductionScheduleEntity>GetEntity(string keyValue);
        /// <summary>
        /// 获取待计划产品信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="materialId"></param>
        /// <param name="productDetailsId"></param>
        /// <returns></returns>
        List<MesProductionScheduleEntity> GetToBeplannedList(string materialId, string productDetailsId);
        /// <summary>
        /// 转换列表数据
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <param name="mesProductDetailsEntity"></param>
        /// <returns></returns>
        List<MesProductionScheduleEntity> ConvertList(IEnumerable<MesProductionScheduleEntity> mesProductionSchedules, MesProductDetailsEntity mesProductDetailsEntity);
        /// <summary>
        /// 获取计划详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<MesProductionScheduleDTO> GetProductionScheduleDetail(string keyValue);

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
        /// 作废生产计划单
        /// </summary>
        /// <param name="cancelProductOrder"></param>
        /// <returns></returns>
        Task CancelEntity(CancelProductOrderDto cancelProductOrder);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesProductionScheduleEntity entity);
        /// <summary>
        /// 生产订单确认
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        Task SaveListEntity(List<MesProductionScheduleEntity> mesProductionSchedules);
        /// <summary>
        /// 修改计划单
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        Task UpdateList(List<MesProductionScheduleEntity> mesProductionSchedules);
        /// <summary>
        /// /生产工单数据修改
        /// </summary>
        /// <param name="mesProductionSchedules"></param>
        /// <returns></returns>
        Task creatdGDuP(List<MesProductionScheduleEntity> mesProductionSchedules);
        #endregion
    }
}