   using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using mes.ibll.SchedulingInfo;
using mes.bll;

namespace mes.controllers
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-10 10:01:07
    /// 描 述： 排期信息
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class SchedulingInfoController : BaseApiController
    {
        private readonly IMesSchedulingInfoBLL _iMesSchedulingInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesSchedulingInfoBLL">排期信息接口</param>
        public SchedulingInfoController(IMesSchedulingInfoBLL iMesSchedulingInfoBLL)
        {
            _iMesSchedulingInfoBLL = iMesSchedulingInfoBLL?? throw new ArgumentNullException(nameof(iMesSchedulingInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取排期信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/schedulingInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesSchedulingInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesSchedulingInfoEntity queryParams)
        {
            var list = await _iMesSchedulingInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取排期信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/schedulingInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesSchedulingInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesSchedulingInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesSchedulingInfoBLL.GetPageList(pagination,queryParams);
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
        /// 获取排期信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/schedulingInfo/ERPpage")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesSchedulingInfoEntity>>), 200)]
        public async Task<IActionResult> GetERPPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] CaseErpSaleEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesSchedulingInfoBLL.GetERPPageList(pagination, queryParams);
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
        [HttpGet("mes/schedulingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesSchedulingInfoEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesSchedulingInfoBLL.GetEntity(id);
            return Success(data);
        }

        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/schedulingInfo/detail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesSchedulingInfoEntity>), 200)]
        public async Task<IActionResult> GetDetailForm(string id)
        {
            var data = await _iMesSchedulingInfoBLL.GetMesSchedulingDetail(id);
            return Success(data);
        }
        /// <summary>
        /// 获取销售数据
        /// </summary>
        /// <param name="paginationInputDto"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpGet("mes/schedulingInfo/Saledetail")]
        [ProducesResponseType(typeof(ResponseDto<MesSchedulingInfoEntity>), 200)]
        public IActionResult GetSaledetail([FromQuery] PaginationInputDto paginationInputDto,[FromQuery] MesSchedulingInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var data =  _iMesSchedulingInfoBLL.GetTableDataList(pagination, queryParams.keyWorld);
            var jsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/schedulingInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesSchedulingInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(MesSchedulingInfoEntity entity)
        {
            await _iMesSchedulingInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/schedulingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesSchedulingInfoEntity entity)
        {
            await _iMesSchedulingInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }

        /// <summary>
        /// 排期保存
        /// </summary>
        /// <param name="schedulingDetailDTO">主键</param>
        /// <returns></returns>
        [HttpPost("mes/schedulingInfo/saveDetail")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> SaveDetail(MesSchedulingDetailDTO schedulingDetailDTO)
        {
            await _iMesSchedulingInfoBLL.SaveDetail(schedulingDetailDTO);
            return Success("排期成功！");
        }

        /// <summary>
        /// 删除排期信息mes_SchedulingInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/schedulingInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesSchedulingInfoBLL.Delete(id);
            return Success("删除成功！");
        }

        /// <summary>
        /// 删除排期详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/schedulingInfo/details/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> deleteDetail(string id)
        {
            await _iMesSchedulingInfoBLL.deleteDetail(id);
            return Success("删除排期详情成功！");
        }

        /// <summary>
        /// 批量删除排期信息mes_SchedulingInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/schedulingInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesSchedulingInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }

        /// <summary>
        /// 发布成功
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPut("mes/schedulingInfo/PublishScheduling/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> PublishScheduling(string id)
        {
            await _iMesSchedulingInfoBLL.PublishScheduling(id);
            return Success("发布成功！");
        }
        #endregion       
    }
}