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
    /// 日 期： 2021-06-08 10:36:08
    /// 描 述： lr_erp_salesoffer
    /// </summary>
    public interface ISalesOfferBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取lr_erp_salesoffer的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_sales_offerEntity>> GetList(Erp_sales_offerEntity queryParams);

        /// <summary>
        /// 获取lr_erp_salesoffer的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_sales_offerEntity>> GetPageList(Pagination pagination, Erp_sales_offerEntity queryParams);
        
        /// <summary>
        /// 获取主表lr_erp_salesoffer的实体
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        Task<Erp_sales_offerEntity> GetEntity(String f_Id);
        /// <summary>
        /// 获取表lr_erp_salesofferdetail的列表
        /// </summary>
        /// <param name="f_SFID">表lr_erp_salesoffer关联字段F_Id</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_sales_offer_detailEntity>> GetLr_erp_salesofferdetailList(String f_SFID);


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        Task Delete(String f_Id);
        /// <summary>
        /// 删除销售报价详细lr_erp_salesofferdetail表数据
        /// </summary>
        /// <param name="f_SFID">表lr_erp_salesoffer关联字段F_Id</param>
        Task DeleteLr_erp_salesofferdetail(String f_SFID);


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_salesofferEntity">销售报价lr_erp_salesoffer实体数据</param>
        /// <param name="lr_erp_salesofferdetailList">销售报价详细lr_erp_salesofferdetail实体数据列表</param>
        Task SaveEntity(String f_Id,Erp_sales_offerEntity lr_erp_salesofferEntity,IEnumerable<Erp_sales_offer_detailEntity> lr_erp_salesofferdetailList);
        /// <summary>
        /// 保存销售报价详细lr_erp_salesofferdetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_salesofferdetailEntity">lr_erp_salesofferdetail实体数据</param>
        Task SaveLr_erp_salesofferdetail(String f_Id,Erp_sales_offer_detailEntity lr_erp_salesofferdetailEntity);

        
        #endregion
    }
}
