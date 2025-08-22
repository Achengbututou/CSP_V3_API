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
    /// 日 期： 2022-12-05 08:27:38
    /// 描 述： 到票记录
    /// </summary>
    public class CaseErpTicketlogBLL : BLLBase, ICaseErpTicketlogBLL,BLL
    {
        private readonly CaseErpTicketlogService caseErpTicketlogService = new CaseErpTicketlogService();

        

        #region 获取数据
        /// <summary>
        /// 获取到票记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpTicketlogEntity>> GetList(CaseErpTicketlogEntity queryParams)
        {
            return caseErpTicketlogService.GetList(queryParams);
        }

        /// <summary>
        /// 获取到票记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpTicketlogEntity>> GetPageList(Pagination pagination, CaseErpTicketlogEntity queryParams)
        {
            return caseErpTicketlogService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpTicketlogEntity> GetEntity(string keyValue)
        {
            return caseErpTicketlogService.GetEntity(keyValue);
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
            await caseErpTicketlogService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpTicketlogEntity entity)
        {
            entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString(); 

            await caseErpTicketlogService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpTicketlogService.Deletes(keyValues);
        }

        

        #endregion
    }
}
