using learun.database;
using System;

namespace mes.ibll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期：2023-08-23 09:44:54
    /// 描 述：mes_IncomingByOrder(来料检验报告按单检验)表的实体
    /// </summary>
    [MyTable("mes_IncomingByOrder")]
    public class MesIncomingByOrderEntity
    {
        #region 实体成员
        /// <summary>
        /// 来料检验主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 来料检验报告主键
        /// </summary>
        public string F_IncomingInspectionId { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 送货数
        /// </summary>
        public int? F_DeliveriesNumber { get; set; }
        /// <summary>
        /// 抽样数
        /// </summary>
        public int? F_SamplesNumber { get; set; }
        /// <summary>
        /// 检测类别
        /// </summary>
        public string F_DetectionCategoryId { get; set; }
        /// <summary>
        /// 检测项目
        /// </summary>
        public string F_DetectionItemId { get; set; }
        /// <summary>
        /// 检验标准
        /// </summary>
        public string F_StandarId { get; set; }
        /// <summary>
        /// 检验方法
        /// </summary>
        public string F_DetectionMethodId { get; set; }
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
        /// 整体判定
        /// </summary>
        public int? F_OveralJudgment { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string F_Annex { get; set; }
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