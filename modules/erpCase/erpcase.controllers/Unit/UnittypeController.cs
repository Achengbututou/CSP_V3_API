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
    /// 日 期： 2022-12-05 16:53:55
    /// 描 述： 单位类型
    /// </summary>
    public class UnittypeController : BaseApiController
    {
        private readonly ICaseErpUnittypeBLL _iCaseErpUnittypeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpUnittypeBLL">单位类型【case_erp_unittype】接口</param>
        public UnittypeController(ICaseErpUnittypeBLL iCaseErpUnittypeBLL)
        {
            _iCaseErpUnittypeBLL = iCaseErpUnittypeBLL ?? throw new ArgumentNullException(nameof(iCaseErpUnittypeBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取单位类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unittypes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpUnittypeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpUnittypeEntity queryParams)
        {
            var list = await _iCaseErpUnittypeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取单位类型的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unittype/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpUnittypeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpUnittypeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpUnittypeBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/unittype/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnittypeEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpUnittypeBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/unittype/caseErpUnittype/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnittypeEntity>), 200)]
        public async Task<IActionResult> GetCaseErpUnittypeEntity(string id)
        {
            var data = await _iCaseErpUnittypeBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unittype")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnittypeEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpUnittypeEntity dto)
        {
            await _iCaseErpUnittypeBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unittype/caseErpUnittype")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnittypeEntity>), 200)]
        public async Task<IActionResult> AddCaseErpUnittype(CaseErpUnittypeEntity entity)
        {
            await _iCaseErpUnittypeBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/unittype/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpUnittypeEntity dto)
        {
            await _iCaseErpUnittypeBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/unittype/caseErpUnittype/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpUnittype(string id, CaseErpUnittypeEntity entity)
        {
            await _iCaseErpUnittypeBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unittype/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpUnittypeBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unittype/caseErpUnittype/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpUnittype(string id)
        {
            await _iCaseErpUnittypeBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unittype/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpUnittypeBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除单位类型【case_erp_unittype】case_erp_unittype数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unittype/caseErpUnittype/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpUnittypes(string ids)
        {
            await _iCaseErpUnittypeBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}