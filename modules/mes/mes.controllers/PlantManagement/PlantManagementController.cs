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
    /// 日 期： 2023-07-26 16:52:42
    /// 描 述： 工厂管理表
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class PlantManagementController : BaseApiController
    {
        private readonly IMesPlantManagementBLL _iMesPlantManagementBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesPlantManagementBLL">工厂信息维护管理接口</param>
        public PlantManagementController(IMesPlantManagementBLL iMesPlantManagementBLL)
        {
            _iMesPlantManagementBLL = iMesPlantManagementBLL?? throw new ArgumentNullException(nameof(iMesPlantManagementBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工厂管理表的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/plantManagements")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesPlantManagementEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesPlantManagementEntity queryParams)
        {
            var list = await _iMesPlantManagementBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工厂管理表的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/plantManagement/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesPlantManagementEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesPlantManagementEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesPlantManagementBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/plantManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesPlantManagementEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesPlantManagementBLL.GetEntity(id);
            return Success(data);
        }

       
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/plantManagement")]
        [ProducesResponseType(typeof(ResponseDto<MesPlantManagementEntity>), 200)]
        public async Task<IActionResult>AddForm(MesPlantManagementEntity entity)
        {

            await _iMesPlantManagementBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/plantManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesPlantManagementEntity entity)
        {
            await _iMesPlantManagementBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工厂信息维护管理mes_PlantManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/plantManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesPlantManagementBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工厂信息维护管理mes_PlantManagement数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/plantManagement/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesPlantManagementBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}