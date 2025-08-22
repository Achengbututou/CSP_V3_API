using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demo.ibll;

namespace demo.controllers
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2022-06-13 10:53:49
    /// 描 述： 配车单
    /// </summary>
    public class MatecardetailController : BaseApiController
    {
        private readonly IEwMatecardetailCurmBLL _iEwMatecardetailCurmBLL;
        private readonly IEwCurmBLL _iEwCurmBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iEwMatecardetailCurmBLL">【苏州益维鑫】配车单子表接口</param>
        /// <param name="iEwCurmBLL">【苏州益维鑫】现存量表接口</param>
        public MatecardetailController(IEwMatecardetailCurmBLL iEwMatecardetailCurmBLL,IEwCurmBLL iEwCurmBLL)
        {
            _iEwMatecardetailCurmBLL = iEwMatecardetailCurmBLL ?? throw new ArgumentNullException(nameof(iEwMatecardetailCurmBLL));
            _iEwCurmBLL = iEwCurmBLL?? throw new ArgumentNullException(nameof(iEwCurmBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取配车单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecardetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EwMatecardetailEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]EwMatecardetailEntity queryParams)
        {
            var list = await _iEwMatecardetailCurmBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取配车单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecardetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EwMatecardetailEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]EwMatecardetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEwMatecardetailCurmBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("demo/matecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MatecardetailDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new MatecardetailDto();
            res.EwMatecardetailEntity = await _iEwMatecardetailCurmBLL.GetEntity(id);
            if(res.EwMatecardetailEntity != null)
            {
                res.EwCurmList = await _iEwCurmBLL.GetList(new EwCurmEntity { F_matecardetailId = res.EwMatecardetailEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("demo/matecardetail/ewMatecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecardetailEntity>), 200)]
        public async Task<IActionResult>GetEwMatecardetailEntity(string id)
        {
            var data = await _iEwMatecardetailCurmBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取【苏州益维鑫】现存量表ew_curm的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecardetail/ewCurms")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EwCurmEntity>>), 200)]
        public async Task<IActionResult> GetEwCurmList([FromQuery]EwCurmEntity queryParams)
        {
            var list = await _iEwCurmBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取【苏州益维鑫】现存量表ew_curm的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecardetail/ewCurm/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EwCurmEntity>>), 200)]
        public async Task<IActionResult> GetEwCurmPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]EwCurmEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEwCurmBLL.GetPageList(pagination,queryParams);
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
        /// 获取【苏州益维鑫】现存量表ew_curm数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("demo/matecardetail/ewCurm/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EwCurmEntity>), 200)]
        public async Task<IActionResult>GetEwCurmEntity(string id)
        {
            var data = await _iEwCurmBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("demo/matecardetail")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecardetailEntity>), 200)]
        public async Task<IActionResult>AddForm(MatecardetailDto dto)
        {
            await _iEwMatecardetailCurmBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.EwMatecardetailEntity);
        }
        /// <summary>
        /// 新增【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("demo/matecardetail/ewMatecardetail")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecardetailEntity>), 200)]
        public async Task<IActionResult>AddEwMatecardetail(EwMatecardetailEntity entity)
        {
            await _iEwMatecardetailCurmBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增【苏州益维鑫】现存量表ew_curm数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("demo/matecardetail/ewCurm")]
        [ProducesResponseType(typeof(ResponseDto<EwCurmEntity>), 200)]
        public async Task<IActionResult>AddEwCurm(EwCurmEntity entity)
        {
            await _iEwCurmBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("demo/matecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MatecardetailDto dto)
        {
            await _iEwMatecardetailCurmBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">id主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("demo/matecardetail/ewMatecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateEwMatecardetail(string id,EwMatecardetailEntity entity)
        {
            await _iEwMatecardetailCurmBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新【苏州益维鑫】现存量表ew_curm数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("demo/matecardetail/ewCurm/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateEwCurm(string id,EwCurmEntity entity)
        {
            await _iEwCurmBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }

        /// <summary>
        /// 删除【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("demo/matecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iEwMatecardetailCurmBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("demo/matecardetail/ewMatecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteEwMatecardetail(string id)
        {
            await _iEwMatecardetailCurmBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除【苏州益维鑫】现存量表ew_curm数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("demo/matecardetail/ewCurm/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteEwCurm(string id)
        {
            await _iEwCurmBLL.Delete(id);
            return Success("删除成功！");
        }


        #endregion       
    }
}