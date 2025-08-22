using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADMF005.ibll;
namespace ADMF005.bll {
    /// <summary>
    /// 访客申请-访客出入厂
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2024-05-03 16:04:51
    /// 描 述： Visitors_Enter
    /// </summary>
    public class VisitorsEnterBLL: BLLBase, IVisitorsEnterBLL, BLL {
        private readonly VisitorsEnterService visitorsEnterService = new VisitorsEnterService();
        #region 获取数据
        /// <summary>
        /// 获取Visitors_Enter的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<VisitorsEnterEntity>>GetList(VisitorsEnterEntity queryParams) {
            return visitorsEnterService.GetList(queryParams);
        }
        /// <summary>
        /// 获取Visitors_Enter的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<VisitorsEnterEntity>>GetPageList(Pagination pagination, VisitorsEnterEntity queryParams) {
            string AuthoritySql = await this.GetDataAuthoritySql("ADMF005_List");
            if (string.IsNullOrEmpty(AuthoritySql))
            {
                AuthoritySql = string.Empty;
            }
            return await visitorsEnterService.GetPageList(pagination, queryParams, AuthoritySql);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<VisitorsEnterEntity>GetEntity(string keyValue) {
            return visitorsEnterService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await visitorsEnterService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await visitorsEnterService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, VisitorsEnterEntity entity)
        {
            entity.Visitors_Note_No = (await GetRuleCodeEx(entity.Visitors_Note_No)).ToString();
            await visitorsEnterService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}