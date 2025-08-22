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
    /// 日 期： 2021-06-08 10:38:08
    /// 描 述： lr_erp_salesreceipt
    /// </summary>
    public class SalesReceiptBLL : BLLBase, ISalesReceiptBLL,BLL
    {
        private readonly SalesReceiptService lr_erp_salesreceiptService = new SalesReceiptService();

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_salesreceipt的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_sales_receiptEntity>> GetList(Erp_sales_receiptEntity queryParams)
        {
            return lr_erp_salesreceiptService.GetList(queryParams);
        }

        /// <summary>
        /// 获取lr_erp_salesreceipt的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_sales_receiptEntity>> GetPageList(Pagination pagination, Erp_sales_receiptEntity queryParams)
        {
            return lr_erp_salesreceiptService.GetPageList(pagination, queryParams);
        }
        
        /// <summary>
        /// 获取主表lr_erp_salesreceipt的实体
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        public Task<Erp_sales_receiptEntity> GetEntity(String f_Id)
        {
            return lr_erp_salesreceiptService.GetEntity(f_Id);
        }
        /// <summary>
        /// 获取表lr_erp_salesreceiptdetail的列表
        /// </summary>
        /// <param name="f_SRId">表lr_erp_salesreceipt关联字段F_Id</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_sales_receipt_detailEntity>> GetLr_erp_salesreceiptdetailList(String f_SRId)
        {
            return lr_erp_salesreceiptService.GetLr_erp_salesreceiptdetailList(f_SRId);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        public async Task Delete(String f_Id)
        {
            await lr_erp_salesreceiptService.Delete(f_Id);
        }
        /// <summary>
        /// 删除销售出库详细lr_erp_salesreceiptdetail表数据
        /// </summary>
        /// <param name="f_SRId">表lr_erp_salesreceipt关联字段F_Id</param>
        public async Task DeleteLr_erp_salesreceiptdetail(String f_SRId)
        {
            await lr_erp_salesreceiptService.DeleteLr_erp_salesreceiptdetail(f_SRId);
        }


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_salesreceiptEntity">销售出库lr_erp_salesreceipt实体数据</param>
        /// <param name="lr_erp_salesreceiptdetailList">销售出库详细lr_erp_salesreceiptdetail实体数据列表</param>
        public Task SaveEntity(String f_Id,Erp_sales_receiptEntity lr_erp_salesreceiptEntity,IEnumerable<Erp_sales_receipt_detailEntity> lr_erp_salesreceiptdetailList)
        {
            return lr_erp_salesreceiptService.SaveEntity(f_Id,lr_erp_salesreceiptEntity,lr_erp_salesreceiptdetailList);
        }
        /// <summary>
        /// 保存销售出库详细lr_erp_salesreceiptdetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_salesreceiptdetailEntity">lr_erp_salesreceiptdetail实体数据</param>
        public Task SaveLr_erp_salesreceiptdetail(String f_Id,Erp_sales_receipt_detailEntity lr_erp_salesreceiptdetailEntity)
        {
            return lr_erp_salesreceiptService.SaveLr_erp_salesreceiptdetail(f_Id,lr_erp_salesreceiptdetailEntity);
        }


        #endregion
    }
}
