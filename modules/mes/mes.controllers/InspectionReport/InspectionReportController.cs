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
    /// 日 期： 2023-08-29 16:23:56
    /// 描 述： 巡检报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class InspectionReportController : BaseApiController
    {
        private readonly IMesInspectionReportBLL _iMesInspectionReportBLL;
        private readonly IMesInspectionDetailBLL _iMesInspectionDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInspectionReportBLL">巡检报告接口</param>
        /// <param name="iMesInspectionDetailBLL">巡检报告巡检数据接口</param>
        public InspectionReportController(IMesInspectionReportBLL iMesInspectionReportBLL,IMesInspectionDetailBLL iMesInspectionDetailBLL)
        {
            _iMesInspectionReportBLL = iMesInspectionReportBLL?? throw new ArgumentNullException(nameof(iMesInspectionReportBLL));
            _iMesInspectionDetailBLL = iMesInspectionDetailBLL?? throw new ArgumentNullException(nameof(iMesInspectionDetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取巡检报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInspectionReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesInspectionReportEntity queryParams)
        {
            var list = await _iMesInspectionReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取巡检报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInspectionReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInspectionReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInspectionReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/inspectionReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<InspectionReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new InspectionReportDto();
            res.MesInspectionReportEntity = await _iMesInspectionReportBLL.GetEntity(id);
            if(res.MesInspectionReportEntity != null)
            {
                res.MesInspectionDetailList = await _iMesInspectionDetailBLL.GetList(new MesInspectionDetailEntity { F_InspectionId = res.MesInspectionReportEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionReport/mesInspectionReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionReportEntity>), 200)]
        public async Task<IActionResult>GetMesInspectionReportEntity(string id)
        {
            var data = await _iMesInspectionReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取巡检报告巡检数据mes_inspectdetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionReport/mesInspectionDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInspectionDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesInspectionDetailList([FromQuery]MesInspectionDetailEntity queryParams)
        {
            var list = await _iMesInspectionDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取巡检报告巡检数据mes_inspectdetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionReport/mesInspectionDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInspectionDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesInspectionDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInspectionDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInspectionDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取巡检报告巡检数据mes_inspectdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/inspectionReport/mesInspectionDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionDetailEntity>), 200)]
        public async Task<IActionResult>GetMesInspectionDetailEntity(string id)
        {
            var data = await _iMesInspectionDetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inspectionReport")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionReportEntity>), 200)]
        public async Task<IActionResult>AddForm(InspectionReportDto dto)
        {
            await _iMesInspectionReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesInspectionReportEntity);
        }
        /// <summary>
        /// 新增巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inspectionReport/mesInspectionReport")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionReportEntity>), 200)]
        public async Task<IActionResult>AddMesInspectionReport(MesInspectionReportEntity entity)
        {
            await _iMesInspectionReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增巡检报告巡检数据mes_inspectdetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inspectionReport/mesInspectionDetail")]
        [ProducesResponseType(typeof(ResponseDto<MesInspectionDetailEntity>), 200)]
        public async Task<IActionResult>AddMesInspectionDetail(MesInspectionDetailEntity entity)
        {
            await _iMesInspectionDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/inspectionReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,InspectionReportDto dto)
        {
            await _iMesInspectionReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/inspectionReport/mesInspectionReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesInspectionReport(string id,MesInspectionReportEntity entity)
        {
            await _iMesInspectionReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新巡检报告巡检数据mes_inspectdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/inspectionReport/mesInspectionDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesInspectionDetail(string id,MesInspectionDetailEntity entity)
        {
            await _iMesInspectionDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesInspectionReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionReport/mesInspectionReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionReport(string id)
        {
            await _iMesInspectionReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除巡检报告巡检数据mes_inspectdetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionReport/mesInspectionDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionDetail(string id)
        {
            await _iMesInspectionDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesInspectionReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除巡检报告mes_InspectionReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionReport/mesInspectionReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionReports(string ids)
        {
            await _iMesInspectionReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除巡检报告巡检数据mes_inspectdetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/inspectionReport/mesInspectionDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInspectionDetails(string ids)
        {
            await _iMesInspectionDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

      
    }
}