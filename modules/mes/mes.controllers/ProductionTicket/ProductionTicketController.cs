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
    /// 日 期： 2023-08-17 16:11:23
    /// 描 述： 生产工单
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProductionTicketController : BaseApiController
    {
        private readonly IMesProductionTicketBLL _iMesProductionTicketBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionTicketBLL">生产工单接口</param>
        public ProductionTicketController(IMesProductionTicketBLL iMesProductionTicketBLL)
        {
            _iMesProductionTicketBLL = iMesProductionTicketBLL?? throw new ArgumentNullException(nameof(iMesProductionTicketBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取生产工单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionTickets")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProductionTicketEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProductionTicketEntity queryParams)
        {
            var list = await _iMesProductionTicketBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取生产工单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionTicket/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionTicketEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProductionTicketEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionTicketBLL.GetPageList(pagination,queryParams);
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
        /// 获取生产工单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionTicket/GetPageListInprogress")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionTicketEntity>>), 200)]
        public async Task<IActionResult> GetPageListInprogress([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProductionTicketEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionTicketBLL.GetPageListInprogress(pagination, queryParams);
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
        /// 获取生产工单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionTicket/GetPageListProgress")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionTicketEntity>>), 200)]
        public async Task<IActionResult> GetPageListProgress([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProductionTicketEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionTicketBLL.GetPageListProgress(pagination, queryParams);
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
        [HttpGet("mes/productionTicket/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionTicketEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProductionTicketBLL.GetEntity(id);
            return Success(data);
        }

        /// <summary>
        /// 生产计划查看工单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/productionTicket/GetEntityBySchedule/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionTicketEntity>), 200)]
        public async Task<IActionResult> GetEntityBySchedule(string id)
        {
            var data = await _iMesProductionTicketBLL.GetEntityBySchedule(id);
            return Success(data);
        }

        /// <summary>
        /// 获取生产工单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionTicket/GetProductionList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionTicketEntity>>), 200)]
        public IActionResult GetProductionList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProductionTicketEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list =  _iMesProductionTicketBLL.GetProductionList(pagination, queryParams);
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
        ///  获取生成订单入库情况
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionTicket/GetWarehousingTicketList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionTicketEntity>>), 200)]
        public IActionResult GetWarehousingTicketList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProductionTicketEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var result= _iMesProductionTicketBLL.GetWarehousingTicketList(pagination, queryParams);
            var list = result.warehousingDetailsDTO;
            var jsonData = new
            {
                rows = list,
                result.Total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionTicketEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProductionTicketEntity entity)
        {
            await _iMesProductionTicketBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }
        /// <summary>
        /// 创建生产工单
        /// </summary>
        /// <param name="productionTicketSaveDTO">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket/CreateTicket")]
        [ProducesResponseType(typeof(ProductionTicketSaveDTO), 200)]
        public async Task<IActionResult> CreateTicket(ProductionTicketSaveDTO productionTicketSaveDTO)
        {
            await _iMesProductionTicketBLL.CreateTicket(productionTicketSaveDTO);
            return Success("创建工单成功！");
        }
        /// <summary>
        /// 生产工单开工
        /// </summary>
        /// <param name="startWork">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket/StartWork")]
        [ProducesResponseType(typeof(StartWorkDTO), 200)]
        public async Task<IActionResult> StartWork(StartWorkDTO startWork)
        {
            await _iMesProductionTicketBLL.StartWork(startWork);
            return Success("操作成功！");
        }
        /// <summary>
        /// 生产工单开工
        /// </summary>
        /// <param name="startWork">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket/EndWork")]
        [ProducesResponseType(typeof(StartWorkDTO), 200)]
        public async Task<IActionResult> EndWork(StartWorkDTO startWork)
        {
            await _iMesProductionTicketBLL.EndWork(startWork);
            return Success("操作成功！");
        }
        /// <summary>
        /// 暂停工单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket/PauseTicket/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> PauseTicket(string id)
        {
            await _iMesProductionTicketBLL.PauseTicket(id);
            return Success("暂停成功！");
        }
        /// <summary>
        /// 关闭工单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket/CloseTicket/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> CloseTicket(string id)
        {
            await _iMesProductionTicketBLL.CloseTicket(id);
            return Success("关闭成功！");
        }
        /// <summary>
        /// 生产工单恢复
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("mes/productionTicket/RestoreWork/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> RestoreWork(string id)
        {
            await _iMesProductionTicketBLL.RestoreWork(id);
            return Success("恢复成功！");
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/productionTicket/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProductionTicketEntity entity)
        {
            await _iMesProductionTicketBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除生产工单mes_ProductionTicket数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionTicket/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProductionTicketBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除生产工单mes_ProductionTicket数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionTicket/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProductionTicketBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}