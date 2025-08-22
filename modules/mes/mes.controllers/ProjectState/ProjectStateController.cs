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
    /// 日 期： 2023-09-01 16:10:21
    /// 描 述： 项目状态
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProjectStateController : BaseApiController
    {
        private readonly IMesProjectStateBLL _iMesProjectStateBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProjectStateBLL">项目状态接口</param>
        public ProjectStateController(IMesProjectStateBLL iMesProjectStateBLL)
        {
            _iMesProjectStateBLL = iMesProjectStateBLL?? throw new ArgumentNullException(nameof(iMesProjectStateBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取项目状态的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectStates")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProjectStateEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProjectStateEntity queryParams)
        {
            var list = await _iMesProjectStateBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取项目状态的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectState/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProjectStateEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProjectStateEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProjectStateBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/projectState/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectStateEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProjectStateBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/projectState")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectStateEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProjectStateEntity entity)
        {
            await _iMesProjectStateBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/projectState/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProjectStateEntity entity)
        {
            await _iMesProjectStateBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除项目状态mes_ProjectState数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectState/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProjectStateBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除项目状态mes_ProjectState数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectState/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProjectStateBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}