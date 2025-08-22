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
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:44:00
    /// 描 述： 客户回款详情
    /// </summary>
    public class CaseErpCustomergatherdetailBLL : BLLBase, ICaseErpCustomergatherdetailBLL,BLL
    {
        private readonly CaseErpCustomergatherdetailService caseErpCustomergatherdetailService = new CaseErpCustomergatherdetailService();
        private readonly ICaseErpCustomergatherBLL _icaseErpCustomergatherBLL;

        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iCaseErpCustomercontactsBLL">客户联系人【case_erp_customercontacts】接口</param>
        public CaseErpCustomergatherdetailBLL(ICaseErpCustomergatherBLL icaseErpCustomergatherBLL)
        {
            _icaseErpCustomergatherBLL = icaseErpCustomergatherBLL ?? throw new ArgumentNullException(nameof(icaseErpCustomergatherBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取客户回款详情的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomergatherdetailEntity>> GetList(CaseErpCustomergatherdetailEntity queryParams)
        {
            return caseErpCustomergatherdetailService.GetList(queryParams);
        }

        /// <summary>
        /// 获取客户回款详情的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomergatherdetailEntity>> GetPageList(Pagination pagination, CaseErpCustomergatherdetailEntity queryParams)
        {
            return caseErpCustomergatherdetailService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpCustomergatherdetailEntity> GetEntity(string keyValue)
        {
            return caseErpCustomergatherdetailService.GetEntity(keyValue);
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
            await caseErpCustomergatherdetailService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpCustomergatherdetailEntity entity)
        {
            caseErpCustomergatherdetailService.BeginTrans();

            await caseErpCustomergatherdetailService.SaveEntity(keyValue, entity);
            //查询该回款详情总和
            var Sum = await caseErpCustomergatherdetailService.BaseRepository().ORM.Queryable<CaseErpCustomergatherdetailEntity>()
                .Where(it=>it.F_GatherId == entity.F_GatherId)
                .Select(t=>new CaseErpCustomergatherdetailEntity
                {
                    SumAmountCollect = SqlFunc.AggregateSum(t.F_AmountCollect),//总销售额
                }).ToListAsync();
            var GatherEntity = await _icaseErpCustomergatherBLL.GetEntity(entity.F_GatherId);
            if (Sum.Count>0)
            {
                //已收金额
                GatherEntity.F_AlreadyAmount = Sum[0].SumAmountCollect;
                //未收金额
                GatherEntity.F_UnpaidAmount = GatherEntity.F_WaitAmount - Sum[0].SumAmountCollect;

                await _icaseErpCustomergatherBLL.SaveEntity(GatherEntity.F_Id, GatherEntity);
                
            }
            if (GatherEntity.F_UnpaidAmount < 0)
            {
                caseErpCustomergatherdetailService.Rollback();
            }
            else
            {
                caseErpCustomergatherdetailService.Commit();
            }
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpCustomergatherdetailService.Deletes(keyValues);
        }

        

        #endregion
    }
}
