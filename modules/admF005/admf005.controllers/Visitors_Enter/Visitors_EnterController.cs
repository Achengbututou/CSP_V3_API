using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADMF005.ibll;
using ce.autofac.extension;

namespace ADMF005.controllers
{
    /// <summary>
    /// 访客申请-访客出入厂
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2024-05-03 16:04:51
    /// 描 述： Visitors_Enter
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class Visitors_EnterController : BaseApiController
    {
        private readonly IVisitorsEnterBLL _iVisitorsEnterBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        public Visitors_EnterController()
        {
            _iVisitorsEnterBLL = IocManager.Instance.GetService<IVisitorsEnterBLL>();
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取Visitors_Enter的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("admF005/visitors_Enters")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<VisitorsEnterEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]VisitorsEnterEntity queryParams)
        {
            var list = await _iVisitorsEnterBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取Visitors_Enter的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("admF005/visitors_Enter/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<VisitorsEnterEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]VisitorsEnterEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iVisitorsEnterBLL.GetPageList(pagination,queryParams);
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
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("admF005/visitors_Enter/{id}")]
        [ProducesResponseType(typeof(ResponseDto<VisitorsEnterEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iVisitorsEnterBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("admF005/visitors_Enter")]
        [ProducesResponseType(typeof(ResponseDto<VisitorsEnterEntity>), 200)]
        public async Task<IActionResult>AddForm(VisitorsEnterEntity entity)
        {
            await _iVisitorsEnterBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("admF005/visitors_Enter/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,VisitorsEnterEntity entity)
        {
            await _iVisitorsEnterBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除访客出入厂表Visitors_Enter数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("admF005/visitors_Enter/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iVisitorsEnterBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除访客出入厂表Visitors_Enter数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("admF005/visitors_Enter/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iVisitorsEnterBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}