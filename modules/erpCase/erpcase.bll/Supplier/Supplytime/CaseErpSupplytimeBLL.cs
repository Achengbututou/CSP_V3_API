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
    /// 日 期： 2022-12-07 15:18:03
    /// 描 述： 供应商时间轴
    /// </summary>
    public class CaseErpSupplytimeBLL : BLLBase, ICaseErpSupplytimeBLL,BLL
    {
        private readonly CaseErpSupplytimeService caseErpSupplytimeService = new CaseErpSupplytimeService();


        #region 获取数据
        /// <summary>
        /// 获取供应商时间轴的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplytimeEntity>> GetList(CaseErpSupplytimeEntity queryParams)
        {
            return caseErpSupplytimeService.GetList(queryParams);
        }

        /// <summary>
        /// 获取供应商时间轴的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplytimeEntity>> GetPageList(Pagination pagination, CaseErpSupplytimeEntity queryParams)
        {
            return caseErpSupplytimeService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplytimeEntity> GetEntity(string keyValue)
        {
            return caseErpSupplytimeService.GetEntity(keyValue);
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
            await caseErpSupplytimeService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplytimeEntity entity)
        {
            
            await caseErpSupplytimeService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSupplytimeService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 保存供应商时间轴数据
        /// </summary>
        /// <param name="F_SupplierId">供应商外键(case_erp_supplier)</param>
        /// <param name="F_Title">时间轴标题</param>
        /// <param name="F_ContentUser">内容(人员)</param>
        /// <param name="F_ContentReason">内容(原因)</param>
        /// <param name="F_ContentExplain">内容(说明)</param>
        /// <returns></returns>
        public async Task SaveSupplyTime(string F_SupplierId, string F_Title, string F_ContentUser, string F_ContentReason, string F_ContentExplain)
        {
            CaseErpSupplytimeEntity supplytimeEntity = new CaseErpSupplytimeEntity();
            supplytimeEntity.F_SupplierId = F_SupplierId;
            supplytimeEntity.F_Title = F_Title;
            supplytimeEntity.F_ContentUser = F_ContentUser;
            supplytimeEntity.F_ContentReason = F_ContentReason;
            supplytimeEntity.F_ContentExplain = F_ContentExplain;

            await caseErpSupplytimeService.SaveEntity(null, supplytimeEntity);
        }
        #endregion
    }
}
