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
    /// 日 期： 2023-09-01 16:10:21
    /// 描 述： 项目状态
    /// </summary>
    public class MesProjectStateBLL: BLLBase, IMesProjectStateBLL, BLL {
        private readonly MesProjectStateService mesProjectStateService = new MesProjectStateService();
        #region 获取数据
        /// <summary>
        /// 获取项目状态的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProjectStateEntity>>GetList(MesProjectStateEntity queryParams) {
            return mesProjectStateService.GetList(queryParams);
        }
        /// <summary>
        /// 获取项目状态的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProjectStateEntity>>GetPageList(Pagination pagination, MesProjectStateEntity queryParams) {
            return mesProjectStateService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProjectStateEntity>GetEntity(string keyValue) {
            return mesProjectStateService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProjectStateService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProjectStateService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProjectStateEntity entity) {
            await mesProjectStateService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}