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
    /// 日 期： 2023-09-01 14:27:53
    /// 描 述： 设备信息
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class DeviceInfoController : BaseApiController
    {
        private readonly IMesDeviceInfoBLL _iMesDeviceInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesDeviceInfoBLL">设备信息接口</param>
        public DeviceInfoController(IMesDeviceInfoBLL iMesDeviceInfoBLL)
        {
            _iMesDeviceInfoBLL = iMesDeviceInfoBLL?? throw new ArgumentNullException(nameof(iMesDeviceInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取设备信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/deviceInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesDeviceInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesDeviceInfoEntity queryParams)
        {
            var list = await _iMesDeviceInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取设备信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/deviceInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesDeviceInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesDeviceInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesDeviceInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/deviceInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesDeviceInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesDeviceInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/deviceInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesDeviceInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesDeviceInfoEntity entity)
        {
            await _iMesDeviceInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/deviceInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesDeviceInfoEntity entity)
        {
            await _iMesDeviceInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除设备信息mes_DeviceInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/deviceInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesDeviceInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除设备信息mes_DeviceInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/deviceInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesDeviceInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}