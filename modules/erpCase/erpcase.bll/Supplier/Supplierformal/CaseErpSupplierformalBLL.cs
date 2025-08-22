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
    /// 日 期： 2022-12-05 16:28:11
    /// 描 述： 供应商转正申请
    /// </summary>
    public class CaseErpSupplierformalBLL : BLLBase, ICaseErpSupplierformalBLL,BLL
    {
        private readonly CaseErpSupplierformalService caseErpSupplierformalService = new CaseErpSupplierformalService();
        private readonly ICaseErpSupplierBLL _icaseErpSupplierBLL;


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplierBLL">供应商信息【case_erp_supplier】接口</param>
        public CaseErpSupplierformalBLL(ICaseErpSupplierBLL icaseErpSupplierBLL)
        {
            _icaseErpSupplierBLL = icaseErpSupplierBLL ?? throw new ArgumentNullException(nameof(icaseErpSupplierBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取供应商转正申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierformalEntity>> GetList(CaseErpSupplierformalEntity queryParams)
        {
            return caseErpSupplierformalService.GetList(queryParams);
        }

        /// <summary>
        /// 获取供应商转正申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierformalEntity>> GetPageList(Pagination pagination, CaseErpSupplierformalEntity queryParams)
        {
            return caseErpSupplierformalService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplierformalEntity> GetEntity(string keyValue)
        {
            return caseErpSupplierformalService.GetEntity(keyValue);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="supplierId">供应商主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplierformalEntity> GetEntityBySupplierId(string supplierId)
        {
            return caseErpSupplierformalService.GetEntityBySupplierId(supplierId);
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
            await caseErpSupplierformalService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplierformalEntity entity)
        {
            //提交转正申请，则潜在供应商状态改为审批中
            if (string.IsNullOrEmpty(keyValue))
            {
                var SupplierEntity=await _icaseErpSupplierBLL.GetEntity(entity.F_SupplierId);
                if (SupplierEntity!=null && SupplierEntity.F_LatentState == 1)
                {
                    throw new Exception("转正申请已经提交了,请勿重复申请！");
                }
            }

            

            await caseErpSupplierformalService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSupplierformalService.Deletes(keyValues);
        }

        

        #endregion
    }
}
