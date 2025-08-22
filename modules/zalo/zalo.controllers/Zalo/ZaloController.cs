using ce.autofac.extension;
using learun.iapplication;
using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using zalo.ibll;


namespace zalo.controllers
{
    /// <summary>
    /// 
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：
    /// 日 期： 
    /// 描 述： 
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class ZaloController : BaseApiController
    {
        private readonly IDemoBLL _iDemoBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ZaloController()
        {
            _iDemoBLL = IocManager.Instance.GetService<IDemoBLL>();
        }

        #region 企业微信登录-供参考
        /// <summary>
        /// 企业微信登录
        /// </summary>
        /// <param name="openid">输入参数</param>
        /// <returns></returns>
        //[HttpPost("login/openidqy/{openid}")]
        [HttpPost("zalo/openidqy/{openid}")]
        [AllowAnonymous] //不需要用tokenfangwen
        [ProducesResponseType(typeof(ResponseDto<LoginOutputDto>), 200)]
        public async Task<IActionResult> OpenIdLoginQY(string openid)
        {
            return OK(await _iDemoBLL.OpenIdLoginQY(openid));
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("zalo/demos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<DemoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] DemoEntity queryParams)
        {
            var list = await _iDemoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("zalo/demo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<DemoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery] DemoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iDemoBLL.GetPageList(pagination,queryParams);
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
        /// 获取数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("zalo/demo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<DemoEntity>), 200)]
        public async Task<IActionResult>GetEntity(string id)
        {
            var data = await _iDemoBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("zalo/demo")]
        [ProducesResponseType(typeof(ResponseDto<DemoEntity>), 200)]
        public async Task<IActionResult>Add(DemoEntity entity)
        {
            await _iDemoBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("zalo/demo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>Update(string id, DemoEntity entity)
        {
            await _iDemoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("zalo/demo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>Delete(string id)
        {
            await _iDemoBLL.Delete(id);
            return Success("删除成功！");
        }
        #endregion       
    }
}