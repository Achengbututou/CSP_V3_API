using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:49:41
    /// 描 述： 物料类别配置
    /// </summary>
    public class CaseErpMaterialclassesBLL : BLLBase, ICaseErpMaterialclassesBLL,BLL
    {
        private readonly CaseErpMaterialclassesService caseErpMaterialclassesService = new CaseErpMaterialclassesService();

        

        #region 获取数据
        /// <summary>
        /// 获取物料类别配置的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpMaterialclassesEntity>> GetList(CaseErpMaterialclassesEntity queryParams)
        {
            return caseErpMaterialclassesService.GetList(queryParams);
        }

        /// <summary>
        /// 获取物料类别配置的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpMaterialclassesEntity>> GetPageList(Pagination pagination, CaseErpMaterialclassesEntity queryParams)
        {
            return caseErpMaterialclassesService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpMaterialclassesEntity> GetEntity(string keyValue)
        {
            return caseErpMaterialclassesService.GetEntity(keyValue);
        }

        

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue)
        {
            await caseErpMaterialclassesService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpMaterialclassesEntity entity)
        {
            
            await caseErpMaterialclassesService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpMaterialclassesService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取对应物料类别主键-【根据物料类别名称】
        /// </summary>
        /// <param name="F_Type">物料类别</param>
        /// <returns></returns>
        public async Task<string> GetMaterialClassesId(string F_Type)
        {
            var entity = await caseErpMaterialclassesService.BaseRepository().FindEntity<CaseErpMaterialclassesEntity>(t => t.F_Type == F_Type);
            if (entity != null)
            {
                return entity.F_Id;
            }
            return string.Empty;
        }

        #endregion
    }
}
