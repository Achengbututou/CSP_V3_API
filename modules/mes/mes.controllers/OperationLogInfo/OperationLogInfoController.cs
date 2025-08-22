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
    /// 日 期： 2023-09-15 15:37:57
    /// 描 述： 仓库操作日志
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class OperationLogInfoController : BaseApiController
    {
        private readonly IMesOperationLogInfoBLL _iMesOperationLogInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesOperationLogInfoBLL">操作日志明细接口</param>
        public OperationLogInfoController(IMesOperationLogInfoBLL iMesOperationLogInfoBLL)
        {
            _iMesOperationLogInfoBLL = iMesOperationLogInfoBLL?? throw new ArgumentNullException(nameof(iMesOperationLogInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取仓库操作日志的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/operationLogInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesOperationLogInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesOperationLogInfoEntity queryParams)
        {
            var list = await _iMesOperationLogInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取仓库操作日志的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/operationLogInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesOperationLogInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesOperationLogInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesOperationLogInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/operationLogInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesOperationLogInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesOperationLogInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/operationLogInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesOperationLogInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesOperationLogInfoEntity entity)
        {
            await _iMesOperationLogInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/operationLogInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesOperationLogInfoEntity entity)
        {
            await _iMesOperationLogInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除操作日志明细mes_OperationLogInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/operationLogInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesOperationLogInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除操作日志明细mes_OperationLogInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/operationLogInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesOperationLogInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}