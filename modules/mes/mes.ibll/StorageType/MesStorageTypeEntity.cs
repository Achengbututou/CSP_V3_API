using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-07-31 11:46:28
    /// 描 述：mes_StorageType(存储类型信息维护)表的实体
    /// </summary>
    [MyTable("mes_StorageType")]
    public class MesStorageTypeEntity
    {
        #region 实体成员
        /// <summary>
        /// 存储类型主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 存储类型编号
        /// </summary>
        public string F_StorageTypeNumber { get; set; }
        /// <summary>
        /// 存储类型名称
        /// </summary>
        public string F_StorageTypeName { get; set; }
        /// <summary>
        /// 存储类型排序
        /// </summary>
        public int? F_StorageTypeSort { get; set; }
        /// <summary>
        /// 存储类型状态
        /// </summary>
        public int? F_StorageTypeState { get; set; }
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