using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-07-31 16:01:14
    /// 描 述： 库位信息
    /// </summary>
    public class MesLibraryLocationBLL: BLLBase, IMesLibraryLocationBLL, BLL {
        private readonly MesLibraryLocationService mesLibraryLocationService = new MesLibraryLocationService();
        #region 获取数据
        /// <summary>
        /// 获取库位信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesLibraryLocationEntity>>GetList(MesLibraryLocationEntity queryParams) {
            return mesLibraryLocationService.GetList(queryParams);
        }
        /// <summary>
        /// 获取库位信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesLibraryLocationEntity>>GetPageList(Pagination pagination, MesLibraryLocationEntity queryParams) {
            return mesLibraryLocationService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesLibraryLocationEntity>GetEntity(string keyValue) {
            return mesLibraryLocationService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesLibraryLocationService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesLibraryLocationService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesLibraryLocationEntity entity) {
            entity.F_LibraryLocationNumber = (await GetRuleCodeEx(entity.F_LibraryLocationNumber)).ToString();
            await mesLibraryLocationService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}