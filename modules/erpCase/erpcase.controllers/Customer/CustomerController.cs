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
    /// 日 期： 2022-12-05 16:42:10
    /// 描 述： 客户信息
    /// </summary>
    public class CustomerController : BaseApiController
    {
        private readonly ICaseErpCustomerBLL _iCaseErpCustomerBLL;
        private readonly ICaseErpCustomercontactsBLL _iCaseErpCustomercontactsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpCustomerBLL">客户信息【case_erp_customer】接口</param>
        /// <param name="iCaseErpCustomercontactsBLL">客户联系人【case_erp_customercontacts】接口</param>
        public CustomerController(ICaseErpCustomerBLL iCaseErpCustomerBLL,ICaseErpCustomercontactsBLL iCaseErpCustomercontactsBLL)
        {
            _iCaseErpCustomerBLL = iCaseErpCustomerBLL?? throw new ArgumentNullException(nameof(iCaseErpCustomerBLL));
            _iCaseErpCustomercontactsBLL = iCaseErpCustomercontactsBLL?? throw new ArgumentNullException(nameof(iCaseErpCustomercontactsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取客户信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customers")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpCustomerEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpCustomerEntity queryParams)
        {
            var list = await _iCaseErpCustomerBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取客户信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customer/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpCustomerEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpCustomerEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpCustomerBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/customer/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CustomerDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new CustomerDto();
            res.CaseErpCustomerEntity = await _iCaseErpCustomerBLL.GetEntity(id);
            if(res.CaseErpCustomerEntity != null)
            {
                res.CaseErpCustomercontactsList = await _iCaseErpCustomercontactsBLL.GetList(new CaseErpCustomercontactsEntity { F_CustomerId = res.CaseErpCustomerEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/customer/caseErpCustomer/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerEntity>), 200)]
        public async Task<IActionResult>GetCaseErpCustomerEntity(string id)
        {
            var data = await _iCaseErpCustomerBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取客户联系人【case_erp_customercontacts】case_erp_customercontacts的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customer/caseErpCustomercontactss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpCustomercontactsEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpCustomercontactsList([FromQuery]CaseErpCustomercontactsEntity queryParams)
        {
            var list = await _iCaseErpCustomercontactsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取客户联系人【case_erp_customercontacts】case_erp_customercontacts的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customer/caseErpCustomercontacts/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpCustomercontactsEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpCustomercontactsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpCustomercontactsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpCustomercontactsBLL.GetPageList(pagination,queryParams);
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
        /// 获取客户联系人【case_erp_customercontacts】case_erp_customercontacts数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/customer/caseErpCustomercontacts/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomercontactsEntity>), 200)]
        public async Task<IActionResult>GetCaseErpCustomercontactsEntity(string id)
        {
            var data = await _iCaseErpCustomercontactsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customer")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerEntity>), 200)]
        public async Task<IActionResult>AddForm(CustomerDto dto)
        {
            await _iCaseErpCustomerBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.CaseErpCustomerEntity);
        }
        /// <summary>
        /// 新增客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customer/caseErpCustomer")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerEntity>), 200)]
        public async Task<IActionResult>AddCaseErpCustomer(CaseErpCustomerEntity entity)
        {
            await _iCaseErpCustomerBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增客户联系人【case_erp_customercontacts】case_erp_customercontacts数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customer/caseErpCustomercontacts")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomercontactsEntity>), 200)]
        public async Task<IActionResult>AddCaseErpCustomercontacts(CaseErpCustomercontactsEntity entity)
        {
            await _iCaseErpCustomercontactsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/customer/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CustomerDto dto)
        {
            await _iCaseErpCustomerBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/customer/caseErpCustomer/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpCustomer(string id,CaseErpCustomerEntity entity)
        {
            await _iCaseErpCustomerBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新客户联系人【case_erp_customercontacts】case_erp_customercontacts数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/customer/caseErpCustomercontacts/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpCustomercontacts(string id,CaseErpCustomercontactsEntity entity)
        {
            await _iCaseErpCustomercontactsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customer/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpCustomerBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customer/caseErpCustomer/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpCustomer(string id)
        {
            await _iCaseErpCustomerBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除客户联系人【case_erp_customercontacts】case_erp_customercontacts数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customer/caseErpCustomercontacts/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpCustomercontacts(string id)
        {
            await _iCaseErpCustomercontactsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customer/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpCustomerBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除客户信息【case_erp_customer】case_erp_customer数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customer/caseErpCustomer/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpCustomers(string ids)
        {
            await _iCaseErpCustomerBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除客户联系人【case_erp_customercontacts】case_erp_customercontacts数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customer/caseErpCustomercontacts/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpCustomercontactss(string ids)
        {
            await _iCaseErpCustomercontactsBLL.Deletes(ids);
            return Success("删除成功！");
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 移入公海
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpPut("erpCase/customer/transferpublic/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> TransferPublic(string ids)
        {
            await _iCaseErpCustomerBLL.TransferPublic(ids);
            return Success("移入成功！");
        }
        /// <summary>
        /// 领取客户
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPut("erpCase/customer/receivecustomer/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> ReceiveCustomer(string id)
        {
            await _iCaseErpCustomerBLL.ReceiveCustomer(id);
            return Success("领取成功！");
        }
        #endregion
    }
}