using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-07-31 15:54:06
    /// 描 述：mes_ReservoirArea(库区信息管理)表的实体
    /// </summary>
    [MyTable("mes_ReservoirArea")]
    public class MesReservoirAreaEntity
    {
        #region 实体成员
        /// <summary>
        /// 库区主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 库区编号
        /// </summary>
        public string F_ReservoirAreaNumber { get; set; }
        /// <summary>
        /// 库区名称
        /// </summary>
        public string F_ReservoirAreaName { get; set; }
        /// <summary>
        /// 库区分类
        /// </summary>
        public string F_ClassificationId { get; set; }
        /// <summary>
        /// 所属仓库
        /// </summary>
        public string F_WarehouseId { get; set; }
        /// <summary>
        /// 库区负责人
        /// </summary>
        public string F_ReservoirPrincipal { get; set; }
        /// <summary>
        /// 库区排序
        /// </summary>
        public int? F_ClassificationSort { get; set; }
        /// <summary>
        /// 库区状态
        /// </summary>
        public int? F_ClassificationState { get; set; }
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

        #endregion
    }
}