using System.Data;
using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using erpCase.ibll;
using learun.office;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 17:17:21
    /// 描 述： BOM信息数据库执行类
    /// </summary>
    public class CaseErpBomService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<CaseErpBomEntity, bool>> GetExpression(CaseErpBomEntity queryParams)
        {
            var exp = Expressionable.Create<CaseErpBomEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_PId), t => t.F_PId.Equals(queryParams.F_PId));
            if (queryParams.F_Level != null)
            {
                exp = exp.And(t => t.F_Level == queryParams.F_Level);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialId), t => t.F_MaterialId.Equals(queryParams.F_MaterialId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Number), t => t.F_Number.Contains(queryParams.F_Number));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Name), t => t.F_Name.Contains(queryParams.F_Name));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Model), t => t.F_Model.Contains(queryParams.F_Model));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Type), t => t.F_Type.Contains(queryParams.F_Type));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Property), t => t.F_Property.Contains(queryParams.F_Property));
            if (queryParams.F_Count != null)
            {
                exp = exp.And(t => t.F_Count == queryParams.F_Count);
            }
            if (queryParams.F_Description != null)
            {
                exp = exp.And(t => t.F_Description == queryParams.F_Description);
            }
            if (queryParams.F_DeleteMark != null)
            {
                exp = exp.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if (queryParams.F_EnabledMark != null)
            {
                exp = exp.And(t => t.F_EnabledMark == queryParams.F_EnabledMark);
            }
            if (!string.IsNullOrEmpty(queryParams.F_CreateDateQRange))
            {
                var f_CreateDate_list = queryParams.F_CreateDateQRange.Split(" - ");
                DateTime f_CreateDate = Convert.ToDateTime(f_CreateDate_list[0]);
                DateTime f_CreateDate_end = Convert.ToDateTime(f_CreateDate_list[1]);
                exp = exp.And(t => t.F_CreateDate >= f_CreateDate && t.F_CreateDate <= f_CreateDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserId), t => t.F_CreateUserId.Contains(queryParams.F_CreateUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreateUserName), t => t.F_CreateUserName.Contains(queryParams.F_CreateUserName));
            if (!string.IsNullOrEmpty(queryParams.F_ModifyDateQRange))
            {
                var f_ModifyDate_list = queryParams.F_ModifyDateQRange.Split(" - ");
                DateTime f_ModifyDate = Convert.ToDateTime(f_ModifyDate_list[0]);
                DateTime f_ModifyDate_end = Convert.ToDateTime(f_ModifyDate_list[1]);
                exp = exp.And(t => t.F_ModifyDate >= f_ModifyDate && t.F_ModifyDate <= f_ModifyDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserId), t => t.F_ModifyUserId.Contains(queryParams.F_ModifyUserId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyUserName), t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));

            return exp.ToExpression();
        }

        /// <summary>
        /// 获取BOM信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpBomEntity>> GetList(CaseErpBomEntity queryParams)
        {
            List<CaseErpBomEntity> list = (List<CaseErpBomEntity>)await this.BaseRepository().FindAll<CaseErpBomEntity>("F_EnabledMark,F_CreateDate");
            List<CaseErpBomEntity> res = new List<CaseErpBomEntity>();

            var expression = GetExpression(queryParams);
            if (!string.IsNullOrEmpty(queryParams.F_PId))
            {
                res = list.FindAll(t => t.F_PId == queryParams.F_PId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_MaterialId))
            {
                res = list.FindAll(t => t.F_MaterialId == queryParams.F_MaterialId);
            }
            if (!string.IsNullOrEmpty(queryParams.F_Number))
            {
                res = list.FindAll(t => t.F_Number == queryParams.F_Number);
            }
            if (!string.IsNullOrEmpty(queryParams.F_Name))
            {
                res = list.FindAll(t => t.F_Name.Contains(queryParams.F_Name));
            }

            foreach (var item in res)
            {
                item.ChlidNum = list.FindAll(t => t.F_PId == item.F_MaterialId).Count;
            }


            return res;
        }

        /// <summary>
        /// 获取BOM信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpBomEntity>> GetPageList(Pagination pagination, CaseErpBomEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<CaseErpBomEntity>(expression, pagination);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpBomEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<CaseErpBomEntity>(keyValue);
        }

        /// <summary>
        /// 获取物料数据
        /// </summary>
        /// <param name="pidList">关联物料集合</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpBomEntity>> GetList(List<string> list)
        {
            return this.BaseRepository().FindList<CaseErpBomEntity>(t => list.Contains(t.F_MaterialId));
        }

        /// <summary>
        /// 获取子集物料数据
        /// </summary>
        /// <param name="pidList">关联物料集合</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpBomEntity>> GetChildList(List<string> list)
        {
            return this.BaseRepository().FindList<CaseErpBomEntity>(t => list.Contains(t.F_PId));
        }



        /// <summary>
        /// 获取子集物料数据
        /// </summary>
        /// <param name="pid">父级id</param>
        /// <returns></returns>
        public Task<DataTable> GetChildTable(string pid)
        {
            string sql = " select f_number,f_name,f_model,f_type,f_number,f_count,f_unit,f_property,f_materialid from case_erp_bom where f_pid = @pid {LEARUN_SASSID_NOTT} ";
            if (pid == "0")
            {
                sql += " AND F_EnabledMark != 1 ";
            }
            return this.BaseRepository().FindTable(sql, new { pid });
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
            await this.BaseRepository().Delete<CaseErpBomEntity>(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Deletes(List<CaseErpBomEntity> list)
        {
            if (list.Count > 0)
            {
                await this.BaseRepository().Delete<CaseErpBomEntity>(list);
            }

        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpBomEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.F_PId))
            {
                entity.F_PId = "0";
            }

            if (string.IsNullOrEmpty(keyValue))
            {
                entity.F_CreateDate = DateTime.Now;
                entity.F_CreateUserId = this.GetUserId();
                entity.F_CreateUserName = this.GetUserName();
                entity.F_Id = Guid.NewGuid().ToString();
                entity.F_EnabledMark = 0;

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
            await this.BaseRepository().Delete<CaseErpBomEntity>(keyValuesArr);
        }

        /// <summary>
        /// 更新子集的父级id
        /// </summary>
        /// <param name="newMaterialId"></param>
        /// <param name="oldMaterialId"></param>
        /// <returns></returns>
        public async Task UpdateMaterialId(string newMaterialId, string oldMaterialId)
        {
            await this.BaseRepository().Update<CaseErpBomEntity>(new { F_PId = newMaterialId }, t => t.F_PId == oldMaterialId);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Inserts(List<CaseErpBomEntity> list)
        {
            if (list.Count > 0)
            {
                await this.BaseRepository().Inserts<CaseErpBomEntity>(list);
            }
        }


        #endregion

        //#region 扩展方法
        ///// <summary>
        ///// 数据导入处理
        ///// </summary>
        ///// <param name="sheets">excel数据</param>
        ///// <returns></returns>
        //public async Task<bool> BomImport(List<ExcelSheet> sheets)
        //{
        //    var db = BaseRepository().BeginTrans();
        //    try
        //    {
        //        if (sheets != null)
        //        {
        //            List<CaseErpBomEntity> erpBomEntities = new List<CaseErpBomEntity>();
        //            foreach (var sheet in sheets)
        //            {
        //                CaseErpBomEntity erpBomEntity = new CaseErpBomEntity();
        //                var superiormaterial = sheet.Data[0].Row;//上级物料信息
        //                var material = sheet.Data[1].Table.Data;//物料信息
        //                //判断是否存在商机物料
        //                if (!string.IsNullOrEmpty(superiormaterial[1].Text)&& !string.IsNullOrEmpty(superiormaterial[3].Text))//存在商机物料
        //                {

        //                }
        //                else//不存在上级物料
        //                {

        //                }





        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //        db.Commit();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        db.Rollback();
        //        return false;
        //        throw;
        //    }

        //}
        //#endregion
    }
}
