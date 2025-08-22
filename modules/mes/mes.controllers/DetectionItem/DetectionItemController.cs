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
    /// 日 期： 2023-08-22 15:53:49
    /// 描 述： 检测项目
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class DetectionItemController : BaseApiController
    {
        private readonly IMesDetectionItemBLL _iMesDetectionItemBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesDetectionItemBLL">检测项目接口</param>
        public DetectionItemController(IMesDetectionItemBLL iMesDetectionItemBLL)
        {
            _iMesDetectionItemBLL = iMesDetectionItemBLL?? throw new ArgumentNullException(nameof(iMesDetectionItemBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取检测项目的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/detectionItems")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesDetectionItemEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesDetectionItemEntity queryParams)
        {
            var list = await _iMesDetectionItemBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取检测项目的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/detectionItem/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesDetectionItemEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesDetectionItemEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesDetectionItemBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/detectionItem/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesDetectionItemEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesDetectionItemBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/detectionItem")]
        [ProducesResponseType(typeof(ResponseDto<MesDetectionItemEntity>), 200)]
        public async Task<IActionResult>AddForm(MesDetectionItemEntity entity)
        {
            await _iMesDetectionItemBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/detectionItem/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesDetectionItemEntity entity)
        {
            await _iMesDetectionItemBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除检测项目mes_detectitem数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/detectionItem/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesDetectionItemBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除检测项目mes_detectitem数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/detectionItem/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesDetectionItemBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}