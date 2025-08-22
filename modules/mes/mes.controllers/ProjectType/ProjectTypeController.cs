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
    /// 日 期： 2023-09-01 15:56:47
    /// 描 述： 项目类型
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProjectTypeController : BaseApiController
    {
        private readonly IMesProjectTypeBLL _iMesProjectTypeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProjectTypeBLL">项目类型接口</param>
        public ProjectTypeController(IMesProjectTypeBLL iMesProjectTypeBLL)
        {
            _iMesProjectTypeBLL = iMesProjectTypeBLL?? throw new ArgumentNullException(nameof(iMesProjectTypeBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取项目类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectTypes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProjectTypeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProjectTypeEntity queryParams)
        {
            var list = await _iMesProjectTypeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取项目类型的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/projectType/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProjectTypeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProjectTypeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProjectTypeBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/projectType/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectTypeEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProjectTypeBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/projectType")]
        [ProducesResponseType(typeof(ResponseDto<MesProjectTypeEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProjectTypeEntity entity)
        {
            await _iMesProjectTypeBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/projectType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProjectTypeEntity entity)
        {
            await _iMesProjectTypeBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除项目类型mes_ProjectType数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProjectTypeBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除项目类型mes_ProjectType数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/projectType/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProjectTypeBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}