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
    /// 日 期： 2023-08-18 11:30:09
    /// 描 述： 工序派工批次
    /// </summary>
    public class MesProcessBacthInfoBLL: BLLBase, IMesProcessBacthInfoBLL, BLL {
        private readonly MesProcessBacthInfoService mesProcessBacthInfoService = new MesProcessBacthInfoService();
        #region 获取数据
        /// <summary>
        /// 获取工序派工批次的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessBacthInfoEntity>>GetList(MesProcessBacthInfoEntity queryParams) {
            return mesProcessBacthInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取工序派工批次的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessBacthInfoEntity>>GetPageList(Pagination pagination, MesProcessBacthInfoEntity queryParams) {
            return mesProcessBacthInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessBacthInfoEntity>GetEntity(string keyValue) {
            return mesProcessBacthInfoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessBacthInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessBacthInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessBacthInfoEntity entity) {
            await mesProcessBacthInfoService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}