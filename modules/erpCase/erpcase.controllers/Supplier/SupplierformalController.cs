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
    /// 日 期： 2022-12-05 16:28:11
    /// 描 述： 供应商转正申请
    /// </summary>
    public class SupplierformalController : BaseApiController
    {
        private readonly ICaseErpSupplierformalBLL _iCaseErpSupplierformalBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplierformalBLL">供应商转正申请【case_erp_supplierformal】接口</param>
        public SupplierformalController(ICaseErpSupplierformalBLL iCaseErpSupplierformalBLL)
        {
            _iCaseErpSupplierformalBLL = iCaseErpSupplierformalBLL ?? throw new ArgumentNullException(nameof(iCaseErpSupplierformalBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取供应商转正申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierformals")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSupplierformalEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpSupplierformalEntity queryParams)
        {
            var list = await _iCaseErpSupplierformalBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取供应商转正申请的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierformal/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSupplierformalEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpSupplierformalEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSupplierformalBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/supplierformal/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierformalEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpSupplierformalBLL.GetEntity(id);
            return Success(data);
        }
        
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">供应商主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierformal/bysupplier/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierformalEntity>), 200)]
        public async Task<IActionResult> GetEntity(string id)
        {
            var data = await _iCaseErpSupplierformalBLL.GetEntityBySupplierId(id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/supplierformal")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierformalEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpSupplierformalEntity dto)
        {
            await _iCaseErpSupplierformalBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/supplierformal/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpSupplierformalEntity dto)
        {
            await _iCaseErpSupplierformalBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除供应商转正申请【case_erp_supplierformal】case_erp_supplierformal数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplierformal/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpSupplierformalBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除供应商转正申请【case_erp_supplierformal】case_erp_supplierformal数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplierformal/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpSupplierformalBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion       
    }
}