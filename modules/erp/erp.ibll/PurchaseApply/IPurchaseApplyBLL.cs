using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.util;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:29:59
    /// 描 述： lr_erp_purchaserequisition
    /// </summary>
    public interface IPurchaseApplyBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchaserequisition的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_purchase_applyEntity>> GetList(Erp_purchase_applyEntity queryParams);

        /// <summary>
        /// 获取lr_erp_purchaserequisition的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_purchase_applyEntity>> GetPageList(Pagination pagination, Erp_purchase_applyEntity queryParams);
        
        /// <summary>
        /// 获取主表lr_erp_purchaserequisition的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        Task<Erp_purchase_applyEntity> GetEntity(String f_Id);
        /// <summary>
        /// 获取表lr_erp_productinfo的列表
        /// </summary>
        /// <param name="f_PRID">表lr_erp_purchaserequisition关联字段F_Id</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_productEntity>> GetLr_erp_productinfoList(String f_PRID);


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        Task Delete(String f_Id);
        /// <summary>
        /// 删除商品信息表lr_erp_productinfo表数据
        /// </summary>
        /// <param name="f_PRID">表lr_erp_purchaserequisition关联字段F_Id</param>
        Task DeleteLr_erp_productinfo(String f_PRID);


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchaserequisitionEntity">采购申请lr_erp_purchaserequisition实体数据</param>
        /// <param name="lr_erp_productinfoList">商品信息表lr_erp_productinfo实体数据列表</param>
        Task SaveEntity(String f_Id,Erp_purchase_applyEntity lr_erp_purchaserequisitionEntity,IEnumerable<Erp_productEntity> lr_erp_productinfoList);
        /// <summary>
        /// 保存商品信息表lr_erp_productinfo表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_productinfoEntity">lr_erp_productinfo实体数据</param>
        Task SaveLr_erp_productinfo(String f_Id,Erp_productEntity lr_erp_productinfoEntity);

        
        #endregion
    }
}
