using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMEMO.ibll;
using learun.database;
using System.Data;

namespace EMEMO.bll {
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： attendance_error_dtl
    /// </summary>
    public class EMEMO_dtl_SubBLL : BLLBase, IEMEMO_dtl_subBLL, BLL {
        private readonly WFProcessIBLL _wfProcessIBLL;

        private readonly EMEMO_dtl_SubService EMEMO_dtl_SubService = new EMEMO_dtl_SubService();
        #region 获取数据
        /// <summary>
        /// 获取attendance_error_dtl的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_dtl_subEntity>>GetList(EMEMO_dtl_subEntity queryParams) {
            return EMEMO_dtl_SubService.GetList(queryParams);
        }
        /// <summary>
        /// 获取attendance_error_dtl的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EMEMO_dtl_subEntity>>GetPageList(Pagination pagination, EMEMO_dtl_subEntity queryParams) {
            return EMEMO_dtl_SubService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EMEMO_dtl_subEntity> GetEntity(string keyValue) {
            return EMEMO_dtl_SubService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await EMEMO_dtl_SubService.Delete(keyValue);
        }
        /// <summary>
        /// 删除attendance_error_dtl的实体根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return EMEMO_dtl_SubService.DeleteRelate(key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await EMEMO_dtl_SubService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EMEMO_dtl_subEntity entity) {
            await EMEMO_dtl_SubService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<EMEMO_dtl_subEntity> list) {
            await EMEMO_dtl_SubService.SaveList(key, list);
        }

        /// <summary>
        /// 请数据数据验证和数据检查
        /// </summary>
        /// <returns></returns>
        public async Task EMEMOInterface(string InType, string par1, string par2, string par3, string par4, string par5, string par6)
        {
            await EMEMOInterface(InType, par1, par2, par3, par4, par5, par6);

        }
        public async Task GetBaseDataFromFVB()
        {
            await GetBaseDataFromFVB();

        }
        #endregion
    }
}