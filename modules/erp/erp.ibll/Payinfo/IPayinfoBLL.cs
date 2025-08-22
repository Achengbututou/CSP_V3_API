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
    /// 日 期： 2021-06-08 10:34:39
    /// 描 述： lr_erp_payinfo
    /// </summary>
    public interface IPayinfoBLL : IBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取lr_erp_payinfo的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_payinfoEntity>> GetList(Erp_payinfoEntity queryParams);

        /// <summary>
        /// 获取lr_erp_payinfo的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_payinfoEntity>> GetPageList(Pagination pagination, Erp_payinfoEntity queryParams);
        
        /// <summary>
        /// 获取主表lr_erp_payinfo的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        Task<Erp_payinfoEntity> GetEntity(String f_Id);
        /// <summary>
        /// 获取表lr_erp_payinfodetail的列表
        /// </summary>
        /// <param name="f_PId">表lr_erp_payinfo关联字段F_Id</param>
        /// <returns></returns>
        Task<IEnumerable<Erp_payinfo_detailEntity>> GetLr_erp_payinfodetailList(String f_PId);


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        Task Delete(String f_Id);
        /// <summary>
        /// 删除付款单详细lr_erp_payinfodetail表数据
        /// </summary>
        /// <param name="f_PId">表lr_erp_payinfo关联字段F_Id</param>
        Task DeleteLr_erp_payinfodetail(String f_PId);


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_payinfoEntity">付款单lr_erp_payinfo实体数据</param>
        /// <param name="lr_erp_payinfodetailList">付款单详细lr_erp_payinfodetail实体数据列表</param>
        Task SaveEntity(String f_Id,Erp_payinfoEntity lr_erp_payinfoEntity,IEnumerable<Erp_payinfo_detailEntity> lr_erp_payinfodetailList);
        /// <summary>
        /// 保存付款单详细lr_erp_payinfodetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_payinfodetailEntity">lr_erp_payinfodetail实体数据</param>
        Task SaveLr_erp_payinfodetail(String f_Id,Erp_payinfo_detailEntity lr_erp_payinfodetailEntity);

        
        #endregion
    }
}
