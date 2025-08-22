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
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-28 17:02:41
    /// 描 述： 运维巡检
    /// </summary>
    public class DeviceinspectController : BaseApiController
    {
        private readonly ICaseErpDeviceinspectBLL _iCaseErpDeviceinspectBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpDeviceinspectBLL">运维巡检【case_erp_deviceinspect】接口</param>
        public DeviceinspectController(ICaseErpDeviceinspectBLL iCaseErpDeviceinspectBLL)
        {
            _iCaseErpDeviceinspectBLL = iCaseErpDeviceinspectBLL ?? throw new ArgumentNullException(nameof(iCaseErpDeviceinspectBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取运维巡检的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/deviceinspects")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpDeviceinspectEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpDeviceinspectEntity queryParams)
        {
            var list = await _iCaseErpDeviceinspectBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取运维巡检的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/deviceinspect/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpDeviceinspectEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpDeviceinspectEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpDeviceinspectBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/deviceinspect/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinspectEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpDeviceinspectBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/deviceinspect/caseErpDeviceinspect/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinspectEntity>), 200)]
        public async Task<IActionResult> GetCaseErpDeviceinspectEntity(string id)
        {
            var data = await _iCaseErpDeviceinspectBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/deviceinspect")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinspectEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpDeviceinspectEntity dto)
        {
            await _iCaseErpDeviceinspectBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/deviceinspect/caseErpDeviceinspect")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinspectEntity>), 200)]
        public async Task<IActionResult> AddCaseErpDeviceinspect(CaseErpDeviceinspectEntity entity)
        {
            await _iCaseErpDeviceinspectBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/deviceinspect/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpDeviceinspectEntity dto)
        {
            await _iCaseErpDeviceinspectBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/deviceinspect/caseErpDeviceinspect/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpDeviceinspect(string id, CaseErpDeviceinspectEntity entity)
        {
            await _iCaseErpDeviceinspectBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinspect/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpDeviceinspectBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinspect/caseErpDeviceinspect/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpDeviceinspect(string id)
        {
            await _iCaseErpDeviceinspectBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinspect/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpDeviceinspectBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除运维巡检【case_erp_deviceinspect】case_erp_deviceinspect数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinspect/caseErpDeviceinspect/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpDeviceinspects(string ids)
        {
            await _iCaseErpDeviceinspectBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 运维巡检列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        [HttpPost("erpCase/deviceinspect/export")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GetExportList(BatchModel export)
        {
            var id = await _iCaseErpDeviceinspectBLL.GetExportList(export.Ids);
            return Success(id);
        }
        #endregion
    }
}