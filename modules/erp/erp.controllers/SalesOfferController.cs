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
    /// 日 期： 2021-06-08 10:36:08
    /// 描 述： lr_erp_salesoffer
    /// </summary>
    public class SalesOfferController : BaseApiController
    {
        private readonly ISalesOfferBLL _iLr_erp_salesofferBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_salesofferBLL">接口</param>
        public SalesOfferController(ISalesOfferBLL iLr_erp_salesofferBLL)
        {
            _iLr_erp_salesofferBLL = iLr_erp_salesofferBLL?? throw new ArgumentNullException(nameof(iLr_erp_salesofferBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_salesoffer的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/salesoffers")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_sales_offerEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_sales_offerEntity queryParams)
        {
            var list = await _iLr_erp_salesofferBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_salesoffer的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/salesoffer/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_sales_offerEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_sales_offerEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_salesofferBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_salesoffer的表单数据
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        [HttpGet("erp/salesoffer/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<SalesOfferDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new SalesOfferDto();
            data.Erp_sales_offerEntity = await _iLr_erp_salesofferBLL.GetEntity(f_Id);
            data.Erp_sales_offer_detailList = await _iLr_erp_salesofferBLL.GetLr_erp_salesofferdetailList(data.Erp_sales_offerEntity.F_Id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_salesofferDto">实体数据</param>
        [HttpPost("erp/salesoffer")]
        [ProducesResponseType(typeof(ResponseDto<Erp_sales_offerEntity>), 200)]
        public async Task<IActionResult> AddEntity(SalesOfferDto lr_erp_salesofferDto)
        {
            await _iLr_erp_salesofferBLL.SaveEntity(null,lr_erp_salesofferDto.Erp_sales_offerEntity,lr_erp_salesofferDto.Erp_sales_offer_detailList);
            return Success("新增成功！",lr_erp_salesofferDto.Erp_sales_offerEntity);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_salesofferDto">实体数据</param>
        [HttpPut("erp/salesoffer/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,SalesOfferDto lr_erp_salesofferDto)
        {
            await _iLr_erp_salesofferBLL.SaveEntity(f_Id,lr_erp_salesofferDto.Erp_sales_offerEntity,lr_erp_salesofferDto.Erp_sales_offer_detailList);
            return SuccessInfo("更新成功！");
        }
        

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        [HttpDelete("erp/salesoffer/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_salesofferBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }
        #endregion       
    }
}