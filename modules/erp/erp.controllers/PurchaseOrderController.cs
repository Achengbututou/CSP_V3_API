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
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:32:13
    /// 描 述： lr_erp_purchaseorder
    /// </summary>
    public class PurchaseOrderController : BaseApiController
    {
        private readonly IPurchaseOrderBLL _iLr_erp_purchaseorderBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_purchaseorderBLL">接口</param>
        public PurchaseOrderController(IPurchaseOrderBLL iLr_erp_purchaseorderBLL)
        {
            _iLr_erp_purchaseorderBLL = iLr_erp_purchaseorderBLL?? throw new ArgumentNullException(nameof(iLr_erp_purchaseorderBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchaseorder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/purchaseorders")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_purchase_orderEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_purchase_orderEntity queryParams)
        {
            var list = await _iLr_erp_purchaseorderBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_purchaseorder的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/purchaseorder/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_purchase_orderEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_purchase_orderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_purchaseorderBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_purchaseorder的表单数据
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        [HttpGet("erp/purchaseorder/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<PurchaseOrderDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new PurchaseOrderDto();
            data.Erp_purchase_orderEntity = await _iLr_erp_purchaseorderBLL.GetEntity(f_Id);
            data.Erp_purchase_order_detailList = await _iLr_erp_purchaseorderBLL.GetLr_erp_purchaseorderdetailList(data.Erp_purchase_orderEntity.F_Id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_purchaseorderDto">实体数据</param>
        [HttpPost("erp/purchaseorder")]
        [ProducesResponseType(typeof(ResponseDto<Erp_purchase_orderEntity>), 200)]
        public async Task<IActionResult> AddEntity(PurchaseOrderDto lr_erp_purchaseorderDto)
        {
            lr_erp_purchaseorderDto.Erp_purchase_orderEntity.F_ModifyUserName = GetUserName();//修改用户名称
            foreach (var item in lr_erp_purchaseorderDto.Erp_purchase_order_detailList)
            {
                item.F_DeleteMark = 0;
                item.F_POID = lr_erp_purchaseorderDto.Erp_purchase_orderEntity.F_Id;
            }
            await _iLr_erp_purchaseorderBLL.SaveEntity(null,lr_erp_purchaseorderDto.Erp_purchase_orderEntity, lr_erp_purchaseorderDto.Erp_purchase_order_detailList);
            return Success("新增成功！",lr_erp_purchaseorderDto.Erp_purchase_orderEntity);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchaseorderDto">实体数据</param>
        [HttpPut("erp/purchaseorder/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,PurchaseOrderDto lr_erp_purchaseorderDto)
        {
            await _iLr_erp_purchaseorderBLL.SaveEntity(f_Id,lr_erp_purchaseorderDto.Erp_purchase_orderEntity, lr_erp_purchaseorderDto.Erp_purchase_order_detailList);
            return SuccessInfo("更新成功！");
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        [HttpDelete("erp/purchaseorder/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_purchaseorderBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }



        #endregion       
    }
}