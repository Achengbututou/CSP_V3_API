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
    /// 日 期： 2023-09-05 17:17:28
    /// 描 述： 入库管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class WarehousingInfoController : BaseApiController
    {
        private readonly IMesWarehousingInfoBLL _iMesWarehousingInfoBLL;
        private readonly IMesWarehousingDetailsBLL _iMesWarehousingDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesWarehousingInfoBLL">入库信息接口</param>
        /// <param name="iMesWarehousingDetailsBLL">入库物品明细接口</param>
        public WarehousingInfoController(IMesWarehousingInfoBLL iMesWarehousingInfoBLL,IMesWarehousingDetailsBLL iMesWarehousingDetailsBLL)
        {
            _iMesWarehousingInfoBLL = iMesWarehousingInfoBLL?? throw new ArgumentNullException(nameof(iMesWarehousingInfoBLL));
            _iMesWarehousingDetailsBLL = iMesWarehousingDetailsBLL?? throw new ArgumentNullException(nameof(iMesWarehousingDetailsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取入库管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesWarehousingInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesWarehousingInfoEntity queryParams)
        {
            var list = await _iMesWarehousingInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取入库管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWarehousingInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesWarehousingInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWarehousingInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/warehousingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<WarehousingInfoDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new WarehousingInfoDto();
            res.MesWarehousingInfoEntity = await _iMesWarehousingInfoBLL.GetEntity(id);
            if(res.MesWarehousingInfoEntity != null)
            {
                res.MesWarehousingDetailsList = await _iMesWarehousingDetailsBLL.GetList(new MesWarehousingDetailsEntity { F_WarehousingInfoId = res.MesWarehousingInfoEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/mesWarehousingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehousingInfoEntity>), 200)]
        public async Task<IActionResult>GetMesWarehousingInfoEntity(string id)
        {
            var data = await _iMesWarehousingInfoBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取入库物品明细mes_WarehousingDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/mesWarehousingDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesWarehousingDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesWarehousingDetailsList([FromQuery]MesWarehousingDetailsEntity queryParams)
        {
            var list = await _iMesWarehousingDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取入库物品明细mes_WarehousingDetails的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/mesWarehousingDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWarehousingDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesWarehousingDetailsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesWarehousingDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWarehousingDetailsBLL.GetPageList(pagination,queryParams);
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
        /// 获取入库物品明细mes_WarehousingDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/mesWarehousingDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehousingDetailsEntity>), 200)]
        public async Task<IActionResult>GetMesWarehousingDetailsEntity(string id)
        {
            var data = await _iMesWarehousingDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/warehousingInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehousingInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(WarehousingInfoDto dto)
        {
            await _iMesWarehousingInfoBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesWarehousingInfoEntity);
        }
        /// <summary>
        /// 新增入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/warehousingInfo/mesWarehousingInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehousingInfoEntity>), 200)]
        public async Task<IActionResult>AddMesWarehousingInfo(MesWarehousingInfoEntity entity)
        {
            await _iMesWarehousingInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增入库物品明细mes_WarehousingDetails数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/warehousingInfo/mesWarehousingDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehousingDetailsEntity>), 200)]
        public async Task<IActionResult>AddMesWarehousingDetails(MesWarehousingDetailsEntity entity)
        {
            await _iMesWarehousingDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/warehousingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,WarehousingInfoDto dto)
        {
            await _iMesWarehousingInfoBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/warehousingInfo/mesWarehousingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesWarehousingInfo(string id,MesWarehousingInfoEntity entity)
        {
            await _iMesWarehousingInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新入库物品明细mes_WarehousingDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/warehousingInfo/mesWarehousingDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesWarehousingDetails(string id,MesWarehousingDetailsEntity entity)
        {
            await _iMesWarehousingDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehousingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesWarehousingInfoBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehousingInfo/mesWarehousingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesWarehousingInfo(string id)
        {
            await _iMesWarehousingInfoBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除入库物品明细mes_WarehousingDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehousingInfo/mesWarehousingDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesWarehousingDetails(string id)
        {
            await _iMesWarehousingDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehousingInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesWarehousingInfoBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除入库信息mes_WarehousingInfo数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/warehousingInfo/mesWarehousingInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesWarehousingInfos(string ids)
        {
            await _iMesWarehousingInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除入库物品明细mes_WarehousingDetails数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/warehousingInfo/mesWarehousingDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesWarehousingDetailss(string ids)
        {
            await _iMesWarehousingDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法 获取入库数据
        /// <summary>
        /// 获取采购订单产品详细含已入库数量
        /// </summary>
        /// <param name="paginationInputDto"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/GetPurchasedetailList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWarehousingDetailsEntity>>), 200)]
        public IActionResult GetPurchasedetailList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesWarehousingDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var dataResult = _iMesWarehousingDetailsBLL.GetPurchasedetailList(pagination, queryParams);
            var list = dataResult.warehousingDetailsDTO;
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
        /// <param name="paginationInputDto"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/GetSalesDetailList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWarehousingDetailsEntity>>), 200)]
        public IActionResult GetSalesDetailList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesWarehousingDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var dataResult = _iMesWarehousingDetailsBLL.GetSalesDetailList(pagination, queryParams);
            var list = dataResult.warehousingDetailsDTO;
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
        /// <param name="paginationInputDto"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpGet("mes/warehousingInfo/GetProductList")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<WarehousingDetailsDTO>>), 200)]
        public IActionResult GetProductList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesWarehousingDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var dataResult = _iMesWarehousingDetailsBLL.GetProductList(pagination, queryParams);
            var jsonData = new
            {
                rows = dataResult,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost("mes/warehousingInfo/Warehousing/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Warehousing(string id)
        {
            await _iMesWarehousingInfoBLL.Warehousing(id);
            return Success("入库成功！");
        }
        #endregion
    }
}