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
    /// 日 期： 2022-12-05 09:07:38
    /// 描 述： 出库记录
    /// </summary>
    public class OutstorelogController : BaseApiController
    {
        private readonly ICaseErpOutstorelogBLL _iCaseErpOutstorelogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpOutstorelogBLL">出库记录【case_erp_outstorelog】接口</param>
        public OutstorelogController(ICaseErpOutstorelogBLL iCaseErpOutstorelogBLL)
        {
            _iCaseErpOutstorelogBLL = iCaseErpOutstorelogBLL?? throw new ArgumentNullException(nameof(iCaseErpOutstorelogBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取出库记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/outstorelogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpOutstorelogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpOutstorelogEntity queryParams)
        {
            var list = await _iCaseErpOutstorelogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取出库记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/outstorelog/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpOutstorelogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpOutstorelogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpOutstorelogBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/outstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpOutstorelogEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpOutstorelogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/outstorelog/caseErpOutstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpOutstorelogEntity>), 200)]
        public async Task<IActionResult>GetCaseErpOutstorelogEntity(string id)
        {
            var data = await _iCaseErpOutstorelogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/outstorelog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpOutstorelogEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpOutstorelogEntity dto)
        {
            await _iCaseErpOutstorelogBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/outstorelog/caseErpOutstorelog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpOutstorelogEntity>), 200)]
        public async Task<IActionResult>AddCaseErpOutstorelog(CaseErpOutstorelogEntity entity)
        {
            await _iCaseErpOutstorelogBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/outstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpOutstorelogEntity dto)
        {
            await _iCaseErpOutstorelogBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/outstorelog/caseErpOutstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpOutstorelog(string id,CaseErpOutstorelogEntity entity)
        {
            await _iCaseErpOutstorelogBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/outstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpOutstorelogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/outstorelog/caseErpOutstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpOutstorelog(string id)
        {
            await _iCaseErpOutstorelogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/outstorelog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpOutstorelogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除出库记录【case_erp_outstorelog】case_erp_outstorelog数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/outstorelog/caseErpOutstorelog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpOutstorelogs(string ids)
        {
            await _iCaseErpOutstorelogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}