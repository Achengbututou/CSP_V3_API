using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-16 13:53:00
    /// 描 述：case_erp_warehouselog(仓库管理【case_erp_warehouselog】)表的实体
    /// </summary>
    [MyTable("case_erp_warehoulog")]
    public class CaseErpWarehouselogEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 物料信息关联外键(case_erp_material)
        /// </summary>
        public string F_MaterialId { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string F_Address { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string F_Person { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string F_Phone { get; set; }
        /// <summary>
        /// 状态(0已完成，1未完成)
        /// </summary>
        public int? F_State { get; set; }
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