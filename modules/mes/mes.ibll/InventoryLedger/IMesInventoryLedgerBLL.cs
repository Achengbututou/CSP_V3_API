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
    /// 日 期： 2023-09-05 15:51:41
    /// 描 述： 库存台账
    /// </summary>
    public interface IMesInventoryLedgerBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取库存台账的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesInventoryLedgerEntity>>GetList(MesInventoryLedgerEntity queryParams);
        /// <summary>
        /// 获取库存台账的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesInventoryLedgerEntity>>GetPageList(Pagination pagination, MesInventoryLedgerEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesInventoryLedgerEntity>GetEntity(string keyValue);
        /// <summary>
        /// 根据仓库获取库存情况
        /// </summary>
        /// <param name="F_WarehouseInfoId"></param>
        /// <returns></returns>
        Task<IEnumerable<MesInventoryLedgerEntity>> GetLedgerList(string F_WarehouseInfoId);
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
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesInventoryLedgerEntity entity);
        /// <summary>
        /// 出入库操作
        /// </summary>
        /// <param name="mesInventoryLedgers"></param>
        /// <returns></returns>
        Task Warehousing(List<MesInventoryLedgerEntity> mesInventoryLedgers);
        #endregion
    }
}