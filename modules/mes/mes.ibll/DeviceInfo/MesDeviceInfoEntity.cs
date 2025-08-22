using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-01 14:27:53
    /// 描 述：mes_DeviceInfo(设备信息)表的实体
    /// </summary>
    [MyTable("mes_DeviceInfo")]
    public class MesDeviceInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 设备主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 设备编码
        /// </summary>
        public string F_DeviceCode { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string F_DeviceName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string F_DeviceType { get; set; }
        /// <summary>
        /// 所属产线
        /// </summary>
        public string F_ProductionLineId { get; set; }
        /// <summary>
        /// 所在工位
        /// </summary>
        public string F_WorkstationInfoId { get; set; }
        /// <summary>
        /// 设备品牌
        /// </summary>
        public string F_DeviceBrand { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string F_Supplier { get; set; }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string F_DeviceModel { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? F_PurchaseDate { get; set; }
        /// <summary>
        /// 维保日期
        /// </summary>
        public DateTime? F_MaintenanceDate { get; set; }
        /// <summary>
        /// 报废日期
        /// </summary>
        public DateTime? F_ScrapDate { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string F_Principal { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string F_ContactInformation { get; set; }
        /// <summary>
        /// 故障图片
        /// </summary>
        public string F_DevicePicture { get; set; }
        /// <summary>
        /// 故障附件
        /// </summary>
        public string F_DeviceAttachment { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
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

        #endregion

        #region 扩展属性
        /// <summary>
        /// 采购日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_PurchaseDateQRange { get; set; }
        /// <summary>
        /// 维保日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_MaintenanceDateQRange { get; set; }
        /// <summary>
        /// 报废日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ScrapDateQRange { get; set; }
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
        /// 负责人
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_PrincipalName { get; set; }
        #endregion
    }
}