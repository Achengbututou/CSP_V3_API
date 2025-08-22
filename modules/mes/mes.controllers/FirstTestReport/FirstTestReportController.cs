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
    /// 日 期： 2023-08-29 13:47:39
    /// 描 述： 收件确认
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class FirstTestReportController : BaseApiController
    {
        private readonly IMesFirstTestReportBLL _iMesFirstTestReportBLL;
        private readonly IMesFirstTestByOrderBLL _iMesFirstTestByOrderBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFirstTestReportBLL">首件检测报告接口</param>
        /// <param name="iMesFirstTestByOrderBLL">首件检测报告检验数据接口</param>
        public FirstTestReportController(IMesFirstTestReportBLL iMesFirstTestReportBLL,IMesFirstTestByOrderBLL iMesFirstTestByOrderBLL)
        {
            _iMesFirstTestReportBLL = iMesFirstTestReportBLL?? throw new ArgumentNullException(nameof(iMesFirstTestReportBLL));
            _iMesFirstTestByOrderBLL = iMesFirstTestByOrderBLL?? throw new ArgumentNullException(nameof(iMesFirstTestByOrderBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取收件确认的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/firstTestReports")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesFirstTestReportEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesFirstTestReportEntity queryParams)
        {
            var list = await _iMesFirstTestReportBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取收件确认的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/firstTestReport/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesFirstTestReportEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesFirstTestReportEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesFirstTestReportBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/firstTestReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<FirstTestReportDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new FirstTestReportDto();
            res.MesFirstTestReportEntity = await _iMesFirstTestReportBLL.GetEntity(id);
            if(res.MesFirstTestReportEntity != null)
            {
                res.MesFirstTestByOrderList = await _iMesFirstTestByOrderBLL.GetList(new MesFirstTestByOrderEntity { F_FirstTestReportId = res.MesFirstTestReportEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/firstTestReport/mesFirstTestReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFirstTestReportEntity>), 200)]
        public async Task<IActionResult>GetMesFirstTestReportEntity(string id)
        {
            var data = await _iMesFirstTestReportBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取首件检测报告检验数据mes_FirstTestByOrder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/firstTestReport/mesFirstTestByOrders")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesFirstTestByOrderEntity>>), 200)]
        public async Task<IActionResult> GetMesFirstTestByOrderList([FromQuery]MesFirstTestByOrderEntity queryParams)
        {
            var list = await _iMesFirstTestByOrderBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取首件检测报告检验数据mes_FirstTestByOrder的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/firstTestReport/mesFirstTestByOrder/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesFirstTestByOrderEntity>>), 200)]
        public async Task<IActionResult> GetMesFirstTestByOrderPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesFirstTestByOrderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesFirstTestByOrderBLL.GetPageList(pagination,queryParams);
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
        /// 获取首件检测报告检验数据mes_FirstTestByOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/firstTestReport/mesFirstTestByOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesFirstTestByOrderEntity>), 200)]
        public async Task<IActionResult>GetMesFirstTestByOrderEntity(string id)
        {
            var data = await _iMesFirstTestByOrderBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/firstTestReport")]
        [ProducesResponseType(typeof(ResponseDto<MesFirstTestReportEntity>), 200)]
        public async Task<IActionResult>AddForm(FirstTestReportDto dto)
        {
            await _iMesFirstTestReportBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesFirstTestReportEntity);
        }
        /// <summary>
        /// 新增首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/firstTestReport/mesFirstTestReport")]
        [ProducesResponseType(typeof(ResponseDto<MesFirstTestReportEntity>), 200)]
        public async Task<IActionResult>AddMesFirstTestReport(MesFirstTestReportEntity entity)
        {
            await _iMesFirstTestReportBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增首件检测报告检验数据mes_FirstTestByOrder数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/firstTestReport/mesFirstTestByOrder")]
        [ProducesResponseType(typeof(ResponseDto<MesFirstTestByOrderEntity>), 200)]
        public async Task<IActionResult>AddMesFirstTestByOrder(MesFirstTestByOrderEntity entity)
        {
            await _iMesFirstTestByOrderBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/firstTestReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,FirstTestReportDto dto)
        {
            await _iMesFirstTestReportBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/firstTestReport/mesFirstTestReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesFirstTestReport(string id,MesFirstTestReportEntity entity)
        {
            await _iMesFirstTestReportBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新首件检测报告检验数据mes_FirstTestByOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/firstTestReport/mesFirstTestByOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesFirstTestByOrder(string id,MesFirstTestByOrderEntity entity)
        {
            await _iMesFirstTestByOrderBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/firstTestReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesFirstTestReportBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/firstTestReport/mesFirstTestReport/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFirstTestReport(string id)
        {
            await _iMesFirstTestReportBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除首件检测报告检验数据mes_FirstTestByOrder数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/firstTestReport/mesFirstTestByOrder/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFirstTestByOrder(string id)
        {
            await _iMesFirstTestByOrderBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/firstTestReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesFirstTestReportBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除首件检测报告mes_FirstTestReport数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/firstTestReport/mesFirstTestReport/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFirstTestReports(string ids)
        {
            await _iMesFirstTestReportBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除首件检测报告检验数据mes_FirstTestByOrder数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/firstTestReport/mesFirstTestByOrder/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesFirstTestByOrders(string ids)
        {
            await _iMesFirstTestByOrderBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}