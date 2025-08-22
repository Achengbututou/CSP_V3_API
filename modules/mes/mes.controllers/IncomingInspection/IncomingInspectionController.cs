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
    /// 日 期： 2023-08-23 09:44:54
    /// 描 述： 来料检验报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class IncomingInspectionController : BaseApiController
    {
        private readonly IMesIncomingInspectionBLL _iMesIncomingInspectionBLL;
        private readonly IMesIncomingByOrderBLL _iMesIncomingByOrderBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesIncomingInspectionBLL">来料检验报告接口</param>
        /// <param name="iMesIncomingByOrderBLL">来料检验报告按单检验接口</param>
        public IncomingInspectionController(IMesIncomingInspectionBLL iMesIncomingInspectionBLL,IMesIncomingByOrderBLL iMesIncomingByOrderBLL)
        {
            _iMesIncomingInspectionBLL = iMesIncomingInspectionBLL?? throw new ArgumentNullException(nameof(iMesIncomingInspectionBLL));
            _iMesIncomingByOrderBLL = iMesIncomingByOrderBLL?? throw new ArgumentNullException(nameof(iMesIncomingByOrderBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取来料检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspections")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesIncomingInspectionEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesIncomingInspectionEntity queryParams)
        {
            var list = await _iMesIncomingInspectionBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取来料检验报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspection/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesIncomingInspectionEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesIncomingInspectionEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesIncomingInspectionBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/incomingInspection/{id}")]
        [ProducesResponseType(typeof(ResponseDto<IncomingInspectionDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new IncomingInspectionDto();
            res.MesIncomingInspectionEntity = await _iMesIncomingInspectionBLL.GetEntity(id);
            if(res.MesIncomingInspectionEntity != null)
            {
                res.MesIncomingByOrderList = await _iMesIncomingByOrderBLL.GetList(new MesIncomingByOrderEntity { F_IncomingInspectionId = res.MesIncomingInspectionEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspection/mesIncomingInspection/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesIncomingInspectionEntity>), 200)]
        public async Task<IActionResult>GetMesIncomingInspectionEntity(string id)
        {
            var data = await _iMesIncomingInspectionBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取来料检验报告按单检验mes_IncomingByOrder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspection/mesIncomingByOrders")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesIncomingByOrderEntity>>), 200)]
        public async Task<IActionResult> GetMesIncomingByOrderList([FromQuery]MesIncomingByOrderEntity queryParams)
        {
            var list = await _iMesIncomingByOrderBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取来料检验报告按单检验mes_IncomingByOrder的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspection/mesIncomingByOrder/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesIncomingByOrderEntity>>), 200)]
        public async Task<IActionResult> GetMesIncomingByOrderPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesIncomingByOrderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesIncomingByOrderBLL.GetPageList(pagination,queryParams);
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
        /// 获取来料检验报告按单检验mes_IncomingByOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspection/mesIncomingByOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesIncomingByOrderEntity>), 200)]
        public async Task<IActionResult>GetMesIncomingByOrderEntity(string id)
        {
            var data = await _iMesIncomingByOrderBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/incomingInspection")]
        [ProducesResponseType(typeof(ResponseDto<MesIncomingInspectionEntity>), 200)]
        public async Task<IActionResult>AddForm(IncomingInspectionDto dto)
        {
            await _iMesIncomingInspectionBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesIncomingInspectionEntity);
        }
        /// <summary>
        /// 新增来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/incomingInspection/mesIncomingInspection")]
        [ProducesResponseType(typeof(ResponseDto<MesIncomingInspectionEntity>), 200)]
        public async Task<IActionResult>AddMesIncomingInspection(MesIncomingInspectionEntity entity)
        {
            await _iMesIncomingInspectionBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增来料检验报告按单检验mes_IncomingByOrder数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/incomingInspection/mesIncomingByOrder")]
        [ProducesResponseType(typeof(ResponseDto<MesIncomingByOrderEntity>), 200)]
        public async Task<IActionResult>AddMesIncomingByOrder(MesIncomingByOrderEntity entity)
        {
            await _iMesIncomingByOrderBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/incomingInspection/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,IncomingInspectionDto dto)
        {
            await _iMesIncomingInspectionBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/incomingInspection/mesIncomingInspection/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesIncomingInspection(string id,MesIncomingInspectionEntity entity)
        {
            await _iMesIncomingInspectionBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新来料检验报告按单检验mes_IncomingByOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/incomingInspection/mesIncomingByOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesIncomingByOrder(string id,MesIncomingByOrderEntity entity)
        {
            await _iMesIncomingByOrderBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingInspection/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesIncomingInspectionBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingInspection/mesIncomingInspection/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesIncomingInspection(string id)
        {
            await _iMesIncomingInspectionBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除来料检验报告按单检验mes_IncomingByOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingInspection/mesIncomingByOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesIncomingByOrder(string id)
        {
            await _iMesIncomingByOrderBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingInspection/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesIncomingInspectionBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除来料检验报告mes_incominginspect数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingInspection/mesIncomingInspection/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesIncomingInspections(string ids)
        {
            await _iMesIncomingInspectionBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除来料检验报告按单检验mes_IncomingByOrder数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingInspection/mesIncomingByOrder/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesIncomingByOrders(string ids)
        {
            await _iMesIncomingByOrderBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion


        #region 扩展 获取检测报告数据
        /// <summary>
        /// 获取巡检报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingInspection/GetReportList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesIncomingInspectionEntity>>), 200)]
        public IActionResult GetReportList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesIncomingInspectionEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var dataList = _iMesIncomingInspectionBLL.GetReportList(pagination, queryParams);
            var list = dataList.inpertionReport;
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