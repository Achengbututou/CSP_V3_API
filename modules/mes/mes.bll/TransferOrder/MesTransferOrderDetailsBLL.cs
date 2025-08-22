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
    /// 日 期： 2023-09-18 15:09:45
    /// 描 述： mes_transferorderde
    /// </summary>
    public class MesTransferOrderDetailsBLL: BLLBase, IMesTransferOrderDetailsBLL, BLL {
        private readonly MesTransferOrderDetailsService mesTransferOrderDetailsService = new MesTransferOrderDetailsService();
        #region 获取数据
        /// <summary>
        /// 获取mes_TransferOrderDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferOrderDetailsEntity>>GetList(MesTransferOrderDetailsEntity queryParams) {
            return mesTransferOrderDetailsService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_TransferOrderDetails的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTransferOrderDetailsEntity>>GetPageList(Pagination pagination, MesTransferOrderDetailsEntity queryParams) {
            return mesTransferOrderDetailsService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTransferOrderDetailsEntity>GetEntity(string keyValue) {
            return mesTransferOrderDetailsService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesTransferOrderDetailsService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_TransferOrderDetails的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesTransferOrderDetailsService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesTransferOrderDetailsService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesTransferOrderDetailsEntity entity) {
            await mesTransferOrderDetailsService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesTransferOrderDetailsEntity>list) {
            await mesTransferOrderDetailsService.SaveList(key, list);
        }
        #endregion
    }
}