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
    /// 日 期： 2022-12-05 16:42:43
    /// 描 述： 客户跟进
    /// </summary>
    public class CustomerfollowController : BaseApiController
    {
        private readonly ICaseErpCustomerfollowBLL _iCaseErpCustomerfollowBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpCustomerfollowBLL">客户跟进【case_erp_customerfollow】接口</param>
        public CustomerfollowController(ICaseErpCustomerfollowBLL iCaseErpCustomerfollowBLL)
        {
            _iCaseErpCustomerfollowBLL = iCaseErpCustomerfollowBLL ?? throw new ArgumentNullException(nameof(iCaseErpCustomerfollowBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取客户跟进的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customerfollows")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpCustomerfollowEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpCustomerfollowEntity queryParams)
        {
            var list = await _iCaseErpCustomerfollowBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取客户跟进的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customerfollow/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpCustomerfollowEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpCustomerfollowEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpCustomerfollowBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/customerfollow/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerfollowEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpCustomerfollowBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/customerfollow/caseErpCustomerfollow/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerfollowEntity>), 200)]
        public async Task<IActionResult> GetCaseErpCustomerfollowEntity(string id)
        {
            var data = await _iCaseErpCustomerfollowBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customerfollow")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerfollowEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpCustomerfollowEntity dto)
        {
            await _iCaseErpCustomerfollowBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customerfollow/caseErpCustomerfollow")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomerfollowEntity>), 200)]
        public async Task<IActionResult> AddCaseErpCustomerfollow(CaseErpCustomerfollowEntity entity)
        {
            await _iCaseErpCustomerfollowBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/customerfollow/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpCustomerfollowEntity dto)
        {
            await _iCaseErpCustomerfollowBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/customerfollow/caseErpCustomerfollow/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpCustomerfollow(string id, CaseErpCustomerfollowEntity entity)
        {
            await _iCaseErpCustomerfollowBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customerfollow/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpCustomerfollowBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customerfollow/caseErpCustomerfollow/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpCustomerfollow(string id)
        {
            await _iCaseErpCustomerfollowBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customerfollow/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpCustomerfollowBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除客户跟进【case_erp_customerfollow】case_erp_customerfollow数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customerfollow/caseErpCustomerfollow/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpCustomerfollows(string ids)
        {
            await _iCaseErpCustomerfollowBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}