using ce.autofac.extension;
using learun.iapplication;
using learun.util;
using oa.ibll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oa.bll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：新闻管理
    /// </summary>
    public class NewsBLL :BLLBase, INewsBLL, BLL
    {

        private readonly NewsService newsService = new NewsService();

        #region 获取数据
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public Task<IEnumerable<NewsEntity>> GetPageList(Pagination pagination,string keyword)
        {
            return newsService.GetPageList(pagination, keyword);
        }
        /// <summary>
        /// 新闻公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<NewsEntity> GetEntity(string keyValue)
        {
            return newsService.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task DeleteEntity(string keyValue)
        {
            await newsService.DeleteEntity(keyValue);
        }
        /// <summary>
        /// 保存（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻公告实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, NewsEntity newsEntity)
        {
            await newsService.SaveEntity(keyValue, newsEntity);
        }
        #endregion
    }
}
