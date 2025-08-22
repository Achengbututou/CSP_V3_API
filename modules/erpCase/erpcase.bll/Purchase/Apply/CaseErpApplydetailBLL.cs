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
    /// 日 期： 2022-11-30 15:26:32
    /// 描 述： 采购申请
    /// </summary>
    public class CaseErpApplydetailBLL : BLLBase, ICaseErpApplydetailBLL,BLL
    {
        private readonly CaseErpApplydetailService caseErpApplydetailService = new CaseErpApplydetailService();

        

        #region 获取数据
        /// <summary>
        /// 获取采购申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpApplydetailEntity>> GetList(CaseErpApplydetailEntity queryParams)
        {
            return caseErpApplydetailService.GetList(queryParams);
        }

        /// <summary>
        /// 获取采购申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpApplydetailEntity>> GetPageList(Pagination pagination, CaseErpApplydetailEntity queryParams)
        {
            return caseErpApplydetailService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpApplydetailEntity> GetEntity(string keyValue)
        {
            return caseErpApplydetailService.GetEntity(keyValue);
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
            await caseErpApplydetailService.Delete(keyValue);
        }

        /// <summary>
        /// 删除@Des的实体根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return caseErpApplydetailService.DeleteRelate(key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpApplydetailEntity entity)
        {
            
            await caseErpApplydetailService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<CaseErpApplydetailEntity> list) {
            await caseErpApplydetailService.SaveList(key,list);
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpApplydetailService.Deletes(keyValues);
        }

        

        #endregion
    }
}
