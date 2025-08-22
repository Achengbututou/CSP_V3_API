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
    /// 日 期： 2023-08-18 11:18:30
    /// 描 述： 班组派工
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class TeamDispatchController : BaseApiController
    {
        private readonly IMesTeamDispatchBLL _iMesTeamDispatchBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTeamDispatchBLL">班组派工接口</param>
        public TeamDispatchController(IMesTeamDispatchBLL iMesTeamDispatchBLL)
        {
            _iMesTeamDispatchBLL = iMesTeamDispatchBLL?? throw new ArgumentNullException(nameof(iMesTeamDispatchBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取班组派工的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/teamDispatchs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTeamDispatchEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesTeamDispatchEntity queryParams)
        {
            var list = await _iMesTeamDispatchBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取班组派工的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/teamDispatch/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTeamDispatchEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTeamDispatchEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTeamDispatchBLL.GetPageList(pagination,queryParams);
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
        /// 获取工单班组派工信息
        /// </summary>
        /// <param name="id">工单主键</param>
        /// <returns></returns>
        [HttpGet("mes/teamDispatch/GetTeamDispatchList/{id}")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTeamDispatchEntity>>), 200)]
        public async Task<IActionResult> GetTeamDispatchList(string id)
        {
            var data = await _iMesTeamDispatchBLL.GetTeamDispatchList(id);
            return Success(data);
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/teamDispatch/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamDispatchEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesTeamDispatchBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/teamDispatch")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamDispatchEntity>), 200)]
        public async Task<IActionResult>AddForm(MesTeamDispatchEntity entity)
        {
            await _iMesTeamDispatchBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }

        /// <summary>
        /// 班组派单
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/teamDispatch/TeamDispatch")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamDispatchEntity>), 200)]
        public async Task<IActionResult> TeamDispatch(MesTeamDispatchEntity entity)
        {
            await _iMesTeamDispatchBLL.TeamDispatch(entity);
            return Success("指派成功！");
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/teamDispatch/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesTeamDispatchEntity entity)
        {
            await _iMesTeamDispatchBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除班组派工mes_TeamDispatch数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/teamDispatch/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesTeamDispatchBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除班组派工mes_TeamDispatch数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/teamDispatch/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesTeamDispatchBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}