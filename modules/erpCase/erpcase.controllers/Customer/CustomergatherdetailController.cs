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
    /// 日 期： 2022-12-05 16:44:00
    /// 描 述： 客户回款详情
    /// </summary>
    public class CustomergatherdetailController : BaseApiController
    {
        private readonly ICaseErpCustomergatherdetailBLL _iCaseErpCustomergatherdetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpCustomergatherdetailBLL">客户回款详情【case_erp_customergatherdetail】接口</param>
        public CustomergatherdetailController(ICaseErpCustomergatherdetailBLL iCaseErpCustomergatherdetailBLL)
        {
            _iCaseErpCustomergatherdetailBLL = iCaseErpCustomergatherdetailBLL ?? throw new ArgumentNullException(nameof(iCaseErpCustomergatherdetailBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取客户回款详情的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customergatherdetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpCustomergatherdetailEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpCustomergatherdetailEntity queryParams)
        {
            var list = await _iCaseErpCustomergatherdetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取客户回款详情的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customergatherdetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpCustomergatherdetailEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpCustomergatherdetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpCustomergatherdetailBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/customergatherdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherdetailEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpCustomergatherdetailBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/customergatherdetail/caseErpCustomergatherdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherdetailEntity>), 200)]
        public async Task<IActionResult> GetCaseErpCustomergatherdetailEntity(string id)
        {
            var data = await _iCaseErpCustomergatherdetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customergatherdetail")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherdetailEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpCustomergatherdetailEntity dto)
        {
            await _iCaseErpCustomergatherdetailBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customergatherdetail/caseErpCustomergatherdetail")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherdetailEntity>), 200)]
        public async Task<IActionResult> AddCaseErpCustomergatherdetail(CaseErpCustomergatherdetailEntity entity)
        {
            await _iCaseErpCustomergatherdetailBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/customergatherdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpCustomergatherdetailEntity dto)
        {
            await _iCaseErpCustomergatherdetailBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/customergatherdetail/caseErpCustomergatherdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpCustomergatherdetail(string id, CaseErpCustomergatherdetailEntity entity)
        {
            await _iCaseErpCustomergatherdetailBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergatherdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpCustomergatherdetailBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergatherdetail/caseErpCustomergatherdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpCustomergatherdetail(string id)
        {
            await _iCaseErpCustomergatherdetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergatherdetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpCustomergatherdetailBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除客户回款详情【case_erp_customergatherdetail】case_erp_customergatherdetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergatherdetail/caseErpCustomergatherdetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpCustomergatherdetails(string ids)
        {
            await _iCaseErpCustomergatherdetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}