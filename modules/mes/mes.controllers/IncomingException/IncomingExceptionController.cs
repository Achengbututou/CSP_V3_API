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
    /// 日 期： 2023-08-23 10:32:39
    /// 描 述： 来料异常检验报告
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class IncomingExceptionController : BaseApiController
    {
        private readonly IMesIncomingExceptionBLL _iMesIncomingExceptionBLL;
        private readonly IMesIncomingInspectionBLL _iMesIncomingInspectionBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesIncomingExceptionBLL"></param>
        /// <param name="iMesIncomingInspectionBLL"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IncomingExceptionController(IMesIncomingExceptionBLL iMesIncomingExceptionBLL, IMesIncomingInspectionBLL iMesIncomingInspectionBLL)
        {
            _iMesIncomingExceptionBLL = iMesIncomingExceptionBLL?? throw new ArgumentNullException(nameof(iMesIncomingExceptionBLL));
            _iMesIncomingInspectionBLL = iMesIncomingInspectionBLL ?? throw new ArgumentNullException(nameof(iMesIncomingInspectionBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取来料异常检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingExceptions")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesIncomingExceptionEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesIncomingExceptionEntity queryParams)
        {
            var list = await _iMesIncomingExceptionBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取来料异常检验报告的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/incomingException/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesIncomingExceptionEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesIncomingExceptionEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesIncomingExceptionBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/incomingException/{id}")]
        [ProducesResponseType(typeof(ResponseDto<IncomingExceptionReDTO>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new IncomingExceptionReDTO();
            res.mesIncomingException = await _iMesIncomingExceptionBLL.GetEntity(id);
            if(res.mesIncomingException != null)
            {
                res.mesIncomingInspectionEntity =await _iMesIncomingInspectionBLL.GetEntity(res.mesIncomingException.F_IncomingInspectionId);
            }
            return Success(res);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/incomingException")]
        [ProducesResponseType(typeof(ResponseDto<MesIncomingExceptionEntity>), 200)]
        public async Task<IActionResult>AddForm(MesIncomingExceptionEntity entity)
        {
            await _iMesIncomingExceptionBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/incomingException/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesIncomingExceptionEntity entity)
        {
            await _iMesIncomingExceptionBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除来料异常检验报告mes_incomingexcept数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingException/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesIncomingExceptionBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除来料异常检验报告mes_incomingexcept数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/incomingException/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesIncomingExceptionBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}