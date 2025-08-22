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
    /// 日 期： 2023-09-01 16:05:05
    /// 描 述： 项目阶段
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProjectPhaseController : BaseApiController
    {
        private readonly IMesProjectPhaseBLL _iMesProjectPhaseBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProjectPhaseBLL">项目阶段接口</param>
        public ProjectPhaseController(IMesProjectPhaseBLL iMesProjectPhaseBLL)
        {
            _iMesProjectPhaseBLL = iMesProjectPhaseBLL?? throw new ArgumentNullException(nameof(iMesProjectPhaseBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取项目阶段的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectPhases")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProjectPhaseEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProjectPhaseEntity queryParams)
        {
            var list = await _iMesProjectPhaseBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取项目阶段的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectPhase/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProjectPhaseEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProjectPhaseEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProjectPhaseBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/projectPhase/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectPhaseEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProjectPhaseBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/projectPhase")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectPhaseEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProjectPhaseEntity entity)
        {
            await _iMesProjectPhaseBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/projectPhase/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProjectPhaseEntity entity)
        {
            await _iMesProjectPhaseBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除项目阶段mes_ProjectPhase数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectPhase/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProjectPhaseBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除项目阶段mes_ProjectPhase数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectPhase/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProjectPhaseBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}