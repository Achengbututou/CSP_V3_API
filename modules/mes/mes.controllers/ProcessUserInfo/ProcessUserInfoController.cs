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
    /// 日 期： 2023-08-18 11:28:59
    /// 描 述： 工序派工用户
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessUserInfoController : BaseApiController
    {
        private readonly IMesProcessUserInfoBLL _iMesProcessUserInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessUserInfoBLL">工序派工用户详情接口</param>
        public ProcessUserInfoController(IMesProcessUserInfoBLL iMesProcessUserInfoBLL)
        {
            _iMesProcessUserInfoBLL = iMesProcessUserInfoBLL?? throw new ArgumentNullException(nameof(iMesProcessUserInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工序派工用户的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processUserInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessUserInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessUserInfoEntity queryParams)
        {
            var list = await _iMesProcessUserInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序派工用户的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processUserInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessUserInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessUserInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessUserInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/processUserInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessUserInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProcessUserInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/processUserInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessUserInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProcessUserInfoEntity entity)
        {
            await _iMesProcessUserInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/processUserInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProcessUserInfoEntity entity)
        {
            await _iMesProcessUserInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 工序派工用户派工
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        [HttpPut("mes/processUserInfo/DispatchUser")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DispatchUser(List<MesProcessUserInfoEntity> entitys)
        {
            await _iMesProcessUserInfoBLL.DispatchUser(entitys);
            return Success("更新成功！");
        }

        /// <summary>
        /// 删除工序派工用户详情mes_ProcessUserInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processUserInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessUserInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序派工用户详情mes_ProcessUserInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processUserInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessUserInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}