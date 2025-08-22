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
    /// 日 期： 2023-08-18 11:24:51
    /// 描 述： 工序派工
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessDispatchController : BaseApiController
    {
        private readonly IMesProcessDispatchBLL _iMesProcessDispatchBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessDispatchBLL">工序派工接口</param>
        public ProcessDispatchController(IMesProcessDispatchBLL iMesProcessDispatchBLL)
        {
            _iMesProcessDispatchBLL = iMesProcessDispatchBLL?? throw new ArgumentNullException(nameof(iMesProcessDispatchBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工序派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processDispatchs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessDispatchEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessDispatchEntity queryParams)
        {
            var list = await _iMesProcessDispatchBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序派工的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processDispatch/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessDispatchEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessDispatchEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessDispatchBLL.GetPageList(pagination,queryParams);
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
        /// 获取工单工序派工
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processDispatch/GetDispatchList/{id}")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessDispatchEntity>>), 200)]
        public async Task<IActionResult> GetDispatchList(string id)
        {
            var data = await _iMesProcessDispatchBLL.GetDispatchList(id);
            return Success(data);
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processDispatch/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessDispatchEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProcessDispatchBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/processDispatch")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessDispatchEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProcessDispatchEntity entity)
        {
            await _iMesProcessDispatchBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }

        /// <summary>
        /// 工序派工
        /// </summary>
        /// <param name="processDispatch"></param>
        /// <returns></returns>
        [HttpPost("mes/processDispatch/mesProcessDispatch")]
        [ProducesResponseType(typeof(ProductionTicketSaveDTO), 200)]
        public async Task<IActionResult> mesProcessDispatch(ProcessDispatchDTO processDispatch)
        {
            await _iMesProcessDispatchBLL.mesProcessDispatch(processDispatch);
            return Success("工序派工成功！");
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/processDispatch/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProcessDispatchEntity entity)
        {
            await _iMesProcessDispatchBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工序派工mes_ProcessDispatch数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processDispatch/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessDispatchBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序派工mes_ProcessDispatch数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processDispatch/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessDispatchBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}