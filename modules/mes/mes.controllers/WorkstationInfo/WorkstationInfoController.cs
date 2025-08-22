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
    /// 日 期： 2023-07-27 15:35:03
    /// 描 述： 工位信息维护
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class WorkstationInfoController : BaseApiController
    {
        private readonly IMesWorkstationInfoBLL _iMesWorkstationInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesWorkstationInfoBLL">工位信息维护接口</param>
        public WorkstationInfoController(IMesWorkstationInfoBLL iMesWorkstationInfoBLL)
        {
            _iMesWorkstationInfoBLL = iMesWorkstationInfoBLL?? throw new ArgumentNullException(nameof(iMesWorkstationInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工位信息维护的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/workstationInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesWorkstationInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesWorkstationInfoEntity queryParams)
        {
            var list = await _iMesWorkstationInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工位信息维护的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/workstationInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWorkstationInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesWorkstationInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWorkstationInfoBLL.GetPageList(pagination,queryParams);
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
        /// 获取工位信息维护的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/workstationInfo/page/alllist")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesWorkstationInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageAllList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] MesWorkstationInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesWorkstationInfoBLL.GetPageAllList(pagination, queryParams);
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
        [HttpGet("mes/workstationInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesWorkstationInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesWorkstationInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/workstationInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesWorkstationInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesWorkstationInfoEntity entity)
        {
             await _iMesWorkstationInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/workstationInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesWorkstationInfoEntity entity)
        {
            await _iMesWorkstationInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工位信息维护mes_WorkstationInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/workstationInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesWorkstationInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工位信息维护mes_WorkstationInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/workstationInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesWorkstationInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}