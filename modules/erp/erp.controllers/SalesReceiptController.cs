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
    /// 日 期： 2021-06-08 10:38:08
    /// 描 述： lr_erp_salesreceipt
    /// </summary>
    public class SalesReceiptController : BaseApiController
    {
        private readonly ISalesReceiptBLL _iLr_erp_salesreceiptBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_salesreceiptBLL">接口</param>
        public SalesReceiptController(ISalesReceiptBLL iLr_erp_salesreceiptBLL)
        {
            _iLr_erp_salesreceiptBLL = iLr_erp_salesreceiptBLL?? throw new ArgumentNullException(nameof(iLr_erp_salesreceiptBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_salesreceipt的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/salesreceipts")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_sales_receiptEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_sales_receiptEntity queryParams)
        {
            var list = await _iLr_erp_salesreceiptBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_salesreceipt的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/salesreceipt/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_sales_receiptEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_sales_receiptEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_salesreceiptBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_salesreceipt的表单数据
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        [HttpGet("erp/salesreceipt/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<SalesReceiptDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new SalesReceiptDto();
            data.Erp_sales_receiptEntity = await _iLr_erp_salesreceiptBLL.GetEntity(f_Id);
            data.Erp_sales_receipt_detailList = await _iLr_erp_salesreceiptBLL.GetLr_erp_salesreceiptdetailList(data.Erp_sales_receiptEntity.F_Id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_salesreceiptDto">实体数据</param>
        [HttpPost("erp/salesreceipt")]
        [ProducesResponseType(typeof(ResponseDto<Erp_sales_receiptEntity>), 200)]
        public async Task<IActionResult> AddEntity(SalesReceiptDto lr_erp_salesreceiptDto)
        {
            await _iLr_erp_salesreceiptBLL.SaveEntity(null,lr_erp_salesreceiptDto.Erp_sales_receiptEntity,lr_erp_salesreceiptDto.Erp_sales_receipt_detailList);
            return Success("新增成功！",lr_erp_salesreceiptDto.Erp_sales_receiptEntity);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_salesreceiptDto">实体数据</param>
        [HttpPut("erp/salesreceipt/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,SalesReceiptDto lr_erp_salesreceiptDto)
        {
            await _iLr_erp_salesreceiptBLL.SaveEntity(f_Id,lr_erp_salesreceiptDto.Erp_sales_receiptEntity,lr_erp_salesreceiptDto.Erp_sales_receipt_detailList);
            return SuccessInfo("更新成功！");
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        [HttpDelete("erp/salesreceipt/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_salesreceiptBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }


        #endregion       
    }
}