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
    /// 日 期： 2023-08-22 15:59:00
    /// 描 述： 标准文件
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class StandarDocumentController : BaseApiController
    {
        private readonly IMesStandarDocumentBLL _iMesStandarDocumentBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesStandarDocumentBLL">标准文件接口</param>
        public StandarDocumentController(IMesStandarDocumentBLL iMesStandarDocumentBLL)
        {
            _iMesStandarDocumentBLL = iMesStandarDocumentBLL?? throw new ArgumentNullException(nameof(iMesStandarDocumentBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取标准文件的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/standarDocuments")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesStandarDocumentEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesStandarDocumentEntity queryParams)
        {
            var list = await _iMesStandarDocumentBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取标准文件的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/standarDocument/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesStandarDocumentEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesStandarDocumentEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesStandarDocumentBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/standarDocument/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesStandarDocumentEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesStandarDocumentBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/standarDocument")]
        [ProducesResponseType(typeof(ResponseDto<MesStandarDocumentEntity>), 200)]
        public async Task<IActionResult>AddForm(MesStandarDocumentEntity entity)
        {
            await _iMesStandarDocumentBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/standarDocument/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesStandarDocumentEntity entity)
        {
            await _iMesStandarDocumentBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除标准文件mes_StandarDocument数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/standarDocument/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesStandarDocumentBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除标准文件mes_StandarDocument数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/standarDocument/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesStandarDocumentBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}