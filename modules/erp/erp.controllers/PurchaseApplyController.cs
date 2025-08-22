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
    /// 日 期： 2021-06-08 10:29:59
    /// 描 述： lr_erp_purchaserequisition
    /// </summary>
    public class PurchaseApplyController : BaseApiController
    {
        private readonly IPurchaseApplyBLL _iPurchaseApplyBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iPurchaseApplyBLL">接口</param>
        public PurchaseApplyController(IPurchaseApplyBLL iPurchaseApplyBLL)
        {
            _iPurchaseApplyBLL = iPurchaseApplyBLL ?? throw new ArgumentNullException(nameof(iPurchaseApplyBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchaserequisition的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/purchaseapplys")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_purchase_applyEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] Erp_purchase_applyEntity queryParams)
        {
            var list = await _iPurchaseApplyBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_purchaserequisition的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/purchaseapply/page")]
        [ProducesResponseType(typeof(ResponseDto<PaginationOutputDto<IEnumerable<Erp_purchase_applyEntity>>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery] Erp_purchase_applyEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iPurchaseApplyBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_purchaserequisition的表单数据
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        [HttpGet("erp/purchaseapply/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<PurchaseApplyDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new PurchaseApplyDto();
            data.erp_purchase_applyEntity = await _iPurchaseApplyBLL.GetEntity(f_Id);
            data.erp_productList = await _iPurchaseApplyBLL.GetLr_erp_productinfoList(data.erp_purchase_applyEntity.F_Id);
            return Success(data);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="purchaseApplyDto">实体数据</param>
        [HttpPost("erp/purchaseapply")]
        [ProducesResponseType(typeof(ResponseDto<Erp_purchase_applyEntity>), 200)]
        public async Task<IActionResult> AddEntity(PurchaseApplyDto purchaseApplyDto)
        {
            await _iPurchaseApplyBLL.SaveEntity(null, purchaseApplyDto.erp_purchase_applyEntity, purchaseApplyDto.erp_productList);
            return Success("新增成功！", purchaseApplyDto.erp_purchase_applyEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="purchaseApplyDto">实体数据</param>
        [HttpPut("erp/purchaseapply/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id, PurchaseApplyDto purchaseApplyDto)
        {
            await _iPurchaseApplyBLL.SaveEntity(f_Id, purchaseApplyDto.erp_purchase_applyEntity, purchaseApplyDto.erp_productList);
            return SuccessInfo("更新成功！");
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        [HttpDelete("erp/purchaseapply/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iPurchaseApplyBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }

        #endregion       
    }
}