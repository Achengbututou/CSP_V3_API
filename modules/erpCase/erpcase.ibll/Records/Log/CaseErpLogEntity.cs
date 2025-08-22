using learun.database;
using System;

namespace erpCase.ibll
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期：2022-12-05 09:24:18
    /// 描 述：case_erp_log(操作记录【case_erp_log】)表的实体
    /// </summary>
    [MyTable("case_erp_log")]
    public class CaseErpLogEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 操作记录分类：0客户，1物料，2采购，3销售
        /// </summary>
        public string F_CategoryId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? F_OperateTime { get; set; }
        /// <summary>
        /// 操作用户id
        /// </summary>
        public string F_OperateUserId { get; set; }
        /// <summary>
        /// 操作用户账号
        /// </summary>
        public string F_OperateAccount { get; set; }
        /// <summary>
        /// 操作用户类型
        /// </summary>
        public string F_OperateTypeId { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string F_IP { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string F_IPAddress { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        public string F_Host { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string F_Browser { get; set; }
        /// <summary>
        /// 执行结果状态
        /// </summary>
        public int? F_ExecuteResult { get; set; }
        /// <summary>
        /// 执行结果内容
        /// </summary>
        public string F_ExecuteResultJson { get; set; }
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
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        /// <summary>
        /// 关联外键----ADD BY SSY 20221207
        /// </summary>
        public string F_KeyId { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 操作时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_OperateTimeQRange { get; set; }
        /// <summary>
        /// 创建日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_CreateDateQRange { get; set; }

        #endregion
    }
}