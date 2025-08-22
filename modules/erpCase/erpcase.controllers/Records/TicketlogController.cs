using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;

namespace erpCase.controllers
{
    /// <summary>
    /// 框架dev-慢慢-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：慢慢
    /// 日 期： 2022-12-05 08:27:38
    /// 描 述： 到票记录
    /// </summary>
    public class TicketlogController : BaseApiController
    {
        private readonly ICaseErpTicketlogBLL _iCaseErpTicketlogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpTicketlogBLL">到票记录【case_erp_ticketlog】接口</param>
        public TicketlogController(ICaseErpTicketlogBLL iCaseErpTicketlogBLL)
        {
            _iCaseErpTicketlogBLL = iCaseErpTicketlogBLL?? throw new ArgumentNullException(nameof(iCaseErpTicketlogBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取到票记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/ticketlogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpTicketlogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpTicketlogEntity queryParams)
        {
            var list = await _iCaseErpTicketlogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取到票记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/ticketlog/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpTicketlogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpTicketlogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpTicketlogBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/ticketlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpTicketlogEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpTicketlogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/ticketlog/caseErpTicketlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpTicketlogEntity>), 200)]
        public async Task<IActionResult>GetCaseErpTicketlogEntity(string id)
        {
            var data = await _iCaseErpTicketlogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/ticketlog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpTicketlogEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpTicketlogEntity dto)
        {
            await _iCaseErpTicketlogBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/ticketlog/caseErpTicketlog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpTicketlogEntity>), 200)]
        public async Task<IActionResult>AddCaseErpTicketlog(CaseErpTicketlogEntity entity)
        {
            await _iCaseErpTicketlogBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/ticketlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpTicketlogEntity dto)
        {
            await _iCaseErpTicketlogBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/ticketlog/caseErpTicketlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpTicketlog(string id,CaseErpTicketlogEntity entity)
        {
            await _iCaseErpTicketlogBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/ticketlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpTicketlogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/ticketlog/caseErpTicketlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpTicketlog(string id)
        {
            await _iCaseErpTicketlogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/ticketlog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpTicketlogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除到票记录【case_erp_ticketlog】case_erp_ticketlog数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/ticketlog/caseErpTicketlog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpTicketlogs(string ids)
        {
            await _iCaseErpTicketlogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}