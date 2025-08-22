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
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期： 2022-12-05 09:24:18
    /// 描 述： 操作记录数据库执行类
    /// </summary>
    public class CaseErpLogService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpLogEntity, bool>> GetExpression(CaseErpLogEntity queryParams) {
            var exp = Expressionable.Create<CaseErpLogEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CategoryId),t => t.F_CategoryId.Contains(queryParams.F_CategoryId));
            if(!string.IsNullOrEmpty(queryParams.F_OperateTimeQRange))
            {
                var f_OperateTime_list = queryParams.F_OperateTimeQRange.Split(" - ");
                DateTime f_OperateTime = Convert.ToDateTime(f_OperateTime_list[0]);
                DateTime f_OperateTime_end = Convert.ToDateTime(f_OperateTime_list[1]);
                exp = exp.And(t => t.F_OperateTime >= f_OperateTime &&t.F_OperateTime <= f_OperateTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OperateUserId),t => t.F_OperateUserId.Contains(queryParams.F_OperateUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OperateAccount),t => t.F_OperateAccount.Contains(queryParams.F_OperateAccount));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_OperateTypeId),t => t.F_OperateTypeId.Contains(queryParams.F_OperateTypeId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IP),t => t.F_IP.Contains(queryParams.F_IP));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_IPAddress),t => t.F_IPAddress.Contains(queryParams.F_IPAddress));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Host),t => t.F_Host.Contains(queryParams.F_Host));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Browser),t => t.F_Browser.Contains(queryParams.F_Browser));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_KeyId), t => t.F_KeyId.Contains(queryParams.F_KeyId));
            if (queryParams.F_ExecuteResult != null)
            {
                exp = exp.And(t => t.F_ExecuteResult == queryParams.F_ExecuteResult);
            }
            if(queryParams.F_ExecuteResultJson != null)
            {
                exp = exp.And(t => t.F_ExecuteResultJson == queryParams.F_ExecuteResultJson);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Description),t => t.F_Description.Contains(queryParams.F_Description));
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

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取操作记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpLogEntity>> GetList(CaseErpLogEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpLogEntity>(expression);
        }

        /// <summary>
        /// 获取操作记录的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpLogEntity>> GetPageList(Pagination pagination, CaseErpLogEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpLogEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpLogEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<CaseErpLogEntity>(keyValue);
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
            await this.BaseRepository().Delete<CaseErpLogEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpLogEntity entity)
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
            await this.BaseRepository().Delete<CaseErpLogEntity>(keyValuesArr);
        }

        
        #endregion
    }
}
