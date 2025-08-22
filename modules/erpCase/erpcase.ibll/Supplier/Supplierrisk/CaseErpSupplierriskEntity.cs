using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:10:51
    /// 描 述：case_erp_supplierrisk(供应商风险评估【case_erp_supplierrisk】)表的实体
    /// </summary>
    [MyTable("case_erp_supplierrisk")]
    public class CaseErpSupplierriskEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 评估类型(0正常评估，1年审)
        /// </summary>
        public int? F_Type { get; set; }
        /// <summary>
        /// 供应商外键(case_erp_supplier)
        /// </summary>
        public string F_SupplierId { get; set; }
        /// <summary>
        /// 供货能力等级(0优秀，1良好，2及格，3不及格)
        /// </summary>
        public string F_CapacityLevel { get; set; }
        /// <summary>
        /// 供货能力理由
        /// </summary>
        public string F_CapacityReason { get; set; }
        /// <summary>
        /// 供货能力附件
        /// </summary>
        public string F_CapacityFile { get; set; }
        /// <summary>
        /// 供货质量等级(0优秀，1良好，2及格，3不及格)
        /// </summary>
        public string F_SupplierLevel { get; set; }
        /// <summary>
        /// 供货质量理由
        /// </summary>
        public string F_SupplierReason { get; set; }
        /// <summary>
        /// 供货质量附件
        /// </summary>
        public string F_SupplierFile { get; set; }
        /// <summary>
        /// 环境与安全等级(0优秀，1良好，2及格，3不及格)
        /// </summary>
        public string F_SafetyLevel { get; set; }
        /// <summary>
        /// 环境与安全理由
        /// </summary>
        public string F_SafetyReason { get; set; }
        /// <summary>
        /// 环境与安全附件
        /// </summary>
        public string F_SafetyFile { get; set; }
        /// <summary>
        /// 最终评估等级(0优秀，1良好，2及格，3不及格)
        /// </summary>
        public string F_FinalState { get; set; }
        /// <summary>
        /// 最终评估理由
        /// </summary>
        public string F_FinalReason { get; set; }
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
        /// 年审审批结果(0优秀，1良好，2及格，3不及格)----ADD BY SSY 20221207
        /// </summary>
        public string F_AuditState { get; set; }
        /// <summary>
        /// 年审审批相关说明----ADD BY SSY 20221207
        /// </summary>
        public string F_AuditReason { get; set; }

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

        #endregion
    }
}