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
    /// 日 期： 2022-12-05 17:17:21
    /// 描 述： BOM信息
    /// </summary>
    public class BomController : BaseApiController
    {
        private readonly ICaseErpBomBLL _iCaseErpBomBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpBomBLL">BOM信息【case_erp_bom】接口</param>
        public BomController(ICaseErpBomBLL iCaseErpBomBLL)
        {
            _iCaseErpBomBLL = iCaseErpBomBLL?? throw new ArgumentNullException(nameof(iCaseErpBomBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取BOM信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/boms")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpBomEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpBomEntity queryParams)
        {
            var list = await _iCaseErpBomBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取BOM信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/bom/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpBomEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpBomEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpBomBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/bom/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpBomEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpBomBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取BOM信息【case_erp_bom】case_erp_bom数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/bom/caseErpBom/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpBomEntity>), 200)]
        public async Task<IActionResult>GetCaseErpBomEntity(string id)
        {
            var data = await _iCaseErpBomBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/bom")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpBomEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpBomEntity dto)
        {
            if(await _iCaseErpBomBLL.SaveEntity(null,dto)){
                return Success("新增成功！", dto);
            }
            else{
                return Fail("新增的物料包含父级");
            }
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/bom/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpBomEntity entity)
        {
            if(await _iCaseErpBomBLL.SaveEntity(id,entity)){
                return Success("更新成功！", entity);
            }
            else{
                return Fail("更新的物料包含父级");
            }
        }
        /// <summary>
        /// 删除BOM信息【case_erp_bom】case_erp_bom数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/bom/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpBomBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除BOM信息【case_erp_bom】case_erp_bom数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/bom/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpBomBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion    

        #region 导出
        /// <summary>
        /// 导出的BOM表
        /// </summary>
        /// <returns></returns>
        [HttpPost("erpCase/bom/excel/export")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> ExportExcel() {
            var id = await _iCaseErpBomBLL.GetExportExcel();
            return Success(id);
        }
        #endregion   
    }
}