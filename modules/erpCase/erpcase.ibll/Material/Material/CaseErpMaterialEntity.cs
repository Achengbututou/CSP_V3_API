using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:49:03
    /// 描 述：case_erp_material(物料信息【case_erp_material】)表的实体
    /// </summary>
    [MyTable("case_erp_mater")]
    public class CaseErpMaterialEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_Number { get; set; }
        /// <summary>
        /// 是否系统编号(0是，1否)----ADD BY SSY 20221205
        /// </summary>
        public int? F_IsSysNum { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_Model { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 物料类别
        /// </summary>
        public string F_Type { get; set; }
        /// <summary>
        /// 物料属性
        /// </summary>
        public string F_Property { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_File { get; set; }
        /// <summary>
        /// 当前库存
        /// </summary>
        public decimal? F_Inventory { get; set; }
        /// <summary>
        /// 物料状态(0已启用，1未启用)
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

        /// <summary>
        /// 关键字段
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }

        #endregion
    }
}