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
    public class F_childrenService: ServiceBase {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<F_childrenEntity, bool>>GetExpression(F_childrenEntity queryParams) {
            var exp = Expressionable.Create<F_childrenEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_text)) {
                exp = exp.And(t => t.F_text == queryParams.F_text);
            }
            if (!string.IsNullOrEmpty(queryParams.F_textarea)) {
                exp = exp.And(t => t.F_textarea == queryParams.F_textarea);
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
            if (!string.IsNullOrEmpty(queryParams.F_dateQRange)) {
                var f_date_list = queryParams.F_dateQRange.Split(" - ");
                DateTime f_date = Convert.ToDateTime(f_date_list[0]);
                DateTime f_date_end = Convert.ToDateTime(f_date_list[1]);
                exp = exp.And(t => t.F_date >= f_date && t.F_date <= f_date_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_parentId)) {
                exp = exp.And(t => t.F_parentId == queryParams.F_parentId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_select2)) {
                exp = exp.And(t => t.F_select2 == queryParams.F_select2);
            }
            if (!string.IsNullOrEmpty(queryParams.F_treeSelect)) {
                exp = exp.And(t => t.F_treeSelect == queryParams.F_treeSelect);
            }
            if (!string.IsNullOrEmpty(queryParams.F_layerSelect)) {
                exp = exp.And(t => t.F_layerSelect == queryParams.F_layerSelect);
            }
            if (!string.IsNullOrEmpty(queryParams.F_time)) {
                exp = exp.And(t => t.F_time == queryParams.F_time);
            }
            if (!string.IsNullOrEmpty(queryParams.F_timerange)) {
                exp = exp.And(t => t.F_timerange == queryParams.F_timerange);
            }
            if (!string.IsNullOrEmpty(queryParams.F_dateRange)) {
                exp = exp.And(t => t.F_dateRange == queryParams.F_dateRange);
            }
            if (!string.IsNullOrEmpty(queryParams.F_areaSelect)) {
                exp = exp.And(t => t.F_areaSelect == queryParams.F_areaSelect);
            }
            if (!string.IsNullOrEmpty(queryParams.F_map)) {
                exp = exp.And(t => t.F_map == queryParams.F_map);
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
            if (!string.IsNullOrEmpty(queryParams.F_muser)) {
                exp = exp.And(t => t.F_muser == queryParams.F_muser);
            }
            if (!string.IsNullOrEmpty(queryParams.F_cdateQRange)) {
                var f_cdate_list = queryParams.F_cdateQRange.Split(" - ");
                DateTime f_cdate = Convert.ToDateTime(f_cdate_list[0]);
                DateTime f_cdate_end = Convert.ToDateTime(f_cdate_list[1]);
                exp = exp.And(t => t.F_cdate >= f_cdate && t.F_cdate <= f_cdate_end);
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
            if (!string.IsNullOrEmpty(queryParams.F_switch)) {
                exp = exp.And(t => t.F_switch == queryParams.F_switch);
            }
            if (queryParams.F_switch2 != null) {
                exp = exp.And(t => t.F_switch2 == queryParams.F_switch2);
            }
            if (!string.IsNullOrEmpty(queryParams.F_clor)) {
                exp = exp.And(t => t.F_clor == queryParams.F_clor);
            }
            if (!string.IsNullOrEmpty(queryParams.F_TenantId)) {
                exp = exp.And(t => t.F_TenantId == queryParams.F_TenantId);
            }
            if (!string.IsNullOrEmpty(queryParams.Table16886255240_Id)) {
                exp = exp.And(t => t.Table16886255240_Id == queryParams.Table16886255240_Id);
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
            if (!string.IsNullOrEmpty(queryParams.F_parent_Id)) {
                exp = exp.And(t => t.F_parent_Id == queryParams.F_parent_Id);
            }
            if (!string.IsNullOrEmpty(queryParams.F_img)) {
                exp = exp.And(t => t.F_img == queryParams.F_img);
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取测试代码生成的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<F_childrenEntity>>GetList(F_childrenEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<F_childrenEntity>(expression);
        }
        /// <summary>
        /// 获取测试代码生成的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<F_childrenEntity>>GetPageList(Pagination pagination, F_childrenEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<F_childrenEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<F_childrenEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<F_childrenEntity>(keyValue);
        }

        public Task ExcPro()
        {
            return this.BaseRepository().ExecuteProc("存储过程名称");
        }

        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<F_childrenEntity>(keyValue);
        }
        /// <summary>
        /// 删除测试代码生成的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository().Delete<F_childrenEntity>(t => t.F_parentId == key);
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
            await this.BaseRepository().Delete<F_childrenEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, F_childrenEntity entity) {
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
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<F_childrenEntity>list) {
            var addList = new List<F_childrenEntity>();
            var db = this.BaseRepository().BeginTrans();
            try {
                await db.Delete<F_childrenEntity>(t => t.F_parentId == key);
                foreach(var item in list) {
                    if (string.IsNullOrEmpty(item.F_Id)) {
                        item.F_Id = Guid.NewGuid().ToString();
                    }
                    item.F_parentId = key;
                    addList.Add(item);
                }
                if (addList.Count>0) {
                    await db.Inserts(addList);
                }
                db.Commit();
            } catch (Exception) {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}