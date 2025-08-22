using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:09:49
    /// 描 述：case_erp_supplier(供应商信息【case_erp_supplier】)表的实体
    /// </summary>
    [MyTable("case_erp_supplier")]
    public class CaseErpSupplierEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 是否系统编号(0是，1否)----ADD BY SSY 20221205
        /// </summary>
        public int? F_IsSysNum { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 供应商负责人
        /// </summary>
        public string F_Person { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string F_Phone { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string F_Scope { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public string F_Type { get; set; }
        /// <summary>
        /// 潜在供应商状态(0潜在，1审批中，2不通过)
        /// </summary>
        public int? F_LatentState { get; set; }
        /// <summary>
        /// 正式供应商当前年审状态(0未年审，1审批中，2审批不通过，3审批通过，4不需要年审)
        /// </summary>
        public int? F_FormalState { get; set; }
        /// <summary>
        /// 供应商状态(0潜在供应商，1正式供应商，2淘汰供应商)
        /// </summary>
        public int? F_State { get; set; }
        /// <summary>
        /// 风险评估报告状态(0优秀，1良好，2及格，3不及格，4未评估)----CHANGE BY SSY 20221206
        /// </summary>
        public int? F_AssessState { get; set; }
        /// <summary>
        /// 淘汰原因
        /// </summary>
        public string F_OutType { get; set; }
        /// <summary>
        /// 淘汰说明
        /// </summary>
        public string F_OutReason { get; set; }
        /// <summary>
        /// 恢复理由
        /// </summary>
        public string F_RecoverReason { get; set; }
        /// <summary>
        /// 恢复文件
        /// </summary>
        public string F_RecoverFile { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Description { get; set; }
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
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        
        /// <summary>
        /// 供应商转正时间
        /// </summary>
        public DateTime? F_FormalDate { get; set; }

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
        /// 关键字
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }
        
        /// <summary>
        /// 是否是淘汰供应商
        /// </summary>
        [Column(IsIgnore = true)]
        public bool isOut { get; set; }
        /// <summary>
        /// 是否是恢复供应商
        /// </summary>
        [Column(IsIgnore = true)]
        public bool isRecover { get; set; }

        #endregion
    }
}