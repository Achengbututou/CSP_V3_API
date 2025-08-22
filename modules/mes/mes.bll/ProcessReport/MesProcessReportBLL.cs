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
    /// 日 期： 2023-08-18 16:15:01
    /// 描 述： 报工
    /// </summary>
    public class MesProcessReportBLL: BLLBase, IMesProcessReportBLL, BLL {
        private readonly MesProcessReportService mesProcessReportService = new MesProcessReportService();
        #region 获取数据
        /// <summary>
        /// 获取报工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessReportEntity>>GetList(MesProcessReportEntity queryParams) {
            return mesProcessReportService.GetList(queryParams);
        }
        /// <summary>
        /// 获取报工的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessReportEntity>>GetPageList(Pagination pagination, MesProcessReportEntity queryParams) {
            return mesProcessReportService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessReportEntity>GetEntity(string keyValue) {
            return mesProcessReportService.GetEntity(keyValue);
        }
        /// <summary>
        /// 获取报工统计情况
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessReportEntity>> GetProcessReportList(Pagination pagination, MesProcessReportEntity queryParams)
        {
            return mesProcessReportService.GetProcessReportList(pagination, queryParams);  
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessReportService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessReportService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessReportEntity entity) {
            await mesProcessReportService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}