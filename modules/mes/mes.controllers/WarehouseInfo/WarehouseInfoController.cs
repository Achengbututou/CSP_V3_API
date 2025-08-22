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
    /// 日 期： 2023-07-31 13:39:16
    /// 描 述： 仓库结果
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class WarehouseInfoController : BaseApiController
    {
        private readonly IMesWarehouseInfoBLL _iMesWarehouseInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesWarehouseInfoBLL">仓库信息管理接口</param>
        public WarehouseInfoController(IMesWarehouseInfoBLL iMesWarehouseInfoBLL)
        {
            _iMesWarehouseInfoBLL = iMesWarehouseInfoBLL?? throw new ArgumentNullException(nameof(iMesWarehouseInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取仓库结果的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehouseInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesWarehouseInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesWarehouseInfoEntity queryParams)
        {
            var list = await _iMesWarehouseInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取仓库结果的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/warehouseInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWarehouseInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesWarehouseInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWarehouseInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/warehouseInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehouseInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesWarehouseInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/warehouseInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesWarehouseInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesWarehouseInfoEntity entity)
        {
            await _iMesWarehouseInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/warehouseInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesWarehouseInfoEntity entity)
        {
            await _iMesWarehouseInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除仓库信息管理mes_WarehouseInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehouseInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesWarehouseInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除仓库信息管理mes_WarehouseInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/warehouseInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesWarehouseInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}