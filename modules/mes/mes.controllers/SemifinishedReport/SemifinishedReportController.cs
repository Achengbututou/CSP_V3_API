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
    /// 日 期： 2023-08-30 16:25:57
    /// 描 述： 半成品检验报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class SemifinishedReportController : BaseApiController
    {
        private readonly IMesSemifinishedReportBLL _iMesSemifinishedReportBLL;
        private readonly IMesSemifinishedDetailBLL _iMesSemifinishedDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesSemifinishedReportBLL">半成品检验报告接口</param>
        /// <param name="iMesSemifinishedDetailBLL">半成品检验数据接口</param>
        public SemifinishedReportController(IMesSemifinishedReportBLL iMesSemifinishedReportBLL,IMesSemifinishedDetailBLL iMesSemifinishedDetailBLL)
        {
            _iMesSemifinishedReportBLL = iMesSemifinishedReportBLL?? throw new ArgumentNullException(nameof(iMesSemifinishedReportBLL));
            _iMesSemifinishedDetailBLL = iMesSemifinishedDetailBLL?? throw new ArgumentNullException(nameof(iMesSemifinishedDetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取半成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesSemifinishedReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesSemifinishedReportEntity queryParams)
        {
            var list = await _iMesSemifinishedReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取半成品检验报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesSemifinishedReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesSemifinishedReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesSemifinishedReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/semifinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SemifinishedReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new SemifinishedReportDto();
            res.MesSemifinishedReportEntity = await _iMesSemifinishedReportBLL.GetEntity(id);
            if(res.MesSemifinishedReportEntity != null)
            {
                res.MesSemifinishedDetailList = await _iMesSemifinishedDetailBLL.GetList(new MesSemifinishedDetailEntity { F_SemifinishedId = res.MesSemifinishedReportEntity.F_Id });
            }
            return Success(res);
        }

        /// <summary>
        /// 获取页面工作流表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReport/Workflow/{id}")]
        [ProducesResponseType(typeof(ResponseDto<SemifinishedReportDto>), 200)]
        public async Task<IActionResult> GetWorkflowForm(string id)
        {
            var res = new SemifinishedReportDto();
            var data = await _iMesSemifinishedDetailBLL.GetEntity(id);
            if(data != null)
            {
                res.MesSemifinishedReportEntity = await _iMesSemifinishedReportBLL.GetEntity(data.F_SemifinishedId);
                if (res.MesSemifinishedReportEntity != null)
                {
                    res.MesSemifinishedDetailList = await _iMesSemifinishedDetailBLL.GetList(new MesSemifinishedDetailEntity { F_SemifinishedId = res.MesSemifinishedReportEntity.F_Id });
                }
            }
            return Success(res);
        }
        /// <summary>
        /// 获取半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReport/mesSemifinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedReportEntity>), 200)]
        public async Task<IActionResult>GetMesSemifinishedReportEntity(string id)
        {
            var data = await _iMesSemifinishedReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取半成品检验数据mes_SemifinishedDetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReport/mesSemifinishedDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesSemifinishedDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesSemifinishedDetailList([FromQuery]MesSemifinishedDetailEntity queryParams)
        {
            var list = await _iMesSemifinishedDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取半成品检验数据mes_SemifinishedDetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReport/mesSemifinishedDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesSemifinishedDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesSemifinishedDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesSemifinishedDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesSemifinishedDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取半成品检验数据mes_SemifinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/semifinishedReport/mesSemifinishedDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedDetailEntity>), 200)]
        public async Task<IActionResult>GetMesSemifinishedDetailEntity(string id)
        {
            var data = await _iMesSemifinishedDetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/semifinishedReport")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedReportEntity>), 200)]
        public async Task<IActionResult>AddForm(SemifinishedReportDto dto)
        {
            await _iMesSemifinishedReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesSemifinishedReportEntity);
        }
        /// <summary>
        /// 新增半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/semifinishedReport/mesSemifinishedReport")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedReportEntity>), 200)]
        public async Task<IActionResult>AddMesSemifinishedReport(MesSemifinishedReportEntity entity)
        {
            await _iMesSemifinishedReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增半成品检验数据mes_SemifinishedDetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/semifinishedReport/mesSemifinishedDetail")]
        [ProducesResponseType(typeof(ResponseDto<MesSemifinishedDetailEntity>), 200)]
        public async Task<IActionResult>AddMesSemifinishedDetail(MesSemifinishedDetailEntity entity)
        {
            await _iMesSemifinishedDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/semifinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,SemifinishedReportDto dto)
        {
            await _iMesSemifinishedReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/semifinishedReport/mesSemifinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesSemifinishedReport(string id,MesSemifinishedReportEntity entity)
        {
            await _iMesSemifinishedReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新半成品检验数据mes_SemifinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/semifinishedReport/mesSemifinishedDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesSemifinishedDetail(string id,MesSemifinishedDetailEntity entity)
        {
            await _iMesSemifinishedDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesSemifinishedReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedReport/mesSemifinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedReport(string id)
        {
            await _iMesSemifinishedReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除半成品检验数据mes_SemifinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedReport/mesSemifinishedDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedDetail(string id)
        {
            await _iMesSemifinishedDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesSemifinishedReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除半成品检验报告mes_SemifinishedReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedReport/mesSemifinishedReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedReports(string ids)
        {
            await _iMesSemifinishedReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除半成品检验数据mes_SemifinishedDetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/semifinishedReport/mesSemifinishedDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesSemifinishedDetails(string ids)
        {
            await _iMesSemifinishedDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}