using learun.database;
using System;

namespace demo.ibll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2022-06-13 10:53:49
    /// 描 述：demo_ew_curm(【案例展示】主子孙-现存量表)表的实体
    /// </summary>
    [MyTable("demo_ew_curm")]
    public class EwCurmEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 【外键ew_matecardetail】
        /// </summary>
        public string F_matecardetailId { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string F_cpbh { get; set; }
        /// <summary>
        /// 库位编号
        /// </summary>
        public string F_kwbh { get; set; }
        /// <summary>
        /// 库存数
        /// </summary>
        public int? F_kcs { get; set; }
        /// <summary>
        /// 出货数
        /// </summary>
        public int? F_chs { get; set; }
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