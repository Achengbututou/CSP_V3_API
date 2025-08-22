using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:42:10
    /// 描 述：case_erp_customer(客户信息【case_erp_customer】)表的实体
    /// </summary>
    [MyTable("case_erp_client")]
    public class CaseErpCustomerEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string F_Type { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string F_Person { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string F_Phone { get; set; }
        /// <summary>
        /// 所在行业
        /// </summary>
        public string F_Industry { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string F_Source { get; set; }
        /// <summary>
        /// 规模
        /// </summary>
        public string F_Scale { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string F_Address { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_File { get; set; }
        /// <summary>
        /// 默认联系人姓名
        /// </summary>
        public string F_DefaultName { get; set; }
        /// <summary>
        /// 默认联系人电话
        /// </summary>
        public string F_DefaultPhone { get; set; }
        /// <summary>
        /// 默认联系人职位
        /// </summary>
        public string F_DefaultPost { get; set; }
        /// <summary>
        /// 默认联系人部门
        /// </summary>
        public string F_DefaultDep { get; set; }
        /// <summary>
        /// 客户所属人员(销售人员)
        /// </summary>
        public string F_SaleId { get; set; }
        /// <summary>
        /// 客户状态(0正常，1公海)
        /// </summary>
        public string F_State { get; set; }
        /// <summary>
        /// 加入公海日期
        /// </summary>
        public DateTime? F_InOpenDate { get; set; }
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
        /// <summary>
        /// 公司性质----ADD BY SSY 20221206
        /// </summary>
        public string F_ComNature { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 加入公海日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_InOpenDateQRange { get; set; }
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

        #endregion
    }
}