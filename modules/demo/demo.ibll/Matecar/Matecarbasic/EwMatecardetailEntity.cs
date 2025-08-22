using learun.database;
using System;

namespace demo.ibll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2022-06-13 10:55:59
    /// 描 述：demo_ew_matecardetail(【案例展示】主子孙-配车单子表)表的实体
    /// </summary>
    [MyTable("demo_ew_matedetail")]
    public class EwMatecardetailEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 【外键ew_matecarbasic】
        /// </summary>
        public string F_matecarbasicId { get; set; }
        /// <summary>
        /// 配车单号
        /// </summary>
        public string F_pcdh { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string F_khbh { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string F_ddbh { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string F_cpbh { get; set; }
        /// <summary>
        /// 本次发货数量
        /// </summary>
        public int? F_bcfhsl { get; set; }
        /// <summary>
        /// 产品规格
        /// </summary>
        public string F_cpgg { get; set; }
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