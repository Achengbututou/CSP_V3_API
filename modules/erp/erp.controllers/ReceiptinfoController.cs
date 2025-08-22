using erp.ibll;
using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace learun.quartz.controllers
{
    /// <summary>
    /// Quartz
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:39:23
    /// 描 述： lr_erp_receiptinfo
    /// </summary>
    public class ReceiptinfoController : BaseApiController
    {
        private readonly IReceiptinfoBLL _iLr_erp_receiptinfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_receiptinfoBLL">接口</param>
        public ReceiptinfoController(IReceiptinfoBLL iLr_erp_receiptinfoBLL)
        {
            _iLr_erp_receiptinfoBLL = iLr_erp_receiptinfoBLL?? throw new ArgumentNullException(nameof(iLr_erp_receiptinfoBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_receiptinfo的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/receiptinfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_receiptinfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_receiptinfoEntity queryParams)
        {
            var list = await _iLr_erp_receiptinfoBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_receiptinfo的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/receiptinfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_receiptinfoEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_receiptinfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_receiptinfoBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_receiptinfo的表单数据
        /// </summary>
        /// <param name="f_Id"></param>
        /// <returns></returns>
        [HttpGet("erp/receiptinfo/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<ReceiptinfoDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new ReceiptinfoDto();
            data.Erp_receiptinfoEntity = await _iLr_erp_receiptinfoBLL.GetEntity(f_Id);
            data.Erp_receiptinfo_detailList = await _iLr_erp_receiptinfoBLL.GetLr_erp_receiptinfodetailList(data.Erp_receiptinfoEntity.F_Id);
            return Success(data);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_receiptinfoDto">实体数据</param>
        [HttpPost("erp/receiptinfo")]
        [ProducesResponseType(typeof(ResponseDto<Erp_receiptinfoEntity>), 200)]
        public async Task<IActionResult> AddEntity(ReceiptinfoDto lr_erp_receiptinfoDto)
        {
            await _iLr_erp_receiptinfoBLL.SaveEntity(null,lr_erp_receiptinfoDto.Erp_receiptinfoEntity, lr_erp_receiptinfoDto.Erp_receiptinfo_detailList);
            return Success("新增成功！",lr_erp_receiptinfoDto.Erp_receiptinfoEntity);
        }



        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id"></param>
        /// <param name="lr_erp_receiptinfoDto">实体数据</param>
        [HttpPut("erp/receiptinfo/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,ReceiptinfoDto lr_erp_receiptinfoDto)
        {
            await _iLr_erp_receiptinfoBLL.SaveEntity(f_Id,lr_erp_receiptinfoDto.Erp_receiptinfoEntity, lr_erp_receiptinfoDto.Erp_receiptinfo_detailList);
            return SuccessInfo("更新成功！");
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id"></param>
        [HttpDelete("erp/receiptinfo/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_receiptinfoBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }


        #endregion       
    }
}