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
    /// 日 期： 2022-12-05 16:50:21
    /// 描 述： 物料属性配置
    /// </summary>
    public class CaseErpMaterialpropertyBLL : BLLBase, ICaseErpMaterialpropertyBLL,BLL
    {
        private readonly CaseErpMaterialpropertyService caseErpMaterialpropertyService = new CaseErpMaterialpropertyService();

        

        #region 获取数据
        /// <summary>
        /// 获取物料属性配置的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpMaterialpropertyEntity>> GetList(CaseErpMaterialpropertyEntity queryParams)
        {
            return caseErpMaterialpropertyService.GetList(queryParams);
        }

        /// <summary>
        /// 获取物料属性配置的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpMaterialpropertyEntity>> GetPageList(Pagination pagination, CaseErpMaterialpropertyEntity queryParams)
        {
            return caseErpMaterialpropertyService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpMaterialpropertyEntity> GetEntity(string keyValue)
        {
            return caseErpMaterialpropertyService.GetEntity(keyValue);
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
            await caseErpMaterialpropertyService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpMaterialpropertyEntity entity)
        {
            
            await caseErpMaterialpropertyService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpMaterialpropertyService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取对应物料属性主键-【根据物料属性名称】
        /// </summary>
        /// <param name="F_Type">物料类别</param>
        /// <returns></returns>
        public async Task<string> GetMaterialPropertyId(string F_Type)
        {
            var entity = await caseErpMaterialpropertyService.BaseRepository().FindEntity<CaseErpMaterialpropertyEntity>(t => t.F_Type == F_Type);
            if (entity != null)
            {
                return entity.F_Id;
            }
            return string.Empty;
        }

        #endregion
    }
}
