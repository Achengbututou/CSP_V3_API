using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:10:51
    /// 描 述： 供应商风险评估数据库执行类
    /// </summary>
    public class CaseErpSupplierriskService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpSupplierriskEntity, bool>> GetExpression(CaseErpSupplierriskEntity queryParams) {
            var exp = Expressionable.Create<CaseErpSupplierriskEntity>();
            if(queryParams.F_Type != null)
            {
                exp = exp.And(t => t.F_Type == queryParams.F_Type);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierId),t => t.F_SupplierId.Contains(queryParams.F_SupplierId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CapacityLevel),t => t.F_CapacityLevel.Contains(queryParams.F_CapacityLevel));
            if(queryParams.F_CapacityReason != null)
            {
                exp = exp.And(t => t.F_CapacityReason == queryParams.F_CapacityReason);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CapacityFile),t => t.F_CapacityFile.Contains(queryParams.F_CapacityFile));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierLevel),t => t.F_SupplierLevel.Contains(queryParams.F_SupplierLevel));
            if(queryParams.F_SupplierReason != null)
            {
                exp = exp.And(t => t.F_SupplierReason == queryParams.F_SupplierReason);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SupplierFile),t => t.F_SupplierFile.Contains(queryParams.F_SupplierFile));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SafetyLevel),t => t.F_SafetyLevel.Contains(queryParams.F_SafetyLevel));
            if(queryParams.F_SafetyReason != null)
            {
                exp = exp.And(t => t.F_SafetyReason == queryParams.F_SafetyReason);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SafetyFile),t => t.F_SafetyFile.Contains(queryParams.F_SafetyFile));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FinalState),t => t.F_FinalState.Contains(queryParams.F_FinalState));
            if(queryParams.F_FinalReason != null)
            {
                exp = exp.And(t => t.F_FinalReason == queryParams.F_FinalReason);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_AuditState), t => t.F_AuditState.Contains(queryParams.F_AuditState));
            if (queryParams.F_AuditReason != null)
            {
                exp = exp.And(t => t.F_AuditReason == queryParams.F_AuditReason);
            }
            if (queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
            }
            if(queryParams.F_DeleteMark != null)
            {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if(queryParams.F_EnabledMark != null)
            {
                exp = exp.And(t => t.F_EnabledMark == queryParams.F_EnabledMark);
            }
            if(!string.IsNullOrEmpty(queryParams.F_CreateDateQRange))
            {
                var f_CreateDate_list = queryParams.F_CreateDateQRange.Split(" - ");
                DateTime f_CreateDate = Convert.ToDateTime(f_CreateDate_list[0]);
                DateTime f_CreateDate_end = Convert.ToDateTime(f_CreateDate_list[1]);
                exp = exp.And(t => t.F_CreateDate >= f_CreateDate &&t.F_CreateDate <= f_CreateDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserId),t => t.F_CreateUserId.Contains(queryParams.F_CreateUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserName),t => t.F_CreateUserName.Contains(queryParams.F_CreateUserName));
            if(!string.IsNullOrEmpty(queryParams.F_ModifyDateQRange))
            {
                var f_ModifyDate_list = queryParams.F_ModifyDateQRange.Split(" - ");
                DateTime f_ModifyDate = Convert.ToDateTime(f_ModifyDate_list[0]);
                DateTime f_ModifyDate_end = Convert.ToDateTime(f_ModifyDate_list[1]);
                exp = exp.And(t => t.F_ModifyDate >= f_ModifyDate &&t.F_ModifyDate <= f_ModifyDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserId),t => t.F_ModifyUserId.Contains(queryParams.F_ModifyUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserName),t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId),t => t.F_TenantId.Contains(queryParams.F_TenantId));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取供应商风险评估的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierriskEntity>> GetList(CaseErpSupplierriskEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSupplierriskEntity>(expression);
        }

        /// <summary>
        /// 获取供应商风险评估的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpSupplierriskEntity>> GetPageList(Pagination pagination, CaseErpSupplierriskEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpSupplierriskEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpSupplierriskEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpSupplierriskEntity>(keyValue);
        }
        
        /// <summary>
        /// 获取最近的年审信息
        /// </summary>
        /// <param name="supplierId">供应商主键</param>
        /// <returns></returns>
        public async Task<CaseErpSupplierriskEntity> GetEntityLastBySupplierId(string supplierId) {
            var list = (List<CaseErpSupplierriskEntity>)await this.BaseRepository().FindList<CaseErpSupplierriskEntity>(t=>t.F_SupplierId == supplierId && t.F_Type == 1,"F_CreateDate DESC");
            if (list.Count() > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
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
            await this.BaseRepository().Delete<CaseErpSupplierriskEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpSupplierriskEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_CreateDate = DateTime.Now;
                entity.F_CreateUserId = this.GetUserId();
                entity.F_CreateUserName = this.GetUserName();

                if (entity.F_Type == 0)
                {
                    var oldEntity =await this.BaseRepository().FindEntity<CaseErpSupplierriskEntity>(t => t.F_SupplierId ==entity.F_SupplierId && t.F_Type == 0);
                    if (oldEntity != null)
                    {
                        throw new Exception("风险评估已提交！");
                    }
                }

                else
                {
                    var oldEntitys =(List<CaseErpSupplierriskEntity>)await this.BaseRepository().FindList<CaseErpSupplierriskEntity>(t => t.F_SupplierId ==entity.F_SupplierId && t.F_Type == 1);
                    if (oldEntitys.FindIndex(t => t.F_CreateDate.ToDate().Year == DateTime.Now.Year) > -1)
                    {
                        throw new Exception("年审已提交！");
                    }
                }
                
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = this.GetUserId();
                entity.F_ModifyUserName = this.GetUserName();
                entity.F_Id = keyValue;


                await this.BaseRepository().Update(entity);
            }
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<CaseErpSupplierriskEntity>(keyValuesArr);
        }
        
        
        
        #endregion
    }
}
