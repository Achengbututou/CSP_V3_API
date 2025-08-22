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
    /// 描 述： mes_processmater
    /// </summary>
    public class MesProcessMaterialBLL: BLLBase, IMesProcessMaterialBLL, BLL {
        private readonly MesProcessMaterialService mesProcessMaterialService = new MesProcessMaterialService();
        #region 获取数据
        /// <summary>
        /// 获取mes_ProcessMaterial的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessMaterialEntity>>GetList(MesProcessMaterialEntity queryParams) {
            return mesProcessMaterialService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_ProcessMaterial的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessMaterialEntity>>GetPageList(Pagination pagination, MesProcessMaterialEntity queryParams) {
            return mesProcessMaterialService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessMaterialEntity>GetEntity(string keyValue) {
            return mesProcessMaterialService.GetEntity(keyValue);
        }
        #endregion
           
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessMaterialService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_ProcessMaterial的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesProcessMaterialService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessMaterialService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessMaterialEntity entity) {
            await mesProcessMaterialService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesProcessMaterialEntity>list) {
            await mesProcessMaterialService.SaveList(key, list);
        }
        #endregion
    }
}