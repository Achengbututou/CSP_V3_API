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
    /// 日 期： 2023-07-31 15:54:06
    /// 描 述： 库区信息
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ReservoirAreaController : BaseApiController
    {
        private readonly IMesReservoirAreaBLL _iMesReservoirAreaBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesReservoirAreaBLL">库区信息管理接口</param>
        public ReservoirAreaController(IMesReservoirAreaBLL iMesReservoirAreaBLL)
        {
            _iMesReservoirAreaBLL = iMesReservoirAreaBLL?? throw new ArgumentNullException(nameof(iMesReservoirAreaBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取库区信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/reservoirAreas")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesReservoirAreaEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesReservoirAreaEntity queryParams)
        {
            var list = await _iMesReservoirAreaBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取库区信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/reservoirArea/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesReservoirAreaEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesReservoirAreaEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesReservoirAreaBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/reservoirArea/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesReservoirAreaEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesReservoirAreaBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/reservoirArea")]
        [ProducesResponseType(typeof(ResponseDto<MesReservoirAreaEntity>), 200)]
        public async Task<IActionResult>AddForm(MesReservoirAreaEntity entity)
        {
            await _iMesReservoirAreaBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/reservoirArea/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesReservoirAreaEntity entity)
        {
            await _iMesReservoirAreaBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除库区信息管理mes_ReservoirArea数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/reservoirArea/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesReservoirAreaBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除库区信息管理mes_ReservoirArea数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/reservoirArea/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesReservoirAreaBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}