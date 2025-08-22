using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-11-28 17:03:09
    /// 描 述：case_erp_devicewarn(设备告警【case_erp_devicewarn】)表的实体
    /// </summary>
    [MyTable("case_erp_devicewarn")]
    public class CaseErpDevicewarnEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string F_UserId { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string F_Type { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_Model { get; set; }
        /// <summary>
        /// 设备位置
        /// </summary>
        public string F_Address { get; set; }
        /// <summary>
        /// 故障等级(0一级，1二级，2三级)
        /// </summary>
        public string F_Level { get; set; }
        /// <summary>
        /// 故障描述
        /// </summary>
        public string F_Description { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_File { get; set; }
        /// <summary>
        /// 处理状态(0已处理，1待处理)
        /// </summary>
        public int? F_State { get; set; }
        /// <summary>
        /// 删除标记(0正常，1删除)
        /// </summary>
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 有效标志(0正常，1禁用)
        /// </summary>
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户id
        /// </summary>
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户id
        /// </summary>
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户名称
        /// </summary>
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 检查设备-设备信息外键Id(case_erp_deviceinfo)----ADD BY SSY 20221205
        /// </summary>
        public string F_DeviceId { get; set; }
        /// <summary>
        /// 告警时间----ADD BY SSY 20221206
        /// </summary>
        public DateTime? F_Date { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        /// <summary>
        /// 处理办法----ADD BY SSY 20221207
        /// </summary>
        public string F_DealWay { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 创建日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreateDateQRange { get; set; }
        /// <summary>
        /// 修改日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyDateQRange { get; set; }
        /// <summary>
        /// 告警时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_DateQRange { get; set; }
        /// <summary>
        /// 故障等级(0一级，1二级，2三级)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_LevelStr { get; set; }
        /// <summary>
        /// 处理状态(0已处理，1待处理)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_StateStr { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_UserIdStr { get; set; }
        /// <summary>
        /// 关键字段
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }

        #endregion
    }
}