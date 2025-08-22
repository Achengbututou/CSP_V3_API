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
    /// 日 期： 2023-09-05 15:51:41
    /// 描 述： 库存台账
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class InventoryLedgerController : BaseApiController
    {
        private readonly IMesInventoryLedgerBLL _iMesInventoryLedgerBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInventoryLedgerBLL">库存台账接口</param>
        public InventoryLedgerController(IMesInventoryLedgerBLL iMesInventoryLedgerBLL)
        {
            _iMesInventoryLedgerBLL = iMesInventoryLedgerBLL?? throw new ArgumentNullException(nameof(iMesInventoryLedgerBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取库存台账的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryLedgers")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInventoryLedgerEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesInventoryLedgerEntity queryParams)
        {
            var list = await _iMesInventoryLedgerBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取库存台账的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryLedger/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInventoryLedgerEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInventoryLedgerEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInventoryLedgerBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/inventoryLedger/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryLedgerEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesInventoryLedgerBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/inventoryLedger")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryLedgerEntity>), 200)]
        public async Task<IActionResult>AddForm(MesInventoryLedgerEntity entity)
        {
            await _iMesInventoryLedgerBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/inventoryLedger/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesInventoryLedgerEntity entity)
        {
            await _iMesInventoryLedgerBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除库存台账mes_InventoryLedger数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryLedger/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesInventoryLedgerBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除库存台账mes_InventoryLedger数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryLedger/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesInventoryLedgerBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}