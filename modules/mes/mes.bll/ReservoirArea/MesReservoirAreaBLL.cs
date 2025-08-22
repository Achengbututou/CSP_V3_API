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
    /// 日 期： 2023-07-31 15:54:06
    /// 描 述： 库区信息
    /// </summary>
    public class MesReservoirAreaBLL: BLLBase, IMesReservoirAreaBLL, BLL {
        private readonly MesReservoirAreaService mesReservoirAreaService = new MesReservoirAreaService();
        #region 获取数据
        /// <summary>
        /// 获取库区信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesReservoirAreaEntity>>GetList(MesReservoirAreaEntity queryParams) {
            return mesReservoirAreaService.GetList(queryParams);
        }
        /// <summary>
        /// 获取库区信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesReservoirAreaEntity>>GetPageList(Pagination pagination, MesReservoirAreaEntity queryParams) {
            return mesReservoirAreaService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesReservoirAreaEntity>GetEntity(string keyValue) {
            return mesReservoirAreaService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesReservoirAreaService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesReservoirAreaService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesReservoirAreaEntity entity) {
            entity.F_ReservoirAreaNumber = (await GetRuleCodeEx(entity.F_ReservoirAreaNumber)).ToString();
            await mesReservoirAreaService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}