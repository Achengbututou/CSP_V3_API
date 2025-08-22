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
    /// 日 期： 2023-09-06 09:56:11
    /// 描 述： 出库管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class OutboundInfoController : BaseApiController
    {
        private readonly IMesOutboundInfoBLL _iMesOutboundInfoBLL;
        private readonly IMesOutboundDetailsBLL _iMesOutboundDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesOutboundInfoBLL">出库信息接口</param>
        /// <param name="iMesOutboundDetailsBLL">出库物品接口</param>
        public OutboundInfoController(IMesOutboundInfoBLL iMesOutboundInfoBLL,IMesOutboundDetailsBLL iMesOutboundDetailsBLL)
        {
            _iMesOutboundInfoBLL = iMesOutboundInfoBLL?? throw new ArgumentNullException(nameof(iMesOutboundInfoBLL));
            _iMesOutboundDetailsBLL = iMesOutboundDetailsBLL?? throw new ArgumentNullException(nameof(iMesOutboundDetailsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取出库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesOutboundInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesOutboundInfoEntity queryParams)
        {
            var list = await _iMesOutboundInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取出库管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesOutboundInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesOutboundInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesOutboundInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/outboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<OutboundInfoDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new OutboundInfoDto();
            res.MesOutboundInfoEntity = await _iMesOutboundInfoBLL.GetEntity(id);
            if(res.MesOutboundInfoEntity != null)
            {
                res.MesOutboundDetailsList = await _iMesOutboundDetailsBLL.GetList(new MesOutboundDetailsEntity { F_OutboundInfoId = res.MesOutboundInfoEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/mesOutboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesOutboundInfoEntity>), 200)]
        public async Task<IActionResult>GetMesOutboundInfoEntity(string id)
        {
            var data = await _iMesOutboundInfoBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取出库物品mes_OutboundDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/mesOutboundDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesOutboundDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesOutboundDetailsList([FromQuery]MesOutboundDetailsEntity queryParams)
        {
            var list = await _iMesOutboundDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取出库物品mes_OutboundDetails的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/mesOutboundDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesOutboundDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesOutboundDetailsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesOutboundDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesOutboundDetailsBLL.GetPageList(pagination,queryParams);
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
        /// 获取出库物品mes_OutboundDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/mesOutboundDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesOutboundDetailsEntity>), 200)]
        public async Task<IActionResult>GetMesOutboundDetailsEntity(string id)
        {
            var data = await _iMesOutboundDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/outboundInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesOutboundInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(OutboundInfoDto dto)
        {
            await _iMesOutboundInfoBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesOutboundInfoEntity);
        }
        /// <summary>
        /// 新增出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/outboundInfo/mesOutboundInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesOutboundInfoEntity>), 200)]
        public async Task<IActionResult>AddMesOutboundInfo(MesOutboundInfoEntity entity)
        {
            await _iMesOutboundInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增出库物品mes_OutboundDetails数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/outboundInfo/mesOutboundDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesOutboundDetailsEntity>), 200)]
        public async Task<IActionResult>AddMesOutboundDetails(MesOutboundDetailsEntity entity)
        {
            await _iMesOutboundDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/outboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,OutboundInfoDto dto)
        {
            await _iMesOutboundInfoBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/outboundInfo/mesOutboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesOutboundInfo(string id,MesOutboundInfoEntity entity)
        {
            await _iMesOutboundInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新出库物品mes_OutboundDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/outboundInfo/mesOutboundDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesOutboundDetails(string id,MesOutboundDetailsEntity entity)
        {
            await _iMesOutboundDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/outboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesOutboundInfoBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/outboundInfo/mesOutboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesOutboundInfo(string id)
        {
            await _iMesOutboundInfoBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除出库物品mes_OutboundDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/outboundInfo/mesOutboundDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesOutboundDetails(string id)
        {
            await _iMesOutboundDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/outboundInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesOutboundInfoBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除出库信息mes_OutboundInfo数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/outboundInfo/mesOutboundInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesOutboundInfos(string ids)
        {
            await _iMesOutboundInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除出库物品mes_OutboundDetails数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/outboundInfo/mesOutboundDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesOutboundDetailss(string ids)
        {
            await _iMesOutboundDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法 
        /// <summary>
        /// 获取生产订单物料详情
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/GETProductionTicketPList")]
        [ProducesResponseType(typeof(PaginationOutputDto<List<OutBoundProductInfoDTO>>), 200)]
        public  IActionResult GETProductionTicketPList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesOutboundDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list =  _iMesOutboundDetailsBLL.GETProductionTicketPList(pagination, queryParams);
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
        /// 获取采购订单产品详细含已入库数量
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/GetPurchasedetailList")]
        [ProducesResponseType(typeof(PaginationOutputDto<List<OutBoundProductInfoDTO>>), 200)]
        public IActionResult GetPurchasedetailList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesOutboundDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = _iMesOutboundDetailsBLL.GetPurchasedetailList(pagination, queryParams);
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
        /// 获取销售订单产品详细含已入库数量
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/GetSalesDetailList")]
        [ProducesResponseType(typeof(PaginationOutputDto<List<OutBoundProductInfoDTO>>), 200)]
        public IActionResult GetSalesDetailList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesOutboundDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = _iMesOutboundDetailsBLL.GetSalesDetailList(pagination, queryParams);
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
        /// 获取物料
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/outboundInfo/GetProductList")]
        [ProducesResponseType(typeof(PaginationOutputDto<List<OutBoundProductInfoDTO>>), 200)]
        public IActionResult GetProductList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesOutboundDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = _iMesOutboundDetailsBLL.GetProductList(pagination, queryParams);
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

        #region 扩展 出库操作

        /// <summary>
        /// 出库操作
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost("mes/outboundInfo/OutboundInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> OutboundInfo(string id)
        {
           var result=  await _iMesOutboundInfoBLL.OutboundInfo(id);
            if (result.IsSuccess)
            {
                return Success("出库成功！");
            }
            else
            {
                return Fail(result.MessageInfo);
            }
        }
        #endregion
    }
}