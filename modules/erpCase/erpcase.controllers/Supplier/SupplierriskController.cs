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
    /// 日 期： 2022-12-05 16:10:51
    /// 描 述： 供应商风险评估
    /// </summary>
    public class SupplierriskController : BaseApiController
    {
        private readonly ICaseErpSupplierriskBLL _iCaseErpSupplierriskBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplierriskBLL">供应商风险评估【case_erp_supplierrisk】接口</param>
        public SupplierriskController(ICaseErpSupplierriskBLL iCaseErpSupplierriskBLL)
        {
            _iCaseErpSupplierriskBLL = iCaseErpSupplierriskBLL?? throw new ArgumentNullException(nameof(iCaseErpSupplierriskBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取供应商风险评估的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierrisks")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSupplierriskEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpSupplierriskEntity queryParams)
        {
            var list = await _iCaseErpSupplierriskBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取供应商风险评估的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierrisk/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSupplierriskEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpSupplierriskEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSupplierriskBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/supplierrisk/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierriskEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpSupplierriskBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/supplierrisk")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierriskEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpSupplierriskEntity dto)
        {
            await _iCaseErpSupplierriskBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/supplierrisk/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpSupplierriskEntity dto)
        {
            await _iCaseErpSupplierriskBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        
        /// <summary>
        /// 删除供应商风险评估【case_erp_supplierrisk】case_erp_supplierrisk数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplierrisk/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpSupplierriskBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除供应商风险评估【case_erp_supplierrisk】case_erp_supplierrisk数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplierrisk/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpSupplierriskBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 根据供应商主键获取评估报告
        /// </summary>
        /// <param name="supplierid">供应商主键</param>
        /// <param name="risktype">报告类型(0风险评估，1年审评估)</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierrisk/{supplierid}/{risktype}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierriskEntity>), 200)]
        public async Task<IActionResult> GetAssess(string supplierid,int risktype)
        {
            var data = await _iCaseErpSupplierriskBLL.GetAssess(supplierid, risktype);
            return Success(data);
        }
        
        
        /// <summary>
        /// 根据供应商主键获取最近的年审报告
        /// </summary>
        /// <param name="supplierid">供应商主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplierrisk/year/{supplierid}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplierriskEntity>), 200)]
        public async Task<IActionResult> GetAssess(string supplierid)
        {
            var data = await _iCaseErpSupplierriskBLL.GetEntityLastBySupplierId(supplierid);
            return Success(data);
        }
        #endregion
    }
}