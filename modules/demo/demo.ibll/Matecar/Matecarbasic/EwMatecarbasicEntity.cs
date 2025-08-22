using learun.database;
using System;

namespace demo.ibll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2022-06-13 10:55:59
    /// 描 述：demo_ew_matecarbasic(【案例展示】主子孙-配车单主表)表的实体
    /// </summary>
    [MyTable("demo_ew_matebasic")]
    public class EwMatecarbasicEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 配车单号
        /// </summary>
        public string F_pcdh { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime? F_djrq { get; set; }
        /// <summary>
        /// 运输车辆
        /// </summary>
        public string F_yscl { get; set; }
        /// <summary>
        /// 驾驶员编号
        /// </summary>
        public string F_jsybh { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string F_zdr { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime? F_zdsj { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_bz { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string F_kh { get; set; }
        /// <summary>
        /// 删除标记(0正常，1删除)
        /// </summary>
        public int? F_DeleteMark { get; set; }
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

        #endregion

        #region 扩展属性
        /// <summary>
        /// 单据日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_djrqQRange { get; set; }
        /// <summary>
        /// 制单时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_zdsjQRange { get; set; }
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