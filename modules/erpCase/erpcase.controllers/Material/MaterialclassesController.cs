using erpCase.ibll;
using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstPlugin.controllers
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:49:41
    /// 描 述： 物料类别配置
    /// </summary>
    public class MaterialclassesController : BaseApiController
    {
        private readonly ICaseErpMaterialclassesBLL _iCaseErpMaterialclassesBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpMaterialclassesBLL">物料类别配置【case_erp_materialclasses】接口</param>
        public MaterialclassesController(ICaseErpMaterialclassesBLL iCaseErpMaterialclassesBLL)
        {
            _iCaseErpMaterialclassesBLL = iCaseErpMaterialclassesBLL ?? throw new ArgumentNullException(nameof(iCaseErpMaterialclassesBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取物料类别配置的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/materialclassess")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpMaterialclassesEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpMaterialclassesEntity queryParams)
        {
            var list = await _iCaseErpMaterialclassesBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取物料类别配置的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/materialclasses/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpMaterialclassesEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpMaterialclassesEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpMaterialclassesBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/materialclasses/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialclassesEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpMaterialclassesBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/materialclasses/caseErpMaterialclasses/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialclassesEntity>), 200)]
        public async Task<IActionResult> GetCaseErpMaterialclassesEntity(string id)
        {
            var data = await _iCaseErpMaterialclassesBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/materialclasses")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialclassesEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpMaterialclassesEntity dto)
        {
            await _iCaseErpMaterialclassesBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/materialclasses/caseErpMaterialclasses")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialclassesEntity>), 200)]
        public async Task<IActionResult> AddCaseErpMaterialclasses(CaseErpMaterialclassesEntity entity)
        {
            await _iCaseErpMaterialclassesBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/materialclasses/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpMaterialclassesEntity dto)
        {
            await _iCaseErpMaterialclassesBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/materialclasses/caseErpMaterialclasses/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpMaterialclasses(string id, CaseErpMaterialclassesEntity entity)
        {
            await _iCaseErpMaterialclassesBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialclasses/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpMaterialclassesBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialclasses/caseErpMaterialclasses/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpMaterialclasses(string id)
        {
            await _iCaseErpMaterialclassesBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialclasses/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpMaterialclassesBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除物料类别配置【case_erp_materialclasses】case_erp_materialclasses数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/materialclasses/caseErpMaterialclasses/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpMaterialclassess(string ids)
        {
            await _iCaseErpMaterialclassesBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}