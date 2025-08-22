using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using erpCase.ibll;
using System.Linq;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-28 17:03:09
    /// 描 述： 设备告警数据库执行类
    /// </summary>
    public class CaseErpDevicewarnService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpDevicewarnEntity, bool>> GetExpression(CaseErpDevicewarnEntity queryParams) {
            var exp = Expressionable.Create<CaseErpDevicewarnEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_UserId),t => t.F_UserId.Contains(queryParams.F_UserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Type),t => t.F_Type.Contains(queryParams.F_Type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number),t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceId), t => t.F_DeviceId.Contains(queryParams.F_DeviceId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Name),t => t.F_Name.Contains(queryParams.F_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Model),t => t.F_Model.Contains(queryParams.F_Model));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Address),t => t.F_Address.Contains(queryParams.F_Address));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Level),t => t.F_Level.Contains(queryParams.F_Level));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DealWay), t => t.F_DealWay.Contains(queryParams.F_DealWay));
            if (queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_File),t => t.F_File.Contains(queryParams.F_File));
            if(queryParams.F_State != null)
            {
                exp = exp.And(t => t.F_State == queryParams.F_State);
            }
            if (!string.IsNullOrEmpty(queryParams.F_DateQRange))
            {
                var f_Date_list = queryParams.F_DateQRange.Split(" - ");
                DateTime f_Date = Convert.ToDateTime(f_Date_list[0]);
                DateTime f_Date_end = Convert.ToDateTime(f_Date_list[1]);
                exp = exp.And(t => t.F_Date >= f_Date && t.F_Date <= f_Date_end);
            }
            if (queryParams.F_DeleteMark != null)
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

            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_Number.Contains(queryParams.Keyword) || t.F_Name.Contains(queryParams.Keyword));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取设备告警的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDevicewarnEntity>> GetList(CaseErpDevicewarnEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpDevicewarnEntity>(expression);
        }

        /// <summary>
        /// 获取设备告警的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDevicewarnEntity>> GetPageList(Pagination pagination, CaseErpDevicewarnEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpDevicewarnEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpDevicewarnEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpDevicewarnEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpDevicewarnEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpDevicewarnEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = this.GetUserId();
                    entity.F_CreateUserName = this.GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();
                }


                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = this.GetUserId();
                entity.F_ModifyUserName = this.GetUserName();
                entity.F_Id = keyValue;


                await this.BaseRepository().Update(entity,true);
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
            await this.BaseRepository().Delete<CaseErpDevicewarnEntity>(keyValuesArr);
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 设备信息列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDevicewarnEntity>> GetExportList(string ids)
        {
            var exp = Expressionable.Create<CaseErpDevicewarnEntity>();
            if (!string.IsNullOrEmpty(ids))
            {
                var IdList = ids.Split(',');
                exp = exp.AndIF(!string.IsNullOrEmpty(ids), t => IdList.Contains(t.F_Id));
            }
            return this.BaseRepository().FindList<CaseErpDevicewarnEntity>(exp.ToExpression());
        }
        #endregion
    }
}
