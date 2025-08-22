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
    /// 日 期： 2023-09-01 11:45:10
    /// 描 述： 设备类型
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class DeviceTypeController : BaseApiController
    {
        private readonly IMesDeviceTypeBLL _iMesDeviceTypeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesDeviceTypeBLL">设备类型接口</param>
        public DeviceTypeController(IMesDeviceTypeBLL iMesDeviceTypeBLL)
        {
            _iMesDeviceTypeBLL = iMesDeviceTypeBLL?? throw new ArgumentNullException(nameof(iMesDeviceTypeBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取设备类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/deviceTypes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesDeviceTypeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesDeviceTypeEntity queryParams)
        {
            var list = await _iMesDeviceTypeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取设备类型的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/deviceType/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesDeviceTypeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesDeviceTypeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesDeviceTypeBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/deviceType/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesDeviceTypeEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesDeviceTypeBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/deviceType")]
        [ProducesResponseType(typeof(ResponseDto<MesDeviceTypeEntity>), 200)]
        public async Task<IActionResult>AddForm(MesDeviceTypeEntity entity)
        {
            await _iMesDeviceTypeBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/deviceType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesDeviceTypeEntity entity)
        {
            await _iMesDeviceTypeBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除设备类型mes_DeviceType数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/deviceType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesDeviceTypeBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除设备类型mes_DeviceType数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/deviceType/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesDeviceTypeBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}