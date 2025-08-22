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
    /// 日 期： 2023-08-18 11:30:09
    /// 描 述： 工序派工批次
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessBacthInfoController : BaseApiController
    {
        private readonly IMesProcessBacthInfoBLL _iMesProcessBacthInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessBacthInfoBLL">工序派工批次信息接口</param>
        public ProcessBacthInfoController(IMesProcessBacthInfoBLL iMesProcessBacthInfoBLL)
        {
            _iMesProcessBacthInfoBLL = iMesProcessBacthInfoBLL?? throw new ArgumentNullException(nameof(iMesProcessBacthInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工序派工批次的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processBacthInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessBacthInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessBacthInfoEntity queryParams)
        {
            var list = await _iMesProcessBacthInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序派工批次的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processBacthInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessBacthInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessBacthInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessBacthInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/processBacthInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessBacthInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProcessBacthInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/processBacthInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessBacthInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProcessBacthInfoEntity entity)
        {
            await _iMesProcessBacthInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/processBacthInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProcessBacthInfoEntity entity)
        {
            await _iMesProcessBacthInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工序派工批次信息mes_ProcessBacthInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processBacthInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessBacthInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序派工批次信息mes_ProcessBacthInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processBacthInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessBacthInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}