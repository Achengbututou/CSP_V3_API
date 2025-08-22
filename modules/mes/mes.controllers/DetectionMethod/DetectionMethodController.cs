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
    /// 日 期： 2023-08-22 16:14:01
    /// 描 述： 检测方法
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class DetectionMethodController : BaseApiController
    {
        private readonly IMesDetectionMethodBLL _iMesDetectionMethodBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesDetectionMethodBLL">检测方法接口</param>
        public DetectionMethodController(IMesDetectionMethodBLL iMesDetectionMethodBLL)
        {
            _iMesDetectionMethodBLL = iMesDetectionMethodBLL?? throw new ArgumentNullException(nameof(iMesDetectionMethodBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取检测方法的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/detectionMethods")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesDetectionMethodEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesDetectionMethodEntity queryParams)
        {
            var list = await _iMesDetectionMethodBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取检测方法的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/detectionMethod/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesDetectionMethodEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesDetectionMethodEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesDetectionMethodBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/detectionMethod/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesDetectionMethodEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesDetectionMethodBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/detectionMethod")]
        [ProducesResponseType(typeof(ResponseDto<MesDetectionMethodEntity>), 200)]
        public async Task<IActionResult>AddForm(MesDetectionMethodEntity entity)
        {
            await _iMesDetectionMethodBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/detectionMethod/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesDetectionMethodEntity entity)
        {
            await _iMesDetectionMethodBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除检测方法mes_detectmethod数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/detectionMethod/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesDetectionMethodBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除检测方法mes_detectmethod数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/detectionMethod/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesDetectionMethodBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}