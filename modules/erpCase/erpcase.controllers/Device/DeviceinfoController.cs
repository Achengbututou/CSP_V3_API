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
    /// 日 期： 2022-11-28 17:00:53
    /// 描 述： 设备信息
    /// </summary>
    public class DeviceinfoController : BaseApiController
    {
        private readonly ICaseErpDeviceinfoBLL _iCaseErpDeviceinfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpDeviceinfoBLL">设备信息【case_erp_deviceinfo】接口</param>
        public DeviceinfoController(ICaseErpDeviceinfoBLL iCaseErpDeviceinfoBLL)
        {
            _iCaseErpDeviceinfoBLL = iCaseErpDeviceinfoBLL ?? throw new ArgumentNullException(nameof(iCaseErpDeviceinfoBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取设备信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/deviceinfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpDeviceinfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpDeviceinfoEntity queryParams)
        {
            var list = await _iCaseErpDeviceinfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取设备信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/deviceinfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpDeviceinfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpDeviceinfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpDeviceinfoBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/deviceinfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinfoEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpDeviceinfoBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/deviceinfo/caseErpDeviceinfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinfoEntity>), 200)]
        public async Task<IActionResult> GetCaseErpDeviceinfoEntity(string id)
        {
            var data = await _iCaseErpDeviceinfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/deviceinfo")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinfoEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpDeviceinfoEntity dto)
        {
            await _iCaseErpDeviceinfoBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/deviceinfo/caseErpDeviceinfo")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpDeviceinfoEntity>), 200)]
        public async Task<IActionResult> AddCaseErpDeviceinfo(CaseErpDeviceinfoEntity entity)
        {
            await _iCaseErpDeviceinfoBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/deviceinfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpDeviceinfoEntity dto)
        {
            await _iCaseErpDeviceinfoBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/deviceinfo/caseErpDeviceinfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpDeviceinfo(string id, CaseErpDeviceinfoEntity entity)
        {
            await _iCaseErpDeviceinfoBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpDeviceinfoBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinfo/caseErpDeviceinfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpDeviceinfo(string id)
        {
            await _iCaseErpDeviceinfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpDeviceinfoBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除设备信息【case_erp_deviceinfo】case_erp_deviceinfo数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/deviceinfo/caseErpDeviceinfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpDeviceinfos(string ids)
        {
            await _iCaseErpDeviceinfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 设备信息列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        [HttpPost("erpCase/deviceinfos/export")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GetExportList(BatchModel export)
        {
            var id = await _iCaseErpDeviceinfoBLL.GetExportList(export.Ids);
            return Success(id);
        }
        #endregion
    }
}