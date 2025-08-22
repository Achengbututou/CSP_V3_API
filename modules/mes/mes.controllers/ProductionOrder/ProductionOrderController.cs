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
    /// 日 期： 2023-08-15 09:12:40
    /// 描 述： 生产订单
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProductionOrderController : BaseApiController
    {
        private readonly IMesProductionOrderBLL _iMesProductionOrderBLL;
        private readonly IMesProductDetailsBLL _iMesProductDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionOrderBLL">生产订单接口</param>
        /// <param name="iMesProductDetailsBLL">生产订单产品明细接口</param>
        public ProductionOrderController(IMesProductionOrderBLL iMesProductionOrderBLL,IMesProductDetailsBLL iMesProductDetailsBLL)
        {
            _iMesProductionOrderBLL = iMesProductionOrderBLL?? throw new ArgumentNullException(nameof(iMesProductionOrderBLL));
            _iMesProductDetailsBLL = iMesProductDetailsBLL?? throw new ArgumentNullException(nameof(iMesProductDetailsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取生产订单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrders")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProductionOrderEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProductionOrderEntity queryParams)
        {
            var list = await _iMesProductionOrderBLL.GetList(queryParams);
            return Success(list);
        } 
        /// <summary>
        /// 获取生产订单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrder/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionOrderEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProductionOrderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionOrderBLL.GetPageList(pagination,queryParams);
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
        /// 获取生产订单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrder/detail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductDetailsEntity>>), 200)]
        public async Task<IActionResult> GetPageDetailList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesProductDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionOrderBLL.GetDetailPageList(pagination, queryParams);
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
        [HttpGet("mes/productionOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ProductionOrderDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new ProductionOrderDto();
            res.MesProductionOrderEntity = await _iMesProductionOrderBLL.GetEntity(id);
            if(res.MesProductionOrderEntity != null)
            {
                res.MesProductDetailsList = await _iMesProductDetailsBLL.GetList(new MesProductDetailsEntity { F_ProductionOrderId = res.MesProductionOrderEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrder/mesProductionOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionOrderEntity>), 200)]
        public async Task<IActionResult>GetMesProductionOrderEntity(string id)
        {
            var data = await _iMesProductionOrderBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取生产订单产品明细mes_ProductDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrder/mesProductDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProductDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesProductDetailsList([FromQuery]MesProductDetailsEntity queryParams)
        {
            var list = await _iMesProductDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取生产订单产品明细mes_ProductDetails的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrder/mesProductDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesProductDetailsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProductDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductDetailsBLL.GetPageList(pagination,queryParams);
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
        /// 获取生产订单产品明细mes_ProductDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/productionOrder/mesProductDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductDetailsEntity>), 200)]
        public async Task<IActionResult>GetMesProductDetailsEntity(string id)
        {
            var data = await _iMesProductDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionOrder")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionOrderEntity>), 200)]
        public async Task<IActionResult>AddForm(ProductionOrderDto dto)
        {
            await _iMesProductionOrderBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesProductionOrderEntity);
        }
        /// <summary>
        /// 新增生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionOrder/mesProductionOrder")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionOrderEntity>), 200)]
        public async Task<IActionResult>AddMesProductionOrder(MesProductionOrderEntity entity)
        {
            await _iMesProductionOrderBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增生产订单产品明细mes_ProductDetails数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionOrder/mesProductDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesProductDetailsEntity>), 200)]
        public async Task<IActionResult>AddMesProductDetails(MesProductDetailsEntity entity)
        {
            await _iMesProductDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/productionOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,ProductionOrderDto dto)
        {
            await _iMesProductionOrderBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/productionOrder/mesProductionOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProductionOrder(string id,MesProductionOrderEntity entity)
        {
            await _iMesProductionOrderBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新生产订单产品明细mes_ProductDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/productionOrder/mesProductDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProductDetails(string id,MesProductDetailsEntity entity)
        {
            await _iMesProductDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }

        /// <summary>
        /// 新增生产订单产品明细mes_ProductDetails数据
        /// </summary>
        /// <param name="cancelProductOrder">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionOrder/CancelProductOrder")]
        [ProducesResponseType(typeof(CancelProductOrderDto), 200)]
        public async Task<IActionResult> CancelProductOrder(CancelProductOrderDto cancelProductOrder)
        {
            await _iMesProductDetailsBLL.CancelProductOrder(cancelProductOrder);
            return Success("作废成功！");
        }
        /// <summary>
        /// 删除生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProductionOrderBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionOrder/mesProductionOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProductionOrder(string id)
        {
            await _iMesProductionOrderBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除生产订单产品明细mes_ProductDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionOrder/mesProductDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProductDetails(string id)
        {
            await _iMesProductDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionOrder/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProductionOrderBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除生产订单mes_ProductionOrder数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/productionOrder/mesProductionOrder/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProductionOrders(string ids)
        {
            await _iMesProductionOrderBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除生产订单产品明细mes_ProductDetails数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/productionOrder/mesProductDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProductDetailss(string ids)
        {
            await _iMesProductDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}