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
    /// 日 期： 2022-12-05 16:15:15
    /// 描 述： 供货清单价格记录
    /// </summary>
    public class CaseErpSupplypricelogBLL : BLLBase, ICaseErpSupplypricelogBLL,BLL
    {
        private readonly CaseErpSupplypricelogService caseErpSupplypricelogService = new CaseErpSupplypricelogService();

        

        #region 获取数据
        /// <summary>
        /// 获取供货清单价格记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplypricelogEntity>> GetList(CaseErpSupplypricelogEntity queryParams)
        {
            return caseErpSupplypricelogService.GetList(queryParams);
        }

        /// <summary>
        /// 获取供货清单价格记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplypricelogEntity>> GetPageList(Pagination pagination, CaseErpSupplypricelogEntity queryParams)
        {
            return caseErpSupplypricelogService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplypricelogEntity> GetEntity(string keyValue)
        {
            return caseErpSupplypricelogService.GetEntity(keyValue);
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
            await caseErpSupplypricelogService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplypricelogEntity entity)
        {
            
            await caseErpSupplypricelogService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSupplypricelogService.Deletes(keyValues);
        }

        

        #endregion
    }
}
