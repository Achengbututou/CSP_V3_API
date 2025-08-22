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
    /// 日 期： 2023-08-07 13:29:09
    /// 描 述： 工艺路线管理
    /// </summary>
    public interface IMesProcessRouteBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取工艺路线管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessRouteEntity>>GetList(MesProcessRouteEntity queryParams);
        /// <summary>
        /// 根据商品编码获取工艺路线
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessRouteEntity>> GETListByCode(string code);
        /// <summary>
        /// 获取工艺路线管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessRouteEntity>>GetPageList(Pagination pagination, MesProcessRouteEntity queryParams);
        /// <summary>
        /// 获取物料工艺路线
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        Task<IEnumerable<MesProcessRouteEntity>> GetPageAllList(Pagination pagination, MesProcessRouteEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProcessRouteEntity>GetEntity(string keyValue);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task DeleteAll(string keyValue);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task DeleteChildrenAll(string keyValue);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task DeleteAlls(string keyValues);
        /// <summary>
        /// 改变产品下的工艺路线的常用状态
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns></returns>
        Task SetCmmon(CommonInfoDTO commonInfo);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesProcessRouteEntity entity);
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        Task SaveAll(string keyValue, ProcessRouteDto dto);
        #endregion
    }
}