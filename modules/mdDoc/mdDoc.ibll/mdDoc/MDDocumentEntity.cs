using learun.database;
using System;

namespace MDDoc.ibll
{
    /// <summary>
    /// MD文档
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-10-21 16:06
    /// 描 述：md_document(MD文档)表的实体
    /// </summary>
    [MyTable("md_document")]
    public class MDDocumentEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 对应历史文档
        /// </summary>
        public string Md_history_rid {  get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool EnabledMark { get; set; }

        #endregion

        #region 扩展属性
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(IsIgnore = true)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(IsIgnore = true)]
        public string CreateUserID { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 文档内容
        /// </summary>
        [Column(IsIgnore = true)]
        public string DocumentData { get; set; }

        /// <summary>
        /// 是否有编辑权限
        /// </summary>
        [Column (IsIgnore = true)]
        public bool isEdit { get; set; }
        #endregion
    }
}