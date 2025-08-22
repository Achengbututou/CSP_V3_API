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
    /// 日 期： 2022-12-05 16:13:41
    /// 描 述： 供应商供货清单
    /// </summary>
    public class CaseErpSupplymaterialBLL : BLLBase, ICaseErpSupplymaterialBLL,BLL
    {
        private readonly CaseErpSupplymaterialService caseErpSupplymaterialService = new CaseErpSupplymaterialService();
        private readonly ICaseErpSupplypricelogBLL _icaseErpSupplypricelogBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CaseErpSupplymaterialBLL(ICaseErpSupplypricelogBLL icaseErpSupplypricelogBLL)
        {
            _icaseErpSupplypricelogBLL = icaseErpSupplypricelogBLL ?? throw new ArgumentNullException(nameof(icaseErpSupplypricelogBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取供应商供货清单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplymaterialEntity>> GetList(CaseErpSupplymaterialEntity queryParams)
        {
            return caseErpSupplymaterialService.GetList(queryParams);
        }

        /// <summary>
        /// 获取供应商供货清单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplymaterialEntity>> GetPageList(Pagination pagination, CaseErpSupplymaterialEntity queryParams)
        {
            return caseErpSupplymaterialService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplymaterialEntity> GetEntity(string keyValue)
        {
            return caseErpSupplymaterialService.GetEntity(keyValue);
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
            await caseErpSupplymaterialService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplymaterialEntity entity)
        {

            if (string.IsNullOrEmpty(entity.F_SupplierId))
            {
                throw new Exception("供应商信息不能为空！");
            }

            var old =await caseErpSupplymaterialService.BaseRepository().FindEntity<CaseErpSupplymaterialEntity>(t => t.F_SupplierId ==entity.F_SupplierId && t.F_Number == entity.F_Number );
            if (old != null && old.F_Id != keyValue)
            {
                throw new Exception("当前物料不能重复添加！");
            }

            await caseErpSupplymaterialService.SaveEntity(keyValue, entity);

            //不管是新增/编辑供应清单均需要将【当前采购价格】进行记录
            if (entity.F_Price  != null)
            {
                CaseErpSupplypricelogEntity supplypricelogEntity = new CaseErpSupplypricelogEntity();
                supplypricelogEntity.F_SupplymaterialId = entity.F_Id;
                supplypricelogEntity.F_CurrentPrice = entity.F_Price;

                await _icaseErpSupplypricelogBLL.SaveEntity(null, supplypricelogEntity);
            }
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSupplymaterialService.Deletes(keyValues);
        }

        

        #endregion
    }
}
