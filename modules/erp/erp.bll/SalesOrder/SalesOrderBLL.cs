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
    /// 日 期： 2021-06-08 10:37:10
    /// 描 述： lr_erp_salesorder
    /// </summary>
    public class SalesOrderBLL : BLLBase, ISalesOrderBLL,BLL
    {
        private readonly SalesOrderService lr_erp_salesorderService = new SalesOrderService();

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_salesorder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_sales_orderEntity>> GetList(Erp_sales_orderEntity queryParams)
        {
            return lr_erp_salesorderService.GetList(queryParams);
        }

        /// <summary>
        /// 获取lr_erp_salesorder的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_sales_orderEntity>> GetPageList(Pagination pagination, Erp_sales_orderEntity queryParams)
        {
            return lr_erp_salesorderService.GetPageList(pagination, queryParams);
        }
        
        /// <summary>
        /// 获取主表lr_erp_salesorder的实体
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        public Task<Erp_sales_orderEntity> GetEntity(String f_Id)
        {
            return lr_erp_salesorderService.GetEntity(f_Id);
        }
        /// <summary>
        /// 获取表lr_erp_salesorderdetail的列表
        /// </summary>
        /// <param name="f_SOID">表lr_erp_salesorder关联字段F_Id</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_sales_order_detailEntity>> GetLr_erp_salesorderdetailList(String f_SOID)
        {
            return lr_erp_salesorderService.GetLr_erp_salesorderdetailList(f_SOID);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        public async Task Delete(String f_Id)
        {
            await lr_erp_salesorderService.Delete(f_Id);
        }
        /// <summary>
        /// 删除销售订单详细lr_erp_salesorderdetail表数据
        /// </summary>
        /// <param name="f_SOID">表lr_erp_salesorder关联字段F_Id</param>
        public async Task DeleteLr_erp_salesorderdetail(String f_SOID)
        {
            await lr_erp_salesorderService.DeleteLr_erp_salesorderdetail(f_SOID);
        }


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_salesorderEntity">销售订单lr_erp_salesorder实体数据</param>
        /// <param name="lr_erp_salesorderdetailList">销售订单详细lr_erp_salesorderdetail实体数据列表</param>
        public Task SaveEntity(String f_Id,Erp_sales_orderEntity lr_erp_salesorderEntity,IEnumerable<Erp_sales_order_detailEntity> lr_erp_salesorderdetailList)
        {
            return lr_erp_salesorderService.SaveEntity(f_Id,lr_erp_salesorderEntity,lr_erp_salesorderdetailList);
        }
        /// <summary>
        /// 保存销售订单详细lr_erp_salesorderdetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_salesorderdetailEntity">lr_erp_salesorderdetail实体数据</param>
        public Task SaveLr_erp_salesorderdetail(String f_Id,Erp_sales_order_detailEntity lr_erp_salesorderdetailEntity)
        {
            return lr_erp_salesorderService.SaveLr_erp_salesorderdetail(f_Id,lr_erp_salesorderdetailEntity);
        }


        #endregion
    }
}
