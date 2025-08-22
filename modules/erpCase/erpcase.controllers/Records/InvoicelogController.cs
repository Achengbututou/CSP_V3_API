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
    /// 日 期： 2022-12-05 08:38:07
    /// 描 述： 开票记录
    /// </summary>
    public class InvoicelogController : BaseApiController
    {
        private readonly ICaseErpInvoicelogBLL _iCaseErpInvoicelogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpInvoicelogBLL">开票记录【case_erp_invoicelog】接口</param>
        public InvoicelogController(ICaseErpInvoicelogBLL iCaseErpInvoicelogBLL)
        {
            _iCaseErpInvoicelogBLL = iCaseErpInvoicelogBLL?? throw new ArgumentNullException(nameof(iCaseErpInvoicelogBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取开票记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/invoicelogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpInvoicelogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpInvoicelogEntity queryParams)
        {
            var list = await _iCaseErpInvoicelogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取开票记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/invoicelog/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpInvoicelogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpInvoicelogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpInvoicelogBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/invoicelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInvoicelogEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpInvoicelogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/invoicelog/caseErpInvoicelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInvoicelogEntity>), 200)]
        public async Task<IActionResult>GetCaseErpInvoicelogEntity(string id)
        {
            var data = await _iCaseErpInvoicelogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/invoicelog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInvoicelogEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpInvoicelogEntity dto)
        {
            await _iCaseErpInvoicelogBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/invoicelog/caseErpInvoicelog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInvoicelogEntity>), 200)]
        public async Task<IActionResult>AddCaseErpInvoicelog(CaseErpInvoicelogEntity entity)
        {
            await _iCaseErpInvoicelogBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">数据集合</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/invoicelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpInvoicelogEntity dto)
        {
            await _iCaseErpInvoicelogBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/invoicelog/caseErpInvoicelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpInvoicelog(string id,CaseErpInvoicelogEntity entity)
        {
            await _iCaseErpInvoicelogBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/invoicelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpInvoicelogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/invoicelog/caseErpInvoicelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpInvoicelog(string id)
        {
            await _iCaseErpInvoicelogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/invoicelog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpInvoicelogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除开票记录【case_erp_invoicelog】case_erp_invoicelog数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/invoicelog/caseErpInvoicelog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpInvoicelogs(string ids)
        {
            await _iCaseErpInvoicelogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}