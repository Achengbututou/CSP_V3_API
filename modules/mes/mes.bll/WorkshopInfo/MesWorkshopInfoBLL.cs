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
    /// 日 期： 2023-07-27 13:56:01
    /// 描 述： 车间信息
    /// </summary>
    public class MesWorkshopInfoBLL: BLLBase, IMesWorkshopInfoBLL, BLL {
        private readonly MesWorkshopInfoService mesWorkshopInfoService = new MesWorkshopInfoService();
        #region 获取数据
        /// <summary>
        /// 获取车间信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWorkshopInfoEntity>>GetList(MesWorkshopInfoEntity queryParams) {
            return mesWorkshopInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取车间信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesWorkshopInfoEntity>>GetPageList(Pagination pagination, MesWorkshopInfoEntity queryParams) {
            return mesWorkshopInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesWorkshopInfoEntity>GetEntity(string keyValue) {
            return mesWorkshopInfoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesWorkshopInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesWorkshopInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesWorkshopInfoEntity entity) {
            entity.F_WorkshopNumber = (await GetRuleCodeEx(entity.F_WorkshopNumber)).ToString();
            await mesWorkshopInfoService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}