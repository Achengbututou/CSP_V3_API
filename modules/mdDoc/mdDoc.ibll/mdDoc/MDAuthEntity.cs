using learun.database;

namespace MDDoc.ibll
{
    /// <summary>
    /// MD文档
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-10-21 16:06
    /// 描 述：md_auth(MD文档权限)表的实体
    /// </summary>
    [MyTable("md_auth")]
    public class MDAuthEntity
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
        /// 只读权限
        /// </summary>
        public bool readAuth { get; set; }

        /// <summary>
        /// 编辑权限
        /// </summary>
        public bool editAuth { get; set; }

        /// <summary>
        /// 对应授权人id
        /// </summary>
        public string ObjId {  get; set; }
        /// <summary>
        /// 对应授权人名称
        /// </summary>
        public string ObjName {  get; set; }
        /// <summary>
        /// 对应授权人的类别，比如角色，用户等
        /// </summary>
        public int ObjType { get; set; }

        #endregion

        #region 扩展属性

        #endregion
    }
}