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
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:32:13
    /// 描 述： lr_erp_purchaseorder
    /// </summary>
    public class PurchaseOrderBLL : BLLBase, IPurchaseOrderBLL,BLL
    {
        private readonly PurchaseOrderService lr_erp_purchaseorderService = new PurchaseOrderService();

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchaseorder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_purchase_orderEntity>> GetList(Erp_purchase_orderEntity queryParams)
        {
            return lr_erp_purchaseorderService.GetList(queryParams);
        }

        /// <summary>
        /// 获取lr_erp_purchaseorder的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_purchase_orderEntity>> GetPageList(Pagination pagination, Erp_purchase_orderEntity queryParams)
        {
            return lr_erp_purchaseorderService.GetPageList(pagination, queryParams);
        }
        
        /// <summary>
        /// 获取主表lr_erp_purchaseorder的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        public Task<Erp_purchase_orderEntity> GetEntity(String f_Id)
        {
            return lr_erp_purchaseorderService.GetEntity(f_Id);
        }
        /// <summary>
        /// 获取表lr_erp_purchaseorderdetail的列表
        /// </summary>
        /// <param name="f_POID">表lr_erp_purchaseorder关联字段F_Id</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_purchase_order_detailEntity>> GetLr_erp_purchaseorderdetailList(String f_POID)
        {
            return lr_erp_purchaseorderService.GetLr_erp_purchaseorderdetailList(f_POID);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        public async Task Delete(String f_Id)
        {
            await lr_erp_purchaseorderService.Delete(f_Id);
        }
        /// <summary>
        /// 删除采购订单详细lr_erp_purchaseorderdetail表数据
        /// </summary>
        /// <param name="f_POID">表lr_erp_purchaseorder关联字段F_Id</param>
        public async Task DeleteLr_erp_purchaseorderdetail(String f_POID)
        {
            await lr_erp_purchaseorderService.DeleteLr_erp_purchaseorderdetail(f_POID);
        }


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchaseorderEntity">采购订单lr_erp_purchaseorder实体数据</param>
        /// <param name="lr_erp_purchaseorderdetailList">采购订单详细lr_erp_purchaseorderdetail实体数据列表</param>
        public async Task SaveEntity(String f_Id,Erp_purchase_orderEntity lr_erp_purchaseorderEntity,IEnumerable<Erp_purchase_order_detailEntity> lr_erp_purchaseorderdetailList)
        {
            await lr_erp_purchaseorderService.SaveEntity(f_Id, lr_erp_purchaseorderEntity, lr_erp_purchaseorderdetailList);
        }
        /// <summary>
        /// 保存采购订单详细lr_erp_purchaseorderdetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_purchaseorderdetailEntity">lr_erp_purchaseorderdetail实体数据</param>
        public Task SaveLr_erp_purchaseorderdetail(String f_Id,Erp_purchase_order_detailEntity lr_erp_purchaseorderdetailEntity)
        {
            return lr_erp_purchaseorderService.SaveLr_erp_purchaseorderdetail(f_Id,lr_erp_purchaseorderdetailEntity);
        }


        #endregion
    }
}
