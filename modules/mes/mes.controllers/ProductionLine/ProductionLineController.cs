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
    /// 日 期： 2023-07-27 15:30:16
    /// 描 述： 产线信息
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProductionLineController : BaseApiController
    {
        private readonly IMesProductionLineBLL _iMesProductionLineBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProductionLineBLL">产线信息管理接口</param>
        public ProductionLineController(IMesProductionLineBLL iMesProductionLineBLL)
        {
            _iMesProductionLineBLL = iMesProductionLineBLL?? throw new ArgumentNullException(nameof(iMesProductionLineBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取产线信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionLines")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProductionLineEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProductionLineEntity queryParams)
        {
            var list = await _iMesProductionLineBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取产线信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/productionLine/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProductionLineEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProductionLineEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProductionLineBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/productionLine/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionLineEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProductionLineBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/productionLine")]
        [ProducesResponseType(typeof(ResponseDto<MesProductionLineEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProductionLineEntity entity)
        {
            await _iMesProductionLineBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/productionLine/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProductionLineEntity entity)
        {
            await _iMesProductionLineBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除产线信息管理mes_ProductionLine数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionLine/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProductionLineBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除产线信息管理mes_ProductionLine数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/productionLine/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProductionLineBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}