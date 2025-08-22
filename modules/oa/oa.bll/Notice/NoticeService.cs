using learun.iapplication;
using learun.util;
using oa.ibll;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oa.bll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：公告管理
    /// </summary>
    public class NoticeService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public Task<IEnumerable<NewsEntity>> GetPageList(Pagination pagination, string keyword)
        {
            var exp = Expressionable.Create<NewsEntity>();
            exp = exp.And(t => t.F_TypeId == 2);
            exp = exp.AndIF(!string.IsNullOrEmpty(keyword), t => t.F_FullHead.Contains(keyword));
            return this.BaseRepository().FindList<NewsEntity>(exp.ToExpression(), pagination);
        }
        /// <summary>
        /// 新闻公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<NewsEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<NewsEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task DeleteEntity(string keyValue)
        {
            await this.BaseRepository().Delete<NewsEntity>(keyValue);
        }
        /// <summary>
        /// 保存（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻公告实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, NewsEntity newsEntity)
        {
            newsEntity.F_TypeId = 2;
            if (!string.IsNullOrEmpty(keyValue))
            {
                newsEntity.F_NewsId = keyValue;
                newsEntity.F_ModifyDate = DateTime.Now;

                newsEntity.F_ModifyUserId = this.GetUserId();
                newsEntity.F_ModifyUserName = this.GetUserName();

                await this.BaseRepository().Update(newsEntity);
            }
            else
            {
                newsEntity.F_NewsId = Guid.NewGuid().ToString();
                newsEntity.F_CreateDate = DateTime.Now;
                newsEntity.F_ReleaseTime = DateTime.Now;
                newsEntity.F_DeleteMark = 0;
                newsEntity.F_EnabledMark = 1;
                newsEntity.F_PV = 0;

                newsEntity.F_CreateUserId = this.GetUserId();
                newsEntity.F_CreateUserName = this.GetUserName();

                await this.BaseRepository().Insert(newsEntity);
            }

        }
        #endregion
    }
}
