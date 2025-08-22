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
    /// 日 期： 2022-12-05 16:13:41
    /// 描 述： 供应商供货清单
    /// </summary>
    public class SupplymaterialController : BaseApiController
    {
        private readonly ICaseErpSupplymaterialBLL _iCaseErpSupplymaterialBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplymaterialBLL">供应商供货清单【case_erp_supplymaterial】接口</param>
        public SupplymaterialController(ICaseErpSupplymaterialBLL iCaseErpSupplymaterialBLL)
        {
            _iCaseErpSupplymaterialBLL = iCaseErpSupplymaterialBLL ?? throw new ArgumentNullException(nameof(iCaseErpSupplymaterialBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取供应商供货清单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplymaterials")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSupplymaterialEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpSupplymaterialEntity queryParams)
        {
            var list = await _iCaseErpSupplymaterialBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取供应商供货清单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplymaterial/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSupplymaterialEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpSupplymaterialEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSupplymaterialBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/supplymaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplymaterialEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpSupplymaterialBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/supplymaterial")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplymaterialEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpSupplymaterialEntity dto)
        {
            await _iCaseErpSupplymaterialBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/supplymaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpSupplymaterialEntity dto)
        {
            await _iCaseErpSupplymaterialBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除供应商供货清单【case_erp_supplymaterial】case_erp_supplymaterial数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplymaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpSupplymaterialBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除供应商供货清单【case_erp_supplymaterial】case_erp_supplymaterial数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplymaterial/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpSupplymaterialBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion       
    }
}