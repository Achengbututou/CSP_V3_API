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
    /// 日 期： 2023-08-10 10:15:58
    /// 描 述： 排期详情
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ScheduleDetailsController : BaseApiController
    {
        private readonly IMesScheduleDetailsBLL _iMesScheduleDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesScheduleDetailsBLL">排期详情接口</param>
        public ScheduleDetailsController(IMesScheduleDetailsBLL iMesScheduleDetailsBLL)
        {
            _iMesScheduleDetailsBLL = iMesScheduleDetailsBLL?? throw new ArgumentNullException(nameof(iMesScheduleDetailsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取排期详情的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/scheduleDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesScheduleDetailsEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesScheduleDetailsEntity queryParams)
        {
            var list = await _iMesScheduleDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取排期详情的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/scheduleDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesScheduleDetailsEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesScheduleDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesScheduleDetailsBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/scheduleDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesScheduleDetailsEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesScheduleDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/scheduleDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesScheduleDetailsEntity>), 200)]
        public async Task<IActionResult>AddForm(MesScheduleDetailsEntity entity)
        {
            await _iMesScheduleDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/scheduleDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesScheduleDetailsEntity entity)
        {
            await _iMesScheduleDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除排期详情mes_ScheduleDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/scheduleDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesScheduleDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除排期详情mes_ScheduleDetails数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/scheduleDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesScheduleDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}