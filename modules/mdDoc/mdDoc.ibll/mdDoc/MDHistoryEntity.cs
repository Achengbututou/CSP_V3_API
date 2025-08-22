using learun.database;
using System;

namespace MDDoc.ibll
{
    /// <summary>
    /// MD文档
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-10-21 16:06
    /// 描 述：md_history(MD文档历史记录)表的实体
    /// </summary>
    [MyTable("md_history")]
    public class MDHistoryEntity
    {
        #region 实体成员
        /// <summary>
        /// RID
        /// </summary>
        [Column(IsPrimary = true)]
        public string RID { get; set; }
        /// <summary>
        /// 对应的md文档rid
        /// </summary>
        public string Md_document_Rid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate {  get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserID {  get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 文档内容
        /// </summary>
        public string DocumentData { get; set; }

        #endregion

        #region 扩展属性

        #endregion
    }
}