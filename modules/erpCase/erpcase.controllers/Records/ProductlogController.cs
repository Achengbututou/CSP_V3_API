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
    /// 日 期： 2022-12-05 08:54:39
    /// 描 述： 生产记录
    /// </summary>
    public class ProductlogController : BaseApiController
    {
        private readonly ICaseErpProductlogBLL _iCaseErpProductlogBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpProductlogBLL">生产记录【case_erp_productlog】接口</param>
        public ProductlogController(ICaseErpProductlogBLL iCaseErpProductlogBLL)
        {
            _iCaseErpProductlogBLL = iCaseErpProductlogBLL?? throw new ArgumentNullException(nameof(iCaseErpProductlogBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取生产记录的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/productlogs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpProductlogEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpProductlogEntity queryParams)
        {
            var list = await _iCaseErpProductlogBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取生产记录的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/productlog/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpProductlogEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpProductlogEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpProductlogBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/productlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpProductlogEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpProductlogBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/productlog/caseErpProductlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpProductlogEntity>), 200)]
        public async Task<IActionResult>GetCaseErpProductlogEntity(string id)
        {
            var data = await _iCaseErpProductlogBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/productlog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpProductlogEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpProductlogEntity dto)
        {
            await _iCaseErpProductlogBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/productlog/caseErpProductlog")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpProductlogEntity>), 200)]
        public async Task<IActionResult>AddCaseErpProductlog(CaseErpProductlogEntity entity)
        {
            await _iCaseErpProductlogBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/productlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpProductlogEntity dto)
        {
            await _iCaseErpProductlogBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/productlog/caseErpProductlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpProductlog(string id,CaseErpProductlogEntity entity)
        {
            await _iCaseErpProductlogBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/productlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpProductlogBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/productlog/caseErpProductlog/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpProductlog(string id)
        {
            await _iCaseErpProductlogBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/productlog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpProductlogBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除生产记录【case_erp_productlog】case_erp_productlog数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/productlog/caseErpProductlog/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpProductlogs(string ids)
        {
            await _iCaseErpProductlogBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}