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
    /// 日 期： 2022-12-05 16:53:55
    /// 描 述： 单位类型
    /// </summary>
    public class CaseErpUnittypeBLL : BLLBase, ICaseErpUnittypeBLL,BLL
    {
        private readonly CaseErpUnittypeService caseErpUnittypeService = new CaseErpUnittypeService();

        

        #region 获取数据
        /// <summary>
        /// 获取单位类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnittypeEntity>> GetList(CaseErpUnittypeEntity queryParams)
        {
            return caseErpUnittypeService.GetList(queryParams);
        }

        /// <summary>
        /// 获取单位类型的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnittypeEntity>> GetPageList(Pagination pagination, CaseErpUnittypeEntity queryParams)
        {
            return caseErpUnittypeService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpUnittypeEntity> GetEntity(string keyValue)
        {
            return caseErpUnittypeService.GetEntity(keyValue);
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
            await caseErpUnittypeService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpUnittypeEntity entity)
        {
            
            await caseErpUnittypeService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpUnittypeService.Deletes(keyValues);
        }

        

        #endregion
    }
}
