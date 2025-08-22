using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-31 10:20:45
    /// 描 述：mes_FinishedExDetail(成品校验异常数据)表的实体
    /// </summary>
    [MyTable("mes_FinishedExDetail")]
    public class MesFinishedExDetailEntity
    {
        #region 实体成员
        /// <summary>
        /// 详细主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 异常报告主键
        /// </summary>
        public string F_FinishedExId { get; set; }
        /// <summary>
        /// 工单编号
        /// </summary>
        public string F_TicketNumber { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 销售单号
        /// </summary>
        public string F_SalesOrderNumber { get; set; }
        /// <summary>
        /// 所属车间
        /// </summary>
        public string F_WorkshopId { get; set; }
        /// <summary>
        /// 基准值
        /// </summary>
        public int? F_BenchmarkValue { get; set; }
        /// <summary>
        /// 上公差
        /// </summary>
        public int? F_UpperTolerance { get; set; }
        /// <summary>
        /// 下公差
        /// </summary>
        public int? F_LowerTolerance { get; set; }
        /// <summary>
        /// 测量值
        /// </summary>
        public string F_MeasuredValue { get; set; }
        /// <summary>
        /// 不良数
        /// </summary>
        public int? F_BadNumber { get; set; }
        /// <summary>
        /// 不良处理方式
        /// </summary>
        public string F_BadHandling { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? F_States { get; set; }
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