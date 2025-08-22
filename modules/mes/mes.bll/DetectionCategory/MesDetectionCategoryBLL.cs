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
    /// 日 期： 2023-08-22 15:44:28
    /// 描 述： 检测类别
    /// </summary>
    public class MesDetectionCategoryBLL: BLLBase, IMesDetectionCategoryBLL, BLL {
        private readonly MesDetectionCategoryService mesDetectionCategoryService = new MesDetectionCategoryService();
        #region 获取数据
        /// <summary>
        /// 获取检测类别的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDetectionCategoryEntity>>GetList(MesDetectionCategoryEntity queryParams) {
            return mesDetectionCategoryService.GetList(queryParams);
        }
        /// <summary>
        /// 获取检测类别的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDetectionCategoryEntity>>GetPageList(Pagination pagination, MesDetectionCategoryEntity queryParams) {
            return mesDetectionCategoryService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesDetectionCategoryEntity>GetEntity(string keyValue) {
            return mesDetectionCategoryService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesDetectionCategoryService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesDetectionCategoryService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesDetectionCategoryEntity entity) {
            entity.F_DetectionCateCode = (await GetRuleCodeEx(entity.F_DetectionCateCode)).ToString();
            await mesDetectionCategoryService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}