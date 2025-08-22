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
    /// 日 期： 2023-07-27 15:30:16
    /// 描 述： 产线信息
    /// </summary>
    public class MesProductionLineBLL: BLLBase, IMesProductionLineBLL, BLL {
        private readonly MesProductionLineService mesProductionLineService = new MesProductionLineService();
        #region 获取数据
        /// <summary>
        /// 获取产线信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionLineEntity>>GetList(MesProductionLineEntity queryParams) {
            return mesProductionLineService.GetList(queryParams);
        }
        /// <summary>
        /// 获取产线信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProductionLineEntity>>GetPageList(Pagination pagination, MesProductionLineEntity queryParams) {
            return mesProductionLineService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProductionLineEntity>GetEntity(string keyValue) {
            return mesProductionLineService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProductionLineService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProductionLineService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProductionLineEntity entity) {
            entity.F_ProductionNumber = (await GetRuleCodeEx(entity.F_ProductionNumber)).ToString();
            await mesProductionLineService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}