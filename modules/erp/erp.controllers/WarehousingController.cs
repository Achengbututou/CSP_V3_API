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
    /// 日 期： 2021-06-08 10:33:31
    /// 描 述： lr_erp_purchasewarehous
    /// </summary>
    public class WarehousingController : BaseApiController
    {
        private readonly IWarehousingBLL _iLr_erp_purchasewarehousBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_purchasewarehousBLL">接口</param>
        public WarehousingController(IWarehousingBLL iLr_erp_purchasewarehousBLL)
        {
            _iLr_erp_purchasewarehousBLL = iLr_erp_purchasewarehousBLL?? throw new ArgumentNullException(nameof(iLr_erp_purchasewarehousBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchasewarehous的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/warehousings")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_warehousingEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_warehousingEntity queryParams)
        {
            var list = await _iLr_erp_purchasewarehousBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_purchasewarehous的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/warehousing/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_warehousingEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_warehousingEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_purchasewarehousBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_purchasewarehous的表单数据
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        [HttpGet("erp/warehousing/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<WarehousingDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new WarehousingDto();
            data.Erp_warehousingEntity = await _iLr_erp_purchasewarehousBLL.GetEntity(f_Id);
            data.Erp_warehousing_detailList = await _iLr_erp_purchasewarehousBLL.GetLr_erp_purchasewarehoudetailList(data.Erp_warehousingEntity.F_Id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_purchasewarehousDto">实体数据</param>
        [HttpPost("erp/warehousing")]
        [ProducesResponseType(typeof(ResponseDto<Erp_warehousingEntity>), 200)]
        public async Task<IActionResult> AddEntity(WarehousingDto lr_erp_purchasewarehousDto)
        {
            await _iLr_erp_purchasewarehousBLL.SaveEntity(null,lr_erp_purchasewarehousDto.Erp_warehousingEntity,lr_erp_purchasewarehousDto.Erp_warehousing_detailList);
            return Success("新增成功！",lr_erp_purchasewarehousDto.Erp_warehousingEntity);
        }



        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchasewarehousDto">实体数据</param>
        [HttpPut("erp/warehousing/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,WarehousingDto lr_erp_purchasewarehousDto)
        {
            await _iLr_erp_purchasewarehousBLL.SaveEntity(f_Id,lr_erp_purchasewarehousDto.Erp_warehousingEntity, lr_erp_purchasewarehousDto.Erp_warehousing_detailList);
            return SuccessInfo("更新成功！");
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        [HttpDelete("erp/warehousing/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_purchasewarehousBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }


        #endregion       
    }
}