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
    /// 日 期： 2021-06-08 10:34:39
    /// 描 述： lr_erp_payinfo
    /// </summary>
    public class PayinfoController : BaseApiController
    {
        private readonly IPayinfoBLL _iLr_erp_payinfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iLr_erp_payinfoBLL">接口</param>
        public PayinfoController(IPayinfoBLL iLr_erp_payinfoBLL)
        {
            _iLr_erp_payinfoBLL = iLr_erp_payinfoBLL?? throw new ArgumentNullException(nameof(iLr_erp_payinfoBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取lr_erp_payinfo的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/payinfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Erp_payinfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]Erp_payinfoEntity queryParams)
        {
            var list = await _iLr_erp_payinfoBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取lr_erp_payinfo的列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erp/payinfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<Erp_payinfoEntity>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]Erp_payinfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iLr_erp_payinfoBLL.GetPageList(pagination,queryParams);
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
        /// 获取主表lr_erp_payinfo的表单数据
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        [HttpGet("erp/payinfo/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto<PayinfoDto>), 200)]
        public async Task<IActionResult> GetForm(String f_Id)
        {
            var data = new PayinfoDto();
            data.Erp_payinfoEntity = await _iLr_erp_payinfoBLL.GetEntity(f_Id);
            data.Erp_payinfo_detailList = await _iLr_erp_payinfoBLL.GetLr_erp_payinfodetailList(data.Erp_payinfoEntity.F_Id);
            return Success(data);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="lr_erp_payinfoDto">实体数据</param>
        [HttpPost("erp/payinfo")]
        [ProducesResponseType(typeof(ResponseDto<Erp_payinfoEntity>), 200)]
        public async Task<IActionResult> AddEntity(PayinfoDto lr_erp_payinfoDto)
        {
            await _iLr_erp_payinfoBLL.SaveEntity(null,lr_erp_payinfoDto.Erp_payinfoEntity,lr_erp_payinfoDto.Erp_payinfo_detailList);
            return Success("新增成功！",lr_erp_payinfoDto.Erp_payinfoEntity);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_payinfoDto">实体数据</param>
        [HttpPut("erp/payinfo/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEntity(String f_Id,PayinfoDto lr_erp_payinfoDto)
        {
            await _iLr_erp_payinfoBLL.SaveEntity(f_Id,lr_erp_payinfoDto.Erp_payinfoEntity,lr_erp_payinfoDto.Erp_payinfo_detailList);
            return SuccessInfo("更新成功！");
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        [HttpDelete("erp/payinfo/{f_Id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> Delete(String f_Id)
        {
            await _iLr_erp_payinfoBLL.Delete(f_Id);
            return SuccessInfo("删除成功！");
        }

        #endregion       
    }
}