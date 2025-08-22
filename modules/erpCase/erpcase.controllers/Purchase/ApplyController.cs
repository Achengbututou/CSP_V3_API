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
    /// 日 期： 2022-11-30 15:26:32
    /// 描 述： 采购申请
    /// </summary>
    public class ApplyController : BaseApiController
    {
        private readonly ICaseErpApplyBLL _iCaseErpApplyBLL;
        private readonly ICaseErpApplydetailBLL _iCaseErpApplydetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpApplyBLL">采购申请信息【case_erp_apply】接口</param>
        /// <param name="iCaseErpApplydetailBLL">采购申请详情【case_erp_applydetail】接口</param>
        public ApplyController(ICaseErpApplyBLL iCaseErpApplyBLL, ICaseErpApplydetailBLL iCaseErpApplydetailBLL)
        {
            _iCaseErpApplyBLL = iCaseErpApplyBLL ?? throw new ArgumentNullException(nameof(iCaseErpApplyBLL));
            _iCaseErpApplydetailBLL = iCaseErpApplydetailBLL ?? throw new ArgumentNullException(nameof(iCaseErpApplydetailBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取采购申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/applys")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpApplyEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpApplyEntity queryParams)
        {
            var list = await _iCaseErpApplyBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取采购申请的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/apply/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpApplyEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpApplyEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpApplyBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/apply/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ApplyDto>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var res = new ApplyDto();
            res.CaseErpApplyEntity = await _iCaseErpApplyBLL.GetEntity(id);
            if (res.CaseErpApplyEntity != null)
            {
                res.CaseErpApplydetailList = await _iCaseErpApplydetailBLL.GetList(new CaseErpApplydetailEntity { F_ApplyId = res.CaseErpApplyEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/apply/caseErpApply/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpApplyEntity>), 200)]
        public async Task<IActionResult> GetCaseErpApplyEntity(string id)
        {
            var data = await _iCaseErpApplyBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取采购申请详情【case_erp_applydetail】case_erp_applydetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/apply/caseErpApplydetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpApplydetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpApplydetailList([FromQuery] CaseErpApplydetailEntity queryParams)
        {
            var list = await _iCaseErpApplydetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取采购申请详情【case_erp_applydetail】case_erp_applydetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/apply/caseErpApplydetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpApplydetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpApplydetailPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpApplydetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpApplydetailBLL.GetPageList(pagination, queryParams);
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
        /// 获取采购申请详情【case_erp_applydetail】case_erp_applydetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/apply/caseErpApplydetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpApplydetailEntity>), 200)]
        public async Task<IActionResult> GetCaseErpApplydetailEntity(string id)
        {
            var data = await _iCaseErpApplydetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/apply")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpApplyEntity>), 200)]
        public async Task<IActionResult> AddForm(ApplyDto dto)
        {
            await _iCaseErpApplyBLL.SaveAll(null, dto);
            return Success("新增成功！", dto.CaseErpApplyEntity);
        }
        /// <summary>
        /// 新增采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/apply/caseErpApply")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpApplyEntity>), 200)]
        public async Task<IActionResult> AddCaseErpApply(CaseErpApplyEntity entity)
        {
            await _iCaseErpApplyBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增采购申请详情【case_erp_applydetail】case_erp_applydetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/apply/caseErpApplydetail")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpApplydetailEntity>), 200)]
        public async Task<IActionResult> AddCaseErpApplydetail(CaseErpApplydetailEntity entity)
        {
            await _iCaseErpApplydetailBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/apply/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, ApplyDto dto)
        {
            await _iCaseErpApplyBLL.SaveAll(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/apply/caseErpApply/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpApply(string id, CaseErpApplyEntity entity)
        {
            await _iCaseErpApplyBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新采购申请详情【case_erp_applydetail】case_erp_applydetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/apply/caseErpApplydetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpApplydetail(string id, CaseErpApplydetailEntity entity)
        {
            await _iCaseErpApplydetailBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/apply/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpApplyBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/apply/caseErpApply/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpApply(string id)
        {
            await _iCaseErpApplyBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除采购申请详情【case_erp_applydetail】case_erp_applydetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/apply/caseErpApplydetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpApplydetail(string id)
        {
            await _iCaseErpApplydetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/apply/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpApplyBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除采购申请信息【case_erp_apply】case_erp_apply数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/apply/caseErpApply/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpApplys(string ids)
        {
            await _iCaseErpApplyBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除采购申请详情【case_erp_applydetail】case_erp_applydetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/apply/caseErpApplydetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpApplydetails(string ids)
        {
            await _iCaseErpApplydetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}