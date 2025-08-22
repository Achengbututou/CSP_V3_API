using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
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
    /// 日 期： 2022-12-05 16:54:57
    /// 描 述： 单位换算数据库执行类
    /// </summary>
    public class CaseErpUnitconvertdetailService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpUnitconvertdetailEntity, bool>> GetExpression(CaseErpUnitconvertdetailEntity queryParams) {
            var exp = Expressionable.Create<CaseErpUnitconvertdetailEntity>();
            if(!string.IsNullOrEmpty(queryParams.F_UnitConvertId))
            {
                exp = exp.And(t => t.F_UnitConvertId == queryParams.F_UnitConvertId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_UnitId),t => t.F_UnitId.Contains(queryParams.F_UnitId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_UnitName), t => t.F_UnitName.Contains(queryParams.F_UnitName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ShiftUnitName), t => t.F_ShiftUnitName.Contains(queryParams.F_ShiftUnitName));
            if (queryParams.F_Quantity != null)
            {
                exp = exp.And(t => t.F_Quantity == queryParams.F_Quantity);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ShiftUnitId),t => t.F_ShiftUnitId.Contains(queryParams.F_ShiftUnitId));
            if(queryParams.F_Description != null)
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
        /// 获取单位换算的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitconvertdetailEntity>> GetList(CaseErpUnitconvertdetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpUnitconvertdetailEntity>(expression);
        }

        /// <summary>
        /// 获取单位换算的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitconvertdetailEntity>> GetPageList(Pagination pagination, CaseErpUnitconvertdetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpUnitconvertdetailEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpUnitconvertdetailEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpUnitconvertdetailEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpUnitconvertdetailEntity>(keyValue);
        }

        /// <summary>
        /// 删除单位换算的数据根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository().Delete<CaseErpUnitconvertdetailEntity>(t=>t.F_UnitConvertId == key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpUnitconvertdetailEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = GetUserId();
                    entity.F_CreateUserName = GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();
                }


                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_Id = keyValue;
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = GetUserId();
                entity.F_ModifyUserName = GetUserName();

                await this.BaseRepository().Update(entity, true);
            }
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<CaseErpUnitconvertdetailEntity> list) {
            var addList = new List<CaseErpUnitconvertdetailEntity>();
            var db = this.BaseRepository().BeginTrans();
            try{
                await db.Delete<CaseErpUnitconvertdetailEntity>(t => t.F_UnitConvertId == key);
                foreach (var item in list)
                {
                    if(string.IsNullOrEmpty(item.F_Id))
                    {
                        item.F_Id = Guid.NewGuid().ToString();
                    }
                    item.F_UnitConvertId = key;
                    addList.Add(item);
                }
                if (addList.Count > 0)
                {
                    await db.Inserts(addList);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
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
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<CaseErpUnitconvertdetailEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
