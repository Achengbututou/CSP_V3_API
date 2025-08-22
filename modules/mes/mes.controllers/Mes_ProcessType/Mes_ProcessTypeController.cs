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
    /// 日 期： 2023-08-07 09:25:39
    /// 描 述： 工序类型
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class Mes_ProcessTypeController : BaseApiController
    {
        private readonly IMesProcessTypeBLL _iMesProcessTypeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessTypeBLL">工序类型接口</param>
        public Mes_ProcessTypeController(IMesProcessTypeBLL iMesProcessTypeBLL)
        {
            _iMesProcessTypeBLL = iMesProcessTypeBLL?? throw new ArgumentNullException(nameof(iMesProcessTypeBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工序类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/mes_ProcessTypes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessTypeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessTypeEntity queryParams)
        {
            var list = await _iMesProcessTypeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序类型的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/mes_ProcessType/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessTypeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessTypeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessTypeBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/mes_ProcessType/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessTypeEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProcessTypeBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/mes_ProcessType")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessTypeEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProcessTypeEntity entity)
        {
            await _iMesProcessTypeBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/mes_ProcessType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProcessTypeEntity entity)
        {
            await _iMesProcessTypeBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工序类型mes_ProcessType数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/mes_ProcessType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessTypeBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序类型mes_ProcessType数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/mes_ProcessType/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessTypeBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}