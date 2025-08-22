using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-01 11:31:36
    /// 描 述：mes_DeviceRepair(设备维修信息)表的实体
    /// </summary>
    [MyTable("mes_DeviceRepair")]
    public class MesDeviceRepairEntity
    {
        #region 实体成员
        /// <summary>
        /// 设备维修主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 维修单编码
        /// </summary>
        public string F_DeviceOrderCode { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string F_DeviceName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string F_DeviceType { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string F_Principal { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string F_ContactInformation { get; set; }
        /// <summary>
        /// 故障时间
        /// </summary>
        public DateTime? F_DownTime { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        public string F_Urgency { get; set; }
        /// <summary>
        /// 维修状态
        /// </summary>
        public string F_MaintenanceState { get; set; }
        /// <summary>
        /// 故障描述
        /// </summary>
        public string F_FaultDescription { get; set; }
        /// <summary>
        /// 故障图片
        /// </summary>
        public string F_FaultPicture { get; set; }
        /// <summary>
        /// 故障附件
        /// </summary>
        public string F_FaultAttachment { get; set; }
        /// <summary>
        /// 开工时间
        /// </summary>
        public DateTime? F_StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 维修时长
        /// </summary>
        public int? F_MaintenanceTime { get; set; }
        /// <summary>
        /// 维修人
        /// </summary>
        public string F_MaintenanceMan { get; set; }
        /// <summary>
        /// 维修故障描述
        /// </summary>
        public string F_WxFaultDescription { get; set; }
        /// <summary>
        /// 维修描述
        /// </summary>
        public string F_RepairDescription { get; set; }
        /// <summary>
        /// 维修图片
        /// </summary>
        public string F_RepairPictures { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Remarks { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string F_CreatUserName { get; set; }
        /// <summary>
        /// 创建人主键
        /// </summary>
        public string F_CreatUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_CreatUserTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string F_ModifyName { get; set; }
        /// <summary>
        /// 修改人主键
        /// </summary>
        public string F_ModifyId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? F_ModifyTime { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public string F_TenantId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 故障时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_DownTimeQRange { get; set; }
        /// <summary>
        /// 开工时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_StartTimeQRange { get; set; }
        /// <summary>
        /// 结束时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_EndDateQRange { get; set; }
        /// <summary>
        /// 创建时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreatUserTimeQRange { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyTimeQRange { get; set; }
        /// <summary>
        /// 设备编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_DeviceCode { get; set; }
        #endregion
    }
}