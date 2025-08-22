using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MDDoc.ibll;
using ce.autofac.extension;

namespace MDDoc.controllers
{
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：undefined
    /// 日 期： 2024-07-24 16:39:53
    /// 描 述： 测试代码生成
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class MDDocController : BaseApiController
    {
        private readonly IMDDocumentBLL _iMDDocumentBLL;
        private readonly IMDHistoryBLL _iMDHistoryBLL;
        private readonly IMDAuthBLL _iMDAuthBLL;
        ///// <summary>
        ///// 构造方法
        ///// </summary>
        ///// <param name="iMDDocumentBLL">MD文档接口</param>
        ///// <param name="iMDHistoryBLL">MD历史记录</param>
        ///// <param name="iMDAuthBLL">MD权限</param>
        //public MDDocController(IMDDocumentBLL iMDDocumentBLL, IMDHistoryBLL iMDHistoryBLL, IMDAuthBLL iMDAuthBLL)
        //{
        //    _iMDDocumentBLL = iMDDocumentBLL ?? throw new ArgumentNullException(nameof(iMDDocumentBLL));
        //    _iMDHistoryBLL = iMDHistoryBLL ?? throw new ArgumentNullException(nameof(iMDHistoryBLL));
        //    _iMDAuthBLL = iMDAuthBLL ?? throw new ArgumentNullException(nameof(iMDHistoryBLL));
        //}

        /// <summary>
        /// 构造方法
        /// </summary>
        public MDDocController()
        {
            _iMDDocumentBLL = IocManager.Instance.GetService<IMDDocumentBLL>();
            _iMDHistoryBLL = IocManager.Instance.GetService<IMDHistoryBLL>();
            _iMDAuthBLL = IocManager.Instance.GetService<IMDAuthBLL>();
        }


        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mdDoc/mdDoc/mdDocs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MDDocumentEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] MDDocumentEntity queryParams)
        {
            var list = await _iMDDocumentBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mdDoc/mdDoc/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MDDocumentEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MDDocumentEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMDDocumentBLL.GetPageList(pagination, queryParams);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="id">查询参数</param>
        /// <returns></returns>
        [HttpGet("mdDoc/history/page/{id}")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MDDocumentEntity>>), 200)]
        public async Task<IActionResult> GetHistoryPageList([FromQuery] PaginationInputDto paginationInputDto, string id)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMDHistoryBLL.GetPageList(pagination, id);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取权限列表数据
        /// </summary>
        /// <param name="id">查询参数</param>
        /// <returns></returns>
        [HttpGet("mdDoc/mdDoc/auths/{id}")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MDAuthEntity>>), 200)]
        public async Task<IActionResult> GetAuthList(string id)
        {
            var list = await _iMDAuthBLL.GetList(id);
            return Success(list);
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mdDoc/mdDoc/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MDDocumentEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            MDDocumentEntity mDDocumentEntity = await _iMDDocumentBLL.GetEntity(id);
            return Success(mDDocumentEntity);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mdDoc/mdDoc")]
        [ProducesResponseType(typeof(ResponseDto<MDDocumentEntity>), 200)]
        public async Task<IActionResult> AddMDDocument(MDDocumentEntity entity)
        {
            await _iMDDocumentBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mdDoc/mdDoc/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateMDDocument(string id, MDDocumentEntity entity)
        {
            await _iMDDocumentBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mdDoc/mdDoc/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteMDDocument(string id)
        {
            await _iMDDocumentBLL.Delete(id);
            return Success("删除成功！");
        }

        /// <summary>
        /// 批量数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mdDoc/mdDoc/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteMDDocuments(string ids)
        {
            await _iMDDocumentBLL.Deletes(ids);
            return Success("删除成功！");
        }

        /// <summary>
        /// 更新历史版本
        /// </summary>
        /// <param name="id">信息主键</param>
        /// <param name="historyId">模板主键</param>
        /// <returns></returns>
        [HttpPut("mdDoc/mdDoc/checkHistory/{id}/{historyId}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateHistory(string id, string historyId)
        {
            await _iMDDocumentBLL.UpdateHistory(id, historyId);
            return SuccessInfo("更新成功！");
        }
        //IEnumerable<FHISLeaveDetailEntity>

        /// <summary>
        /// 保存历史数据
        /// </summary>
        /// <param name="id">信息主键</param>
        /// <param name="list">模板主键</param>
        /// <returns></returns>
        [HttpPut("mdDoc/mdDoc/saveAuths/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> SaveAuthList(string id, IEnumerable<MDAuthEntity> list)
        {
            await _iMDAuthBLL.SaveList(id, list);
            return Success("更新成功！");
        }


        #endregion
    }
}