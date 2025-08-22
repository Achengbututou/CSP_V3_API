using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-07 13:29:09
    /// 描 述：mes_ProcessRoute(工艺路线管理)表的实体
    /// </summary>
    [MyTable("mes_ProcessRoute")]
    public class MesProcessRouteEntity
    {
        #region 实体成员
        /// <summary>
        /// 工艺路线主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 路线编码
        /// </summary>
        public string F_RouteNumber { get; set; }
        /// <summary>
        /// 用户输入编码
        /// </summary>
        public string F_IsSysNum { get; set; }
        /// <summary>
        /// 是否使用系统编码
        /// </summary>
        public int? F_NumberState { get; set; }
        /// <summary>
        /// 路线名称
        /// </summary>
        public string F_RouteName { get; set; }
        /// <summary>
        /// 产品绑定
        /// </summary>
        public string F_ProductId { get; set; }
        /// <summary>
        /// 常用状态
        /// </summary>
        public int? F_CommonState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string F_Remarks { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string F_CreatUserName { get; set; }
        /// <summary>
        /// 创建人主键
        /// </summary>
        public string F_CreatUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_CreatUserTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string F_ModifyName { get; set; }
        /// <summary>
        /// 修改人主键
        /// </summary>
        public string F_ModifyId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? F_ModifyTime { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public string F_TenantId { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 创建时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreatUserTimeQRange { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ModifyTimeQRange { get; set; }
        /// <summary>
        /// 关键字段
        /// </summary>
        [Column(IsIgnore = true)]
        public string Keyword { get; set; }

        /// <summary>
        /// 物料编号
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_ProductNumber { get; set; }

        #endregion
    }
}