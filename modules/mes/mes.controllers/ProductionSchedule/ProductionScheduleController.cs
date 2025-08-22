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
    /// 日 期： 2023-08-15 09:40:10
    /// 描 述： 生产计划单
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProductionScheduleController : BaseApiController
    {
        private readonly IMesProductionScheduleBLL _iMesProductionScheduleBLL;
        private readonly IMesProductDetailsBLL _iMesProductDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionScheduleBLL"></param>
        /// <param name="iMesProductDetailsBLL"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductionScheduleController(IMesProductionScheduleBLL iMesProductionScheduleBLL, IMesProductDetailsBLL iMesProductDetailsBLL)
        {
            _iMesProductionScheduleBLL = iMesProductionScheduleBLL?? throw new ArgumentNullException(nameof(iMesProductionScheduleBLL));
            _iMesProductDetailsBLL = iMesProductDetailsBLL ?? throw new ArgumentNullException(nameof(iMesProductDetailsBLL));
        }



        #region 获取数据
        /// <summary>
        /// 获取生产计划单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionSchedules")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProductionScheduleEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProductionScheduleEntity queryParams)
        {
            var list = await _iMesProductionScheduleBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取生产计划单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionSchedule/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionScheduleEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProductionScheduleEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionScheduleBLL.GetPageList(pagination,queryParams);
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
        /// 获取生产计划单的分页列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionSchedule/GetToBeplannedList/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionScheduleEntity>>), 200)]
        public async Task<IActionResult> GetToBeplannedList([FromQuery] MesProductionScheduleEntity queryParams)
        {
           
            var data = await _iMesProductDetailsBLL.GetDetailEntity(queryParams.F_ProductionDetailId);
            var list = _iMesProductionScheduleBLL.GetToBeplannedList(data.F_MaterialId,data.F_Id);
            var resultList = _iMesProductionScheduleBLL.ConvertList(list, data);
            return Success(resultList);
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/productionSchedule/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionScheduleEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProductionScheduleBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/productionSchedule/productDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionScheduleEntity>), 200)]
        public async Task<IActionResult> GetproductDetail(string id)
        {
            var data = await _iMesProductionScheduleBLL.GetProductionScheduleDetail(id);
            return Success(data);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/productionSchedule")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionScheduleEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProductionScheduleEntity entity)
        {
            await _iMesProductionScheduleBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }

        /// <summary>
        /// 创建生产计划
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/productionSchedule/SaveListEntity")]
        [ProducesResponseType(typeof(List<MesProductionScheduleEntity>), 200)]
        public async Task<IActionResult> SaveListEntity(List<MesProductionScheduleEntity> entity)
        {
            await _iMesProductionScheduleBLL.SaveListEntity(entity);
            return Success("创建生产计划成功！");
        }
        /// <summary>
        /// 创建生产计划
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/productionSchedule/UpdateListEntity")]
        [ProducesResponseType(typeof(List<MesProductionScheduleEntity>), 200)]
        public async Task<IActionResult> UpdateListEntity(List<MesProductionScheduleEntity> entity)
        {
            await _iMesProductionScheduleBLL.UpdateList(entity);
            return Success("编辑生产计划成功！");
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/productionSchedule/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProductionScheduleEntity entity)
        {
            await _iMesProductionScheduleBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }

        /// <summary>
        /// 作废生产计划单
        /// </summary>
        /// <param name="cancelProductOrder">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/productionSchedule/CancelProductionSchedule")]
        [ProducesResponseType(typeof(CancelProductOrderDto), 200)]
        public async Task<IActionResult> CancelProductionSchedule(CancelProductOrderDto cancelProductOrder)
        {
            await _iMesProductionScheduleBLL.CancelEntity(cancelProductOrder);
            return Success("作废成功！");
        }

        /// <summary>
        /// 删除生产计划单mes_ProductionSchedule数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionSchedule/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProductionScheduleBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除生产计划单mes_ProductionSchedule数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionSchedule/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProductionScheduleBLL.Deletes(ids);
            return Success("删除成功！");
        }

        #endregion
    }
}