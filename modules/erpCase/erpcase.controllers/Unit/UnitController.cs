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
    /// 日 期： 2022-12-05 16:53:20
    /// 描 述： 单位列表
    /// </summary>
    public class UnitController : BaseApiController
    {
        private readonly ICaseErpUnitBLL _iCaseErpUnitBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpUnitBLL">单位列表【case_erp_unit】接口</param>
        public UnitController(ICaseErpUnitBLL iCaseErpUnitBLL)
        {
            _iCaseErpUnitBLL = iCaseErpUnitBLL?? throw new ArgumentNullException(nameof(iCaseErpUnitBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取单位列表的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/units")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpUnitEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpUnitEntity queryParams)
        {
            var list = await _iCaseErpUnitBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取单位列表的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unit/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpUnitEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpUnitEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpUnitBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/unit/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpUnitBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/unit/caseErpUnit/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitEntity>), 200)]
        public async Task<IActionResult>GetCaseErpUnitEntity(string id)
        {
            var data = await _iCaseErpUnitBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unit")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpUnitEntity dto)
        {
            await _iCaseErpUnitBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unit/caseErpUnit")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitEntity>), 200)]
        public async Task<IActionResult>AddCaseErpUnit(CaseErpUnitEntity entity)
        {
            await _iCaseErpUnitBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/unit/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpUnitEntity dto)
        {
            await _iCaseErpUnitBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/unit/caseErpUnit/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpUnit(string id,CaseErpUnitEntity entity)
        {
            await _iCaseErpUnitBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unit/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpUnitBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unit/caseErpUnit/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpUnit(string id)
        {
            await _iCaseErpUnitBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unit/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpUnitBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除单位列表【case_erp_unit】case_erp_unit数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unit/caseErpUnit/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpUnits(string ids)
        {
            await _iCaseErpUnitBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}