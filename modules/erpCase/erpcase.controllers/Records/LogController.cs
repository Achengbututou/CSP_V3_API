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
    /// 日 期： 2022-12-05 09:24:18
    /// 描 述： 操作记录
    /// </summary>
    public class LogController : BaseApiController
    {
        private readonly ICaseErpLogBLL _iCaseErpLogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpLogBLL">操作记录【case_erp_log】接口</param>
        public LogController(ICaseErpLogBLL iCaseErpLogBLL)
        {
            _iCaseErpLogBLL = iCaseErpLogBLL?? throw new ArgumentNullException(nameof(iCaseErpLogBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取操作记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/logs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpLogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpLogEntity queryParams)
        {
            var list = await _iCaseErpLogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取操作记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/log/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpLogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpLogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpLogBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/log/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpLogEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpLogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/log/caseErpLog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpLogEntity>), 200)]
        public async Task<IActionResult>GetCaseErpLogEntity(string id)
        {
            var data = await _iCaseErpLogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/log")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpLogEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpLogEntity dto)
        {
            await _iCaseErpLogBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/log/caseErpLog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpLogEntity>), 200)]
        public async Task<IActionResult>AddCaseErpLog(CaseErpLogEntity entity)
        {
            await _iCaseErpLogBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/log/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpLogEntity dto)
        {
            await _iCaseErpLogBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/log/caseErpLog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpLog(string id,CaseErpLogEntity entity)
        {
            await _iCaseErpLogBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/log/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpLogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/log/caseErpLog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpLog(string id)
        {
            await _iCaseErpLogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/log/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpLogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除操作记录【case_erp_log】case_erp_log数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/log/caseErpLog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpLogs(string ids)
        {
            await _iCaseErpLogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}