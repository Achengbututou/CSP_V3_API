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
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:09:49
    /// 描 述： 供应商信息
    /// </summary>
    public class SupplierController : BaseApiController
    {
        private readonly ICaseErpSupplierBLL _iCaseErpSupplierBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplierBLL">供应商信息【case_erp_supplier】接口</param>
        public SupplierController(ICaseErpSupplierBLL iCaseErpSupplierBLL)
        {
            _iCaseErpSupplierBLL = iCaseErpSupplierBLL?? throw new ArgumentNullException(nameof(iCaseErpSupplierBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取供应商信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/suppliers")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSupplierEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpSupplierEntity queryParams)
        {
            var list = await _iCaseErpSupplierBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取供应商信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplier/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSupplierEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpSupplierEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSupplierBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/supplier/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpSupplierBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/supplier")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpSupplierEntity dto)
        {
            await _iCaseErpSupplierBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/supplier/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpSupplierEntity dto)
        {
            await _iCaseErpSupplierBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 删除供应商信息【case_erp_supplier】case_erp_supplier数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplier/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpSupplierBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除供应商信息【case_erp_supplier】case_erp_supplier数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplier/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpSupplierBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion       
    }
}