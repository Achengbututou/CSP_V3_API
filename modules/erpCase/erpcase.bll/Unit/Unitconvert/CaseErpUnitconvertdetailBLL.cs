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
    /// 日 期： 2022-12-05 16:54:57
    /// 描 述： 单位换算
    /// </summary>
    public class CaseErpUnitconvertdetailBLL : BLLBase, ICaseErpUnitconvertdetailBLL,BLL
    {
        private readonly CaseErpUnitconvertdetailService caseErpUnitconvertdetailService = new CaseErpUnitconvertdetailService();

        

        #region 获取数据
        /// <summary>
        /// 获取单位换算的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitconvertdetailEntity>> GetList(CaseErpUnitconvertdetailEntity queryParams)
        {
            return caseErpUnitconvertdetailService.GetList(queryParams);
        }

        /// <summary>
        /// 获取单位换算的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitconvertdetailEntity>> GetPageList(Pagination pagination, CaseErpUnitconvertdetailEntity queryParams)
        {
            return caseErpUnitconvertdetailService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpUnitconvertdetailEntity> GetEntity(string keyValue)
        {
            return caseErpUnitconvertdetailService.GetEntity(keyValue);
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
            await caseErpUnitconvertdetailService.Delete(keyValue);
        }

        /// <summary>
        /// 删除@Des的实体根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return caseErpUnitconvertdetailService.DeleteRelate(key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpUnitconvertdetailEntity entity)
        {
            
            await caseErpUnitconvertdetailService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<CaseErpUnitconvertdetailEntity> list) {
            await caseErpUnitconvertdetailService.SaveList(key,list);
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpUnitconvertdetailService.Deletes(keyValues);
        }

        

        #endregion
    }
}
