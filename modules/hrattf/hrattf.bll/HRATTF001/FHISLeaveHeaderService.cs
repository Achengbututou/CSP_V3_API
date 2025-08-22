using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using HRATTF.ibll;
using System.Collections;
using NPOI.SS.Formula.Functions;
namespace HRATTF.bll
{
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2024-01-09 14:54:39
    /// 描 述： 请假申请数据库执行类
    /// </summary>
    public class FHISLeaveHeaderService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<FHISLeaveHeaderEntity, bool>> GetExpression(FHISLeaveHeaderEntity queryParams)
        {
            var exp = Expressionable.Create<FHISLeaveHeaderEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Leave_Note_NO), t => t.Leave_Note_NO.Contains(queryParams.Leave_Note_NO));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Emp_No), t => t.Emp_No.Contains(queryParams.Emp_No));
            if (queryParams.Not_Continu_Leave_Flag != null)
            {
                exp = exp.And(t => t.Not_Continu_Leave_Flag == queryParams.Not_Continu_Leave_Flag);
            }
            if (!string.IsNullOrEmpty(queryParams.From_DateQRange))
            {
                var from_Date_list = queryParams.From_DateQRange.Split(" - ");
                DateTime from_Date = Convert.ToDateTime(from_Date_list[0]);
                DateTime from_Date_end = Convert.ToDateTime(from_Date_list[1]);
                exp = exp.And(t => t.From_Date >= from_Date && t.From_Date <= from_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.From_Time), t => t.From_Time.Contains(queryParams.From_Time));
            if (queryParams.From_Date_Minute != null)
            {
                exp = exp.And(t => t.From_Date_Minute == queryParams.From_Date_Minute);
            }
            if (!string.IsNullOrEmpty(queryParams.To_DateQRange))
            {
                var to_Date_list = queryParams.To_DateQRange.Split(" - ");
                DateTime to_Date = Convert.ToDateTime(to_Date_list[0]);
                DateTime to_Date_end = Convert.ToDateTime(to_Date_list[1]);
                exp = exp.And(t => t.To_Date >= to_Date && t.To_Date <= to_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.To_Time), t => t.To_Time.Contains(queryParams.To_Time));
            if (queryParams.To_Date_Minute != null)
            {
                exp = exp.And(t => t.To_Date_Minute == queryParams.To_Date_Minute);
            }
            if (!string.IsNullOrEmpty(queryParams.Industrial_injury_DateQRange))
            {
                var industrial_injury_Date_list = queryParams.Industrial_injury_DateQRange.Split(" - ");
                DateTime industrial_injury_Date = Convert.ToDateTime(industrial_injury_Date_list[0]);
                DateTime industrial_injury_Date_end = Convert.ToDateTime(industrial_injury_Date_list[1]);
                exp = exp.And(t => t.Industrial_injury_Date >= industrial_injury_Date && t.Industrial_injury_Date <= industrial_injury_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Leave_Type), t => t.Leave_Type.Contains(queryParams.Leave_Type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Leave_List_RID), t => t.Leave_List_RID.Contains(queryParams.Leave_List_RID));
            if (queryParams.Cancel_Limit_Flag != null)
            {
                exp = exp.And(t => t.Cancel_Limit_Flag == queryParams.Cancel_Limit_Flag);
            }
            if (queryParams.From_Date_Full_Flag != null)
            {
                exp = exp.And(t => t.From_Date_Full_Flag == queryParams.From_Date_Full_Flag);
            }
            if (queryParams.To_Date_Full_Flag != null)
            {
                exp = exp.And(t => t.To_Date_Full_Flag == queryParams.To_Date_Full_Flag);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Remark), t => t.Remark.Contains(queryParams.Remark));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Submit_UserID), t => t.Submit_UserID.Contains(queryParams.Submit_UserID));
            if (!string.IsNullOrEmpty(queryParams.Leave_Submit_DateQRange))
            {
                var leave_Submit_Date_list = queryParams.Leave_Submit_DateQRange.Split(" - ");
                DateTime leave_Submit_Date = Convert.ToDateTime(leave_Submit_Date_list[0]);
                DateTime leave_Submit_Date_end = Convert.ToDateTime(leave_Submit_Date_list[1]);
                exp = exp.And(t => t.Leave_Submit_Date >= leave_Submit_Date && t.Leave_Submit_Date <= leave_Submit_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Approve_Status), t => t.Approve_Status.Contains(queryParams.Approve_Status));
            if (!string.IsNullOrEmpty(queryParams.Last_Update_DateQRange))
            {
                var last_Update_Date_list = queryParams.Last_Update_DateQRange.Split(" - ");
                DateTime last_Update_Date = Convert.ToDateTime(last_Update_Date_list[0]);
                DateTime last_Update_Date_end = Convert.ToDateTime(last_Update_Date_list[1]);
                exp = exp.And(t => t.Last_Update_Date >= last_Update_Date && t.Last_Update_Date <= last_Update_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Leave_Way), t => t.Leave_Way.Contains(queryParams.Leave_Way));
            if (queryParams.Leave_Shift_Item != null)
            {
                exp = exp.And(t => t.Leave_Shift_Item == queryParams.Leave_Shift_Item);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.M_Approve_UserID), t => t.M_Approve_UserID.Contains(queryParams.M_Approve_UserID));
            if (!string.IsNullOrEmpty(queryParams.M_Approve_DateQRange))
            {
                var m_Approve_Date_list = queryParams.M_Approve_DateQRange.Split(" - ");
                DateTime m_Approve_Date = Convert.ToDateTime(m_Approve_Date_list[0]);
                DateTime m_Approve_Date_end = Convert.ToDateTime(m_Approve_Date_list[1]);
                exp = exp.And(t => t.M_Approve_Date >= m_Approve_Date && t.M_Approve_Date <= m_Approve_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.M_Approve_remark), t => t.M_Approve_remark.Contains(queryParams.M_Approve_remark));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.M_Approve_Status), t => t.M_Approve_Status.Contains(queryParams.M_Approve_Status));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.E_Approve_UserID), t => t.E_Approve_UserID.Contains(queryParams.E_Approve_UserID));
            if (!string.IsNullOrEmpty(queryParams.E_Approve_DateQRange))
            {
                var e_Approve_Date_list = queryParams.E_Approve_DateQRange.Split(" - ");
                DateTime e_Approve_Date = Convert.ToDateTime(e_Approve_Date_list[0]);
                DateTime e_Approve_Date_end = Convert.ToDateTime(e_Approve_Date_list[1]);
                exp = exp.And(t => t.E_Approve_Date >= e_Approve_Date && t.E_Approve_Date <= e_Approve_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.E_Approve_remark), t => t.E_Approve_remark.Contains(queryParams.E_Approve_remark));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.E_Approve_Status), t => t.E_Approve_Status.Contains(queryParams.E_Approve_Status));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.HRD_Approve_UserID), t => t.HRD_Approve_UserID.Contains(queryParams.HRD_Approve_UserID));
            if (!string.IsNullOrEmpty(queryParams.HRD_Approve_DateQRange))
            {
                var hrD_Approve_Date_list = queryParams.HRD_Approve_DateQRange.Split(" - ");
                DateTime hrD_Approve_Date = Convert.ToDateTime(hrD_Approve_Date_list[0]);
                DateTime hrD_Approve_Date_end = Convert.ToDateTime(hrD_Approve_Date_list[1]);
                exp = exp.And(t => t.HRD_Approve_Date >= hrD_Approve_Date && t.HRD_Approve_Date <= hrD_Approve_Date_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.HRD_Approve_remark), t => t.HRD_Approve_remark.Contains(queryParams.HRD_Approve_remark));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.HRD_Approve_Status), t => t.HRD_Approve_Status.Contains(queryParams.HRD_Approve_Status));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Signature), t => t.Signature.Contains(queryParams.Signature));
            if (queryParams.Year != null)
            {
                exp = exp.And(t => t.Year == queryParams.Year);
            }
            if (queryParams.Leave_Day != null)
            {
                exp = exp.And(t => t.Leave_Day == queryParams.Leave_Day);
            }
            if (queryParams.M_is_E != null)
            {
                exp = exp.And(t => t.M_is_E == queryParams.M_is_E);
            }
            if (queryParams.Need_HRD != null)
            {
                exp = exp.And(t => t.Need_HRD == queryParams.Need_HRD);
            }
            if (queryParams.Is_All_Voucher != null)
            {
                exp = exp.And(t => t.Is_All_Voucher == queryParams.Is_All_Voucher);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Company_Id), t => t.Company_Id.Contains(queryParams.Company_Id));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Appraiser_UserID), t => t.Appraiser_UserID.Contains(queryParams.Appraiser_UserID));
            if (!string.IsNullOrEmpty(queryParams.Appraiser_UserDateQRange))
            {
                var appraiser_UserDate_list = queryParams.Appraiser_UserDateQRange.Split(" - ");
                DateTime appraiser_UserDate = Convert.ToDateTime(appraiser_UserDate_list[0]);
                DateTime appraiser_UserDate_end = Convert.ToDateTime(appraiser_UserDate_list[1]);
                exp = exp.And(t => t.Appraiser_UserDate >= appraiser_UserDate && t.Appraiser_UserDate <= appraiser_UserDate_end);
            }
            //add by kyle on 2024-02-22
            if (queryParams.Approve_StatusRange != null)
            {
                ArrayList ASRList = new ArrayList();
                switch (queryParams.Approve_StatusRange)
                {
                    case 1:
                        exp = exp.And(t => t.Approve_Status.Equals("99")); //已批核
                        break;
                    case 2:
                        exp = exp.And(t => t.Approve_Status.Equals("24") || t.Approve_Status.Equals("33")); //待HRD批核
                        break;
                    case 3:
                        exp = exp.And(t => t.Approve_Status.Equals("23") || t.Approve_Status.Equals("32")); //待上传凭证
                        break;
                    case 4:
                        exp = exp.And(t => t.Approve_Status.Equals("10") || t.Approve_Status.Equals("12") || t.Approve_Status.Equals("22")); //待批核
                        break;
                    default:
                        exp = exp.And(t => t.Approve_Status.Equals("99") || t.Approve_Status.Equals("23") || t.Approve_Status.Equals("32")
                                       || t.Approve_Status.Equals("24") || t.Approve_Status.Equals("33"));
                        break;
                }
            }
            if (queryParams.Synchronous_Status != null)
            {
                exp = exp.And(t => t.Synchronous_Status == queryParams.Synchronous_Status);
            }

            return exp.ToExpression();
        }
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveHeaderEntity>> GetList(FHISLeaveHeaderEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<FHISLeaveHeaderEntity>(expression);
        }
        /// <summary>
        /// 获取请假申请的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<FHISLeaveHeaderEntity>> GetPageList(Pagination pagination, FHISLeaveHeaderEntity queryParams, string AuthoritySql = null)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<FHISLeaveHeaderEntity>(expression, pagination, AuthoritySql);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<FHISLeaveHeaderEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository("OA").FindEntityByKey<FHISLeaveHeaderEntity>(keyValue);
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
            await this.BaseRepository("OA").Delete<FHISLeaveHeaderEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<FHISLeaveHeaderEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, FHISLeaveHeaderEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.RID))
                {
                    entity.RID = Guid.NewGuid().ToString();
                }
                entity.Submit_UserID = this.GetUserId();
                entity.Leave_Submit_Date = DateTime.Now;
                await this.BaseRepository("OA").Insert(entity);
            }
            else
            {
                entity.RID = keyValue;
                entity.Last_Update_Date = DateTime.Now;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        #endregion
    }
}