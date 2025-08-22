using ce.autofac.extension;
using erp.ibll;
using learun.iapplication;
using learun.util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp.bll
{
    /// <summary>
    /// Quartz
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:33:31
    /// 描 述： lr_erp_purchasewarehous
    /// </summary>
    public class WarehousingBLL : BLLBase, IWarehousingBLL,BLL
    {
        private readonly WarehousingService lr_erp_purchasewarehousService = new WarehousingService();

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchasewarehous的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_warehousingEntity>> GetList(Erp_warehousingEntity queryParams)
        {
            return lr_erp_purchasewarehousService.GetList(queryParams);
        }

        /// <summary>
        /// 获取lr_erp_purchasewarehous的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_warehousingEntity>> GetPageList(Pagination pagination, Erp_warehousingEntity queryParams)
        {
            return lr_erp_purchasewarehousService.GetPageList(pagination, queryParams);
        }
        
        /// <summary>
        /// 获取主表lr_erp_purchasewarehous的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        public Task<Erp_warehousingEntity> GetEntity(String f_Id)
        {
            return lr_erp_purchasewarehousService.GetEntity(f_Id);
        }
        /// <summary>
        /// 获取表lr_erp_purchasewarehoudetail的列表
        /// </summary>
        /// <param name="f_PWID">表lr_erp_purchasewarehous关联字段F_Id</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_warehousing_detailEntity>> GetLr_erp_purchasewarehoudetailList(String f_PWID)
        {
            return lr_erp_purchasewarehousService.GetLr_erp_purchasewarehoudetailList(f_PWID);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        public async Task Delete(String f_Id)
        {
            await lr_erp_purchasewarehousService.Delete(f_Id);
        }
        /// <summary>
        /// 删除采购入库详细表lr_erp_purchasewarehoudetail表数据
        /// </summary>
        /// <param name="f_PWID">表lr_erp_purchasewarehous关联字段F_Id</param>
        public async Task DeleteLr_erp_purchasewarehoudetail(String f_PWID)
        {
            await lr_erp_purchasewarehousService.DeleteLr_erp_purchasewarehoudetail(f_PWID);
        }


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchasewarehousEntity">采购入库lr_erp_purchasewarehous实体数据</param>
        /// <param name="lr_erp_purchasewarehoudetailList">采购入库详细表lr_erp_purchasewarehoudetail实体数据列表</param>
        public async Task SaveEntity(String f_Id,Erp_warehousingEntity lr_erp_purchasewarehousEntity,IEnumerable<Erp_warehousing_detailEntity> lr_erp_purchasewarehoudetailList)
        {
            await lr_erp_purchasewarehousService.SaveEntity(f_Id, lr_erp_purchasewarehousEntity, lr_erp_purchasewarehoudetailList);
        }
        /// <summary>
        /// 保存采购入库详细表lr_erp_purchasewarehoudetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_purchasewarehoudetailEntity">lr_erp_purchasewarehoudetail实体数据</param>
        public Task SaveLr_erp_purchasewarehoudetail(String f_Id,Erp_warehousing_detailEntity lr_erp_purchasewarehoudetailEntity)
        {
            return lr_erp_purchasewarehousService.SaveLr_erp_purchasewarehoudetail(f_Id,lr_erp_purchasewarehoudetailEntity);
        }


        #endregion
    }
}
