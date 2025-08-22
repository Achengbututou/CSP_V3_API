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
    /// 日 期： 2023-08-30 17:20:47
    /// 描 述： 成品检验报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class FinishedReportController : BaseApiController
    {
        private readonly IMesFinishedReportBLL _iMesFinishedReportBLL;
        private readonly IMesFinishedDetailBLL _iMesFinishedDetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFinishedReportBLL">成品检验报告接口</param>
        /// <param name="iMesFinishedDetailBLL">成品检验数据接口</param>
        public FinishedReportController(IMesFinishedReportBLL iMesFinishedReportBLL,IMesFinishedDetailBLL iMesFinishedDetailBLL)
        {
            _iMesFinishedReportBLL = iMesFinishedReportBLL?? throw new ArgumentNullException(nameof(iMesFinishedReportBLL));
            _iMesFinishedDetailBLL = iMesFinishedDetailBLL?? throw new ArgumentNullException(nameof(iMesFinishedDetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取成品检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesFinishedReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesFinishedReportEntity queryParams)
        {
            var list = await _iMesFinishedReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取成品检验报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesFinishedReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesFinishedReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesFinishedReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/finishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<FinishedReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new FinishedReportDto();
            res.MesFinishedReportEntity = await _iMesFinishedReportBLL.GetEntity(id);
            if(res.MesFinishedReportEntity != null)
            {
                res.MesFinishedDetailList = await _iMesFinishedDetailBLL.GetList(new MesFinishedDetailEntity { F_FinishedId = res.MesFinishedReportEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReport/mesFinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedReportEntity>), 200)]
        public async Task<IActionResult>GetMesFinishedReportEntity(string id)
        {
            var data = await _iMesFinishedReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取成品检验数据mes_FinishedDetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReport/mesFinishedDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesFinishedDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesFinishedDetailList([FromQuery]MesFinishedDetailEntity queryParams)
        {
            var list = await _iMesFinishedDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取成品检验数据mes_FinishedDetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReport/mesFinishedDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesFinishedDetailEntity>>), 200)]
        public async Task<IActionResult> GetMesFinishedDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesFinishedDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesFinishedDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取成品检验数据mes_FinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReport/mesFinishedDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedDetailEntity>), 200)]
        public async Task<IActionResult>GetMesFinishedDetailEntity(string id)
        {
            var data = await _iMesFinishedDetailBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取成品检验数据mes_FinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/finishedReport/Workflow/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedDetailEntity>), 200)]
        public async Task<IActionResult> GetMesFinishedWorkflow(string id)
        {
            var data = await _iMesFinishedDetailBLL.GetEntity(id);
            var res = new FinishedReportDto();
            if (data != null)
            {
                res.MesFinishedReportEntity = await _iMesFinishedReportBLL.GetEntity(data.F_FinishedId);
                if (res.MesFinishedReportEntity != null)
                {
                    res.MesFinishedDetailList = await _iMesFinishedDetailBLL.GetList(new MesFinishedDetailEntity { F_FinishedId = res.MesFinishedReportEntity.F_Id });
                }
            }
            return Success(res);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/finishedReport")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedReportEntity>), 200)]
        public async Task<IActionResult>AddForm(FinishedReportDto dto)
        {
            await _iMesFinishedReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesFinishedReportEntity);
        }
        /// <summary>
        /// 新增成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/finishedReport/mesFinishedReport")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedReportEntity>), 200)]
        public async Task<IActionResult>AddMesFinishedReport(MesFinishedReportEntity entity)
        {
            await _iMesFinishedReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增成品检验数据mes_FinishedDetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/finishedReport/mesFinishedDetail")]
        [ProducesResponseType(typeof(ResponseDto<MesFinishedDetailEntity>), 200)]
        public async Task<IActionResult>AddMesFinishedDetail(MesFinishedDetailEntity entity)
        {
            await _iMesFinishedDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/finishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,FinishedReportDto dto)
        {
            await _iMesFinishedReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/finishedReport/mesFinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesFinishedReport(string id,MesFinishedReportEntity entity)
        {
            await _iMesFinishedReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新成品检验数据mes_FinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/finishedReport/mesFinishedDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesFinishedDetail(string id,MesFinishedDetailEntity entity)
        {
            await _iMesFinishedDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesFinishedReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedReport/mesFinishedReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedReport(string id)
        {
            await _iMesFinishedReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除成品检验数据mes_FinishedDetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedReport/mesFinishedDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedDetail(string id)
        {
            await _iMesFinishedDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesFinishedReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除成品检验报告mes_FinishedReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedReport/mesFinishedReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedReports(string ids)
        {
            await _iMesFinishedReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除成品检验数据mes_FinishedDetail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/finishedReport/mesFinishedDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFinishedDetails(string ids)
        {
            await _iMesFinishedDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}