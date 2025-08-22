using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using SqlSugar;
using System.Linq;

namespace erpCase.bll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期： 2022-12-02 15:33:00
    /// 描 述： 入库记录
    /// </summary>
    public class CaseErpInstorelogBLL : BLLBase, ICaseErpInstorelogBLL,BLL
    {
        private readonly CaseErpInstorelogService caseErpInstorelogService = new CaseErpInstorelogService();
        private readonly ICaseErpMaterialBLL _icaseErpMaterialBLL;
        private readonly ICaseErpPurchaseBLL _icaseErpPurchaseBLL;
        private readonly ICaseErpPurchasedetailBLL _iCaseErpPurchasedetailBLL;
        private readonly ICaseErpApplyBLL _icaseErpApplyBLL;
        private readonly ICaseErpApplydetailBLL _icaseErpApplydetailBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CaseErpInstorelogBLL(
            ICaseErpMaterialBLL icaseErpMaterialBLL, 
            ICaseErpPurchaseBLL icaseErpPurchaseBLL,
            ICaseErpPurchasedetailBLL icaseErpPurchasedetailBLL,
            ICaseErpApplyBLL icaseErpApplyBLL,
            ICaseErpApplydetailBLL icaseErpApplydetailBLL)
        {
            _icaseErpMaterialBLL = icaseErpMaterialBLL ?? throw new ArgumentNullException(nameof(icaseErpMaterialBLL));
            _icaseErpPurchaseBLL = icaseErpPurchaseBLL ?? throw new ArgumentNullException(nameof(icaseErpPurchaseBLL));
            _iCaseErpPurchasedetailBLL = icaseErpPurchasedetailBLL ?? throw new ArgumentNullException(nameof(icaseErpPurchasedetailBLL));
            _icaseErpApplyBLL = icaseErpApplyBLL ?? throw new ArgumentNullException(nameof(icaseErpMaterialBLL));
            _icaseErpApplydetailBLL = icaseErpApplydetailBLL ?? throw new ArgumentNullException(nameof(icaseErpApplydetailBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取入库记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpInstorelogEntity>> GetList(CaseErpInstorelogEntity queryParams)
        {
            return caseErpInstorelogService.GetList(queryParams);
        }

        /// <summary>
        /// 获取入库记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpInstorelogEntity>> GetPageList(Pagination pagination, CaseErpInstorelogEntity queryParams)
        {
            return caseErpInstorelogService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpInstorelogEntity> GetEntity(string keyValue)
        {
            return caseErpInstorelogService.GetEntity(keyValue);
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
            await caseErpInstorelogService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpInstorelogEntity entity)
        {
            entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString();
            await caseErpInstorelogService.SaveEntity(keyValue, entity);
            //同步物料信息的当前库存
            if (!string.IsNullOrEmpty(entity.F_MaterialId))
            {
                var MaterialEntity = await _icaseErpMaterialBLL.GetEntity(entity.F_MaterialId);
                if (MaterialEntity!=null)
                {
                    //入库总量
                    var SumInStore = await caseErpInstorelogService.BaseRepository().ORM.Queryable<CaseErpInstorelogEntity>()
                        .Where(it => it.F_MaterialId == MaterialEntity.F_Id)
                        .Select(t => new CaseErpInstorelogEntity
                        {
                            SumInStore = SqlFunc.AggregateSum(t.F_Count),//入库总量
                        }).ToListAsync();

                    //出库总量
                    var SumOutStore = await caseErpInstorelogService.BaseRepository().ORM.Queryable<CaseErpOutstorelogEntity>()
                        .Where(it => it.F_MaterialId == MaterialEntity.F_Id)
                        .Select(t => new CaseErpOutstorelogEntity
                        {
                            SumOutStore = SqlFunc.AggregateSum(t.F_Count),//出库总量
                        }).ToListAsync();

                    MaterialEntity.F_Inventory = SumInStore[0].SumInStore??0 - SumOutStore[0].SumOutStore??0;//最新当前库存=入库总量-出库数量
                    await _icaseErpMaterialBLL.SaveEntity(entity.F_MaterialId, MaterialEntity);
                }
            }
            //入库记录关联到对应的采购申请，进行采购申请状态的更新
            var F_PurchaseState = 0;//采购状态(0未采购，1部分采购，2已采购)
            if (!string.IsNullOrEmpty(entity.F_PurchaseId) && !string.IsNullOrEmpty(entity.F_MaterialId))
            {
                //采购订单
                var PurchaeEntity = await _icaseErpPurchaseBLL.GetEntity(entity.F_PurchaseId);
                if (PurchaeEntity!=null)
                {
                    if (PurchaeEntity.F_IsRelated==0)
                    {
                        var ApplyEntity = await _icaseErpApplyBLL.GetEntity(PurchaeEntity.F_ApplyId);
                        if (ApplyEntity!=null)
                        {
                            //对应入库记录信息
                            var InstoreList = (await caseErpInstorelogService.GetList(new CaseErpInstorelogEntity { F_PurchaseId = entity.F_PurchaseId })).ToObject<List<CaseErpInstorelogEntity>>();
                            //采购申请明细
                            var ApplyList = (await _icaseErpApplydetailBLL.GetList(new CaseErpApplydetailEntity { F_ApplyId = ApplyEntity.F_Id })).ToObject<List<CaseErpApplydetailEntity>>();
                            if (InstoreList.Count > 0)
                            {
                                var IsPurchaseAll = true;//是否采购全部
                                foreach (var item in ApplyList)
                                {
                                    var MaterialEntity = await caseErpInstorelogService.BaseRepository().FindEntity<CaseErpMaterialEntity>(it=>it.F_Number== item.F_Number);
                                    if (MaterialEntity!=null)
                                    {
                                        //循环采购申请明细与入库记录对比，要是都包含且数量大于等于目标数量则为全部采购，反之为部分采购【用物料编码查询】
                                        var same = InstoreList.Count(it => it.F_MaterialId == MaterialEntity.F_Id&& it.F_Count >= item.F_Count);
                                        if (same == 0)//相同个数为零，则部分采购
                                        {
                                            IsPurchaseAll = false;
                                            break;
                                        }
                                    }
                                }
                                if (IsPurchaseAll)
                                {
                                    F_PurchaseState = 2;
                                }
                                else
                                {
                                    F_PurchaseState = 1;
                                }
                            }
                            ApplyEntity.F_PurchaseState = F_PurchaseState;//采购状态(0未采购，1部分采购，2已采购)
                            await _icaseErpApplyBLL.SaveEntity(ApplyEntity.F_Id, ApplyEntity);
                        }
                    }
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
            await caseErpInstorelogService.Deletes(keyValues);
        }

        

        #endregion
    }
}
