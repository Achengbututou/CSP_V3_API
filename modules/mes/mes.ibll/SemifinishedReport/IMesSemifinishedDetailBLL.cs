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
    /// 日 期： 2023-08-30 16:25:57
    /// 描 述： mes_semifinishdetail
    /// </summary>
    public interface IMesSemifinishedDetailBLL: IBLL {
        #region 获取数据
        /// <summary>
        /// 获取mes_SemifinishedDetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesSemifinishedDetailEntity>>GetList(MesSemifinishedDetailEntity queryParams);
        /// <summary>
        /// 获取半成品报告
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IEnumerable<MesSemifinishedDetailEntity>> GetListByIds(List<string> ids);
        /// <summary>
        /// 获取mes_SemifinishedDetail的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<MesSemifinishedDetailEntity>>GetPageList(Pagination pagination, MesSemifinishedDetailEntity queryParams);
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<MesSemifinishedDetailEntity>GetEntity(string keyValue);
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);
        /// <summary>
        /// 删除mes_SemifinishedDetail的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        Task DeleteRelateEntity(string key);
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);
        /// <summary>
        /// 批量修改半成品检验报告的数据
        /// </summary>
        /// <param name="mesSemifinishedDetails"></param>
        /// <returns></returns>
        Task UpdateList(List<MesSemifinishedDetailEntity> mesSemifinishedDetails);
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, MesSemifinishedDetailEntity entity);
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        Task SaveList(string key, IEnumerable<MesSemifinishedDetailEntity>list);
        #endregion
    }
}