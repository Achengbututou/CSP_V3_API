using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:42:10
    /// 描 述：case_erp_customercontacts(客户联系人【case_erp_customercontacts】)表的实体
    /// </summary>
    [MyTable("case_erp_clientcontact")]
    public class CaseErpCustomercontactsEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 客户信息外键(case_erp_customer)
        /// </summary>
        public string F_CustomerId { get; set; }
        /// <summary>
        /// 是否为默认联系人(0是，1否)
        /// </summary>
        public int? F_IsDefault { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string F_Phone { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string F_Post { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string F_Dep { get; set; }
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
        /// 创建用户id(归属)
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