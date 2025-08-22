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
    /// 日 期： 2023-08-30 17:03:50
    /// 描 述： 半成品检测报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class SemifinishedExReportController : BaseApiController
    {
        private readonly IMesSemifinishedExReportBLL _iMesSemifinishedExReportBLL;
        private readonly IMesSemifinishedExDetailBLL _iMesSemifinishedExDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesSemifinishedExReportBLL">半成品校验异常报告接口</param>
        /// <param name="iMesSemifinishedExDetailBLL">半成品校验异常数据接口</param>
        public SemifinishedExReportController(IMesSemifinishedExReportBLL iMesSemifinishedExReportBLL,IMesSemifinishedExDetailBLL iMesSemifinishedExDetailBLL)
        {
            _iMesSemifinishedExReportBLL = iMesSemifinishedExReportBLL?? throw new ArgumentNullException(nameof(iMesSemifinishedExReportBLL));
            _iMesSemifinishedExDetailBLL = iMesSemifinishedExDetailBLL?? throw new ArgumentNullException(nameof(iMesSemifinishedExDetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取半成品检测报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedExReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesSemifinishedExReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesSemifinishedExReportEntity queryParams)
        {
            var list = await _iMesSemifinishedExReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取半成品检测报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedExReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesSemifinishedExReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesSemifinishedExReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesSemifinishedExReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/semifinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SemifinishedExReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new SemifinishedExReportDto();
            res.MesSemifinishedExReportEntity = await _iMesSemifinishedExReportBLL.GetEntity(id);
            if(res.MesSemifinishedExReportEntity != null)
            {
                res.MesSemifinishedExDetailList = await _iMesSemifinishedExDetailBLL.GetList(new MesSemifinishedExDetailEntity { F_SemifinishedExId = res.MesSemifinishedExReportEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedExReport/mesSemifinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedExReportEntity>), 200)]
        public async Task<IActionResult>GetMesSemifinishedExReportEntity(string id)
        {
            var data = await _iMesSemifinishedExReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取半成品校验异常数据mes_SemifinishedExDetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedExReport/mesSemifinishedExDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesSemifinishedExDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesSemifinishedExDetailList([FromQuery]MesSemifinishedExDetailEntity queryParams)
        {
            var list = await _iMesSemifinishedExDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取半成品校验异常数据mes_SemifinishedExDetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedExReport/mesSemifinishedExDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesSemifinishedExDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesSemifinishedExDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesSemifinishedExDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesSemifinishedExDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取半成品校验异常数据mes_SemifinishedExDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedExReport/mesSemifinishedExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedExDetailEntity>), 200)]
        public async Task<IActionResult>GetMesSemifinishedExDetailEntity(string id)
        {
            var data = await _iMesSemifinishedExDetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/semifinishedExReport")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedExReportEntity>), 200)]
        public async Task<IActionResult>AddForm(SemifinishedExReportDto dto)
        {
            await _iMesSemifinishedExReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesSemifinishedExReportEntity);
        }
        /// <summary>
        /// 新增半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/semifinishedExReport/mesSemifinishedExReport")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedExReportEntity>), 200)]
        public async Task<IActionResult>AddMesSemifinishedExReport(MesSemifinishedExReportEntity entity)
        {
            await _iMesSemifinishedExReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增半成品校验异常数据mes_SemifinishedExDetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/semifinishedExReport/mesSemifinishedExDetail")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedExDetailEntity>), 200)]
        public async Task<IActionResult>AddMesSemifinishedExDetail(MesSemifinishedExDetailEntity entity)
        {
            await _iMesSemifinishedExDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/semifinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,SemifinishedExReportDto dto)
        {
            await _iMesSemifinishedExReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/semifinishedExReport/mesSemifinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesSemifinishedExReport(string id,MesSemifinishedExReportEntity entity)
        {
            await _iMesSemifinishedExReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新半成品校验异常数据mes_SemifinishedExDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/semifinishedExReport/mesSemifinishedExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesSemifinishedExDetail(string id,MesSemifinishedExDetailEntity entity)
        {
            await _iMesSemifinishedExDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesSemifinishedExReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedExReport/mesSemifinishedExReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedExReport(string id)
        {
            await _iMesSemifinishedExReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除半成品校验异常数据mes_SemifinishedExDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedExReport/mesSemifinishedExDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedExDetail(string id)
        {
            await _iMesSemifinishedExDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedExReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesSemifinishedExReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除半成品校验异常报告mes_SemifinishedExReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedExReport/mesSemifinishedExReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedExReports(string ids)
        {
            await _iMesSemifinishedExReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除半成品校验异常数据mes_SemifinishedExDetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedExReport/mesSemifinishedExDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedExDetails(string ids)
        {
            await _iMesSemifinishedExDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}