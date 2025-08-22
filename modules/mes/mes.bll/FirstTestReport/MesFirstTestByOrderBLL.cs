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
    /// 日 期： 2023-08-29 13:47:39
    /// 描 述： mes_FirstTestByOrder
    /// </summary>
    public class MesFirstTestByOrderBLL: BLLBase, IMesFirstTestByOrderBLL, BLL {
        private readonly MesFirstTestByOrderService mesFirstTestByOrderService = new MesFirstTestByOrderService();
        #region 获取数据
        /// <summary>
        /// 获取mes_FirstTestByOrder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFirstTestByOrderEntity>>GetList(MesFirstTestByOrderEntity queryParams) {
            return mesFirstTestByOrderService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_FirstTestByOrder的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesFirstTestByOrderEntity>>GetPageList(Pagination pagination, MesFirstTestByOrderEntity queryParams) {
            return mesFirstTestByOrderService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesFirstTestByOrderEntity>GetEntity(string keyValue) {
            return mesFirstTestByOrderService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesFirstTestByOrderService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_FirstTestByOrder的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesFirstTestByOrderService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesFirstTestByOrderService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesFirstTestByOrderEntity entity) {
            await mesFirstTestByOrderService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesFirstTestByOrderEntity>list) {
            await mesFirstTestByOrderService.SaveList(key, list);
        }
        #endregion
    }
}