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
    /// 日 期： 2022-12-05 16:50:21
    /// 描 述： 物料属性配置
    /// </summary>
    public class MaterialpropertyController : BaseApiController
    {
        private readonly ICaseErpMaterialpropertyBLL _iCaseErpMaterialpropertyBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpMaterialpropertyBLL">物料属性配置【case_erp_materialproperty】接口</param>
        public MaterialpropertyController(ICaseErpMaterialpropertyBLL iCaseErpMaterialpropertyBLL)
        {
            _iCaseErpMaterialpropertyBLL = iCaseErpMaterialpropertyBLL ?? throw new ArgumentNullException(nameof(iCaseErpMaterialpropertyBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取物料属性配置的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/materialpropertys")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpMaterialpropertyEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpMaterialpropertyEntity queryParams)
        {
            var list = await _iCaseErpMaterialpropertyBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取物料属性配置的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/materialproperty/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpMaterialpropertyEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpMaterialpropertyEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpMaterialpropertyBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/materialproperty/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialpropertyEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpMaterialpropertyBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/materialproperty/caseErpMaterialproperty/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialpropertyEntity>), 200)]
        public async Task<IActionResult> GetCaseErpMaterialpropertyEntity(string id)
        {
            var data = await _iCaseErpMaterialpropertyBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/materialproperty")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialpropertyEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpMaterialpropertyEntity dto)
        {
            await _iCaseErpMaterialpropertyBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/materialproperty/caseErpMaterialproperty")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialpropertyEntity>), 200)]
        public async Task<IActionResult> AddCaseErpMaterialproperty(CaseErpMaterialpropertyEntity entity)
        {
            await _iCaseErpMaterialpropertyBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/materialproperty/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpMaterialpropertyEntity dto)
        {
            await _iCaseErpMaterialpropertyBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/materialproperty/caseErpMaterialproperty/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpMaterialproperty(string id, CaseErpMaterialpropertyEntity entity)
        {
            await _iCaseErpMaterialpropertyBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialproperty/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpMaterialpropertyBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialproperty/caseErpMaterialproperty/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpMaterialproperty(string id)
        {
            await _iCaseErpMaterialpropertyBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialproperty/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpMaterialpropertyBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除物料属性配置【case_erp_materialproperty】case_erp_materialproperty数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialproperty/caseErpMaterialproperty/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpMaterialpropertys(string ids)
        {
            await _iCaseErpMaterialpropertyBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}