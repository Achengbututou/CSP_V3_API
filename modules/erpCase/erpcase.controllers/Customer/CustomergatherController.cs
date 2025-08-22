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
    /// 日 期： 2022-12-05 16:43:25
    /// 描 述： 客户回款
    /// </summary>
    public class CustomergatherController : BaseApiController
    {
        private readonly ICaseErpCustomergatherBLL _iCaseErpCustomergatherBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpCustomergatherBLL">客户回款【case_erp_customergather】接口</param>
        public CustomergatherController(ICaseErpCustomergatherBLL iCaseErpCustomergatherBLL)
        {
            _iCaseErpCustomergatherBLL = iCaseErpCustomergatherBLL ?? throw new ArgumentNullException(nameof(iCaseErpCustomergatherBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取客户回款的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customergathers")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpCustomergatherEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpCustomergatherEntity queryParams)
        {
            var list = await _iCaseErpCustomergatherBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取客户回款的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/customergather/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpCustomergatherEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpCustomergatherEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpCustomergatherBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/customergather/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var data = await _iCaseErpCustomergatherBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/customergather/caseErpCustomergather/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherEntity>), 200)]
        public async Task<IActionResult> GetCaseErpCustomergatherEntity(string id)
        {
            var data = await _iCaseErpCustomergatherBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customergather")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherEntity>), 200)]
        public async Task<IActionResult> AddForm(CaseErpCustomergatherEntity dto)
        {
            await _iCaseErpCustomergatherBLL.SaveEntity(null, dto);
            return Success("新增成功！", dto);
        }
        /// <summary>
        /// 新增客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/customergather/caseErpCustomergather")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpCustomergatherEntity>), 200)]
        public async Task<IActionResult> AddCaseErpCustomergather(CaseErpCustomergatherEntity entity)
        {
            await _iCaseErpCustomergatherBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/customergather/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, CaseErpCustomergatherEntity dto)
        {
            await _iCaseErpCustomergatherBLL.SaveEntity(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/customergather/caseErpCustomergather/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpCustomergather(string id, CaseErpCustomergatherEntity entity)
        {
            await _iCaseErpCustomergatherBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergather/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpCustomergatherBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergather/caseErpCustomergather/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpCustomergather(string id)
        {
            await _iCaseErpCustomergatherBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergather/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpCustomergatherBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除客户回款【case_erp_customergather】case_erp_customergather数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/customergather/caseErpCustomergather/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpCustomergathers(string ids)
        {
            await _iCaseErpCustomergatherBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}