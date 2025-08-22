using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期： 2022-12-05 08:38:07
    /// 描 述： 开票记录
    /// </summary>
    public class CaseErpInvoicelogBLL : BLLBase, ICaseErpInvoicelogBLL,BLL
    {
        private readonly CaseErpInvoicelogService caseErpInvoicelogService = new CaseErpInvoicelogService();

        

        #region 获取数据
        /// <summary>
        /// 获取开票记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpInvoicelogEntity>> GetList(CaseErpInvoicelogEntity queryParams)
        {
            return caseErpInvoicelogService.GetList(queryParams);
        }

        /// <summary>
        /// 获取开票记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpInvoicelogEntity>> GetPageList(Pagination pagination, CaseErpInvoicelogEntity queryParams)
        {
            return caseErpInvoicelogService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpInvoicelogEntity> GetEntity(string keyValue)
        {
            return caseErpInvoicelogService.GetEntity(keyValue);
        }

        

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue)
        {
            await caseErpInvoicelogService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpInvoicelogEntity entity)
        {
            entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString(); 

            await caseErpInvoicelogService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpInvoicelogService.Deletes(keyValues);
        }

        

        #endregion
    }
}
