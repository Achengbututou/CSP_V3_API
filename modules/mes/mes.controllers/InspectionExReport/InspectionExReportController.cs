using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;

namespace mes.controllers
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-29 17:24:38
    /// 描 述： 巡检异常报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class InspectionExReportController : BaseApiController
    {
        private readonly IMesInspectionExReportBLL _iMesInspectionExReportBLL;
        private readonly IMesInspectionExDetailBLL _iMesInspectionExDetailBLL;
        private readonly IMesInspectionReportBLL _iMesInspectionReportBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInspectionExReportBLL"></param>
        /// <param name="iMesInspectionExDetailBLL"></param>
        /// <param name="iMesInspectionReportBLL"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InspectionExReportController(IMesInspectionExReportBLL iMesInspectionExReportBLL,IMesInspectionExDetailBLL iMesInspectionExDetailBLL, IMesInspectionReportBLL iMesInspectionReportBLL)
        {
            _iMesInspectionExReportBLL = iMesInspectionExReportBLL?? throw new ArgumentNullException(nameof(iMesInspectionExReportBLL));
            _iMesInspectionExDetailBLL = iMesInspectionExDetailBLL?? throw new ArgumentNullException(nameof(iMesInspectionExDetailBLL));
            _iMesInspectionReportBLL = iMesInspectionReportBLL ?? throw new ArgumentNullException(nameof(iMesInspectionReportBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取巡检异常报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionExReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInspectionExReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesInspectionExReportEntity queryParams)
        {
            var list = await _iMesInspectionExReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取巡检异常报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionExReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInspectionExReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInspectionExReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInspectionExReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/inspectionExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<InspectionExReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new InspectionExReportReDto();
            res.MesInspectionExReportEntity = await _iMesInspectionExReportBLL.GetEntity(id);
            if(res.MesInspectionExReportEntity != null)
            {
                res.MesInspectionExDetailList = await _iMesInspectionExDetailBLL.GetList(new MesInspectionExDetailEntity { F_InspectionExId = res.MesInspectionExReportEntity.F_Id });
                res.MesInspectionReportEntity=  await _iMesInspectionReportBLL.GetEntity(res.MesInspectionExReportEntity.F_InspectionId);
            }
            return Success(res);
        }
        /// <summary>
        /// 获取巡检异常报告mes_inspectexreport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionExReport/mesInspectionExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionExReportEntity>), 200)]
        public async Task<IActionResult>GetMesInspectionExReportEntity(string id)
        {
            var data = await _iMesInspectionExReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取异常巡检报告巡检数据mes_inspectexdetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionExReport/mesInspectionExDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInspectionExDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesInspectionExDetailList([FromQuery]MesInspectionExDetailEntity queryParams)
        {
            var list = await _iMesInspectionExDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取异常巡检报告巡检数据mes_inspectexdetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionExReport/mesInspectionExDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInspectionExDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesInspectionExDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInspectionExDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInspectionExDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取异常巡检报告巡检数据mes_inspectexdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionExReport/mesInspectionExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionExDetailEntity>), 200)]
        public async Task<IActionResult>GetMesInspectionExDetailEntity(string id)
        {
            var data = await _iMesInspectionExDetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inspectionExReport")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionExReportEntity>), 200)]
        public async Task<IActionResult>AddForm(InspectionExReportDto dto)
        {
            await _iMesInspectionExReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesInspectionExReportEntity);
        }
        /// <summary>
        /// 新增巡检异常报告mes_InspectionExReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inspectionExReport/mesInspectionExReport")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionExReportEntity>), 200)]
        public async Task<IActionResult>AddMesInspectionExReport(MesInspectionExReportEntity entity)
        {
            await _iMesInspectionExReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增异常巡检报告巡检数据mes_inspectexdetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inspectionExReport/mesInspectionExDetail")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionExDetailEntity>), 200)]
        public async Task<IActionResult>AddMesInspectionExDetail(MesInspectionExDetailEntity entity)
        {
            await _iMesInspectionExDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/inspectionExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,InspectionExReportDto dto)
        {
            await _iMesInspectionExReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新巡检异常报告mes_InspectionExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/inspectionExReport/mesInspectionExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesInspectionExReport(string id,MesInspectionExReportEntity entity)
        {
            await _iMesInspectionExReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新异常巡检报告巡检数据mes_inspectexdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/inspectionExReport/mesInspectionExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesInspectionExDetail(string id,MesInspectionExDetailEntity entity)
        {
            await _iMesInspectionExDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除巡检异常报告mes_InspectionExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesInspectionExReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除巡检异常报告mes_InspectionExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionExReport/mesInspectionExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionExReport(string id)
        {
            await _iMesInspectionExReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除异常巡检报告巡检数据mes_inspectexdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionExReport/mesInspectionExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionExDetail(string id)
        {
            await _iMesInspectionExDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除巡检异常报告mes_InspectionExReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionExReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesInspectionExReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除巡检异常报告mes_InspectionExReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionExReport/mesInspectionExReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionExReports(string ids)
        {
            await _iMesInspectionExReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除异常巡检报告巡检数据mes_inspectexdetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionExReport/mesInspectionExDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionExDetails(string ids)
        {
            await _iMesInspectionExDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}