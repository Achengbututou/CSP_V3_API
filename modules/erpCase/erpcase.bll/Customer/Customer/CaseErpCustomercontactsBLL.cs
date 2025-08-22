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
    /// 日 期： 2022-12-05 16:42:10
    /// 描 述： 客户信息
    /// </summary>
    public class CaseErpCustomercontactsBLL : BLLBase, ICaseErpCustomercontactsBLL, BLL
    {
        private readonly CaseErpCustomercontactsService caseErpCustomercontactsService = new CaseErpCustomercontactsService();



        #region 获取数据
        /// <summary>
        /// 获取客户信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomercontactsEntity>> GetList(CaseErpCustomercontactsEntity queryParams)
        {
            return caseErpCustomercontactsService.GetList(queryParams);
        }

        /// <summary>
        /// 获取客户信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomercontactsEntity>> GetPageList(Pagination pagination, CaseErpCustomercontactsEntity queryParams)
        {
            return caseErpCustomercontactsService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpCustomercontactsEntity> GetEntity(string keyValue)
        {
            return caseErpCustomercontactsService.GetEntity(keyValue);
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
            await caseErpCustomercontactsService.Delete(keyValue);
        }

        /// <summary>
        /// 删除@Des的实体根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key)
        {
            return caseErpCustomercontactsService.DeleteRelate(key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpCustomercontactsEntity entity)
        {

            await caseErpCustomercontactsService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<CaseErpCustomercontactsEntity> list)
        {
            await caseErpCustomercontactsService.SaveList(key, list);
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpCustomercontactsService.Deletes(keyValues);
        }



        #endregion
    }
}
