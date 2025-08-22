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
    /// 日 期： 2023-07-31 11:49:49
    /// 描 述： 仓库类型
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class WarehouseTypeController : BaseApiController
    {
        private readonly IMesWarehouseTypeBLL _iMesWarehouseTypeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesWarehouseTypeBLL">仓库类型管理接口</param>
        public WarehouseTypeController(IMesWarehouseTypeBLL iMesWarehouseTypeBLL)
        {
            _iMesWarehouseTypeBLL = iMesWarehouseTypeBLL?? throw new ArgumentNullException(nameof(iMesWarehouseTypeBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取仓库类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehouseTypes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesWarehouseTypeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesWarehouseTypeEntity queryParams)
        {
            var list = await _iMesWarehouseTypeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取仓库类型的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehouseType/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWarehouseTypeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesWarehouseTypeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWarehouseTypeBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/warehouseType/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehouseTypeEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesWarehouseTypeBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/warehouseType")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehouseTypeEntity>), 200)]
        public async Task<IActionResult>AddForm(MesWarehouseTypeEntity entity)
        {
            await _iMesWarehouseTypeBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/warehouseType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesWarehouseTypeEntity entity)
        {
            await _iMesWarehouseTypeBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除仓库类型管理mes_WarehouseType数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehouseType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesWarehouseTypeBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除仓库类型管理mes_WarehouseType数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehouseType/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesWarehouseTypeBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}