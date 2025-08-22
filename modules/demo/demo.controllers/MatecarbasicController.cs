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
    /// 日 期： 2022-06-13 10:55:59
    /// 描 述： 配车单
    /// </summary>
    public class MatecarbasicController : BaseApiController
    {
        private readonly IEwMatecarbasicBLL _iEwMatecarbasicBLL;
        private readonly IEwMatecardetailBLL _iEwMatecardetailBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iEwMatecarbasicBLL">【苏州益维鑫】配车单主表接口</param>
        /// <param name="iEwMatecardetailBLL">【苏州益维鑫】配车单子表接口</param>
        public MatecarbasicController(IEwMatecarbasicBLL iEwMatecarbasicBLL,IEwMatecardetailBLL iEwMatecardetailBLL)
        {
            _iEwMatecarbasicBLL = iEwMatecarbasicBLL?? throw new ArgumentNullException(nameof(iEwMatecarbasicBLL));
            _iEwMatecardetailBLL = iEwMatecardetailBLL?? throw new ArgumentNullException(nameof(iEwMatecardetailBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取配车单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecarbasics")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EwMatecarbasicEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]EwMatecarbasicEntity queryParams)
        {
            var list = await _iEwMatecarbasicBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取配车单的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecarbasic/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EwMatecarbasicEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]EwMatecarbasicEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEwMatecarbasicBLL.GetPageList(pagination,queryParams);
            foreach (var item in list)
            {
                List<string> kh = new List<string>();
                var Matecardetail = await _iEwMatecardetailBLL.GetList(new EwMatecardetailEntity { F_matecarbasicId = item.F_Id });
                foreach (var Matecardetail_item in Matecardetail)
                {
                    kh.Add(Matecardetail_item.F_khbh);
                }
                if (kh.Count>0)
                {
                    string khstr = string.Empty;
                    foreach (var arr in CommonHelper.RemoveDup(kh.ToArray()))
                    {
                        khstr += arr + ',';
                    }
                    item.F_kh = khstr.TrimEnd(',') ;
                }
                
            }
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
        [HttpGet("demo/matecarbasic/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MatecarbasicDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new MatecarbasicDto();
            res.EwMatecarbasicEntity = await _iEwMatecarbasicBLL.GetEntity(id);
            if(res.EwMatecarbasicEntity != null)
            {
                res.EwMatecardetailList = await _iEwMatecardetailBLL.GetList(new EwMatecardetailEntity { F_matecarbasicId = res.EwMatecarbasicEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取【苏州益维鑫】配车单主表ew_matecarbasic数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("demo/matecarbasic/ewMatecarbasic/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecarbasicEntity>), 200)]
        public async Task<IActionResult>GetEwMatecarbasicEntity(string id)
        {
            var data = await _iEwMatecarbasicBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取【苏州益维鑫】配车单子表ew_matecardetail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecarbasic/ewMatecardetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EwMatecardetailEntity>>), 200)]
        public async Task<IActionResult> GetEwMatecardetailList([FromQuery]EwMatecardetailEntity queryParams)
        {
            var list = await _iEwMatecardetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取【苏州益维鑫】配车单子表ew_matecardetail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("demo/matecarbasic/ewMatecardetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EwMatecardetailEntity>>), 200)]
        public async Task<IActionResult> GetEwMatecardetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]EwMatecardetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEwMatecardetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("demo/matecarbasic/ewMatecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecardetailEntity>), 200)]
        public async Task<IActionResult>GetEwMatecardetailEntity(string id)
        {
            var data = await _iEwMatecardetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("demo/matecarbasic")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecarbasicEntity>), 200)]
        public async Task<IActionResult>AddForm(MatecarbasicDto dto)
        {
            await _iEwMatecarbasicBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.EwMatecarbasicEntity);
        }
        /// <summary>
        /// 新增【苏州益维鑫】配车单主表ew_matecarbasic数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("demo/matecarbasic/ewMatecarbasic")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecarbasicEntity>), 200)]
        public async Task<IActionResult>AddEwMatecarbasic(EwMatecarbasicEntity entity)
        {
            await _iEwMatecarbasicBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("demo/matecarbasic/ewMatecardetail")]
        [ProducesResponseType(typeof(ResponseDto<EwMatecardetailEntity>), 200)]
        public async Task<IActionResult>AddEwMatecardetail(EwMatecardetailEntity entity)
        {
            await _iEwMatecardetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("demo/matecarbasic/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MatecarbasicDto dto)
        {
            await _iEwMatecarbasicBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新【苏州益维鑫】配车单主表ew_matecarbasic数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("demo/matecarbasic/ewMatecarbasic/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateEwMatecarbasic(string id,EwMatecarbasicEntity entity)
        {
            await _iEwMatecarbasicBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("demo/matecarbasic/ewMatecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateEwMatecardetail(string id,EwMatecardetailEntity entity)
        {
            await _iEwMatecardetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除【苏州益维鑫】配车单主表ew_matecarbasic数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("demo/matecarbasic/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iEwMatecarbasicBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除【苏州益维鑫】配车单主表ew_matecarbasic数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("demo/matecarbasic/ewMatecarbasic/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteEwMatecarbasic(string id)
        {
            await _iEwMatecarbasicBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除【苏州益维鑫】配车单子表ew_matecardetail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("demo/matecarbasic/ewMatecardetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteEwMatecardetail(string id)
        {
            await _iEwMatecardetailBLL.Delete(id);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 生成送货单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPut("demo/matecarbasic/CreateDelivery/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> CreateDelivery(string id)
        {
            await _iEwMatecarbasicBLL.CreateDelivery(id);
            return Success("生成成功！");
        }
        #endregion
    }
}