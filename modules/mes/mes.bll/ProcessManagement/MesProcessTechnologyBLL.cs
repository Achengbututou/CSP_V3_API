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
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： mes_processtechnol
    /// </summary>
    public class MesProcessTechnologyBLL: BLLBase, IMesProcessTechnologyBLL, BLL {
        private readonly MesProcessTechnologyService mesProcessTechnologyService = new MesProcessTechnologyService();
        #region 获取数据
        /// <summary>
        /// 获取mes_ProcessTechnology的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessTechnologyEntity>>GetList(MesProcessTechnologyEntity queryParams) {
            return mesProcessTechnologyService.GetList(queryParams);
        }
        /// <summary>
        /// 获取mes_ProcessTechnology的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessTechnologyEntity>>GetPageList(Pagination pagination, MesProcessTechnologyEntity queryParams) {
            return mesProcessTechnologyService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessTechnologyEntity>GetEntity(string keyValue) {
            return mesProcessTechnologyService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessTechnologyService.Delete(keyValue);
        }
        /// <summary>
        /// 删除mes_ProcessTechnology的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return mesProcessTechnologyService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessTechnologyService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessTechnologyEntity entity) {
            await mesProcessTechnologyService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesProcessTechnologyEntity>list) {
            await mesProcessTechnologyService.SaveList(key, list);
        }
        #endregion
    }
}