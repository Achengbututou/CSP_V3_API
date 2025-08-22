using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 10:30:31
    /// 描 述：mes_InventoryInfo(盘点信息)表的实体
    /// </summary>
    [MyTable("mes_InventoryInfo")]
    public class MesInventoryInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 盘点主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 盘点编码
        /// </summary>
        public string F_InventoryNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateTime? F_InventoryDate { get; set; }
        /// <summary>
        /// 盘点主题
        /// </summary>
        public string F_InventoryTheme { get; set; }
        /// <summary>
        /// 盘点仓库
        /// </summary>
        public string F_WarehouseInfoId { get; set; }
        /// <summary>
        /// 盘点人员
        /// </summary>
        public string F_InventoryStaff { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_Annex { get; set; }
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
        /// 盘点日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InventoryDateQRange { get; set; }
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
        /// 盘点人员
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InventoryStaffName { get; set; }
        #endregion
    }
}