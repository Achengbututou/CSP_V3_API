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
    /// 日 期： 2022-12-05 16:15:15
    /// 描 述： 供货清单价格记录
    /// </summary>
    public class SupplypricelogController : BaseApiController
    {
        private readonly ICaseErpSupplypricelogBLL _iCaseErpSupplypricelogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSupplypricelogBLL">供货清单价格记录【case_erp_supplypricelog】接口</param>
        public SupplypricelogController(ICaseErpSupplypricelogBLL iCaseErpSupplypricelogBLL)
        {
            _iCaseErpSupplypricelogBLL = iCaseErpSupplypricelogBLL ?? throw new ArgumentNullException(nameof(iCaseErpSupplypricelogBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取供货清单价格记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplypricelogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSupplypricelogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpSupplypricelogEntity queryParams)
        {
            var list = await _iCaseErpSupplypricelogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取供货清单价格记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/supplypricelog/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSupplypricelogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpSupplypricelogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSupplypricelogBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/supplypricelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplypricelogEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpSupplypricelogBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/supplypricelog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSupplypricelogEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpSupplypricelogEntity dto)
        {
            await _iCaseErpSupplypricelogBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/supplypricelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpSupplypricelogEntity dto)
        {
            await _iCaseErpSupplypricelogBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        


        /// <summary>
        /// 删除供货清单价格记录【case_erp_supplypricelog】case_erp_supplypricelog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplypricelog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpSupplypricelogBLL.Delete(id);
            return Success("删除成功！");
        }
        

        /// <summary>
        /// 批量删除供货清单价格记录【case_erp_supplypricelog】case_erp_supplypricelog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/supplypricelog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpSupplypricelogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion       
    }
}