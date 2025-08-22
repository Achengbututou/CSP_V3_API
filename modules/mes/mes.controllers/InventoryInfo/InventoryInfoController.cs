using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using mes.ibll.InventoryInfo;

namespace mes.controllers
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-06 10:30:31
    /// 描 述： 盘点管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class InventoryInfoController : BaseApiController
    {
        private readonly IMesInventoryInfoBLL _iMesInventoryInfoBLL;
        private readonly IMesInventoryDetailsBLL _iMesInventoryDetailsBLL;
        private readonly IMesOperationLogInfoBLL _iMesOperationLogInfoBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesInventoryInfoBLL"></param>
        /// <param name="iMesInventoryDetailsBLL"></param>
        /// <param name="iMesOperationLogInfoBLL"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InventoryInfoController(IMesInventoryInfoBLL iMesInventoryInfoBLL,IMesInventoryDetailsBLL iMesInventoryDetailsBLL, IMesOperationLogInfoBLL iMesOperationLogInfoBLL)
        {
            _iMesInventoryInfoBLL = iMesInventoryInfoBLL?? throw new ArgumentNullException(nameof(iMesInventoryInfoBLL));
            _iMesInventoryDetailsBLL = iMesInventoryDetailsBLL?? throw new ArgumentNullException(nameof(iMesInventoryDetailsBLL));
            _iMesOperationLogInfoBLL = iMesOperationLogInfoBLL ?? throw new ArgumentNullException(nameof(iMesOperationLogInfoBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取盘点管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInventoryInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesInventoryInfoEntity queryParams)
        {
            var list = await _iMesInventoryInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取盘点管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInventoryInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInventoryInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInventoryInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/inventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<InventoryInfoDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new InventoryInfoDto();
            res.MesInventoryInfoEntity = await _iMesInventoryInfoBLL.GetEntity(id);
            if(res.MesInventoryInfoEntity != null)
            {
                res.MesInventoryDetailsList = await _iMesInventoryDetailsBLL.GetList(new MesInventoryDetailsEntity { F_InventoryInfoId = res.MesInventoryInfoEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryInfo/mesInventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryInfoEntity>), 200)]
        public async Task<IActionResult>GetMesInventoryInfoEntity(string id)
        {
            var data = await _iMesInventoryInfoBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取盘点物品明细mes_InventoryDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryInfo/mesInventoryDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesInventoryDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesInventoryDetailsList([FromQuery]MesInventoryDetailsEntity queryParams)
        {
            var list = await _iMesInventoryDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取盘点物品明细mes_InventoryDetails的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryInfo/mesInventoryDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesInventoryDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesInventoryDetailsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesInventoryDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesInventoryDetailsBLL.GetPageList(pagination,queryParams);
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
        /// 获取盘点物品明细mes_InventoryDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/inventoryInfo/mesInventoryDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryDetailsEntity>), 200)]
        public async Task<IActionResult>GetMesInventoryDetailsEntity(string id)
        {
            var data = await _iMesInventoryDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inventoryInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(InventoryInfoDto dto)
        {
            await _iMesInventoryInfoBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesInventoryInfoEntity);
        }
        /// <summary>
        /// 新增盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inventoryInfo/mesInventoryInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryInfoEntity>), 200)]
        public async Task<IActionResult>AddMesInventoryInfo(MesInventoryInfoEntity entity)
        {
            await _iMesInventoryInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增盘点物品明细mes_InventoryDetails数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/inventoryInfo/mesInventoryDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesInventoryDetailsEntity>), 200)]
        public async Task<IActionResult>AddMesInventoryDetails(MesInventoryDetailsEntity entity)
        {
            await _iMesInventoryDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/inventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,InventoryInfoDto dto)
        {
            await _iMesInventoryInfoBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/inventoryInfo/mesInventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesInventoryInfo(string id,MesInventoryInfoEntity entity)
        {
            await _iMesInventoryInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新盘点物品明细mes_InventoryDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/inventoryInfo/mesInventoryDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesInventoryDetails(string id,MesInventoryDetailsEntity entity)
        {
            await _iMesInventoryDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesInventoryInfoBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryInfo/mesInventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInventoryInfo(string id)
        {
            await _iMesInventoryInfoBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除盘点物品明细mes_InventoryDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryInfo/mesInventoryDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInventoryDetails(string id)
        {
            await _iMesInventoryDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesInventoryInfoBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除盘点信息mes_InventoryInfo数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryInfo/mesInventoryInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInventoryInfos(string ids)
        {
            await _iMesInventoryInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除盘点物品明细mes_InventoryDetails数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/inventoryInfo/mesInventoryDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesInventoryDetailss(string ids)
        {
            await _iMesInventoryDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展 盘点操作
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPut("mes/inventoryInfo/InventoryInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> InventoryInfo(string id)
        {
            var result=await _iMesInventoryInfoBLL.InventoryInfo(id);
            if (result.IsSuccess)
            {
                return Success("盘点成功！");
            }
            else
            {
                return Fail(result.MessageInfo);
            }
        }
        #endregion
    }
}