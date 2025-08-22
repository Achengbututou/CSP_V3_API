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
    /// 日 期： 2023-09-18 15:09:45
    /// 描 述： 调拨列表
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class TransferOrderController : BaseApiController
    {
        private readonly IMesTransferOrderBLL _iMesTransferOrderBLL;
        private readonly IMesTransferOrderDetailsBLL _iMesTransferOrderDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTransferOrderBLL">调拨单信息接口</param>
        /// <param name="iMesTransferOrderDetailsBLL">调拨物品明细接口</param>
        public TransferOrderController(IMesTransferOrderBLL iMesTransferOrderBLL,IMesTransferOrderDetailsBLL iMesTransferOrderDetailsBLL)
        {
            _iMesTransferOrderBLL = iMesTransferOrderBLL?? throw new ArgumentNullException(nameof(iMesTransferOrderBLL));
            _iMesTransferOrderDetailsBLL = iMesTransferOrderDetailsBLL?? throw new ArgumentNullException(nameof(iMesTransferOrderDetailsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取调拨列表的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferOrders")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTransferOrderEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesTransferOrderEntity queryParams)
        {
            var list = await _iMesTransferOrderBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取调拨列表的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferOrder/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTransferOrderEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTransferOrderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTransferOrderBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/transferOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto<TransferOrderDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new TransferOrderDto();
            res.MesTransferOrderEntity = await _iMesTransferOrderBLL.GetEntity(id);
            if(res.MesTransferOrderEntity != null)
            {
                res.MesTransferOrderDetailsList = await _iMesTransferOrderDetailsBLL.GetList(new MesTransferOrderDetailsEntity { F_TransferInfoId = res.MesTransferOrderEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/transferOrder/mesTransferOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferOrderEntity>), 200)]
        public async Task<IActionResult>GetMesTransferOrderEntity(string id)
        {
            var data = await _iMesTransferOrderBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取调拨物品明细mes_TransferOrderDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferOrder/mesTransferOrderDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTransferOrderDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesTransferOrderDetailsList([FromQuery]MesTransferOrderDetailsEntity queryParams)
        {
            var list = await _iMesTransferOrderDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取调拨物品明细mes_TransferOrderDetails的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferOrder/mesTransferOrderDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTransferOrderDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesTransferOrderDetailsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTransferOrderDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTransferOrderDetailsBLL.GetPageList(pagination,queryParams);
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
        /// 获取调拨物品明细mes_TransferOrderDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/transferOrder/mesTransferOrderDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferOrderDetailsEntity>), 200)]
        public async Task<IActionResult>GetMesTransferOrderDetailsEntity(string id)
        {
            var data = await _iMesTransferOrderDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/transferOrder")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferOrderEntity>), 200)]
        public async Task<IActionResult>AddForm(TransferOrderDto dto)
        {
            await _iMesTransferOrderBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesTransferOrderEntity);
        }
        /// <summary>
        /// 新增调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/transferOrder/mesTransferOrder")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferOrderEntity>), 200)]
        public async Task<IActionResult>AddMesTransferOrder(MesTransferOrderEntity entity)
        {
            await _iMesTransferOrderBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增调拨物品明细mes_TransferOrderDetails数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/transferOrder/mesTransferOrderDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferOrderDetailsEntity>), 200)]
        public async Task<IActionResult>AddMesTransferOrderDetails(MesTransferOrderDetailsEntity entity)
        {
            await _iMesTransferOrderDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/transferOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,TransferOrderDto dto)
        {
            await _iMesTransferOrderBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/transferOrder/mesTransferOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesTransferOrder(string id,MesTransferOrderEntity entity)
        {
            await _iMesTransferOrderBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新调拨物品明细mes_TransferOrderDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/transferOrder/mesTransferOrderDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesTransferOrderDetails(string id,MesTransferOrderDetailsEntity entity)
        {
            await _iMesTransferOrderDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesTransferOrderBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferOrder/mesTransferOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferOrder(string id)
        {
            await _iMesTransferOrderBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除调拨物品明细mes_TransferOrderDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferOrder/mesTransferOrderDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferOrderDetails(string id)
        {
            await _iMesTransferOrderDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferOrder/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesTransferOrderBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除调拨单信息mes_TransferOrder数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/transferOrder/mesTransferOrder/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferOrders(string ids)
        {
            await _iMesTransferOrderBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除调拨物品明细mes_TransferOrderDetails数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/transferOrder/mesTransferOrderDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferOrderDetailss(string ids)
        {
            await _iMesTransferOrderDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展操作 确认调拨
        /// <summary>
        ///  确认调拨
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPut("mes/transferOrder/Transfer/{keyValue}")]
        [ProducesResponseType(typeof(OutboundResultDTO), 200)]
        public async Task<IActionResult> Transfer(string keyValue)
        {
            var result = await _iMesTransferOrderBLL.Transfer(keyValue);
            if (result.IsSuccess)
            {
                return Success("调拨成功！");
            }
            else
            {
                return Fail(result.MessageInfo);
            }
        }
        #endregion
    }
}