using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
using MathNet.Numerics.Distributions;
using System.Security.Principal;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-01 14:27:53
    /// 描 述： 设备信息数据库执行类
    /// </summary>
    public class MesDeviceInfoService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesDeviceInfoEntity, bool>>GetExpression(MesDeviceInfoEntity queryParams) {
            var exp = Expressionable.Create<MesDeviceInfoEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceCode), t => t.F_DeviceCode.Contains(queryParams.F_DeviceCode));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceName), t => t.F_DeviceName.Contains(queryParams.F_DeviceName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceType), t => t.F_DeviceType.Contains(queryParams.F_DeviceType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ProductionLineId), t => t.F_ProductionLineId.Contains(queryParams.F_ProductionLineId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WorkstationInfoId), t => t.F_WorkstationInfoId.Contains(queryParams.F_WorkstationInfoId));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceBrand), t => t.F_DeviceBrand.Contains(queryParams.F_DeviceBrand));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Supplier), t => t.F_Supplier.Contains(queryParams.F_Supplier));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceModel), t => t.F_DeviceModel.Contains(queryParams.F_DeviceModel));
            if (!string.IsNullOrEmpty(queryParams.F_PurchaseDateQRange)) {
                var f_PurchaseDate_list = queryParams.F_PurchaseDateQRange.Split(" - ");
                DateTime f_PurchaseDate = Convert.ToDateTime(f_PurchaseDate_list[0]);
                DateTime f_PurchaseDate_end = Convert.ToDateTime(f_PurchaseDate_list[1]);
                exp = exp.And(t => t.F_PurchaseDate >= f_PurchaseDate && t.F_PurchaseDate <= f_PurchaseDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_MaintenanceDateQRange)) {
                var f_MaintenanceDate_list = queryParams.F_MaintenanceDateQRange.Split(" - ");
                DateTime f_MaintenanceDate = Convert.ToDateTime(f_MaintenanceDate_list[0]);
                DateTime f_MaintenanceDate_end = Convert.ToDateTime(f_MaintenanceDate_list[1]);
                exp = exp.And(t => t.F_MaintenanceDate >= f_MaintenanceDate && t.F_MaintenanceDate <= f_MaintenanceDate_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_ScrapDateQRange)) {
                var f_ScrapDate_list = queryParams.F_ScrapDateQRange.Split(" - ");
                DateTime f_ScrapDate = Convert.ToDateTime(f_ScrapDate_list[0]);
                DateTime f_ScrapDate_end = Convert.ToDateTime(f_ScrapDate_list[1]);
                exp = exp.And(t => t.F_ScrapDate >= f_ScrapDate && t.F_ScrapDate <= f_ScrapDate_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Principal), t => t.F_Principal.Contains(queryParams.F_Principal));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ContactInformation), t => t.F_ContactInformation.Contains(queryParams.F_ContactInformation));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DevicePicture), t => t.F_DevicePicture.Contains(queryParams.F_DevicePicture));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceAttachment), t => t.F_DeviceAttachment.Contains(queryParams.F_DeviceAttachment));
            if (queryParams.F_States != null) {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Remarks), t => t.F_Remarks.Contains(queryParams.F_Remarks));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserName), t => t.F_CreatUserName.Contains(queryParams.F_CreatUserName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_CreatUserId), t => t.F_CreatUserId.Contains(queryParams.F_CreatUserId));
            if (!string.IsNullOrEmpty(queryParams.F_CreatUserTimeQRange)) {
                var f_CreatUserTime_list = queryParams.F_CreatUserTimeQRange.Split(" - ");
                DateTime f_CreatUserTime = Convert.ToDateTime(f_CreatUserTime_list[0]);
                DateTime f_CreatUserTime_end = Convert.ToDateTime(f_CreatUserTime_list[1]);
                exp = exp.And(t => t.F_CreatUserTime >= f_CreatUserTime && t.F_CreatUserTime <= f_CreatUserTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyName), t => t.F_ModifyName.Contains(queryParams.F_ModifyName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ModifyId), t => t.F_ModifyId.Contains(queryParams.F_ModifyId));
            if (!string.IsNullOrEmpty(queryParams.F_ModifyTimeQRange)) {
                var f_ModifyTime_list = queryParams.F_ModifyTimeQRange.Split(" - ");
                DateTime f_ModifyTime = Convert.ToDateTime(f_ModifyTime_list[0]);
                DateTime f_ModifyTime_end = Convert.ToDateTime(f_ModifyTime_list[1]);
                exp = exp.And(t => t.F_ModifyTime >= f_ModifyTime && t.F_ModifyTime <= f_ModifyTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_TenantId), t => t.F_TenantId.Contains(queryParams.F_TenantId));
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取设备信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDeviceInfoEntity>>GetList(MesDeviceInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesDeviceInfoEntity>(expression);
        }
        /// <summary>
        /// 获取设备信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDeviceInfoEntity>>GetPageList(Pagination pagination, MesDeviceInfoEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesDeviceInfoEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<MesDeviceInfoEntity>GetEntity(string keyValue) {
            var dataList= await this.BaseRepository().ORM.Queryable<MesDeviceInfoEntity>()
                 .LeftJoin<BaseUserEntity>((t, t1) => t.F_Principal ==t1.F_UserId)
                 .Where(t=>t.F_Id==keyValue)
                 .Select((t,t1) => new MesDeviceInfoEntity {
                     F_Id = t.F_Id,
                     F_DeviceCode=t.F_DeviceCode,
                     F_DeviceName=t.F_DeviceName,
                     F_DeviceType = t.F_DeviceType,
                     F_ProductionLineId = t.F_ProductionLineId,
                     F_WorkstationInfoId = t.F_WorkstationInfoId,
                     F_DeviceBrand = t.F_DeviceBrand,
                     F_Supplier = t.F_Supplier,
                     F_DeviceModel = t.F_DeviceModel,
                     F_PurchaseDate = t.F_PurchaseDate,
                     F_MaintenanceDate=t.F_MaintenanceDate,
                     F_ScrapDate=t.F_ScrapDate,
                     F_Principal=t.F_Principal,
                     F_PrincipalName=t1.F_RealName,
                     F_ContactInformation=t.F_ContactInformation,
                     F_DevicePicture=t.F_DevicePicture,
                     F_DeviceAttachment=t.F_DeviceAttachment,
                     F_States=t.F_States,
                     F_Remarks=t.F_Remarks,
                     F_CreatUserName=t.F_CreatUserName,
                     F_CreatUserId=t.F_CreatUserId,
                     F_CreatUserTime=t.F_CreatUserTime,
                     F_ModifyId=t.F_ModifyId,
                     F_ModifyName=t.F_ModifyName,
                     F_ModifyTime=t.F_ModifyTime
                 }).ToListAsync();
            if (dataList.Count > 0)
            {
                return dataList[0];
            }
            else
            {
                return null;
            }
     }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesDeviceInfoEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesDeviceInfoEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesDeviceInfoEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                    entity.F_CreatUserId = this.GetUserId();
                    entity.F_CreatUserName = this.GetUserName();
                    entity.F_CreatUserTime = DateTime.Now;
                }
                await this.BaseRepository().Insert(entity);
            } else {
                entity.F_Id = keyValue;
                entity.F_ModifyId = this.GetUserId();
                entity.F_ModifyName = this.GetUserName();
                entity.F_ModifyTime = DateTime.Now;
                await this.BaseRepository().Update(entity);
            }
        }
        #endregion
    }
}