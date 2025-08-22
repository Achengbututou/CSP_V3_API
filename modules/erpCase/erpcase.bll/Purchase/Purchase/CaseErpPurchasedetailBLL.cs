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
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-30 15:20:23
    /// 描 述： 采购订单
    /// </summary>
    public class CaseErpPurchasedetailBLL : BLLBase, ICaseErpPurchasedetailBLL, BLL
    {
        private readonly CaseErpPurchasedetailService caseErpPurchasedetailService = new CaseErpPurchasedetailService();



        #region 获取数据
        /// <summary>
        /// 获取采购订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchasedetailEntity>> GetList(CaseErpPurchasedetailEntity queryParams)
        {
            return caseErpPurchasedetailService.GetList(queryParams);
        }

        /// <summary>
        /// 获取采购订单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpPurchasedetailEntity>> GetPageList(Pagination pagination, CaseErpPurchasedetailEntity queryParams)
        {
            return caseErpPurchasedetailService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpPurchasedetailEntity> GetEntity(string keyValue)
        {
            return caseErpPurchasedetailService.GetEntity(keyValue);
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
            await caseErpPurchasedetailService.Delete(keyValue);
        }

        /// <summary>
        /// 删除@Des的实体根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key)
        {
            return caseErpPurchasedetailService.DeleteRelate(key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpPurchasedetailEntity entity)
        {

            await caseErpPurchasedetailService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<CaseErpPurchasedetailEntity> list)
        {
            await caseErpPurchasedetailService.SaveList(key, list);
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpPurchasedetailService.Deletes(keyValues);
        }



        #endregion
    }
}
