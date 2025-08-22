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
    /// 日 期： 2022-11-28 17:03:09
    /// 描 述： 设备告警
    /// </summary>
    public class DevicewarnController : BaseApiController
    {
        private readonly ICaseErpDevicewarnBLL _iCaseErpDevicewarnBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpDevicewarnBLL">设备告警【case_erp_devicewarn】接口</param>
        public DevicewarnController(ICaseErpDevicewarnBLL iCaseErpDevicewarnBLL)
        {
            _iCaseErpDevicewarnBLL = iCaseErpDevicewarnBLL ?? throw new ArgumentNullException(nameof(iCaseErpDevicewarnBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取设备告警的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/devicewarns")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpDevicewarnEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpDevicewarnEntity queryParams)
        {
            var list = await _iCaseErpDevicewarnBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取设备告警的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/devicewarn/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpDevicewarnEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpDevicewarnEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpDevicewarnBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/devicewarn/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDevicewarnEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpDevicewarnBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/devicewarn/caseErpDevicewarn/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDevicewarnEntity>), 200)]
        public async Task<IActionResult> GetCaseErpDevicewarnEntity(string id)
        {
            var data = await _iCaseErpDevicewarnBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/devicewarn")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDevicewarnEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpDevicewarnEntity dto)
        {
            await _iCaseErpDevicewarnBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/devicewarn/caseErpDevicewarn")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDevicewarnEntity>), 200)]
        public async Task<IActionResult> AddCaseErpDevicewarn(CaseErpDevicewarnEntity entity)
        {
            await _iCaseErpDevicewarnBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/devicewarn/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpDevicewarnEntity dto)
        {
            await _iCaseErpDevicewarnBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/devicewarn/caseErpDevicewarn/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpDevicewarn(string id, CaseErpDevicewarnEntity entity)
        {
            await _iCaseErpDevicewarnBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/devicewarn/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpDevicewarnBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/devicewarn/caseErpDevicewarn/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpDevicewarn(string id)
        {
            await _iCaseErpDevicewarnBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/devicewarn/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpDevicewarnBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除设备告警【case_erp_devicewarn】case_erp_devicewarn数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/devicewarn/caseErpDevicewarn/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpDevicewarns(string ids)
        {
            await _iCaseErpDevicewarnBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 设备告警列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        [HttpPost("erpCase/devicewarns/export")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GetExportList(BatchModel export)
        {
            var id = await _iCaseErpDevicewarnBLL.GetExportList(export.Ids);
            return Success(id);
        }
        #endregion
    }
}