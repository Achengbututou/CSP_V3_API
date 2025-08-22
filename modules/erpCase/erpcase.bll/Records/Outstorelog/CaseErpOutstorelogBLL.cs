using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using SqlSugar;

namespace erpCase.bll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期： 2022-12-05 09:07:38
    /// 描 述： 出库记录
    /// </summary>
    public class CaseErpOutstorelogBLL : BLLBase, ICaseErpOutstorelogBLL,BLL
    {
        private readonly CaseErpOutstorelogService caseErpOutstorelogService = new CaseErpOutstorelogService();
        private readonly ICaseErpMaterialBLL _icaseErpMaterialBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CaseErpOutstorelogBLL(ICaseErpMaterialBLL icaseErpMaterialBLL)
        {
            _icaseErpMaterialBLL = icaseErpMaterialBLL ?? throw new ArgumentNullException(nameof(icaseErpMaterialBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取出库记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpOutstorelogEntity>> GetList(CaseErpOutstorelogEntity queryParams)
        {
            return caseErpOutstorelogService.GetList(queryParams);
        }

        /// <summary>
        /// 获取出库记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpOutstorelogEntity>> GetPageList(Pagination pagination, CaseErpOutstorelogEntity queryParams)
        {
            return caseErpOutstorelogService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpOutstorelogEntity> GetEntity(string keyValue)
        {
            return caseErpOutstorelogService.GetEntity(keyValue);
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
            await caseErpOutstorelogService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpOutstorelogEntity entity)
        {
            entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString(); 

            await caseErpOutstorelogService.SaveEntity(keyValue, entity);

            //同步物料信息的当前库存
            if (!string.IsNullOrEmpty(entity.F_MaterialId))
            {
                var MaterialEntity = await _icaseErpMaterialBLL.GetEntity(entity.F_MaterialId);
                if (MaterialEntity != null)
                {
                    //入库总量
                    var SumInStore = await caseErpOutstorelogService.BaseRepository().ORM.Queryable<CaseErpInstorelogEntity>()
                        .Where(it => it.F_MaterialId == MaterialEntity.F_Id)
                        .Select(t => new CaseErpInstorelogEntity
                        {
                            SumInStore = SqlFunc.AggregateSum(t.F_Count),//入库总量
                        }).ToListAsync();
                    //出库总量
                    var SumOutStore = await caseErpOutstorelogService.BaseRepository().ORM.Queryable<CaseErpOutstorelogEntity>()
                        .Where(it => it.F_MaterialId == MaterialEntity.F_Id)
                        .Select(t => new CaseErpOutstorelogEntity
                        {
                            SumOutStore = SqlFunc.AggregateSum(t.F_Count),//出库总量
                        }).ToListAsync();

                    MaterialEntity.F_Inventory = SumInStore[0].SumInStore??0- SumOutStore[0].SumOutStore??0;//最新当前库存=入库总量-出库数量
                    await _icaseErpMaterialBLL.SaveEntity(entity.F_MaterialId, MaterialEntity);
                }
            }
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpOutstorelogService.Deletes(keyValues);
        }

        

        #endregion
    }
}
