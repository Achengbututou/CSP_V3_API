using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using ADMF005.ibll;
using NPOI.SS.Formula.Functions;
namespace ADMF005.bll
{
    /// <summary>
    /// 访客申请-访客出入厂
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2024-05-03 16:04:51
    /// 描 述： Visitors_Enter数据库执行类
    /// </summary>
    public class VisitorsEnterService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<VisitorsEnterEntity, bool>> GetExpression(VisitorsEnterEntity queryParams)
        {
            var exp = Expressionable.Create<VisitorsEnterEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_Note_No), t => t.Visitors_Note_No.Contains(queryParams.Visitors_Note_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_Name), t => t.Visitors_Name.Contains(queryParams.Visitors_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_living), t => t.Visitors_living.Contains(queryParams.Visitors_living));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_ID_No), t => t.Visitors_ID_No.Contains(queryParams.Visitors_ID_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_type), t => t.Visitors_type.Contains(queryParams.Visitors_type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visit_reason), t => t.Visit_reason.Contains(queryParams.Visit_reason));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_unit), t => t.Visitors_unit.Contains(queryParams.Visitors_unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_phone), t => t.Visitors_phone.Contains(queryParams.Visitors_phone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Receiver_Name), t => t.Receiver_Name.Contains(queryParams.Receiver_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Receiver_EMP), t => t.Receiver_EMP.Contains(queryParams.Receiver_EMP));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Receiver_Company), t => t.Receiver_Company.Contains(queryParams.Receiver_Company));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Receiver_Dept), t => t.Receiver_Dept.Contains(queryParams.Receiver_Dept));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Receiver_phone), t => t.Receiver_phone.Contains(queryParams.Receiver_phone));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Receiver_extension), t => t.Receiver_extension.Contains(queryParams.Receiver_extension));

            DateTime estimated_from_time = DateTime.MinValue;
            DateTime estimated_end_time = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(queryParams.Estimated_from_timeQRange))
            {
                var estimated_from_time_list = queryParams.Estimated_from_timeQRange.Split(" - ");
                estimated_from_time = Convert.ToDateTime(estimated_from_time_list[0]);
            }
            if (!string.IsNullOrEmpty(queryParams.Estimated_end_timeQRange))
            {
                var estimated_end_time_list = queryParams.Estimated_end_timeQRange.Split(" - ");
                estimated_end_time = Convert.ToDateTime(estimated_end_time_list[0]);
            }
            exp = exp.And(t => t.Estimated_from_time >= estimated_from_time && t.Estimated_end_time <= estimated_end_time);

            if (!string.IsNullOrEmpty(queryParams.Enable_enter_time))
            {
                var enable_enter_time_list = queryParams.Enable_enter_time.Split(" - ");
                DateTime enable_enter_time = Convert.ToDateTime(enable_enter_time_list[0]);
                exp = exp.And(t => SqlFunc.ToDate(t.Estimated_from_time).Date <= SqlFunc.ToDate(enable_enter_time).Date && SqlFunc.ToDate(t.Estimated_end_time).Date >= SqlFunc.ToDate(enable_enter_time).Date);
                //exp = exp.And(t => SqlFunc.ToDate(t.Estimated_from_time).Date <= enable_enter_time && SqlFunc.ToDate(t.Estimated_end_time).Date >= enable_enter_time);
            }
            if (!string.IsNullOrEmpty(queryParams.Enable_enter_time2))
            {
                var enable_enter_time_list = queryParams.Enable_enter_time2.Split(" - ");
                DateTime enable_enter_time2 = Convert.ToDateTime(enable_enter_time_list[0]);
                exp = exp.And(t => t.Estimated_from_time <= enable_enter_time2 && t.Estimated_end_time >= enable_enter_time2);
            }
            //if (!string.IsNullOrEmpty(queryParams.Estimated_from_timeQRange))
            //{
            //    var estimated_from_time_list = queryParams.Estimated_from_timeQRange.Split(" - ");
            //    DateTime estimated_from_time = Convert.ToDateTime(estimated_from_time_list[0]);
            //    DateTime estimated_from_time_end = Convert.ToDateTime(estimated_from_time_list[1]);
            //    exp = exp.And(t => t.Estimated_from_time >= estimated_from_time && t.Estimated_from_time <= estimated_from_time_end);
            //}
            //if (!string.IsNullOrEmpty(queryParams.Estimated_end_timeQRange))
            //{
            //    var estimated_end_time_list = queryParams.Estimated_end_timeQRange.Split(" - ");
            //    DateTime estimated_end_time = Convert.ToDateTime(estimated_end_time_list[0]);
            //    DateTime estimated_end_time_end = Convert.ToDateTime(estimated_end_time_list[1]);
            //    exp = exp.And(t => t.Estimated_end_time >= estimated_end_time && t.Estimated_end_time <= estimated_end_time_end);
            //}
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.In_times), t => t.In_times.Contains(queryParams.In_times));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visit_No), t => t.Visit_No.Contains(queryParams.Visit_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Parking_No), t => t.Parking_No.Contains(queryParams.Parking_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Car_No), t => t.Car_No.Contains(queryParams.Car_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.In_position), t => t.In_position.Contains(queryParams.In_position));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Status), t => t.Status.Contains(queryParams.Status));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visitors_level), t => t.Visitors_level.Contains(queryParams.Visitors_level));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Need_check), t => t.Need_check.Contains(queryParams.Need_check));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Action_user), t => t.Action_user.Contains(queryParams.Action_user));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Visit_area), t => t.Visit_area.Contains(queryParams.Visit_area));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.security_check), t => t.security_check.Contains(queryParams.security_check));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.security_remark), t => t.security_remark.Contains(queryParams.security_remark));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Frame_No), t => t.Frame_No.Contains(queryParams.Frame_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Container_No), t => t.Container_No.Contains(queryParams.Container_No));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Seal_No), t => t.Seal_No.Contains(queryParams.Seal_No));

            if (!string.IsNullOrEmpty(queryParams.Action_dateQRange))
            {
                var action_date_list = queryParams.Action_dateQRange.Split(" - ");
                DateTime action_date = Convert.ToDateTime(action_date_list[0]);
                DateTime action_date_end = Convert.ToDateTime(action_date_list[1]);
                exp = exp.And(t => t.Action_date >= action_date && t.Action_date <= action_date_end);
            }
                return exp.ToExpression();
        }
        /// <summary>
        /// 获取Visitors_Enter的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<VisitorsEnterEntity>> GetList(VisitorsEnterEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<VisitorsEnterEntity>(expression);
        }
        /// <summary>
        /// 获取Visitors_Enter的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<VisitorsEnterEntity>> GetPageList(Pagination pagination, VisitorsEnterEntity queryParams, string AuthoritySql = null)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<VisitorsEnterEntity>(expression, pagination, AuthoritySql);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<VisitorsEnterEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<VisitorsEnterEntity>(keyValue);
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
            await this.BaseRepository("OA").Delete<VisitorsEnterEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<VisitorsEnterEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, VisitorsEnterEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.RID))
                {
                    entity.RID = Guid.NewGuid().ToString();
                }
                await this.BaseRepository("OA").Insert(entity);
            }
            else
            {
                entity.RID = keyValue;
                entity.Action_user = this.GetUserId();
                entity.Action_date = DateTime.Now;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        #endregion
    }
}