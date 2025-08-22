using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using Test1.ibll;
namespace Test1.bll {
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：
    /// 日 期： 2024-07-24 16:39:53
    /// 描 述： 测试代码生成数据库执行类
    /// </summary>
    public class F_parentService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<F_parentEntity, bool>>GetExpression(F_parentEntity queryParams) {
            var exp = Expressionable.Create<F_parentEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_text)) {
                exp = exp.And(t => t.F_text == queryParams.F_text);
            }
            if (!string.IsNullOrEmpty(queryParams.F_textarea)) {
                exp = exp.And(t => t.F_textarea == queryParams.F_textarea);
            }
            if (!string.IsNullOrEmpty(queryParams.F_edit)) {
                exp = exp.And(t => t.F_edit == queryParams.F_edit);
            }
            if (queryParams.F_Num != null) {
                exp = exp.And(t => t.F_Num == queryParams.F_Num);
            }
            if (!string.IsNullOrEmpty(queryParams.F_password)) {
                exp = exp.And(t => t.F_password == queryParams.F_password);
            }
            if (!string.IsNullOrEmpty(queryParams.F_radio)) {
                exp = exp.And(t => t.F_radio == queryParams.F_radio);
            }
            if (!string.IsNullOrEmpty(queryParams.F_checkbox)) {
                exp = exp.And(t => t.F_checkbox == queryParams.F_checkbox);
            }
            if (!string.IsNullOrEmpty(queryParams.F_select)) {
                exp = exp.And(t => t.F_select == queryParams.F_select);
            }
            if (!string.IsNullOrEmpty(queryParams.F_select2)) {
                exp = exp.And(t => t.F_select2 == queryParams.F_select2);
            }
            if (!string.IsNullOrEmpty(queryParams.F_treeSelect)) {
                exp = exp.And(t => t.F_treeSelect == queryParams.F_treeSelect);
            }
            if (!string.IsNullOrEmpty(queryParams.F_time)) {
                exp = exp.And(t => t.F_time == queryParams.F_time);
            }
            if (!string.IsNullOrEmpty(queryParams.F_time2)) {
                exp = exp.And(t => t.F_time2 == queryParams.F_time2);
            }
            if (!string.IsNullOrEmpty(queryParams.F_dateQRange)) {
                var f_date_list = queryParams.F_dateQRange.Split(" - ");
                DateTime f_date = Convert.ToDateTime(f_date_list[0]);
                DateTime f_date_end = Convert.ToDateTime(f_date_list[1]);
                exp = exp.And(t => t.F_date >= f_date && t.F_date <= f_date_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_file)) {
                exp = exp.And(t => t.F_file == queryParams.F_file);
            }
            if (!string.IsNullOrEmpty(queryParams.F_img)) {
                exp = exp.And(t => t.F_img == queryParams.F_img);
            }
            if (!string.IsNullOrEmpty(queryParams.F_guid)) {
                exp = exp.And(t => t.F_guid == queryParams.F_guid);
            }
            if (!string.IsNullOrEmpty(queryParams.F_company)) {
                exp = exp.And(t => t.F_company == queryParams.F_company);
            }
            if (!string.IsNullOrEmpty(queryParams.F_department)) {
                exp = exp.And(t => t.F_department == queryParams.F_department);
            }
            if (!string.IsNullOrEmpty(queryParams.F_user)) {
                exp = exp.And(t => t.F_user == queryParams.F_user);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ccompany)) {
                exp = exp.And(t => t.F_ccompany == queryParams.F_ccompany);
            }
            if (!string.IsNullOrEmpty(queryParams.F_cdepartment)) {
                exp = exp.And(t => t.F_cdepartment == queryParams.F_cdepartment);
            }
            if (!string.IsNullOrEmpty(queryParams.F_cuser)) {
                exp = exp.And(t => t.F_cuser == queryParams.F_cuser);
            }
            if (!string.IsNullOrEmpty(queryParams.F_cdateQRange)) {
                var f_cdate_list = queryParams.F_cdateQRange.Split(" - ");
                DateTime f_cdate = Convert.ToDateTime(f_cdate_list[0]);
                DateTime f_cdate_end = Convert.ToDateTime(f_cdate_list[1]);
                exp = exp.And(t => t.F_cdate >= f_cdate && t.F_cdate <= f_cdate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_muser)) {
                exp = exp.And(t => t.F_muser == queryParams.F_muser);
            }
            if (!string.IsNullOrEmpty(queryParams.F_mdateQRange)) {
                var f_mdate_list = queryParams.F_mdateQRange.Split(" - ");
                DateTime f_mdate = Convert.ToDateTime(f_mdate_list[0]);
                DateTime f_mdate_end = Convert.ToDateTime(f_mdate_list[1]);
                exp = exp.And(t => t.F_mdate >= f_mdate && t.F_mdate <= f_mdate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_code)) {
                exp = exp.And(t => t.F_code == queryParams.F_code);
            }
            if (!string.IsNullOrEmpty(queryParams.F_icon)) {
                exp = exp.And(t => t.F_icon == queryParams.F_icon);
            }
            if (queryParams.F_rate != null) {
                exp = exp.And(t => t.F_rate == queryParams.F_rate);
            }
            if (queryParams.F_swtich != null) {
                exp = exp.And(t => t.F_swtich == queryParams.F_swtich);
            }
            if (queryParams.F_swtich2 != null) {
                exp = exp.And(t => t.F_swtich2 == queryParams.F_swtich2);
            }
            if (!string.IsNullOrEmpty(queryParams.F_color)) {
                exp = exp.And(t => t.F_color == queryParams.F_color);
            }
            if (!string.IsNullOrEmpty(queryParams.F_layerSelect)) {
                exp = exp.And(t => t.F_layerSelect == queryParams.F_layerSelect);
            }
            if (!string.IsNullOrEmpty(queryParams.F_daterange)) {
                exp = exp.And(t => t.F_daterange == queryParams.F_daterange);
            }
            if (!string.IsNullOrEmpty(queryParams.F_areaSelect)) {
                exp = exp.And(t => t.F_areaSelect == queryParams.F_areaSelect);
            }
            if (!string.IsNullOrEmpty(queryParams.F_map)) {
                exp = exp.And(t => t.F_map == queryParams.F_map);
            }
            if (!string.IsNullOrEmpty(queryParams.F_TenantId)) {
                exp = exp.And(t => t.F_TenantId == queryParams.F_TenantId);
            }
            if (!string.IsNullOrEmpty(queryParams.Xxxx)) {
                exp = exp.And(t => t.Xxxx == queryParams.Xxxx);
            }
            if (queryParams.F_DeleteMark != null) {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if (!string.IsNullOrEmpty(queryParams.F_CreateDateQRange)) {
                var f_CreateDate_list = queryParams.F_CreateDateQRange.Split(" - ");
                DateTime f_CreateDate = Convert.ToDateTime(f_CreateDate_list[0]);
                DateTime f_CreateDate_end = Convert.ToDateTime(f_CreateDate_list[1]);
                exp = exp.And(t => t.F_CreateDate >= f_CreateDate && t.F_CreateDate <= f_CreateDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_CreateUserId)) {
                exp = exp.And(t => t.F_CreateUserId == queryParams.F_CreateUserId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_CreateUserName)) {
                exp = exp.And(t => t.F_CreateUserName == queryParams.F_CreateUserName);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ModifyDateQRange)) {
                var f_ModifyDate_list = queryParams.F_ModifyDateQRange.Split(" - ");
                DateTime f_ModifyDate = Convert.ToDateTime(f_ModifyDate_list[0]);
                DateTime f_ModifyDate_end = Convert.ToDateTime(f_ModifyDate_list[1]);
                exp = exp.And(t => t.F_ModifyDate >= f_ModifyDate && t.F_ModifyDate <= f_ModifyDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ModifyUserId)) {
                exp = exp.And(t => t.F_ModifyUserId == queryParams.F_ModifyUserId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ModifyUserName)) {
                exp = exp.And(t => t.F_ModifyUserName == queryParams.F_ModifyUserName);
            }
            if (!string.IsNullOrEmpty(queryParams.Field16934719940)) {
                exp = exp.And(t => t.Field16934719940 == queryParams.Field16934719940);
            }
            if (!string.IsNullOrEmpty(queryParams.Field16934719941)) {
                exp = exp.And(t => t.Field16934719941 == queryParams.Field16934719941);
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取测试代码生成的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<F_parentEntity>>GetList(F_parentEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<F_parentEntity>(expression);
        }
        /// <summary>
        /// 获取测试代码生成的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<F_parentEntity>>GetPageList(Pagination pagination, F_parentEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<F_parentEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<F_parentEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<F_parentEntity>(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<F_parentEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = null;
            string[] arr = keyValues.Split(",");
            keyValuesArr = arr;
            await this.BaseRepository().Delete<F_parentEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, F_parentEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                await this.BaseRepository().Insert(entity);
            } else {
                entity.F_Id = keyValue;
                await this.BaseRepository().Update(entity);
            }
        }
        #endregion
    }
}