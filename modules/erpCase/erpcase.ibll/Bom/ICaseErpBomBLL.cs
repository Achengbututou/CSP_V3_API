using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.office;
using learun.util;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 17:17:21
    /// 描 述： BOM信息
    /// </summary>
    public interface ICaseErpBomBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取BOM信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpBomEntity>> GetList(CaseErpBomEntity queryParams);

        /// <summary>
        /// 获取BOM信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<CaseErpBomEntity>> GetPageList(Pagination pagination, CaseErpBomEntity queryParams);

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<CaseErpBomEntity> GetEntity(string keyValue);



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
        Task<bool> SaveEntity(string keyValue, CaseErpBomEntity entity);



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        Task Deletes(string keyValues);



        #endregion

        #region 扩展方法
        /// <summary>
        /// 用户列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        Task<string> GetExportExcel();
        /// <summary>
        /// 数据导入处理
        /// </summary>
        /// <param name="sheets">excel数据</param>
        /// <returns></returns>
        Task<bool> BomImport(List<ExcelSheet> sheets);
        #endregion
    }
}
