using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using TencentCloud.Cme.V20191029.Models;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:42:10
    /// 描 述： 客户信息
    /// </summary>
    public class CaseErpCustomerBLL : BLLBase, ICaseErpCustomerBLL, BLL
    {
        private readonly CaseErpCustomerService caseErpCustomerService = new CaseErpCustomerService();

        private readonly ICaseErpCustomercontactsBLL _iCaseErpCustomercontactsBLL;
        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iCaseErpCustomercontactsBLL">客户联系人【case_erp_customercontacts】接口</param>
        public CaseErpCustomerBLL(ICaseErpCustomercontactsBLL iCaseErpCustomercontactsBLL)
        {
            _iCaseErpCustomercontactsBLL = iCaseErpCustomercontactsBLL ?? throw new ArgumentNullException(nameof(iCaseErpCustomercontactsBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取客户信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomerEntity>> GetList(CaseErpCustomerEntity queryParams)
        {
            return caseErpCustomerService.GetList(queryParams);
        }

        /// <summary>
        /// 获取客户信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpCustomerEntity>> GetPageList(Pagination pagination, CaseErpCustomerEntity queryParams)
        {
            string AuthoritySql = await this.GetDataAuthoritySql("erpsale");
            return await caseErpCustomerService.GetPageList(pagination, queryParams, AuthoritySql);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<CaseErpCustomerEntity> GetEntity(string keyValue)
        {
            #region 添加操作记录-客户
            string F_Description = "查看客户信息";
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(keyValue, "0", F_Description, GetUserId());
            #endregion

            return await caseErpCustomerService.GetEntity(keyValue);
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
            await caseErpCustomerService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new CustomerDto();
            res.CaseErpCustomerEntity = await GetEntity(keyValue);
            if (res.CaseErpCustomerEntity != null)
            {
                res.CaseErpCustomercontactsList = await _iCaseErpCustomercontactsBLL.GetList(new CaseErpCustomercontactsEntity { F_CustomerId = res.CaseErpCustomerEntity.F_Id });
            }
            caseErpCustomerService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if (res.CaseErpCustomerEntity != null)
                {
                    await _iCaseErpCustomercontactsBLL.DeleteRelateEntity(res.CaseErpCustomerEntity.F_Id);
                }
                caseErpCustomerService.Commit();
            }
            catch (Exception)
            {
                caseErpCustomerService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpCustomerEntity entity)
        {

            await caseErpCustomerService.SaveEntity(keyValue, entity);

            #region 添加操作记录-客户
            string F_Description = "修改客户信息";
            if (string.IsNullOrEmpty(keyValue))
            {
                F_Description = "添加客户";
            }
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(entity.F_Id, "0", F_Description, GetUserId());
            #endregion
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, CustomerDto dto)
        {
            caseErpCustomerService.BeginTrans();
            try
            {
                await SaveEntity(keyValue, dto.CaseErpCustomerEntity);
                await _iCaseErpCustomercontactsBLL.SaveList(dto.CaseErpCustomerEntity.F_Id, dto.CaseErpCustomercontactsList);
                caseErpCustomerService.Commit();
            }
            catch (Exception)
            {
                caseErpCustomerService.Rollback();
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
            await caseErpCustomerService.Deletes(keyValues);
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
                var res = new CustomerDto();
                res.CaseErpCustomerEntity = await GetEntity(keyValue);
                if (res.CaseErpCustomerEntity != null)
                {
                    res.CaseErpCustomercontactsList = await _iCaseErpCustomercontactsBLL.GetList(new CaseErpCustomercontactsEntity { F_CustomerId = res.CaseErpCustomerEntity.F_Id });
                }
                caseErpCustomerService.BeginTrans();
                try
                {
                    await Delete(keyValue);
                    if (res.CaseErpCustomerEntity != null)
                    {
                        await _iCaseErpCustomercontactsBLL.DeleteRelateEntity(res.CaseErpCustomerEntity.F_Id);
                    }
                    caseErpCustomerService.Commit();
                }
                catch (Exception)
                {
                    caseErpCustomerService.Rollback();
                    throw;
                }
            }
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 移入公海
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        public async Task TransferPublic(string ids)
        {
            string[] idlist = ids.Split(",");
            foreach (var id in idlist)
            {
                var entity = await GetEntity(id);
                if (entity != null)
                {
                    entity.F_SaleId = string.Empty;
                    entity.F_State = "1";
                    entity.F_InOpenDate = DateTime.Now;
                    await SaveEntity(id, entity);

                    #region 添加操作记录-客户
                    var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
                    await _iCaseErpLogBLL.SaveLog(entity.F_Id, "0", "移入公海", GetUserId());
                    #endregion
                }
            }
        }

        /// <summary>
        /// 客户领取
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task ReceiveCustomer(string id)
        {
            var entity = await GetEntity(id);
            if (entity != null)
            {
                entity.F_State = "0";
                entity.F_SaleId = GetUserId();
                await SaveEntity(id, entity);

                #region 添加操作记录-客户
                var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
                await _iCaseErpLogBLL.SaveLog(entity.F_Id, "0", "领取客户", GetUserId());
                #endregion
            }
        }

        #endregion
    }
}
