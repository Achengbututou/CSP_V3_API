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
    /// 日 期： 2022-12-05 16:53:20
    /// 描 述： 单位列表
    /// </summary>
    public class CaseErpUnitBLL : BLLBase, ICaseErpUnitBLL, BLL
    {
        private readonly CaseErpUnitService caseErpUnitService = new CaseErpUnitService();



        #region 获取数据
        /// <summary>
        /// 获取单位列表的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitEntity>> GetList(CaseErpUnitEntity queryParams)
        {
            return caseErpUnitService.GetList(queryParams);
        }

        /// <summary>
        /// 获取单位列表的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitEntity>> GetPageList(Pagination pagination, CaseErpUnitEntity queryParams)
        {
            return caseErpUnitService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpUnitEntity> GetEntity(string keyValue)
        {
            return caseErpUnitService.GetEntity(keyValue);
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
            await caseErpUnitService.Delete(keyValue);
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpUnitEntity entity)
        {
            //若是此单位选择为基准单位，则将其余其余相同单位类型的单位列表改为不是基准单位
            if (entity.F_IsStandard == 0)
            {
                var UtilList = await caseErpUnitService.GetList(new CaseErpUnitEntity { F_UnitTypeId = entity.F_UnitTypeId });
                foreach (var item in UtilList)
                {
                    if (keyValue != item.F_Id)
                    {
                        item.F_IsStandard = 1;
                        await caseErpUnitService.SaveEntity(item.F_Id, item);
                    }

                }
            }
            await caseErpUnitService.SaveEntity(keyValue, entity);
        }



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpUnitService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取对应单位主键-【根据单位名称】
        /// </summary>
        /// <param name="F_Name">单位名称</param>
        /// <returns></returns>
        public async Task<string> GetUnitId(string F_Name)
        {
            var entity = await caseErpUnitService.BaseRepository().FindEntity<CaseErpUnitEntity>(t => t.F_Name == F_Name);
            if (entity != null)
            {
                return entity.F_Id;
            }
            return string.Empty;
        }

        #endregion
    }
}
