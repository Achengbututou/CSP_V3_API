using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 异常统计报表实体传递
    /// </summary>
    public class ExceptionReportDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string F_Id { get; set; }    
        /// <summary>
        /// 异常报告编码
        /// </summary>
        public string F_ExceptionNumber { get; set; }
        /// <summary>
        /// 检测类别
        /// </summary>
        public string F_DetectionCategoryId { get; set; }   
        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_ProductName { get; set; }  
        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_ProductNumber { get; set; } 
        /// <summary>
        /// 产品型号
        /// </summary>
        public string F_Model { get; set; } 
        /// <summary>
        /// 产品分类
        /// </summary>
        public string F_Type { get; set; }
        /// <summary>
        /// 缺陷产品数量
        /// </summary>
        public int? F_BadNumber { get; set; }
    }
}
