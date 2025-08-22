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
    /// 日 期： 2023-09-01 11:31:36
    /// 描 述： 设备维修
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class Mes_DeviceRepairController : BaseApiController
    {
        private readonly IMesDeviceRepairBLL _iMesDeviceRepairBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesDeviceRepairBLL">设备维修信息接口</param>
        public Mes_DeviceRepairController(IMesDeviceRepairBLL iMesDeviceRepairBLL)
        {
            _iMesDeviceRepairBLL = iMesDeviceRepairBLL?? throw new ArgumentNullException(nameof(iMesDeviceRepairBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取设备维修的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/mes_DeviceRepairs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesDeviceRepairEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesDeviceRepairEntity queryParams)
        {
            var list = await _iMesDeviceRepairBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取设备维修的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/mes_DeviceRepair/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesDeviceRepairEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesDeviceRepairEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesDeviceRepairBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/mes_DeviceRepair/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesDeviceRepairEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesDeviceRepairBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/mes_DeviceRepair")]
        [ProducesResponseType(typeof(ResponseDto<MesDeviceRepairEntity>), 200)]
        public async Task<IActionResult>AddForm(MesDeviceRepairEntity entity)
        {
            await _iMesDeviceRepairBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/mes_DeviceRepair/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesDeviceRepairEntity entity)
        {
            await _iMesDeviceRepairBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除设备维修信息mes_DeviceRepair数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/mes_DeviceRepair/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesDeviceRepairBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除设备维修信息mes_DeviceRepair数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/mes_DeviceRepair/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesDeviceRepairBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}