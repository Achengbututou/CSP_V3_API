using learun.database;
using System;

namespace erp.ibll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期：2021-06-08 10:29:59
    /// 描 述：lr_erp_purchaserequisition(采购申请)表的实体
    /// </summary>
    [MyTable("erp_purchase_apply")]
    public class Erp_purchase_applyEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识【GUID】
        /// </summary>
        [Column(IsPrimary = true)]
        public String F_Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? F_Amount { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public String F_Appler { get; set; }
        /// <summary>
        /// 申请日期(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_ApplyDate { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public String F_BarCode { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String F_Code { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Decimal? F_Count { get; set; }
        /// <summary>
        /// 创建时间(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 申请单位
        /// </summary>
        public String F_Department { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String F_Description { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public String F_File { get; set; }
        /// <summary>
        /// 修改日期(做为条件字段为开始时间)
        /// </summary>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户名称
        /// </summary>
        public String F_ModifyUserName { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String F_Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public String F_Number { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        public String F_Place { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public Decimal? F_Price { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public String F_PurchaseNo { get; set; }
        /// <summary>
        /// 采购类别
        /// </summary>
        public String F_PurchaseType { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public String F_Specification { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public String F_Status { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public String F_Theme { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public String F_Type { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public String F_Unit { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 申请日期(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_ApplyDate_end { get; set; }
        /// <summary>
        /// 创建时间(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_CreateDate_end { get; set; }
        /// <summary>
        /// 修改日期(做为条件字段为结束时间)
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime? F_ModifyDate_end { get; set; }

        #endregion


        #region 多租户
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        #endregion
    }
}