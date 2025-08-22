using learun.database;
using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期：2022-12-05 16:54:57
    /// 描 述：case_erp_unitconvertdetail(单位换算详情【case_erp_unitconvertdetail】)表的实体
    /// </summary>
    [MyTable("case_erp_unitconvde")]
    public class CaseErpUnitconvertdetailEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 单位算换外键Id(case_erp_unitconvert)
        /// </summary>
        public string F_UnitConvertId { get; set; }
        /// <summary>
        /// 基准单位外键Id(case_erp_unit)
        /// </summary>
        public string F_UnitId { get; set; }
        /// <summary>
        /// 基准单位名称----ADD BY SSY 20221205
        /// </summary>
        public string F_UnitName { get; set; }
        /// <summary>
        /// 转换数量
        /// </summary>
        public decimal? F_Quantity { get; set; }
        /// <summary>
        /// 转换单位外键(case_erp_unit)
        /// </summary>
        public string F_ShiftUnitId { get; set; }
        /// <summary>
        /// 转换单位名称----ADD BY SSY 20221205
        /// </summary>
        public string F_ShiftUnitName { get; set; }
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
