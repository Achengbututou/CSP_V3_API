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
    /// 日 期： 2023-08-22 15:53:49
    /// 描 述： 检测项目
    /// </summary>
    public class MesDetectionItemBLL: BLLBase, IMesDetectionItemBLL, BLL {
        private readonly MesDetectionItemService mesDetectionItemService = new MesDetectionItemService();
        #region 获取数据
        /// <summary>
        /// 获取检测项目的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDetectionItemEntity>>GetList(MesDetectionItemEntity queryParams) {
            return mesDetectionItemService.GetList(queryParams);
        }
        /// <summary>
        /// 获取检测项目的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDetectionItemEntity>>GetPageList(Pagination pagination, MesDetectionItemEntity queryParams) {
            return mesDetectionItemService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesDetectionItemEntity>GetEntity(string keyValue) {
            return mesDetectionItemService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesDetectionItemService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesDetectionItemService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesDetectionItemEntity entity) {
            entity.F_DetectionItemCode = (await GetRuleCodeEx(entity.F_DetectionItemCode)).ToString();
            await mesDetectionItemService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}