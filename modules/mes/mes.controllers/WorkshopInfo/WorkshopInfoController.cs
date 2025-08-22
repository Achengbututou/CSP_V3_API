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
    /// 日 期： 2023-07-27 13:56:01
    /// 描 述： 车间信息
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class WorkshopInfoController : BaseApiController
    {
        private readonly IMesWorkshopInfoBLL _iMesWorkshopInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesWorkshopInfoBLL">车间信息接口</param>
        public WorkshopInfoController(IMesWorkshopInfoBLL iMesWorkshopInfoBLL)
        {
            _iMesWorkshopInfoBLL = iMesWorkshopInfoBLL?? throw new ArgumentNullException(nameof(iMesWorkshopInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取车间信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/workshopInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesWorkshopInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesWorkshopInfoEntity queryParams)
        {
            var list = await _iMesWorkshopInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取车间信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/workshopInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWorkshopInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesWorkshopInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWorkshopInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/workshopInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesWorkshopInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesWorkshopInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/workshopInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesWorkshopInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesWorkshopInfoEntity entity)
        {
            await _iMesWorkshopInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/workshopInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesWorkshopInfoEntity entity)
        {
            await _iMesWorkshopInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除车间信息mes_WorkshopInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/workshopInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesWorkshopInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除车间信息mes_WorkshopInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/workshopInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesWorkshopInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}