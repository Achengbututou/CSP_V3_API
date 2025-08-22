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
    /// 日 期： 2022-12-16 13:53:00
    /// 描 述： 仓库管理
    /// </summary>
    public class WarehouselogController : BaseApiController
    {
        private readonly ICaseErpWarehouselogBLL _iCaseErpWarehouselogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpWarehouselogBLL">仓库管理【case_erp_warehouselog】接口</param>
        public WarehouselogController(ICaseErpWarehouselogBLL iCaseErpWarehouselogBLL)
        {
            _iCaseErpWarehouselogBLL = iCaseErpWarehouselogBLL ?? throw new ArgumentNullException(nameof(iCaseErpWarehouselogBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取仓库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/warehouselogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpWarehouselogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpWarehouselogEntity queryParams)
        {
            var list = await _iCaseErpWarehouselogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取仓库管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/warehouselog/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpWarehouselogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpWarehouselogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpWarehouselogBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/warehouselog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpWarehouselogEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpWarehouselogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/warehouselog/caseErpWarehouselog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpWarehouselogEntity>), 200)]
        public async Task<IActionResult> GetCaseErpWarehouselogEntity(string id)
        {
            var data = await _iCaseErpWarehouselogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/warehouselog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpWarehouselogEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpWarehouselogEntity dto)
        {
            await _iCaseErpWarehouselogBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/warehouselog/caseErpWarehouselog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpWarehouselogEntity>), 200)]
        public async Task<IActionResult> AddCaseErpWarehouselog(CaseErpWarehouselogEntity entity)
        {
            await _iCaseErpWarehouselogBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/warehouselog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpWarehouselogEntity dto)
        {
            await _iCaseErpWarehouselogBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/warehouselog/caseErpWarehouselog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpWarehouselog(string id, CaseErpWarehouselogEntity entity)
        {
            await _iCaseErpWarehouselogBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/warehouselog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpWarehouselogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/warehouselog/caseErpWarehouselog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpWarehouselog(string id)
        {
            await _iCaseErpWarehouselogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/warehouselog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpWarehouselogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除仓库管理【case_erp_warehouselog】case_erp_warehouselog数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/warehouselog/caseErpWarehouselog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpWarehouselogs(string ids)
        {
            await _iCaseErpWarehouselogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}