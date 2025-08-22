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
    /// 日 期： 2023-07-31 16:01:14
    /// 描 述： 库位信息
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class LibraryLocationController : BaseApiController
    {
        private readonly IMesLibraryLocationBLL _iMesLibraryLocationBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesLibraryLocationBLL">库位信息维护接口</param>
        public LibraryLocationController(IMesLibraryLocationBLL iMesLibraryLocationBLL)
        {
            _iMesLibraryLocationBLL = iMesLibraryLocationBLL?? throw new ArgumentNullException(nameof(iMesLibraryLocationBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取库位信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/libraryLocations")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesLibraryLocationEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesLibraryLocationEntity queryParams)
        {
            var list = await _iMesLibraryLocationBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取库位信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/libraryLocation/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesLibraryLocationEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesLibraryLocationEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesLibraryLocationBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/libraryLocation/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesLibraryLocationEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesLibraryLocationBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/libraryLocation")]
        [ProducesResponseType(typeof(ResponseDto<MesLibraryLocationEntity>), 200)]
        public async Task<IActionResult>AddForm(MesLibraryLocationEntity entity)
        {
            await _iMesLibraryLocationBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/libraryLocation/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesLibraryLocationEntity entity)
        {
            await _iMesLibraryLocationBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除库位信息维护mes_LibraryLocation数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/libraryLocation/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesLibraryLocationBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除库位信息维护mes_LibraryLocation数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/libraryLocation/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesLibraryLocationBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}