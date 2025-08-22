using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期： 2022-12-05 09:24:18
    /// 描 述： 操作记录
    /// </summary>
    public interface ICaseErpLogBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取操作记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpLogEntity>> GetList(CaseErpLogEntity queryParams);

        /// <summary>
        /// 获取操作记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpLogEntity>> GetPageList(Pagination pagination, CaseErpLogEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpLogEntity> GetEntity(string keyValue);

        

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task Delete(string keyValue);

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task SaveEntity(string keyValue, CaseErpLogEntity entity);

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion

        #region 扩展方法
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="KeyId">关联外键</param>
        /// <param name="F_CategoryId">操作记录分类：0客户，1物料，2采购，3销售</param>
        /// <param name="F_Description"></param>
        /// <param name="F_AddPerson"></param>
        /// <returns></returns>
        Task SaveLog(string KeyId, string F_CategoryId, string F_Description, string F_AddPerson);
        #endregion
    }
}
