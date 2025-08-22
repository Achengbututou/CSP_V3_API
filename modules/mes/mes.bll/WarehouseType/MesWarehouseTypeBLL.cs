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
    /// 日 期： 2023-07-31 11:49:49
    /// 描 述： 仓库类型
    /// </summary>
    public class MesWarehouseTypeBLL: BLLBase, IMesWarehouseTypeBLL, BLL {
        private readonly MesWarehouseTypeService mesWarehouseTypeService = new MesWarehouseTypeService();
        #region 获取数据
        /// <summary>
        /// 获取仓库类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehouseTypeEntity>>GetList(MesWarehouseTypeEntity queryParams) {
            return mesWarehouseTypeService.GetList(queryParams);
        }
        /// <summary>
        /// 获取仓库类型的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWarehouseTypeEntity>>GetPageList(Pagination pagination, MesWarehouseTypeEntity queryParams) {
            return mesWarehouseTypeService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesWarehouseTypeEntity>GetEntity(string keyValue) {
            return mesWarehouseTypeService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesWarehouseTypeService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesWarehouseTypeService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesWarehouseTypeEntity entity) {
            entity.F_WarehouseTypeNumber = (await GetRuleCodeEx(entity.F_WarehouseTypeNumber)).ToString();
            await mesWarehouseTypeService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}