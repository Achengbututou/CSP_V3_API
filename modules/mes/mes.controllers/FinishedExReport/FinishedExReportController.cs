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
    /// 日 期： 2023-08-31 10:20:45
    /// 描 述： 成品异常报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class FinishedExReportController : BaseApiController
    {
        private readonly IMesFinishedExReportBLL _iMesFinishedExReportBLL;
        private readonly IMesFinishedExDetailBLL _iMesFinishedExDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFinishedExReportBLL">成品校验异常报告接口</param>
        /// <param name="iMesFinishedExDetailBLL">成品校验异常数据接口</param>
        public FinishedExReportController(IMesFinishedExReportBLL iMesFinishedExReportBLL,IMesFinishedExDetailBLL iMesFinishedExDetailBLL)
        {
            _iMesFinishedExReportBLL = iMesFinishedExReportBLL?? throw new ArgumentNullException(nameof(iMesFinishedExReportBLL));
            _iMesFinishedExDetailBLL = iMesFinishedExDetailBLL?? throw new ArgumentNullException(nameof(iMesFinishedExDetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取成品异常报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesFinishedExReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesFinishedExReportEntity queryParams)
        {
            var list = await _iMesFinishedExReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取成品异常报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesFinishedExReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesFinishedExReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesFinishedExReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/finishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<FinishedExReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new FinishedExReportDto();
            res.MesFinishedExReportEntity = await _iMesFinishedExReportBLL.GetEntity(id);
            if(res.MesFinishedExReportEntity != null)
            {
                res.MesFinishedExDetailList = await _iMesFinishedExDetailBLL.GetList(new MesFinishedExDetailEntity { F_FinishedExId = res.MesFinishedExReportEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReport/mesFinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedExReportEntity>), 200)]
        public async Task<IActionResult>GetMesFinishedExReportEntity(string id)
        {
            var data = await _iMesFinishedExReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取成品校验异常数据mes_FinishedExDetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReport/mesFinishedExDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesFinishedExDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesFinishedExDetailList([FromQuery]MesFinishedExDetailEntity queryParams)
        {
            var list = await _iMesFinishedExDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取成品校验异常数据mes_FinishedExDetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReport/mesFinishedExDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesFinishedExDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesFinishedExDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesFinishedExDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesFinishedExDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取成品校验异常数据mes_FinishedExDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReport/mesFinishedExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedExDetailEntity>), 200)]
        public async Task<IActionResult>GetMesFinishedExDetailEntity(string id)
        {
            var data = await _iMesFinishedExDetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/finishedExReport")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedExReportEntity>), 200)]
        public async Task<IActionResult>AddForm(FinishedExReportDto dto)
        {
            await _iMesFinishedExReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesFinishedExReportEntity);
        }
        /// <summary>
        /// 新增成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/finishedExReport/mesFinishedExReport")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedExReportEntity>), 200)]
        public async Task<IActionResult>AddMesFinishedExReport(MesFinishedExReportEntity entity)
        {
            await _iMesFinishedExReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增成品校验异常数据mes_FinishedExDetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/finishedExReport/mesFinishedExDetail")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedExDetailEntity>), 200)]
        public async Task<IActionResult>AddMesFinishedExDetail(MesFinishedExDetailEntity entity)
        {
            await _iMesFinishedExDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/finishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,FinishedExReportDto dto)
        {
            await _iMesFinishedExReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/finishedExReport/mesFinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesFinishedExReport(string id,MesFinishedExReportEntity entity)
        {
            await _iMesFinishedExReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新成品校验异常数据mes_FinishedExDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/finishedExReport/mesFinishedExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesFinishedExDetail(string id,MesFinishedExDetailEntity entity)
        {
            await _iMesFinishedExDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesFinishedExReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedExReport/mesFinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedExReport(string id)
        {
            await _iMesFinishedExReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除成品校验异常数据mes_FinishedExDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedExReport/mesFinishedExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedExDetail(string id)
        {
            await _iMesFinishedExDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedExReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesFinishedExReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除成品校验异常报告mes_FinishedExReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedExReport/mesFinishedExReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedExReports(string ids)
        {
            await _iMesFinishedExReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除成品校验异常数据mes_FinishedExDetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedExReport/mesFinishedExDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedExDetails(string ids)
        {
            await _iMesFinishedExDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展 获取检测报表统计数据

        /// <summary>
        /// 获取异常检测报表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedExReport/mesFinishedExDetail/GetExceptionReportList")]
        [ProducesResponseType(typeof(PaginationOutputDto<List<ExceptionReportDTO>>), 200)]
        public IActionResult GetExceptionReportList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesFinishedExDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list =  _iMesFinishedExDetailBLL.GetExceptionReportList(pagination, queryParams);
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