using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using oa.ibll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace learun.webapp.Areas.LR_OAModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS-Core 力软敏捷开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：新闻管理
    /// </summary>
    public class NewsController : BaseApiController
    {
        private readonly INewsBLL _iNewsBLL;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="inewsBLL"></param>
        public NewsController(INewsBLL inewsBLL) {
            _iNewsBLL = inewsBLL;
        }

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        [HttpGet("oa/news/page")]
        [ProducesResponseType(typeof(ResponseDto<PaginationOutputDto<IEnumerable<NewsEntity>>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, string keyword)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var data = await _iNewsBLL.GetPageList(pagination, keyword);
            var jsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("oa/news/{id}")]
        [ProducesResponseType(typeof(ResponseDto<NewsEntity>), 200)]
        public async Task<IActionResult> GetEntity(string id)
        {
            var data =await _iNewsBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost("oa/news")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Add(NewsEntity entity)
        {
            await _iNewsBLL.SaveEntity(string.Empty, entity);
            return SuccessInfo("保存成功！");
        }
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPut("oa/news/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Update(string id, NewsEntity entity)
        {
            await _iNewsBLL.SaveEntity(id, entity);
            return SuccessInfo("保存成功！");
        }

        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("oa/news/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iNewsBLL.DeleteEntity(id);
            return SuccessInfo("删除成功！");
        }
        #endregion
    }
}