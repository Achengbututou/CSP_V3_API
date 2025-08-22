using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-09-06 09:56:11
    /// 描 述：mes_OutboundInfo(出库信息)表的实体
    /// </summary>
    [MyTable("mes_OutboundInfo")]
    public class MesOutboundInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 出库主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 出库编码
        /// </summary>
        public string F_OutboundNumber { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 出库类型
        /// </summary>
        public string F_OutboundType { get; set; }
        /// <summary>
        /// 出库主题
        /// </summary>
        public string F_OutboundTheme { get; set; }
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? F_OutboundDate { get; set; }
        /// <summary>
        /// 生产单号
        /// </summary>
        public string F_ProductionNumber { get; set; }
        /// <summary>
        /// 选择单据主键
        /// </summary>
        public string F_ProductId { get; set; }
        /// <summary>
        /// 领用部门
        /// </summary>
        public string F_CollarDepartment { get; set; }
        /// <summary>
        /// 领用人员
        /// </summary>
        public string F_Consultant { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string F_ContactPerson { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string F_ContactNumber { get; set; }
        /// <summary>
        /// 采购部门
        /// </summary>
        public string F_PurchasingDe { get; set; }
        /// <summary>
        /// 采购人员
        /// </summary>
        public string F_PurchasingStaff { get; set; }
        /// <summary>
        /// 出库仓库
        /// </summary>
        public string F_WarehouseInfoId { get; set; }
        /// <summary>
        /// 出库操作员
        /// </summary>
        public string F_WarehousingStaff { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string F_CustomerName { get; set; }  
        /// <summary>
        /// 供应商
        /// </summary>
        public string F_Supplier { get; set; }
        /// <summary>
        /// 关联项目
        /// </summary>
        public string F_RelatedItems { get; set; }
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
        /// 出库日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_OutboundDateQRange { get; set; }
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

        #endregion
    }
}