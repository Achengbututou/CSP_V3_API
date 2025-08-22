using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using DocumentFormat.OpenXml.Wordprocessing;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-29 16:23:56
    /// 描 述： 巡检报告数据库执行类
    /// </summary>
    public class MesInspectionDetailService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesInspectionDetailEntity, bool>> GetExpression(MesInspectionDetailEntity queryParams)
        {
            var exp = Expressionable.Create<MesInspectionDetailEntity>();
            if (!string.IsNullOrEmpty(queryParams.F_InspectionId))
            {
                exp = exp.And(t => t.F_InspectionId == queryParams.F_InspectionId);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FirstTestNumber), t => t.F_FirstTestNumber.Contains(queryParams.F_FirstTestNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_SalesOrderNumber), t => t.F_SalesOrderNumber.Contains(queryParams.F_SalesOrderNumber));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductCode), t => t.F_ProductCode.Contains(queryParams.F_ProductCode));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductName), t => t.F_ProductName.Contains(queryParams.F_ProductName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialCoding), t => t.F_MaterialCoding.Contains(queryParams.F_MaterialCoding));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaterialName), t => t.F_MaterialName.Contains(queryParams.F_MaterialName));
            //if (!string.IsNullOrEmpty(queryParams.F_InspectionDateQRange)) {
            //    var f_InspectionDate_list = queryParams.F_InspectionDateQRange.Split(" - ");
            //    DateTime f_InspectionDate = Convert.ToDateTime(f_InspectionDate_list[0]);
            //    DateTime f_InspectionDate_end = Convert.ToDateTime(f_InspectionDate_list[1]);
            //    exp = exp.And(t => t.F_InspectionDate >= f_InspectionDate && t.F_InspectionDate <= f_InspectionDate_end);
            //}
            if (queryParams.F_DetectionsNumber != null)
            {
                exp = exp.And(t => t.F_DetectionsNumber == queryParams.F_DetectionsNumber);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Unit), t => t.F_Unit.Contains(queryParams.F_Unit));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DetectionCategoryId), t => t.F_DetectionCategoryId.Contains(queryParams.F_DetectionCategoryId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DetectionItemId), t => t.F_DetectionItemId.Contains(queryParams.F_DetectionItemId));
            if (queryParams.F_BenchmarkValue != null)
            {
                exp = exp.And(t => t.F_BenchmarkValue == queryParams.F_BenchmarkValue);
            }
            if (queryParams.F_UpperTolerance != null)
            {
                exp = exp.And(t => t.F_UpperTolerance == queryParams.F_UpperTolerance);
            }
            if (queryParams.F_LowerTolerance != null)
            {
                exp = exp.And(t => t.F_LowerTolerance == queryParams.F_LowerTolerance);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MeasuredValue), t => t.F_MeasuredValue.Contains(queryParams.F_MeasuredValue));
            if (queryParams.F_BadNumber != null)
            {
                exp = exp.And(t => t.F_BadNumber == queryParams.F_BadNumber);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_BadHandling), t => t.F_BadHandling.Contains(queryParams.F_BadHandling));
            if (queryParams.F_States != null)
            {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Remarks), t => t.F_Remarks.Contains(queryParams.F_Remarks));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserName), t => t.F_CreatUserName.Contains(queryParams.F_CreatUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserId), t => t.F_CreatUserId.Contains(queryParams.F_CreatUserId));
            if (!string.IsNullOrEmpty(queryParams.F_CreatUserTimeQRange))
            {
                var f_CreatUserTime_list = queryParams.F_CreatUserTimeQRange.Split(" - ");
                DateTime f_CreatUserTime = Convert.ToDateTime(f_CreatUserTime_list[0]);
                DateTime f_CreatUserTime_end = Convert.ToDateTime(f_CreatUserTime_list[1]);
                exp = exp.And(t => t.F_CreatUserTime >= f_CreatUserTime && t.F_CreatUserTime <= f_CreatUserTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyName), t => t.F_ModifyName.Contains(queryParams.F_ModifyName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyId), t => t.F_ModifyId.Contains(queryParams.F_ModifyId));
            if (!string.IsNullOrEmpty(queryParams.F_ModifyTimeQRange))
            {
                var f_ModifyTime_list = queryParams.F_ModifyTimeQRange.Split(" - ");
                DateTime f_ModifyTime = Convert.ToDateTime(f_ModifyTime_list[0]);
                DateTime f_ModifyTime_end = Convert.ToDateTime(f_ModifyTime_list[1]);
                exp = exp.And(t => t.F_ModifyTime >= f_ModifyTime && t.F_ModifyTime <= f_ModifyTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.Keyword), t => t.F_FirstTestNumber.Contains(queryParams.Keyword) || t.F_ProductCode.Contains(queryParams.Keyword) || t.F_ProductName.Contains(queryParams.Keyword));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取巡检报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesInspectionDetailEntity>> GetList(MesInspectionDetailEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesInspectionDetailEntity>(expression);
        }
        /// <summary>
        /// 获取巡检报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<MesInspectionDetailEntity>> GetPageList(Pagination pagination, MesInspectionDetailEntity queryParams)
        {
            //检测类别集合
            Dictionary<string,string> detectionDIC = new Dictionary<string,string>();
            var mesDetections = await  this.BaseRepository().FindAll<MesDetectionCategoryEntity>();
            foreach(var mesDetection in mesDetections)
            {
                if (!detectionDIC.ContainsKey(mesDetection.F_Id))
                {
                    detectionDIC.Add(mesDetection.F_Id, mesDetection.F_DetectionCategory);
                }
            }
            //检测项目集合
            Dictionary<string,string> itemDIC2 = new Dictionary<string,string>();
            var mesDetectionItems= await this.BaseRepository().FindAll<MesDetectionItemEntity>();
            foreach(var mesDetectionItem in mesDetectionItems)
            {
                if (!itemDIC2.ContainsKey(mesDetectionItem.F_Id))
                {
                    itemDIC2.Add(mesDetectionItem.F_Id, mesDetectionItem.F_DetectionItemName);
                }
            }
            //获取数据
            var list= await this.BaseRepository().FindListByQueryable<MesInspectionDetailEntity>(q => {
                var queryable = q.LeftJoin<CaseErpUnitconvertdetailEntity>((t, t1) => t.F_Unit == t1.F_Id);
                var expression = GetExpression(queryParams);
                queryable = queryable.Where(expression);
               return queryable.Select((t, t1) => new MesInspectionDetailEntity()
               {
                   F_Id = t.F_Id,
                   F_InspectionId = t.F_InspectionId,
                   F_FirstTestNumber = t.F_FirstTestNumber,
                   F_SalesOrderNumber = t.F_SalesOrderNumber,
                   F_ProductCode = t.F_ProductCode,
                   F_ProductName = t.F_ProductName,
                   F_MaterialCoding = t.F_MaterialCoding,
                   F_MaterialName = t.F_MaterialName,
                   F_InspectionDate = t.F_InspectionDate,
                   F_DetectionsNumber = t.F_DetectionsNumber,
                   F_Unit=t1.F_UnitName,
                   F_DetectionCategoryId=t.F_DetectionCategoryId,
                   F_DetectionItemId=t.F_DetectionItemId,
                   F_BenchmarkValue=t.F_BenchmarkValue,
                   F_UpperTolerance=t.F_UpperTolerance,
                   F_MeasuredValue=t.F_MeasuredValue,
                   F_BadNumber=t.F_BadNumber,
                   F_BadHandling=t.F_BadHandling,
                   F_States = t.F_States,
                   F_Annex = t.F_Annex,
                   F_Remarks = t.F_Remarks,
                   F_CreatUserName = t.F_CreatUserName,
                   F_CreatUserTime = t.F_CreatUserTime,
                   F_ModifyName = t.F_ModifyName,
                   F_ModifyTime = t.F_ModifyTime
               });
            }, pagination);
            foreach(var item in list)
            {
                string[] detectionCategorys = item.F_DetectionCategoryId.Split(',');
                string detetionCategorys = "";
                foreach(var detection in detectionCategorys)
                {
                    if (detectionDIC.ContainsKey(detection))
                    {
                        if (!string.IsNullOrEmpty(detetionCategorys))
                        {
                            detetionCategorys += ",";
                        }
                        detetionCategorys+= detectionDIC.GetValueOrDefault(detection);
                    }
                }
                item.F_DetectionCategoryId = detetionCategorys;
                string[] detectitemNames = item.F_DetectionItemId.Split(',');
                string deteName = "";
                foreach(var itemName in detectitemNames)
                {
                    if (itemDIC2.ContainsKey(itemName))
                    {
                        if (!string.IsNullOrEmpty(deteName))
                        {
                            deteName += ",";
                        }
                        deteName += itemDIC2.GetValueOrDefault(deteName);
                    }
                }
                item.F_DetectionItemId = deteName;
            }
            return list;
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesInspectionDetailEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<MesInspectionDetailEntity>(keyValue);
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
            await this.BaseRepository().Delete<MesInspectionDetailEntity>(keyValue);
        }
        /// <summary>
        /// 删除巡检报告的数据根据外键
        /// </summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key)
        {
            await this.BaseRepository().Delete<MesInspectionDetailEntity>(t => t.F_InspectionId == key);
        }
        /// <summary>
        /// 批量根据外键删除详细数据
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public async Task DeleteRelates(List<string> keys)
        {
            await this.BaseRepository().Delete<MesInspectionDetailEntity>(t => keys.Contains(t.F_InspectionId));
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesInspectionDetailEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesInspectionDetailEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                if (string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }
                entity.F_CreatUserId = this.GetUserId();
                entity.F_CreatUserName = this.GetUserName();
                entity.F_CreatUserTime = DateTime.Now;
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_Id = keyValue;
                entity.F_ModifyId = this.GetUserId();
                entity.F_ModifyName = this.GetUserName();
                entity.F_ModifyTime = DateTime.Now;
                await this.BaseRepository().Update(entity);
            }
        }
        /// <summary>
        /// 保存子表数据
        /// </summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<MesInspectionDetailEntity> list)
        {
            var addList = new List<MesInspectionDetailEntity>();
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<MesInspectionDetailEntity>(t => t.F_InspectionId == key);
                foreach (var item in list)
                {

                    item.F_Id = Guid.NewGuid().ToString();
                    item.F_CreatUserId = this.GetUserId();
                    item.F_CreatUserName = this.GetUserName();
                    item.F_CreatUserTime = DateTime.Now;
                    item.F_InspectionId = key;
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
        #endregion
    }
}