using learun.util;
using learun.iapplication;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-01 11:31:36
    /// 描 述： 设备维修数据库执行类
    /// </summary>
    public class MesDeviceRepairService: ServiceBase {

        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        private Expression<Func<MesDeviceRepairEntity, bool>>GetExpression(MesDeviceRepairEntity queryParams) {
            var exp = Expressionable.Create<MesDeviceRepairEntity>();
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceOrderCode), t => t.F_DeviceOrderCode.Contains(queryParams.F_DeviceOrderCode));
            if (queryParams.F_NumberState != null) {
                exp = exp.And(t => t.F_NumberState == queryParams.F_NumberState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceName), t => t.F_DeviceName.Contains(queryParams.F_DeviceName));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_DeviceType), t => t.F_DeviceType.Contains(queryParams.F_DeviceType));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Principal), t => t.F_Principal.Contains(queryParams.F_Principal));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_ContactInformation), t => t.F_ContactInformation.Contains(queryParams.F_ContactInformation));
            if (!string.IsNullOrEmpty(queryParams.F_DownTimeQRange)) {
                var f_DownTime_list = queryParams.F_DownTimeQRange.Split(" - ");
                DateTime f_DownTime = Convert.ToDateTime(f_DownTime_list[0]);
                DateTime f_DownTime_end = Convert.ToDateTime(f_DownTime_list[1]);
                exp = exp.And(t => t.F_DownTime >= f_DownTime && t.F_DownTime <= f_DownTime_end);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_Urgency), t => t.F_Urgency.Contains(queryParams.F_Urgency));
            if (queryParams.F_MaintenanceState != null) {
                exp = exp.And(t => t.F_MaintenanceState == queryParams.F_MaintenanceState);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FaultDescription), t => t.F_FaultDescription.Contains(queryParams.F_FaultDescription));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FaultPicture), t => t.F_FaultPicture.Contains(queryParams.F_FaultPicture));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_FaultAttachment), t => t.F_FaultAttachment.Contains(queryParams.F_FaultAttachment));
            if (!string.IsNullOrEmpty(queryParams.F_StartTimeQRange)) {
                var f_StartTime_list = queryParams.F_StartTimeQRange.Split(" - ");
                DateTime f_StartTime = Convert.ToDateTime(f_StartTime_list[0]);
                DateTime f_StartTime_end = Convert.ToDateTime(f_StartTime_list[1]);
                exp = exp.And(t => t.F_StartTime >= f_StartTime && t.F_StartTime <= f_StartTime_end);
            }
            if (!string.IsNullOrEmpty(queryParams.F_EndDateQRange)) {
                var f_EndDate_list = queryParams.F_EndDateQRange.Split(" - ");
                DateTime f_EndDate = Convert.ToDateTime(f_EndDate_list[0]);
                DateTime f_EndDate_end = Convert.ToDateTime(f_EndDate_list[1]);
                exp = exp.And(t => t.F_EndDate >= f_EndDate && t.F_EndDate <= f_EndDate_end);
            }
            if (queryParams.F_MaintenanceTime != null) {
                exp = exp.And(t => t.F_MaintenanceTime == queryParams.F_MaintenanceTime);
            }
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_MaintenanceMan), t => t.F_MaintenanceMan.Contains(queryParams.F_MaintenanceMan));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_WxFaultDescription), t => t.F_WxFaultDescription.Contains(queryParams.F_WxFaultDescription));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RepairDescription), t => t.F_RepairDescription.Contains(queryParams.F_RepairDescription));
            exp = exp.AndIF(!string.IsNullOrEmpty(queryParams.F_RepairPictures), t => t.F_RepairPictures.Contains(queryParams.F_RepairPictures));
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
            if (queryParams.F_States != null) {
                exp = exp.And(t => t.F_States == queryParams.F_States);
            }
            return exp.ToExpression();
        }
        /// <summary>
        /// 获取设备维修的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDeviceRepairEntity>>GetList(MesDeviceRepairEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<MesDeviceRepairEntity>(expression);
        }
        /// <summary>
        /// 获取设备维修的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesDeviceRepairEntity>>GetPageList(Pagination pagination, MesDeviceRepairEntity queryParams) {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindListByQueryable<MesDeviceRepairEntity>(q => {
                var queryable = q.LeftJoin<MesDeviceInfoEntity>((t, t1) => t.F_DeviceName == t1.F_Id);
                var exp = GetExpression(queryParams);
                queryable = queryable.Where(exp);
                return queryable.Select((t, t1) => new MesDeviceRepairEntity()
                {
                    F_Id = t.F_Id,
                    F_DeviceOrderCode = t.F_DeviceOrderCode,
                    F_NumberState = t.F_NumberState,
                    F_DeviceName = t.F_DeviceName,
                    F_DeviceType = t.F_DeviceType,
                    F_Principal = t.F_Principal,
                    F_ContactInformation = t.F_ContactInformation,
                    F_DownTime = t.F_DownTime,
                    F_States = t.F_States,
                    F_Remarks = t.F_Remarks,
                    F_CreatUserName = t.F_CreatUserName,
                    F_CreatUserTime = t.F_CreatUserTime,
                    F_ModifyName=t.F_ModifyName,
                    F_ModifyTime=t.F_ModifyTime,    
                    F_Urgency = t.F_Urgency,
                    F_MaintenanceState = t.F_MaintenanceState,
                    F_FaultDescription = t.F_FaultDescription,
                    F_FaultPicture = t.F_FaultPicture,
                    F_FaultAttachment = t.F_FaultAttachment,
                    F_StartTime = t.F_StartTime,
                    F_EndDate = t.F_EndDate,
                    F_MaintenanceTime = t.F_MaintenanceTime,
                    F_MaintenanceMan = t.F_MaintenanceMan,
                    F_WxFaultDescription = t.F_WxFaultDescription,
                    F_RepairDescription = t.F_RepairDescription,
                    F_RepairPictures = t.F_RepairPictures,
                    F_DeviceCode = t1.F_DeviceCode
                });
            }, pagination);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesDeviceRepairEntity>GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<MesDeviceRepairEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await this.BaseRepository().Delete<MesDeviceRepairEntity>(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            string[] keyValuesArr = keyValues.Split(",");
            await this.BaseRepository().Delete<MesDeviceRepairEntity>(keyValuesArr);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesDeviceRepairEntity entity) {
            if (string.IsNullOrEmpty(keyValue)) {
                if (string.IsNullOrEmpty(entity.F_Id)) {
                    entity.F_Id = Guid.NewGuid().ToString();
                    if (entity.F_States == null)
                    {
                        entity.F_States = 1;
                    }
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