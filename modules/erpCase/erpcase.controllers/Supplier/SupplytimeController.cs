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
    /// 日 期： 2022-12-07 15:18:03
    /// 描 述： 供应商时间轴
    /// </summary>
    public class SupplytimeController : BaseApiController
    {
        private readonly ICaseErpSupplytimeBLL _iCaseErpSupplytimeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplytimeBLL">供应商时间轴【case_erp_supplytime】接口</param>
        public SupplytimeController(ICaseErpSupplytimeBLL iCaseErpSupplytimeBLL)
        {
            _iCaseErpSupplytimeBLL = iCaseErpSupplytimeBLL ?? throw new ArgumentNullException(nameof(iCaseErpSupplytimeBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取供应商时间轴的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplytimes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSupplytimeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpSupplytimeEntity queryParams)
        {
            var list = await _iCaseErpSupplytimeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取供应商时间轴的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplytime/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSupplytimeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpSupplytimeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSupplytimeBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/supplytime/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplytimeEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpSupplytimeBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/supplytime")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplytimeEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpSupplytimeEntity dto)
        {
            await _iCaseErpSupplytimeBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/supplytime/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpSupplytimeEntity dto)
        {
            await _iCaseErpSupplytimeBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        


        /// <summary>
        /// 删除供应商时间轴【case_erp_supplytime】case_erp_supplytime数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplytime/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpSupplytimeBLL.Delete(id);
            return Success("删除成功！");
        }
        

        /// <summary>
        /// 批量删除供应商时间轴【case_erp_supplytime】case_erp_supplytime数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplytime/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpSupplytimeBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion       
    }
}