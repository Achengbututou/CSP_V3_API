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
    /// 日 期： 2023-07-31 11:46:28
    /// 描 述： 储存类型
    /// </summary>
    public class MesStorageTypeBLL: BLLBase, IMesStorageTypeBLL, BLL {
        private readonly MesStorageTypeService mesStorageTypeService = new MesStorageTypeService();
        #region 获取数据
        /// <summary>
        /// 获取储存类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesStorageTypeEntity>>GetList(MesStorageTypeEntity queryParams) {
            return mesStorageTypeService.GetList(queryParams);
        }
        /// <summary>
        /// 获取储存类型的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesStorageTypeEntity>>GetPageList(Pagination pagination, MesStorageTypeEntity queryParams) {
            return mesStorageTypeService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesStorageTypeEntity>GetEntity(string keyValue) {
            return mesStorageTypeService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesStorageTypeService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesStorageTypeService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesStorageTypeEntity entity) {
            entity.F_StorageTypeNumber = (await GetRuleCodeEx(entity.F_StorageTypeNumber)).ToString();
            await mesStorageTypeService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}