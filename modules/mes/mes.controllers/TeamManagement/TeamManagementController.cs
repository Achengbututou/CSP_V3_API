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
    /// 日 期： 2023-08-08 14:33:08
    /// 描 述： 班组管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class TeamManagementController : BaseApiController
    {
        private readonly IMesTeamManagementBLL _iMesTeamManagementBLL;
        private readonly IMesTeamMembersBLL _iMesTeamMembersBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTeamManagementBLL">班组管理接口</param>
        /// <param name="iMesTeamMembersBLL">班组人员接口</param>
        public TeamManagementController(IMesTeamManagementBLL iMesTeamManagementBLL,IMesTeamMembersBLL iMesTeamMembersBLL)
        {
            _iMesTeamManagementBLL = iMesTeamManagementBLL?? throw new ArgumentNullException(nameof(iMesTeamManagementBLL));
            _iMesTeamMembersBLL = iMesTeamMembersBLL?? throw new ArgumentNullException(nameof(iMesTeamMembersBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取班组管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/teamManagements")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTeamManagementEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesTeamManagementEntity queryParams)
        {
            var list = await _iMesTeamManagementBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取班组管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/teamManagement/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTeamManagementEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTeamManagementEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTeamManagementBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/teamManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto<TeamManagementDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new TeamManagementDto();
            res.MesTeamManagementEntity = await _iMesTeamManagementBLL.GetEntity(id);
            if(res.MesTeamManagementEntity != null)
            {
                res.MesTeamMembersList = await _iMesTeamMembersBLL.GetList(new MesTeamMembersEntity { F_TeamManagementId = res.MesTeamManagementEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/teamManagement/mesTeamManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamManagementEntity>), 200)]
        public async Task<IActionResult>GetMesTeamManagementEntity(string id)
        {
            var data = await _iMesTeamManagementBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取班组人员mes_TeamMembers的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/teamManagement/mesTeamMemberss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTeamMembersEntity>>), 200)]
        public async Task<IActionResult> GetMesTeamMembersList([FromQuery]MesTeamMembersEntity queryParams)
        {
            var list = await _iMesTeamMembersBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取班组人员mes_TeamMembers的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/teamManagement/mesTeamMembers/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTeamMembersEntity>>), 200)]
        public async Task<IActionResult> GetMesTeamMembersPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTeamMembersEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTeamMembersBLL.GetPageList(pagination,queryParams);
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
        /// 获取班组人员mes_TeamMembers数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/teamManagement/mesTeamMembers/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamMembersEntity>), 200)]
        public async Task<IActionResult>GetMesTeamMembersEntity(string id)
        {
            var data = await _iMesTeamMembersBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/teamManagement")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamManagementEntity>), 200)]
        public async Task<IActionResult>AddForm(TeamManagementDto dto)
        {
            await _iMesTeamManagementBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesTeamManagementEntity);
        }
        /// <summary>
        /// 新增班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/teamManagement/mesTeamManagement")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamManagementEntity>), 200)]
        public async Task<IActionResult>AddMesTeamManagement(MesTeamManagementEntity entity)
        {
            await _iMesTeamManagementBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增班组人员mes_TeamMembers数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/teamManagement/mesTeamMembers")]
        [ProducesResponseType(typeof(ResponseDto<MesTeamMembersEntity>), 200)]
        public async Task<IActionResult>AddMesTeamMembers(MesTeamMembersEntity entity)
        {
            await _iMesTeamMembersBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/teamManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,TeamManagementDto dto)
        {
            await _iMesTeamManagementBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/teamManagement/mesTeamManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesTeamManagement(string id,MesTeamManagementEntity entity)
        {
            await _iMesTeamManagementBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新班组人员mes_TeamMembers数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/teamManagement/mesTeamMembers/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesTeamMembers(string id,MesTeamMembersEntity entity)
        {
            await _iMesTeamMembersBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/teamManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesTeamManagementBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/teamManagement/mesTeamManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTeamManagement(string id)
        {
            await _iMesTeamManagementBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除班组人员mes_TeamMembers数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/teamManagement/mesTeamMembers/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTeamMembers(string id)
        {
            await _iMesTeamMembersBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/teamManagement/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesTeamManagementBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除班组管理mes_TeamManagement数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/teamManagement/mesTeamManagement/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTeamManagements(string ids)
        {
            await _iMesTeamManagementBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除班组人员mes_TeamMembers数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/teamManagement/mesTeamMembers/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTeamMemberss(string ids)
        {
            await _iMesTeamMembersBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}