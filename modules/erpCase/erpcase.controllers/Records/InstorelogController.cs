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
    /// 日 期： 2022-12-02 15:33:00
    /// 描 述： 入库记录
    /// </summary>
    public class InstorelogController : BaseApiController
    {
        private readonly ICaseErpInstorelogBLL _iCaseErpInstorelogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpInstorelogBLL">入库记录【case_erp_instorelog】接口</param>
        public InstorelogController(ICaseErpInstorelogBLL iCaseErpInstorelogBLL)
        {
            _iCaseErpInstorelogBLL = iCaseErpInstorelogBLL?? throw new ArgumentNullException(nameof(iCaseErpInstorelogBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取入库记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpcase/instorelogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpInstorelogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpInstorelogEntity queryParams)
        {
            var list = await _iCaseErpInstorelogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取入库记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpcase/instorelogs/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpInstorelogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpInstorelogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpInstorelogBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpcase/instorelogs/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInstorelogEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpInstorelogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpcase/instorelogs/caseErpInstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInstorelogEntity>), 200)]
        public async Task<IActionResult>GetCaseErpInstorelogEntity(string id)
        {
            var data = await _iCaseErpInstorelogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpcase/instorelogs")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInstorelogEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpInstorelogEntity dto)
        {
            await _iCaseErpInstorelogBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpcase/instorelogs/caseErpInstorelog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpInstorelogEntity>), 200)]
        public async Task<IActionResult>AddCaseErpInstorelog(CaseErpInstorelogEntity entity)
        {
            await _iCaseErpInstorelogBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpcase/instorelogs/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpInstorelogEntity dto)
        {
            await _iCaseErpInstorelogBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpcase/instorelogs/caseErpInstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpInstorelog(string id,CaseErpInstorelogEntity entity)
        {
            await _iCaseErpInstorelogBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpcase/instorelogs/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpInstorelogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpcase/instorelog/caseErpInstorelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpInstorelog(string id)
        {
            await _iCaseErpInstorelogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpcase/instorelogs/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpInstorelogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除入库记录【case_erp_instorelog】case_erp_instorelog数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpcase/instorelog/caseErpInstorelog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpInstorelogs(string ids)
        {
            await _iCaseErpInstorelogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}