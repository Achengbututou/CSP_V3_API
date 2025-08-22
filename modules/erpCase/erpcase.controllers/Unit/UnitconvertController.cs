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
    /// 日 期： 2022-12-05 16:54:57
    /// 描 述： 单位换算
    /// </summary>
    public class UnitconvertController : BaseApiController
    {
        private readonly ICaseErpUnitconvertBLL _iCaseErpUnitconvertBLL;
        private readonly ICaseErpUnitconvertdetailBLL _iCaseErpUnitconvertdetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpUnitconvertBLL">单位换算【case_erp_unitconvert】接口</param>
        /// <param name="iCaseErpUnitconvertdetailBLL">单位换算详情【case_erp_unitconvertdetail】接口</param>
        public UnitconvertController(ICaseErpUnitconvertBLL iCaseErpUnitconvertBLL, ICaseErpUnitconvertdetailBLL iCaseErpUnitconvertdetailBLL)
        {
            _iCaseErpUnitconvertBLL = iCaseErpUnitconvertBLL ?? throw new ArgumentNullException(nameof(iCaseErpUnitconvertBLL));
            _iCaseErpUnitconvertdetailBLL = iCaseErpUnitconvertdetailBLL ?? throw new ArgumentNullException(nameof(iCaseErpUnitconvertdetailBLL));
        }


        #region 获取数据

        /// <summary>
        /// 获取单位换算的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unitconverts")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpUnitconvertEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] CaseErpUnitconvertEntity queryParams)
        {
            var list = await _iCaseErpUnitconvertBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取单位换算的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unitconvert/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpUnitconvertEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpUnitconvertEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpUnitconvertBLL.GetPageList(pagination, queryParams);
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
        [HttpGet("erpCase/unitconvert/{id}")]
        [ProducesResponseType(typeof(ResponseDto<UnitconvertDto>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            var res = new UnitconvertDto();
            res.CaseErpUnitconvertEntity = await _iCaseErpUnitconvertBLL.GetEntity(id);
            if (res.CaseErpUnitconvertEntity != null)
            {
                res.CaseErpUnitconvertdetailList = await _iCaseErpUnitconvertdetailBLL.GetList(new CaseErpUnitconvertdetailEntity { F_UnitConvertId = res.CaseErpUnitconvertEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/unitconvert/caseErpUnitconvert/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitconvertEntity>), 200)]
        public async Task<IActionResult> GetCaseErpUnitconvertEntity(string id)
        {
            var data = await _iCaseErpUnitconvertBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unitconvert/caseErpUnitconvertdetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpUnitconvertdetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpUnitconvertdetailList([FromQuery] CaseErpUnitconvertdetailEntity queryParams)
        {
            var list = await _iCaseErpUnitconvertdetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unitconvert/caseErpUnitconvertdetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpUnitconvertdetailEntity>>), 200)]
        public async Task<IActionResult> GetCaseErpUnitconvertdetailPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpUnitconvertdetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpUnitconvertdetailBLL.GetPageList(pagination, queryParams);
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
        /// 获取单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/unitconvert/caseErpUnitconvertdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitconvertdetailEntity>), 200)]
        public async Task<IActionResult> GetCaseErpUnitconvertdetailEntity(string id)
        {
            var data = await _iCaseErpUnitconvertdetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unitconvert")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitconvertEntity>), 200)]
        public async Task<IActionResult> AddForm(UnitconvertDto dto)
        {
            await _iCaseErpUnitconvertBLL.SaveAll(null, dto);
            return Success("新增成功！", dto.CaseErpUnitconvertEntity);
        }
        /// <summary>
        /// 新增单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unitconvert/caseErpUnitconvert")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitconvertEntity>), 200)]
        public async Task<IActionResult> AddCaseErpUnitconvert(CaseErpUnitconvertEntity entity)
        {
            await _iCaseErpUnitconvertBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/unitconvert/caseErpUnitconvertdetail")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpUnitconvertdetailEntity>), 200)]
        public async Task<IActionResult> AddCaseErpUnitconvertdetail(CaseErpUnitconvertdetailEntity entity)
        {
            await _iCaseErpUnitconvertdetailBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/unitconvert/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, UnitconvertDto dto)
        {
            await _iCaseErpUnitconvertBLL.SaveAll(id, dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/unitconvert/caseErpUnitconvert/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpUnitconvert(string id, CaseErpUnitconvertEntity entity)
        {
            await _iCaseErpUnitconvertBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/unitconvert/caseErpUnitconvertdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateCaseErpUnitconvertdetail(string id, CaseErpUnitconvertdetailEntity entity)
        {
            await _iCaseErpUnitconvertdetailBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unitconvert/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _iCaseErpUnitconvertBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unitconvert/caseErpUnitconvert/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpUnitconvert(string id)
        {
            await _iCaseErpUnitconvertBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unitconvert/caseErpUnitconvertdetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpUnitconvertdetail(string id)
        {
            await _iCaseErpUnitconvertdetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unitconvert/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForms(string ids)
        {
            await _iCaseErpUnitconvertBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除单位换算【case_erp_unitconvert】case_erp_unitconvert数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unitconvert/caseErpUnitconvert/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpUnitconverts(string ids)
        {
            await _iCaseErpUnitconvertBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除单位换算详情【case_erp_unitconvertdetail】case_erp_unitconvertdetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/unitconvert/caseErpUnitconvertdetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteCaseErpUnitconvertdetails(string ids)
        {
            await _iCaseErpUnitconvertdetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取单位列表配置信息
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/unit/getconfig/{typeids}")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<UnitconvertDto>>), 200)]
        public async Task<IActionResult> GetConfig([FromQuery] CaseErpUnitconvertEntity queryParams)
        {
            var list = await _iCaseErpUnitconvertBLL.GetConfig(queryParams);
            return Success(list);
        }
        #endregion
    }
}