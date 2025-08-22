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
    /// 日 期： 2022-12-05 16:40:15
    /// 描 述： 销售订单信息
    /// </summary>
    public class CaseErpSaleBLL : BLLBase, ICaseErpSaleBLL,BLL
    {
        private readonly CaseErpSaleService caseErpSaleService = new CaseErpSaleService();

        private readonly ICaseErpSaledetailBLL _iCaseErpSaledetailBLL;
        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iCaseErpSaledetailBLL">销售订单详情【case_erp_saledetail】接口</param>
        public CaseErpSaleBLL(ICaseErpSaledetailBLL iCaseErpSaledetailBLL)
        {
            _iCaseErpSaledetailBLL = iCaseErpSaledetailBLL?? throw new ArgumentNullException(nameof(iCaseErpSaledetailBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取销售订单信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSaleEntity>> GetList(CaseErpSaleEntity queryParams)
        {
            return caseErpSaleService.GetList(queryParams);
        }

        /// <summary>
        /// 获取销售订单信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpSaleEntity>> GetPageList(Pagination pagination, CaseErpSaleEntity queryParams)
        {
            return await caseErpSaleService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<CaseErpSaleEntity> GetEntity(string keyValue)
        {
            #region 添加操作记录-销售订单
            string F_Description = "查看销售订单";
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(keyValue, "3", F_Description, GetUserId());
            #endregion

            return await caseErpSaleService.GetEntity(keyValue);
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
            await caseErpSaleService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new SaleDto();
            res.CaseErpSaleEntity = await GetEntity(keyValue);
            if(res.CaseErpSaleEntity != null)
            {
                res.CaseErpSaledetailList = await _iCaseErpSaledetailBLL.GetList(new CaseErpSaledetailEntity { F_SaleId = res.CaseErpSaleEntity.F_Id });
            }
            caseErpSaleService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if(res.CaseErpSaleEntity != null)
                {
                    await _iCaseErpSaledetailBLL.DeleteRelateEntity(res.CaseErpSaleEntity.F_Id);
                }
                caseErpSaleService.Commit();
            }
            catch (Exception)
            {
                caseErpSaleService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSaleEntity entity)
        {
            
            await caseErpSaleService.SaveEntity(keyValue, entity);

            #region 添加操作记录-销售订单
            string F_Description = "修改销售订单";
            if (string.IsNullOrEmpty(keyValue))
            {
                F_Description = "新增销售订单";
            }
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(entity.F_Id, "3", F_Description, GetUserId());
            #endregion
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, SaleDto dto)
        {
            caseErpSaleService.BeginTrans();
            if (dto.CaseErpSaleEntity.F_IsSysNum == 0)//是否系统编号(0是，1否)
            {
                dto.CaseErpSaleEntity.F_Number = (await GetRuleCodeEx(dto.CaseErpSaleEntity.F_Number)).ToString();
            }
            //产品概要
            var F_ProductSynopsis = string.Empty;
            if (dto.CaseErpSaledetailList != null)
            {
                foreach (var item in dto.CaseErpSaledetailList)
                {
                    F_ProductSynopsis += $"{item.F_Name}:{item.F_Count},";
                }
                dto.CaseErpSaleEntity.F_ProductSynopsis = F_ProductSynopsis.TrimEnd(',');
            }
            try
            {
                await SaveEntity(keyValue,dto.CaseErpSaleEntity);
                await _iCaseErpSaledetailBLL.SaveList(dto.CaseErpSaleEntity.F_Id,dto.CaseErpSaledetailList);
                caseErpSaleService.Commit();
            }
            catch (Exception)
            {
                caseErpSaleService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpSaleService.Deletes(keyValues);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues)
        {
            var keyValuelist = keyValues.Split(",");
            foreach (var keyValue in keyValuelist)
            {
                var res = new SaleDto();
                res.CaseErpSaleEntity = await GetEntity(keyValue);
            if(res.CaseErpSaleEntity != null)
            {
                res.CaseErpSaledetailList = await _iCaseErpSaledetailBLL.GetList(new CaseErpSaledetailEntity { F_SaleId = res.CaseErpSaleEntity.F_Id });
            }
                caseErpSaleService.BeginTrans();
                try
                {
                    await Delete(keyValue);
                if(res.CaseErpSaleEntity != null)
                {
                    await _iCaseErpSaledetailBLL.DeleteRelateEntity(res.CaseErpSaleEntity.F_Id);
                }
                    caseErpSaleService.Commit();
                }
                catch (Exception)
                {
                    caseErpSaleService.Rollback();
                    throw;
                }
            }
        }


        #endregion
    }
}
