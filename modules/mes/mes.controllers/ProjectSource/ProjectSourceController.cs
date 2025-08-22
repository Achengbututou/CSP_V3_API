using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;

namespace mes.controllers
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-01 16:14:55
    /// 描 述： 项目来源
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProjectSourceController : BaseApiController
    {
        private readonly IMesProjectSourceBLL _iMesProjectSourceBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProjectSourceBLL">项目来源接口</param>
        public ProjectSourceController(IMesProjectSourceBLL iMesProjectSourceBLL)
        {
            _iMesProjectSourceBLL = iMesProjectSourceBLL?? throw new ArgumentNullException(nameof(iMesProjectSourceBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取项目来源的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectSources")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProjectSourceEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProjectSourceEntity queryParams)
        {
            var list = await _iMesProjectSourceBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取项目来源的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectSource/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProjectSourceEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProjectSourceEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProjectSourceBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/projectSource/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectSourceEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProjectSourceBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/projectSource")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectSourceEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProjectSourceEntity entity)
        {
            await _iMesProjectSourceBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/projectSource/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProjectSourceEntity entity)
        {
            await _iMesProjectSourceBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除项目来源mes_ProjectSource数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectSource/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProjectSourceBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除项目来源mes_ProjectSource数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectSource/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProjectSourceBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}