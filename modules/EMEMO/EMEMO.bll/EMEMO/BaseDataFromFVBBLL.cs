using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMEMO.ibll;
namespace EMEMO.bll
{
    /// <summary>
    /// EMEMO-EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： EMEMO
    /// </summary>
    public class BaseDataFromFVBBLL : BLLBase, BLL
    {
        private readonly BaseDataFromFVBService BaseDataFromFVBService = new BaseDataFromFVBService();
        private readonly IBaseDataFromFVBBLL _IBaseDataFromFVBBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="IBaseDataFromFVBBLL">null接口</param>
        public BaseDataFromFVBBLL(IBaseDataFromFVBBLL IBaseDataFromFVBBLL)
        {
            _IBaseDataFromFVBBLL = IBaseDataFromFVBBLL ??
                throw new ArgumentNullException(nameof(IBaseDataFromFVBBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取EMEMO的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<BaseDataFromFVBEntity>> GetList(BaseDataFromFVBEntity queryParams)
        {
            return BaseDataFromFVBService.GetList(queryParams);
        }
        /// <summary>
        /// 获取EMEMO的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<BaseDataFromFVBEntity>> GetPageList(Pagination pagination, BaseDataFromFVBEntity queryParams)
        {
            return BaseDataFromFVBService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<BaseDataFromFVBEntity> GetEntity(string keyValue)
        {
            return BaseDataFromFVBService.GetEntity(keyValue);
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
            await BaseDataFromFVBService.Delete(keyValue);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await BaseDataFromFVBService.Deletes(keyValues);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, BaseDataFromFVBEntity entity)
        {
            await BaseDataFromFVBService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 获取FVB数据源
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task GetBaseDataFromFVB()
        {
            await BaseDataFromFVBService.GetBaseDataFromFVB();
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, EMEMODto dto)
        {
            BaseDataFromFVBService.BeginTrans();
            try
            {
                await SaveEntity(keyValue, dto.BaseDataFromFVBEntity);
                BaseDataFromFVBService.Commit();
            }
            catch (Exception)
            {
                BaseDataFromFVBService.Rollback();
                throw;
            }
        }
        #endregion
    }
}