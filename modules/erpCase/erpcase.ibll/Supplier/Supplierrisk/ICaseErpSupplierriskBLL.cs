using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:10:51
    /// 描 述： 供应商风险评估
    /// </summary>
    public interface ICaseErpSupplierriskBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取供应商风险评估的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSupplierriskEntity>> GetList(CaseErpSupplierriskEntity queryParams);

        /// <summary>
        /// 获取供应商风险评估的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpSupplierriskEntity>> GetPageList(Pagination pagination, CaseErpSupplierriskEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpSupplierriskEntity> GetEntity(string keyValue);

        /// <summary>
        /// 获取最近的年审信息
        /// </summary>
        /// <param name="supplierId">供应商主键</param>
        /// <returns></returns>
        Task<CaseErpSupplierriskEntity> GetEntityLastBySupplierId(string supplierId);

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
        Task SaveEntity(string keyValue, CaseErpSupplierriskEntity entity);

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion

        #region 扩展方法
        /// <summary>
        /// 根据供应商主键获取评估报告
        /// </summary>
        /// <param name="supplierid">供应商主键</param>
        /// <param name="risktype">报告类型(0风险评估，1年审评估)</param>
        /// <returns></returns>
        Task<CaseErpSupplierriskEntity> GetAssess(string supplierid,int risktype);
        #endregion
    }
}
