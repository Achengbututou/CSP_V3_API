using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using HRATTF004.ibll;
using learun.database;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.SS.Formula.Functions;

namespace HRATTF004.bll {
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤数据库执行类
    /// </summary>
    public class AttendanceErrorDtlService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<AttendanceErrorDtlEntity, bool>>GetExpression(AttendanceErrorDtlEntity queryParams) {
            var exp = Expressionable.Create<AttendanceErrorDtlEntity>();
            if (!string.IsNullOrEmpty(queryParams.attendance_error_rid)) {
                exp = exp.And(t => t.attendance_error_rid == queryParams.attendance_error_rid);
            }
            if (queryParams.use_flag != null) {
                exp = exp.And(t => t.use_flag == queryParams.use_flag);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.organization_level), t => t.organization_level.Contains(queryParams.organization_level));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.emp_no), t => t.emp_no.Contains(queryParams.emp_no));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.emp_name), t => t.emp_name.Contains(queryParams.emp_name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.position_name), t => t.position_name.Contains(queryParams.position_name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.att_date), t => t.att_date.Contains(queryParams.att_date));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.att_name), t => t.att_name.Contains(queryParams.att_name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.shift_code), t => t.shift_code.Contains(queryParams.shift_code));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.from_time1), t => t.from_time1.Contains(queryParams.from_time1));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.to_time1), t => t.to_time1.Contains(queryParams.to_time1));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.from_time2), t => t.from_time2.Contains(queryParams.from_time2));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.to_time2), t => t.to_time2.Contains(queryParams.to_time2));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.from_time3), t => t.from_time3.Contains(queryParams.from_time3));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.to_time3), t => t.to_time3.Contains(queryParams.to_time3));
            if (queryParams.normal_minute != null) {
                exp = exp.And(t => t.normal_minute == queryParams.normal_minute);
            }
            if (queryParams.absent_minute != null) {
                exp = exp.And(t => t.absent_minute == queryParams.absent_minute);
            }
            if (queryParams.ot_minute != null) {
                exp = exp.And(t => t.ot_minute == queryParams.ot_minute);
            }
            if (queryParams.ot_app_minute != null) {
                exp = exp.And(t => t.ot_app_minute == queryParams.ot_app_minute);
            }
            if (queryParams.leave_app_minute != null) {
                exp = exp.And(t => t.leave_app_minute == queryParams.leave_app_minute);
            }
            if (queryParams.pay_leave_minute != null) {
                exp = exp.And(t => t.pay_leave_minute == queryParams.pay_leave_minute);
            }
            if (queryParams.nopay_leave_minute != null) {
                exp = exp.And(t => t.nopay_leave_minute == queryParams.nopay_leave_minute);
            }
            if (queryParams.layoff_minute != null) {
                exp = exp.And(t => t.layoff_minute == queryParams.layoff_minute);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.error_desc), t => t.error_desc.Contains(queryParams.error_desc));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceErrorDtlEntity>>GetList(AttendanceErrorDtlEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<AttendanceErrorDtlEntity>(expression);
        }
        /// <summary>
        /// 获取错误考勤的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<AttendanceErrorDtlEntity>>GetPageList(Pagination pagination, AttendanceErrorDtlEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository("OA").FindList<AttendanceErrorDtlEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<AttendanceErrorDtlEntity>GetEntity(string keyValue) {
            return this.BaseRepository("OA").FindEntityByKey<AttendanceErrorDtlEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository("OA").Delete<AttendanceErrorDtlEntity>(keyValue);
        }
        /// <summary>
        /// 删除错误考勤的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository("OA").Delete<AttendanceErrorDtlEntity>(t => t.attendance_error_rid == key);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository("OA").Delete<AttendanceErrorDtlEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, AttendanceErrorDtlEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.rid)) {
                    entity.rid = Guid.NewGuid().ToString();
                }
                await this.BaseRepository("OA").Insert(entity);
            } else {
                entity.rid = keyValue;
                await this.BaseRepository("OA").Update(entity);
            }
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<AttendanceErrorDtlEntity>list) {
            var addList = new List<AttendanceErrorDtlEntity>();
            var db = this.BaseRepository("OA").BeginTrans();
            try {
                await db.Delete<AttendanceErrorDtlEntity>(t => t.attendance_error_rid == key);
                foreach(var item in list) {
                    if (string.IsNullOrEmpty(item.rid)) {
                        item.rid = Guid.NewGuid().ToString();
                    }
                    item.attendance_error_rid = key;
                    addList.Add(item);
                }
                if (addList.Count>0) {
                    await db.Inserts(addList,false);
                }
                db.Commit();
            } catch (Exception) {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 请数据数据验证和数据检查
        /// </summary>
        /// <returns></returns>
        public async Task GetDataErrorATT(DateTime From_Date, DateTime To_Date,string userid, string Emp_No, int page, int rows, string sidx)
        {
            string From_Date_str = From_Date.ToString("dd MMM yyyy");
            string To_Date_str = To_Date.ToString("dd MMM yyyy");
            //添加userid条件  add by jack zhou  21 May 2024
            string SQLStr_name;
            SQLStr_name = "exec SP_GetErrorATTData '" + From_Date_str + "','" + To_Date_str + "','" + Emp_No + "','" + userid + "'";
            if (From_Date_str == "01 Jan 1900")
            {
                SQLStr_name = "exec SP_GetErrorATTData null,null,'" + Emp_No + "','" + userid + "'";
            }

            RepositoryFactory repositoryFactory = new RepositoryFactory();

            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    From_Date
                                    ,
                                    To_Date
                                    ,
                                    userid
                                    ,
                                    Emp_No
                                });

            long records = dt_name.Rows.Count;
            long total = rows;


            var jsonData = new
            {
                rows = dt_name,
                total,
                page,
                records
            };



            //for (int i = 0; i < dt_name.Rows.Count; i++)
            //{
            //    await _wfProcessIBLL.Create(ProcessId, SchemeCode, UserId, NextUsers, SecretLevel, Title);
            //}



        }

        public async Task GetParentUrl(string Moudle_ID)
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_GetParentUrl  @Moudle_ID";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    Moudle_ID
                                });

            var jsonData = dt_name.ToJson();


        }

        public async Task ErrorAttInterface(string InType, string par1, string par2, string par3, string par4, string par5, string par6)
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_ErrorAttInterface  @InType,@par1,@par2,@par3,@par4,@par5,@par6";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    InType,
                                    par1,
                                    par2,
                                    par3,
                                    par4,
                                    par5,
                                    par6
                                });

            var jsonData = dt_name.ToJson();


        }

        public async Task GetBaseDataFromFVB()
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_GetBaseDataFromFVB";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name);

            //var jsonData = dt_name.ToJson();
            long records = dt_name.Rows.Count;
            long total = 50;
            long page = 50;

            var jsonData = new
            {
                rows = dt_name,
                total,
                page,
                records
            };


        }
        #endregion
    }
}