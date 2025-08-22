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
    /// 日 期： 2021-06-08 10:33:31
    /// 描 述： lr_erp_purchasewarehous
    /// </summary>
    public interface IWarehousingBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchasewarehous的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_warehousingEntity>> GetList(Erp_warehousingEntity queryParams);

        /// <summary>
        /// 获取lr_erp_purchasewarehous的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_warehousingEntity>> GetPageList(Pagination pagination, Erp_warehousingEntity queryParams);
        
        /// <summary>
        /// 获取主表lr_erp_purchasewarehous的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        Task<Erp_warehousingEntity> GetEntity(String f_Id);
        /// <summary>
        /// 获取表lr_erp_purchasewarehoudetail的列表
        /// </summary>
        /// <param name="f_PWID">表lr_erp_purchasewarehous关联字段F_Id</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_warehousing_detailEntity>> GetLr_erp_purchasewarehoudetailList(String f_PWID);


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        Task Delete(String f_Id);
        /// <summary>
        /// 删除采购入库详细表lr_erp_purchasewarehoudetail表数据
        /// </summary>
        /// <param name="f_PWID">表lr_erp_purchasewarehous关联字段F_Id</param>
        Task DeleteLr_erp_purchasewarehoudetail(String f_PWID);


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchasewarehousEntity">采购入库lr_erp_purchasewarehous实体数据</param>
        /// <param name="lr_erp_purchasewarehoudetailList">采购入库详细表lr_erp_purchasewarehoudetail实体数据列表</param>
        Task SaveEntity(String f_Id,Erp_warehousingEntity lr_erp_purchasewarehousEntity,IEnumerable<Erp_warehousing_detailEntity> lr_erp_purchasewarehoudetailList);
        /// <summary>
        /// 保存采购入库详细表lr_erp_purchasewarehoudetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_purchasewarehoudetailEntity">lr_erp_purchasewarehoudetail实体数据</param>
        Task SaveLr_erp_purchasewarehoudetail(String f_Id,Erp_warehousing_detailEntity lr_erp_purchasewarehoudetailEntity);

        
        #endregion
    }
}
