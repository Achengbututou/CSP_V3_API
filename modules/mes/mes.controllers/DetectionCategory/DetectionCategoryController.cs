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
    /// 日 期： 2023-08-22 15:44:28
    /// 描 述： 检测类别
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class DetectionCategoryController : BaseApiController
    {
        private readonly IMesDetectionCategoryBLL _iMesDetectionCategoryBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesDetectionCategoryBLL">检测类别信息维护接口</param>
        public DetectionCategoryController(IMesDetectionCategoryBLL iMesDetectionCategoryBLL)
        {
            _iMesDetectionCategoryBLL = iMesDetectionCategoryBLL?? throw new ArgumentNullException(nameof(iMesDetectionCategoryBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取检测类别的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/detectionCategorys")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesDetectionCategoryEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesDetectionCategoryEntity queryParams)
        {
            var list = await _iMesDetectionCategoryBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取检测类别的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/detectionCategory/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesDetectionCategoryEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesDetectionCategoryEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesDetectionCategoryBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/detectionCategory/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesDetectionCategoryEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesDetectionCategoryBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/detectionCategory")]
        [ProducesResponseType(typeof(ResponseDto<MesDetectionCategoryEntity>), 200)]
        public async Task<IActionResult>AddForm(MesDetectionCategoryEntity entity)
        {
            await _iMesDetectionCategoryBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/detectionCategory/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesDetectionCategoryEntity entity)
        {
            await _iMesDetectionCategoryBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除检测类别信息维护mes_detectcateg数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/detectionCategory/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesDetectionCategoryBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除检测类别信息维护mes_detectcateg数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/detectionCategory/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesDetectionCategoryBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}