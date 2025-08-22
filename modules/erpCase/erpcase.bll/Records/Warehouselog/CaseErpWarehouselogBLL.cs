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
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-16 13:53:00
    /// 描 述： 仓库管理
    /// </summary>
    public class CaseErpWarehouselogBLL : BLLBase, ICaseErpWarehouselogBLL,BLL
    {
        private readonly CaseErpWarehouselogService caseErpWarehouselogService = new CaseErpWarehouselogService();

        

        #region 获取数据
        /// <summary>
        /// 获取仓库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpWarehouselogEntity>> GetList(CaseErpWarehouselogEntity queryParams)
        {
            return caseErpWarehouselogService.GetList(queryParams);
        }

        /// <summary>
        /// 获取仓库管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpWarehouselogEntity>> GetPageList(Pagination pagination, CaseErpWarehouselogEntity queryParams)
        {
            return caseErpWarehouselogService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpWarehouselogEntity> GetEntity(string keyValue)
        {
            return caseErpWarehouselogService.GetEntity(keyValue);
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
            await caseErpWarehouselogService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpWarehouselogEntity entity)
        {
            entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString();

            await caseErpWarehouselogService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpWarehouselogService.Deletes(keyValues);
        }

        

        #endregion
    }
}
