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
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： mes_processworkstat
    /// </summary>
    public class MesProcessWorkstationBLL: BLLBase, IMesProcessWorkstationBLL, BLL {
        private readonly MesProcessWorkstationService mesProcessWorkstationService = new MesProcessWorkstationService();
        #region 获取数据
        /// <summary>
        /// 获取mes_ProcessWorkstation的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessWorkstationEntity>>GetList(MesProcessWorkstationEntity queryParams) {
            return mesProcessWorkstationService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_ProcessWorkstation的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessWorkstationEntity>>GetPageList(Pagination pagination, MesProcessWorkstationEntity queryParams) {
            return mesProcessWorkstationService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessWorkstationEntity>GetEntity(string keyValue) {
            return mesProcessWorkstationService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessWorkstationService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_ProcessWorkstation的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesProcessWorkstationService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessWorkstationService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessWorkstationEntity entity) {
            await mesProcessWorkstationService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesProcessWorkstationEntity>list) {
            await mesProcessWorkstationService.SaveList(key, list);
        }
        #endregion
    }
}