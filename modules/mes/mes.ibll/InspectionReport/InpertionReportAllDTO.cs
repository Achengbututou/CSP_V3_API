using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 
    /// </summary>
    public class InpertionReportAllDTO
    {
        /// <summary>
        /// 检验类型
        /// </summary>
        public string F_TestType { get; set; }
        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? F_InspectionDate { get; set; }    
        /// <summary>
        /// 检验人员
        /// </summary>
        public string F_Inspector { get; set; }
        /// <summary>
        /// 检验结果
        /// </summary>
        public string F_OveralJudgment { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }
        /// <summary>
        /// 物料类型
        /// </summary>
        public string F_ProductType { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string F_Model { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string F_Unit { get; set; }
        /// <summary>
        /// 合格数量
        /// </summary>
        public decimal? F_QualifiedNumber { get; set; }
    }
}
