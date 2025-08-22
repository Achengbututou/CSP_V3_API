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
    /// 日 期： 2023-08-15 09:12:40
    /// 描 述： mes_ProductDetails
    /// </summary>
    public interface IMesProductDetailsBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取mes_ProductDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProductDetailsEntity>>GetList(MesProductDetailsEntity queryParams);
        /// <summary>
        /// 获取mes_ProductDetails的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesProductDetailsEntity>>GetPageList(Pagination pagination, MesProductDetailsEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesProductDetailsEntity>GetEntity(string keyValue);
        /// <summary>
        /// 获取生成订单详情
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<MesProductDetailsEntity> GetDetailEntity(string keyValue);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除mes_ProductDetails的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        Task DeleteRelateEntity(string key);
        /// <summary>
        /// 作废生产订单
        /// </summary>
        /// <param name="cancelProductOrder"></param>
        /// <returns></returns>
        Task CancelProductOrder(CancelProductOrderDto cancelProductOrder);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 计划生产订单详细
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task UpdateEntity(string keyValue);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesProductDetailsEntity entity);
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        Task SaveList(string key, IEnumerable<MesProductDetailsEntity>list);
        #endregion
    }
}