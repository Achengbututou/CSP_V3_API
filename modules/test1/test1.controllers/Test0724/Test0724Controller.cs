using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test1.ibll;

namespace Test1.controllers
{
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：undefined
    /// 日 期： 2024-07-24 16:39:53
    /// 描 述： 测试代码生成
    /// </summary>
    public class Test0724Controller : BaseApiController
    {
        private readonly IF_parentBLL _iF_parentBLL;
        private readonly IF_childrenBLL _iF_childrenBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iF_parentBLL">接口</param>
        /// <param name="iF_childrenBLL">接口</param>
        public Test0724Controller(IF_parentBLL iF_parentBLL,IF_childrenBLL iF_childrenBLL)
        {
            _iF_parentBLL = iF_parentBLL?? throw new ArgumentNullException(nameof(iF_parentBLL));
            _iF_childrenBLL = iF_childrenBLL?? throw new ArgumentNullException(nameof(iF_childrenBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取测试代码生成的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("test1/test0724s")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<F_parentEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]F_parentEntity queryParams)
        {
            var list = await _iF_parentBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取测试代码生成的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("test1/test0724/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<F_parentEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]F_parentEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iF_parentBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("test1/test0724/{id}")]
        [ProducesResponseType(typeof(ResponseDto<Test0724Dto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new Test0724Dto();
            res.F_parentEntity = await _iF_parentBLL.GetEntity(id);
            if(res.F_parentEntity != null)
            {
                res.F_childrenList = await _iF_childrenBLL.GetList(new F_childrenEntity { F_parentId = res.F_parentEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取F_parent数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("test1/test0724/f_parent/{id}")]
        [ProducesResponseType(typeof(ResponseDto<F_parentEntity>), 200)]
        public async Task<IActionResult>GetF_parentEntity(string id)
        {
            var data = await _iF_parentBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取F_children的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("test1/test0724/f_childrens")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<F_childrenEntity>>), 200)]
        public async Task<IActionResult> GetF_childrenList([FromQuery]F_childrenEntity queryParams)
        {
            var list = await _iF_childrenBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取F_children的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("test1/test0724/f_children/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<F_childrenEntity>>), 200)]
        public async Task<IActionResult> GetF_childrenPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]F_childrenEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iF_childrenBLL.GetPageList(pagination,queryParams);
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
        /// 获取F_children数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("test1/test0724/f_children/{id}")]
        [ProducesResponseType(typeof(ResponseDto<F_childrenEntity>), 200)]
        public async Task<IActionResult>GetF_childrenEntity(string id)
        {
            var data = await _iF_childrenBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("test1/test0724")]
        [ProducesResponseType(typeof(ResponseDto<F_parentEntity>), 200)]
        public async Task<IActionResult>AddForm(Test0724Dto dto)
        {
            await _iF_parentBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.F_parentEntity);
        }
        /// <summary>
        /// 新增F_parent数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("test1/test0724/f_parent")]
        [ProducesResponseType(typeof(ResponseDto<F_parentEntity>), 200)]
        public async Task<IActionResult>AddF_parent(F_parentEntity entity)
        {
            await _iF_parentBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增F_children数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("test1/test0724/f_children")]
        [ProducesResponseType(typeof(ResponseDto<F_childrenEntity>), 200)]
        public async Task<IActionResult>AddF_children(F_childrenEntity entity)
        {
            await _iF_childrenBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("test1/test0724/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,Test0724Dto dto)
        {
            await _iF_parentBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新F_parent数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("test1/test0724/f_parent/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateF_parent(string id,F_parentEntity entity)
        {
            await _iF_parentBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新F_children数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("test1/test0724/f_children/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateF_children(string id,F_childrenEntity entity)
        {
            await _iF_childrenBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除F_parent数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("test1/test0724/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iF_parentBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除F_parent数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("test1/test0724/f_parent/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteF_parent(string id)
        {
            await _iF_parentBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除F_children数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("test1/test0724/f_children/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteF_children(string id)
        {
            await _iF_childrenBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除F_parent数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("test1/test0724/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iF_parentBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除F_parent数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("test1/test0724/f_parent/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteF_parents(string ids)
        {
            await _iF_parentBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除F_children数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("test1/test0724/f_children/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteF_childrens(string ids)
        {
            await _iF_childrenBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}