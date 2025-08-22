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
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-30 15:20:23
    /// 描 述： 采购订单
    /// </summary>
    public class PurchaseController : BaseApiController
    {
        private readonly ICaseErpPurchaseBLL _iCaseErpPurchaseBLL;
        private readonly ICaseErpPurchasedetailBLL _iCaseErpPurchasedetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpPurchaseBLL">采购订单信息【case_erp_purchase】接口</param>
        /// <param name="iCaseErpPurchasedetailBLL">采购订单详情【case_erp_purchasedetail】接口</param>
        public PurchaseController(ICaseErpPurchaseBLL iCaseErpPurchaseBLL,ICaseErpPurchasedetailBLL iCaseErpPurchasedetailBLL)
        {
            _iCaseErpPurchaseBLL = iCaseErpPurchaseBLL?? throw new ArgumentNullException(nameof(iCaseErpPurchaseBLL));
            _iCaseErpPurchasedetailBLL = iCaseErpPurchasedetailBLL?? throw new ArgumentNullException(nameof(iCaseErpPurchasedetailBLL));
        }

         
        #region 获取数据
        
        /// <summary>
        /// 获取采购订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/purchases")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpPurchaseEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpPurchaseEntity queryParams)
        {
            var list = await _iCaseErpPurchaseBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取采购订单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/purchase/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpPurchaseEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpPurchaseEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpPurchaseBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/purchase/{id}")]
        [ProducesResponseType(typeof(ResponseDto<PurchaseDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new PurchaseDto();
            res.CaseErpPurchaseEntity = await _iCaseErpPurchaseBLL.GetEntity(id);
            if(res.CaseErpPurchaseEntity != null)
            {
                res.CaseErpPurchasedetailList = await _iCaseErpPurchasedetailBLL.GetList(new CaseErpPurchasedetailEntity { F_PurchaseId = res.CaseErpPurchaseEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/purchase/caseErpPurchase/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpPurchaseEntity>), 200)]
        public async Task<IActionResult>GetCaseErpPurchaseEntity(string id)
        {
            var data = await _iCaseErpPurchaseBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/purchase/caseErpPurchasedetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpPurchasedetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpPurchasedetailList([FromQuery]CaseErpPurchasedetailEntity queryParams)
        {
            var list = await _iCaseErpPurchasedetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/purchase/caseErpPurchasedetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpPurchasedetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpPurchasedetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpPurchasedetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpPurchasedetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/purchase/caseErpPurchasedetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpPurchasedetailEntity>), 200)]
        public async Task<IActionResult>GetCaseErpPurchasedetailEntity(string id)
        {
            var data = await _iCaseErpPurchasedetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/purchase")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpPurchaseEntity>), 200)]
        public async Task<IActionResult>AddForm(PurchaseDto dto)
        {
            await _iCaseErpPurchaseBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.CaseErpPurchaseEntity);
        }
        /// <summary>
        /// 新增采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/purchase/caseErpPurchase")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpPurchaseEntity>), 200)]
        public async Task<IActionResult>AddCaseErpPurchase(CaseErpPurchaseEntity entity)
        {
            await _iCaseErpPurchaseBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/purchase/caseErpPurchasedetail")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpPurchasedetailEntity>), 200)]
        public async Task<IActionResult>AddCaseErpPurchasedetail(CaseErpPurchasedetailEntity entity)
        {
            await _iCaseErpPurchasedetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/purchase/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,PurchaseDto dto)
        {
            await _iCaseErpPurchaseBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/purchase/caseErpPurchase/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpPurchase(string id,CaseErpPurchaseEntity entity)
        {
            await _iCaseErpPurchaseBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/purchase/caseErpPurchasedetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpPurchasedetail(string id,CaseErpPurchasedetailEntity entity)
        {
            await _iCaseErpPurchasedetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/purchase/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpPurchaseBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/purchase/caseErpPurchase/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpPurchase(string id)
        {
            await _iCaseErpPurchaseBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/purchase/caseErpPurchasedetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpPurchasedetail(string id)
        {
            await _iCaseErpPurchasedetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/purchase/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpPurchaseBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除采购订单信息【case_erp_purchase】case_erp_purchase数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/purchase/caseErpPurchase/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpPurchases(string ids)
        {
            await _iCaseErpPurchaseBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除采购订单详情【case_erp_purchasedetail】case_erp_purchasedetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/purchase/caseErpPurchasedetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpPurchasedetails(string ids)
        {
            await _iCaseErpPurchasedetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion


        #region 扩展方法
        /// <summary>
        /// 获取对应物料的采购记录
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpGet("erpCase/purchase/getpurchaseslog/{num}")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpPurchaseEntity>>), 200)]
        public async Task<IActionResult> GetPurchasesLog([FromQuery] Pagination pagination, [FromQuery] CaseErpPurchaseEntity queryParams, string num)
        {
            var list = await _iCaseErpPurchaseBLL.GetPurchasesLog(pagination, queryParams, num);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }
        #endregion
    }
}