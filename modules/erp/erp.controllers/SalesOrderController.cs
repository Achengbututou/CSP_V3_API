using erp.ibll;
using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp.controllers
{
    /// <summary>
    /// Quartz
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:37:10
    /// 描 述： lr_erp_salesorder
    /// </summary>
    public class SalesOrderController : BaseApiController
    {
        private readonly ISalesOrderBLL _iLr_erp_salesorderBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_salesorderBLL">接口</param>
        public SalesOrderController(ISalesOrderBLL iLr_erp_salesorderBLL)
        {
            _iLr_erp_salesorderBLL = iLr_erp_salesorderBLL?? throw new ArgumentNullException(nameof(iLr_erp_salesorderBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_salesorder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/salesorders")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_sales_orderEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_sales_orderEntity queryParams)
        {
            var list = await _iLr_erp_salesorderBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_salesorder的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/salesorder/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_sales_orderEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_sales_orderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_salesorderBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_salesorder的表单数据
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        [HttpGet("erp/salesorder/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<SalesOrderDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new SalesOrderDto();
            data.Erp_sales_orderEntity = await _iLr_erp_salesorderBLL.GetEntity(f_Id);
            data.Erp_sales_order_detailList = await _iLr_erp_salesorderBLL.GetLr_erp_salesorderdetailList(data.Erp_sales_orderEntity.F_Id);
            return Success(data);
        }





        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_salesorderDto">实体数据</param>
        [HttpPost("erp/salesorder")]
        [ProducesResponseType(typeof(ResponseDto<Erp_sales_orderEntity>), 200)]
        public async Task<IActionResult> AddEntity(SalesOrderDto lr_erp_salesorderDto)
        {
            await _iLr_erp_salesorderBLL.SaveEntity(null,lr_erp_salesorderDto.Erp_sales_orderEntity,lr_erp_salesorderDto.Erp_sales_order_detailList);
            return Success("新增成功！",lr_erp_salesorderDto.Erp_sales_orderEntity);
        }



        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_salesorderDto">实体数据</param>
        [HttpPut("erp/salesorder/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,SalesOrderDto lr_erp_salesorderDto)
        {
            await _iLr_erp_salesorderBLL.SaveEntity(f_Id,lr_erp_salesorderDto.Erp_sales_orderEntity,lr_erp_salesorderDto.Erp_sales_order_detailList);
            return SuccessInfo("更新成功！");
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        [HttpDelete("erp/salesorder/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_salesorderBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }



        #endregion       
    }
}