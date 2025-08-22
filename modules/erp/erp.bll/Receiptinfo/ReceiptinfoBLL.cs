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
    /// 日 期： 2021-06-08 10:39:23
    /// 描 述： lr_erp_receiptinfo
    /// </summary>
    public class ReceiptinfoBLL : BLLBase, IReceiptinfoBLL,BLL
    {
        private readonly ReceiptinfoService lr_erp_receiptinfoService = new ReceiptinfoService();

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_receiptinfo的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_receiptinfoEntity>> GetList(Erp_receiptinfoEntity queryParams)
        {
            return lr_erp_receiptinfoService.GetList(queryParams);
        }

        /// <summary>
        /// 获取lr_erp_receiptinfo的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_receiptinfoEntity>> GetPageList(Pagination pagination, Erp_receiptinfoEntity queryParams)
        {
            return lr_erp_receiptinfoService.GetPageList(pagination, queryParams);
        }
        
        /// <summary>
        /// 获取主表lr_erp_receiptinfo的实体
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        public Task<Erp_receiptinfoEntity> GetEntity(String f_Id)
        {
            return lr_erp_receiptinfoService.GetEntity(f_Id);
        }
        /// <summary>
        /// 获取表lr_erp_receiptinfodetail的列表
        /// </summary>
        /// <param name="f_RId">表lr_erp_receiptinfo关联字段F_Id</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_receiptinfo_detailEntity>> GetLr_erp_receiptinfodetailList(String f_RId)
        {
            return lr_erp_receiptinfoService.GetLr_erp_receiptinfodetailList(f_RId);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        public async Task Delete(String f_Id)
        {
            await lr_erp_receiptinfoService.Delete(f_Id);
        }
        /// <summary>
        /// 删除收款单详细lr_erp_receiptinfodetail表数据
        /// </summary>
        /// <param name="f_RId">表lr_erp_receiptinfo关联字段F_Id</param>
        public async Task DeleteLr_erp_receiptinfodetail(String f_RId)
        {
            await lr_erp_receiptinfoService.DeleteLr_erp_receiptinfodetail(f_RId);
        }


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_receiptinfoEntity">收款单lr_erp_receiptinfo实体数据</param>
        /// <param name="lr_erp_receiptinfodetailList">收款单详细lr_erp_receiptinfodetail实体数据列表</param>
        public Task SaveEntity(String f_Id,Erp_receiptinfoEntity lr_erp_receiptinfoEntity,IEnumerable<Erp_receiptinfo_detailEntity> lr_erp_receiptinfodetailList)
        {
            return lr_erp_receiptinfoService.SaveEntity(f_Id,lr_erp_receiptinfoEntity,lr_erp_receiptinfodetailList);
        }
        /// <summary>
        /// 保存收款单详细lr_erp_receiptinfodetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_receiptinfodetailEntity">lr_erp_receiptinfodetail实体数据</param>
        public Task SaveLr_erp_receiptinfodetail(String f_Id,Erp_receiptinfo_detailEntity lr_erp_receiptinfodetailEntity)
        {
            return lr_erp_receiptinfoService.SaveLr_erp_receiptinfodetail(f_Id,lr_erp_receiptinfodetailEntity);
        }


        #endregion
    }
}
