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
    /// 日 期： 2023-08-18 16:15:01
    /// 描 述： 报工
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessReportController : BaseApiController
    {
        private readonly IMesProcessReportBLL _iMesProcessReportBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessReportBLL">工序报工接口</param>
        public ProcessReportController(IMesProcessReportBLL iMesProcessReportBLL)
        {
            _iMesProcessReportBLL = iMesProcessReportBLL?? throw new ArgumentNullException(nameof(iMesProcessReportBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取报工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessReportEntity queryParams)
        {
            var list = await _iMesProcessReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取报工的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/processReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessReportEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProcessReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取报工的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processReport/GetProcessReportList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessReportEntity>>), 200)]
        public async Task<IActionResult> GetProcessReportList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProcessReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessReportBLL.GetProcessReportList(pagination, queryParams);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/processReport")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessReportEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProcessReportEntity entity)
        {
            await _iMesProcessReportBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/processReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProcessReportEntity entity)
        {
            await _iMesProcessReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工序报工mes_ProcessReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessReportBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序报工mes_ProcessReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessReportBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}