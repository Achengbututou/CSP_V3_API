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
    /// 日 期： 2022-12-05 16:40:15
    /// 描 述： 销售订单信息
    /// </summary>
    public class SaleController : BaseApiController
    {
        private readonly ICaseErpSaleBLL _iCaseErpSaleBLL;
        private readonly ICaseErpSaledetailBLL _iCaseErpSaledetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpSaleBLL">销售订单信息【case_erp_sale】接口</param>
        /// <param name="iCaseErpSaledetailBLL">销售订单详情【case_erp_saledetail】接口</param>
        public SaleController(ICaseErpSaleBLL iCaseErpSaleBLL,ICaseErpSaledetailBLL iCaseErpSaledetailBLL)
        {
            _iCaseErpSaleBLL = iCaseErpSaleBLL?? throw new ArgumentNullException(nameof(iCaseErpSaleBLL));
            _iCaseErpSaledetailBLL = iCaseErpSaledetailBLL?? throw new ArgumentNullException(nameof(iCaseErpSaledetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取销售订单信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/sales")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSaleEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpSaleEntity queryParams)
        {
            var list = await _iCaseErpSaleBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取销售订单信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/sale/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSaleEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpSaleEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSaleBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/sale/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SaleDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new SaleDto();
            res.CaseErpSaleEntity = await _iCaseErpSaleBLL.GetEntity(id);
            if(res.CaseErpSaleEntity != null)
            {
                res.CaseErpSaledetailList = await _iCaseErpSaledetailBLL.GetList(new CaseErpSaledetailEntity { F_SaleId = res.CaseErpSaleEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/sale/caseErpSale/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSaleEntity>), 200)]
        public async Task<IActionResult>GetCaseErpSaleEntity(string id)
        {
            var data = await _iCaseErpSaleBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取销售订单详情【case_erp_saledetail】case_erp_saledetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/sale/caseErpSaledetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpSaledetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpSaledetailList([FromQuery]CaseErpSaledetailEntity queryParams)
        {
            var list = await _iCaseErpSaledetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取销售订单详情【case_erp_saledetail】case_erp_saledetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/sale/caseErpSaledetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpSaledetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpSaledetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpSaledetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpSaledetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取销售订单详情【case_erp_saledetail】case_erp_saledetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/sale/caseErpSaledetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSaledetailEntity>), 200)]
        public async Task<IActionResult>GetCaseErpSaledetailEntity(string id)
        {
            var data = await _iCaseErpSaledetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/sale")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSaleEntity>), 200)]
        public async Task<IActionResult>AddForm(SaleDto dto)
        {
            await _iCaseErpSaleBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.CaseErpSaleEntity);
        }
        /// <summary>
        /// 新增销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/sale/caseErpSale")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSaleEntity>), 200)]
        public async Task<IActionResult>AddCaseErpSale(CaseErpSaleEntity entity)
        {
            await _iCaseErpSaleBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增销售订单详情【case_erp_saledetail】case_erp_saledetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/sale/caseErpSaledetail")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpSaledetailEntity>), 200)]
        public async Task<IActionResult>AddCaseErpSaledetail(CaseErpSaledetailEntity entity)
        {
            await _iCaseErpSaledetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/sale/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,SaleDto dto)
        {
            await _iCaseErpSaleBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/sale/caseErpSale/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpSale(string id,CaseErpSaleEntity entity)
        {
            await _iCaseErpSaleBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新销售订单详情【case_erp_saledetail】case_erp_saledetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/sale/caseErpSaledetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpSaledetail(string id,CaseErpSaledetailEntity entity)
        {
            await _iCaseErpSaledetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/sale/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpSaleBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/sale/caseErpSale/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpSale(string id)
        {
            await _iCaseErpSaleBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除销售订单详情【case_erp_saledetail】case_erp_saledetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/sale/caseErpSaledetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpSaledetail(string id)
        {
            await _iCaseErpSaledetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/sale/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpSaleBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除销售订单信息【case_erp_sale】case_erp_sale数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/sale/caseErpSale/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpSales(string ids)
        {
            await _iCaseErpSaleBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除销售订单详情【case_erp_saledetail】case_erp_saledetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/sale/caseErpSaledetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpSaledetails(string ids)
        {
            await _iCaseErpSaledetailBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion       
    }
}