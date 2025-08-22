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
    /// 日 期： 2023-08-18 11:31:18
    /// 描 述： 工序派工物料
    /// </summary>
    public class MesProcessMaterialInfoBLL: BLLBase, IMesProcessMaterialInfoBLL, BLL {
        private readonly MesProcessMaterialInfoService mesProcessMaterialInfoService = new MesProcessMaterialInfoService();
        #region 获取数据
        /// <summary>
        /// 获取工序派工物料的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessMaterialInfoEntity>>GetList(MesProcessMaterialInfoEntity queryParams) {
            return mesProcessMaterialInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取本级及下级物料信息
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        public Task<List<MesProcessMaterialInfoEntity>> GetChildrenList(string KeyValue)
        {
            return mesProcessMaterialInfoService.GetChildrenList(KeyValue);
        }
        /// <summary>
        /// 获取工序派工物料的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessMaterialInfoEntity>>GetPageList(Pagination pagination, MesProcessMaterialInfoEntity queryParams) {
            return mesProcessMaterialInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessMaterialInfoEntity>GetEntity(string keyValue) {
            return mesProcessMaterialInfoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessMaterialInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessMaterialInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessMaterialInfoEntity entity) {
            await mesProcessMaterialInfoService.SaveEntity(keyValue, entity);
        }
        #endregion
    }
}