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
    /// 日 期： 2023-08-07 13:29:09
    /// 描 述： 工艺路线管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessRouteController : BaseApiController
    {
        private readonly IMesProcessRouteBLL _iMesProcessRouteBLL;
        private readonly IMesProceNodeRouteBLL _iMesProceNodeRouteBLL;
        private readonly IMesProcessLineRouteBLL _iMesProcessLineRouteBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessRouteBLL">工艺路线管理接口</param>
        /// <param name="iMesProceNodeRouteBLL">null接口</param>
        /// <param name="iMesProcessLineRouteBLL">工艺路线线条接口</param>
        public ProcessRouteController(IMesProcessRouteBLL iMesProcessRouteBLL,IMesProceNodeRouteBLL iMesProceNodeRouteBLL,IMesProcessLineRouteBLL iMesProcessLineRouteBLL)
        {
            _iMesProcessRouteBLL = iMesProcessRouteBLL?? throw new ArgumentNullException(nameof(iMesProcessRouteBLL));
            _iMesProceNodeRouteBLL = iMesProceNodeRouteBLL?? throw new ArgumentNullException(nameof(iMesProceNodeRouteBLL));
            _iMesProcessLineRouteBLL = iMesProcessLineRouteBLL?? throw new ArgumentNullException(nameof(iMesProcessLineRouteBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工艺路线管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoutes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessRouteEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessRouteEntity queryParams)
        {
            var list = await _iMesProcessRouteBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工艺路线管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessRouteEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessRouteEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessRouteBLL.GetPageList(pagination,queryParams);
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
        /// 根据物料编码获取工艺路线
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/GetPageByCode")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessRouteEntity>>), 200)]
        public async Task<IActionResult> GetPageByCode([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProcessRouteEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list =await _iMesProcessRouteBLL.GetPageAllList(pagination, queryParams);
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
        [HttpGet("mes/processRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ProcessRouteDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new ProcessRouteDto();
            res.F_ProcessRouteId = id;
            if(res.F_ProcessRouteId != null)
            {
                res.nodes = await _iMesProceNodeRouteBLL.GetList(new MesProceNodeRouteEntity { F_ProcessRouteId = res.F_ProcessRouteId });
                res.edges = await _iMesProcessLineRouteBLL.GetList(new MesProcessLineRouteEntity { F_ProcessRouteId = res.F_ProcessRouteId });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProcessRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessRouteEntity>), 200)]
        public async Task<IActionResult>GetMesProcessRouteEntity(string id)
        {
            var data = await _iMesProcessRouteBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取nullmes_ProceNodeRoute的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProceNodeRoutes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProceNodeRouteEntity>>), 200)]
        public async Task<IActionResult> GetMesProceNodeRouteList([FromQuery]MesProceNodeRouteEntity queryParams)
        {
            var list = await _iMesProceNodeRouteBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取nullmes_ProceNodeRoute的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProceNodeRoute/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProceNodeRouteEntity>>), 200)]
        public async Task<IActionResult> GetMesProceNodeRoutePageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProceNodeRouteEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProceNodeRouteBLL.GetPageList(pagination,queryParams);
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
        /// 获取nullmes_ProceNodeRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProceNodeRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProceNodeRouteEntity>), 200)]
        public async Task<IActionResult>GetMesProceNodeRouteEntity(string id)
        {
            var data = await _iMesProceNodeRouteBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取工艺路线
        /// </summary>
        /// <param name="code">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProceNodeRoute/getRouteByCode/{code}")]
        [ProducesResponseType(typeof(ResponseDto<MesProceNodeRouteEntity>), 200)]
        public async Task<IActionResult> GETListByCode(string code)
        {
            var data = await _iMesProcessRouteBLL.GETListByCode(code);
            return Success(data);
        }
        /// <summary>
        /// 获取工艺路线线条mes_ProcessLineRoute的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProcessLineRoutes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessLineRouteEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessLineRouteList([FromQuery]MesProcessLineRouteEntity queryParams)
        {
            var list = await _iMesProcessLineRouteBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工艺路线线条mes_ProcessLineRoute的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProcessLineRoute/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessLineRouteEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessLineRoutePageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessLineRouteEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessLineRouteBLL.GetPageList(pagination,queryParams);
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
        /// 获取工艺路线线条mes_ProcessLineRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processRoute/mesProcessLineRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessLineRouteEntity>), 200)]
        public async Task<IActionResult>GetMesProcessLineRouteEntity(string id)
        {
            var data = await _iMesProcessLineRouteBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processRoute")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessRouteEntity>), 200)]
        public async Task<IActionResult>AddForm(ProcessRouteDto dto)
        {
            await _iMesProcessRouteBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.F_ProcessRouteId);
        }

        /// <summary>
        /// 新增工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processRoute/mesProcessRoute")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessRouteEntity>), 200)]
        public async Task<IActionResult>AddMesProcessRoute(MesProcessRouteEntity entity)
        {
            await _iMesProcessRouteBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增nullmes_ProceNodeRoute数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processRoute/mesProceNodeRoute")]
        [ProducesResponseType(typeof(ResponseDto<MesProceNodeRouteEntity>), 200)]
        public async Task<IActionResult>AddMesProceNodeRoute(MesProceNodeRouteEntity entity)
        {
            await _iMesProceNodeRouteBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增工艺路线线条mes_ProcessLineRoute数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processRoute/mesProcessLineRoute")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessLineRouteEntity>), 200)]
        public async Task<IActionResult>AddMesProcessLineRoute(MesProcessLineRouteEntity entity)
        {
            await _iMesProcessLineRouteBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }

        /// <summary>
        /// 改变产品下的工艺路线的常用状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("mes/processRoute/SetCmmon")]
        [ProducesResponseType(typeof(ResponseDto<CommonInfoDTO>), 200)]
        public async Task<IActionResult> SetCmmon(CommonInfoDTO dto)
        {
            await _iMesProcessRouteBLL.SetCmmon(dto);
            return Success("设置成功！");
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/processRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,ProcessRouteDto dto)
        {
            await _iMesProcessRouteBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processRoute/mesProcessRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProcessRoute(string id,MesProcessRouteEntity entity)
        {
            await _iMesProcessRouteBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新nullmes_ProceNodeRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processRoute/mesProceNodeRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProceNodeRoute(string id,MesProceNodeRouteEntity entity)
        {
            await _iMesProceNodeRouteBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新工艺路线线条mes_ProcessLineRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processRoute/mesProcessLineRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProcessLineRoute(string id,MesProcessLineRouteEntity entity)
        {
            await _iMesProcessLineRouteBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessRouteBLL.DeleteAll(id);
            return Success("删除成功！");
        }

        /// <summary>
        /// 删除工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/children/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteChildForm(string id)
        {
            await _iMesProcessRouteBLL.DeleteChildrenAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/mesProcessRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessRoute(string id)
        {
            await _iMesProcessRouteBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除nullmes_ProceNodeRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/mesProceNodeRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProceNodeRoute(string id)
        {
            await _iMesProceNodeRouteBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除工艺路线线条mes_ProcessLineRoute数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/mesProcessLineRoute/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessLineRoute(string id)
        {
            await _iMesProcessLineRouteBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessRouteBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除工艺路线管理mes_ProcessRoute数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/mesProcessRoute/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessRoutes(string ids)
        {
            await _iMesProcessRouteBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除nullmes_ProceNodeRoute数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/mesProceNodeRoute/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProceNodeRoutes(string ids)
        {
            await _iMesProceNodeRouteBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除工艺路线线条mes_ProcessLineRoute数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processRoute/mesProcessLineRoute/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessLineRoutes(string ids)
        {
            await _iMesProcessLineRouteBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}