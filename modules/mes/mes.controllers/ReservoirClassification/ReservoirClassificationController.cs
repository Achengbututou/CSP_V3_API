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
    /// 日 期： 2023-07-31 10:57:00
    /// 描 述： 库区分类
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ReservoirClassificationController : BaseApiController
    {
        private readonly IMesReservoirClassificationBLL _iMesReservoirClassificationBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesReservoirClassificationBLL">库区分类信息维护接口</param>
        public ReservoirClassificationController(IMesReservoirClassificationBLL iMesReservoirClassificationBLL)
        {
            _iMesReservoirClassificationBLL = iMesReservoirClassificationBLL?? throw new ArgumentNullException(nameof(iMesReservoirClassificationBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取库区分类的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/reservoirClassifications")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesReservoirClassificationEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesReservoirClassificationEntity queryParams)
        {
            var list = await _iMesReservoirClassificationBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取库区分类的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/reservoirClassification/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesReservoirClassificationEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesReservoirClassificationEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesReservoirClassificationBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/reservoirClassification/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesReservoirClassificationEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesReservoirClassificationBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/reservoirClassification")]
        [ProducesResponseType(typeof(ResponseDto<MesReservoirClassificationEntity>), 200)]
        public async Task<IActionResult>AddForm(MesReservoirClassificationEntity entity)
        {
            await _iMesReservoirClassificationBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/reservoirClassification/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesReservoirClassificationEntity entity)
        {
            await _iMesReservoirClassificationBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除库区分类信息维护mes_ReservoirClassification数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/reservoirClassification/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesReservoirClassificationBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除库区分类信息维护mes_ReservoirClassification数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/reservoirClassification/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesReservoirClassificationBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}