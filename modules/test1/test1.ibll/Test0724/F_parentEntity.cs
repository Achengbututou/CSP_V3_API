using learun.database;
using System;

namespace Test1.ibll
{
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：
    /// 日 期：2024-07-24 16:39:53
    /// 描 述：f_parent表的实体
    /// </summary>
    [MyTable("f_parent")]
    public class F_parentEntity
    {
        #region 实体成员
        /// <summary>
        /// 唯一标识(GUID)
        /// </summary>
        [Column(IsPrimary = true,ColumnName = "F_Id")]
        public string F_Id { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        [Column(ColumnName = "F_text")]
        public string F_text { get; set; }
        /// <summary>
        /// 多行文本
        /// </summary>
        [Column(ColumnName = "F_textarea")]
        public string F_textarea { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>
        [Column(ColumnName = "F_edit")]
        public string F_edit { get; set; }
        /// <summary>
        /// 计数器
        /// </summary>
        [Column(ColumnName = "F_Num")]
        public int? F_Num { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column(ColumnName = "F_password")]
        public string F_password { get; set; }
        /// <summary>
        /// 单选
        /// </summary>
        [Column(ColumnName = "F_radio")]
        public string F_radio { get; set; }
        /// <summary>
        /// 多选
        /// </summary>
        [Column(ColumnName = "F_checkbox")]
        public string F_checkbox { get; set; }
        /// <summary>
        /// 下拉多选1
        /// </summary>
        [Column(ColumnName = "F_select")]
        public string F_select { get; set; }
        /// <summary>
        /// 下拉多选2
        /// </summary>
        [Column(ColumnName = "F_select2")]
        public string F_select2 { get; set; }
        /// <summary>
        /// 树形选择框
        /// </summary>
        [Column(ColumnName = "F_treeSelect")]
        public string F_treeSelect { get; set; }
        /// <summary>
        /// 时间选择
        /// </summary>
        [Column(ColumnName = "F_time")]
        public string F_time { get; set; }
        /// <summary>
        /// 时间范围
        /// </summary>
        [Column(ColumnName = "F_time2")]
        public string F_time2 { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Column(ColumnName = "F_date")]
        public DateTime? F_date { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        [Column(ColumnName = "F_file")]
        public string F_file { get; set; }
        /// <summary>
        /// 图片上传
        /// </summary>
        [Column(ColumnName = "F_img")]
        public string F_img { get; set; }
        /// <summary>
        /// guid
        /// </summary>
        [Column(ColumnName = "F_guid")]
        public string F_guid { get; set; }
        /// <summary>
        /// 公司选择
        /// </summary>
        [Column(ColumnName = "F_company")]
        public string F_company { get; set; }
        /// <summary>
        /// 部门选择
        /// </summary>
        [Column(ColumnName = "F_department")]
        public string F_department { get; set; }
        /// <summary>
        /// 用户选择
        /// </summary>
        [Column(ColumnName = "F_user")]
        public string F_user { get; set; }
        /// <summary>
        /// 当前公司
        /// </summary>
        [Column(ColumnName = "F_ccompany")]
        public string F_ccompany { get; set; }
        /// <summary>
        /// 当前部门
        /// </summary>
        [Column(ColumnName = "F_cdepartment")]
        public string F_cdepartment { get; set; }
        /// <summary>
        /// 当前用户
        /// </summary>
        [Column(ColumnName = "F_cuser")]
        public string F_cuser { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        [Column(ColumnName = "F_cdate")]
        public DateTime? F_cdate { get; set; }
        /// <summary>
        /// 修改人员
        /// </summary>
        [Column(ColumnName = "F_muser")]
        public string F_muser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(ColumnName = "F_mdate")]
        public DateTime? F_mdate { get; set; }
        /// <summary>
        /// 单据编码
        /// </summary>
        [Column(ColumnName = "F_code")]
        public string F_code { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Column(ColumnName = "F_icon")]
        public string F_icon { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        [Column(ColumnName = "F_rate")]
        public int? F_rate { get; set; }
        /// <summary>
        /// 开关
        /// </summary>
        [Column(ColumnName = "F_swtich")]
        public int? F_swtich { get; set; }
        /// <summary>
        /// 滑块
        /// </summary>
        [Column(ColumnName = "F_swtich2")]
        public int? F_swtich2 { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        [Column(ColumnName = "F_color")]
        public string F_color { get; set; }
        /// <summary>
        /// 弹窗选择
        /// </summary>
        [Column(ColumnName = "F_layerSelect")]
        public string F_layerSelect { get; set; }
        /// <summary>
        /// 日期范围
        /// </summary>
        [Column(ColumnName = "F_daterange")]
        public string F_daterange { get; set; }
        /// <summary>
        /// 省市区选择
        /// </summary>
        [Column(ColumnName = "F_areaSelect")]
        public string F_areaSelect { get; set; }
        /// <summary>
        /// 地图选择
        /// </summary>
        [Column(ColumnName = "F_map")]
        public string F_map { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        [Column(ColumnName = "F_TenantId")]
        public string F_TenantId { get; set; }
        /// <summary>
        /// Xxxx
        /// </summary>
        [Column(ColumnName = "Xxxx")]
        public string Xxxx { get; set; }
        /// <summary>
        /// 删除标记(0正常，1删除)
        /// </summary>
        [Column(ColumnName = "F_DeleteMark")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Column(ColumnName = "F_CreateDate")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户id
        /// </summary>
        [Column(ColumnName = "F_CreateUserId")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        [Column(ColumnName = "F_CreateUserName")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column(ColumnName = "F_ModifyDate")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户id
        /// </summary>
        [Column(ColumnName = "F_ModifyUserId")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户名称
        /// </summary>
        [Column(ColumnName = "F_ModifyUserName")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 单行文本
        /// </summary>
        [Column(ColumnName = "field16934719940")]
        public string Field16934719940 { get; set; }
        /// <summary>
        /// 下拉选择
        /// </summary>
        [Column(ColumnName = "field16934719941")]
        public string Field16934719941 { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 日期(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_dateQRange { get; set; }
        /// <summary>
        /// 当前时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_cdateQRange { get; set; }
        /// <summary>
        /// 修改时间(时间查询范围)
        /// </summary>
        [Column(IsIgnore = true)]
        public string F_mdateQRange { get; set; }
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