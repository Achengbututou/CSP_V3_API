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
    /// 日 期： 2023-08-18 11:31:18
    /// 描 述： 工序派工物料
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessMaterialInfoController : BaseApiController
    {
        private readonly IMesProcessMaterialInfoBLL _iMesProcessMaterialInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessMaterialInfoBLL">工序派工物料信息接口</param>
        public ProcessMaterialInfoController(IMesProcessMaterialInfoBLL iMesProcessMaterialInfoBLL)
        {
            _iMesProcessMaterialInfoBLL = iMesProcessMaterialInfoBLL?? throw new ArgumentNullException(nameof(iMesProcessMaterialInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工序派工物料的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processMaterialInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessMaterialInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessMaterialInfoEntity queryParams)
        {
            var list = await _iMesProcessMaterialInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取本级及下级物料信息
        /// </summary>
        /// <param name="id">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processMaterialInfos/GetChildrenList/{id}")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessMaterialInfoEntity>>), 200)]
        public async Task<IActionResult> GetChildrenList(string id)
        {
            var list = await _iMesProcessMaterialInfoBLL.GetChildrenList(id);
            return Success(list);
        }
        /// <summary>
        /// 获取工序派工物料的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processMaterialInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessMaterialInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessMaterialInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessMaterialInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/processMaterialInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessMaterialInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesProcessMaterialInfoBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/processMaterialInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessMaterialInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesProcessMaterialInfoEntity entity)
        {
            await _iMesProcessMaterialInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/processMaterialInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesProcessMaterialInfoEntity entity)
        {
            await _iMesProcessMaterialInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工序派工物料信息mes_ProcessMaterialInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processMaterialInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesProcessMaterialInfoBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序派工物料信息mes_ProcessMaterialInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processMaterialInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessMaterialInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}