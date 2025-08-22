using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;

namespace mes.controllers
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-09-06 11:26:24
    /// 描 述： 调拨管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class TransferInfoController : BaseApiController
    {
        private readonly IMesTransferInfoBLL _iMesTransferInfoBLL;
        private readonly IMesTransferDetailsBLL _iMesTransferDetailsBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTransferInfoBLL">调拨信息接口</param>
        /// <param name="iMesTransferDetailsBLL">调拨物品明细接口</param>
        public TransferInfoController(IMesTransferInfoBLL iMesTransferInfoBLL,IMesTransferDetailsBLL iMesTransferDetailsBLL)
        {
            _iMesTransferInfoBLL = iMesTransferInfoBLL?? throw new ArgumentNullException(nameof(iMesTransferInfoBLL));
            _iMesTransferDetailsBLL = iMesTransferDetailsBLL?? throw new ArgumentNullException(nameof(iMesTransferDetailsBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取调拨管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferInfos")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTransferInfoEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesTransferInfoEntity queryParams)
        {
            var list = await _iMesTransferInfoBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取调拨管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferInfo/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTransferInfoEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTransferInfoEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTransferInfoBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/transferInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<TransferInfoDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new TransferInfoDto();
            res.MesTransferInfoEntity = await _iMesTransferInfoBLL.GetEntity(id);
            if(res.MesTransferInfoEntity != null)
            {
                res.MesTransferDetailsList = await _iMesTransferDetailsBLL.GetList(new MesTransferDetailsEntity { F_TransferInfoId = res.MesTransferInfoEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/transferInfo/mesTransferInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferInfoEntity>), 200)]
        public async Task<IActionResult>GetMesTransferInfoEntity(string id)
        {
            var data = await _iMesTransferInfoBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取调拨物品明细mes_TransferDetails的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferInfo/mesTransferDetailss")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesTransferDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesTransferDetailsList([FromQuery]MesTransferDetailsEntity queryParams)
        {
            var list = await _iMesTransferDetailsBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取调拨物品明细mes_TransferDetails的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/transferInfo/mesTransferDetails/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesTransferDetailsEntity>>), 200)]
        public async Task<IActionResult> GetMesTransferDetailsPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesTransferDetailsEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesTransferDetailsBLL.GetPageList(pagination,queryParams);
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
        /// 获取调拨物品明细mes_TransferDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/transferInfo/mesTransferDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferDetailsEntity>), 200)]
        public async Task<IActionResult>GetMesTransferDetailsEntity(string id)
        {
            var data = await _iMesTransferDetailsBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/transferInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferInfoEntity>), 200)]
        public async Task<IActionResult>AddForm(TransferInfoDto dto)
        {
            await _iMesTransferInfoBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesTransferInfoEntity);
        }
        /// <summary>
        /// 新增调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/transferInfo/mesTransferInfo")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferInfoEntity>), 200)]
        public async Task<IActionResult>AddMesTransferInfo(MesTransferInfoEntity entity)
        {
            await _iMesTransferInfoBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增调拨物品明细mes_TransferDetails数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/transferInfo/mesTransferDetails")]
        [ProducesResponseType(typeof(ResponseDto<MesTransferDetailsEntity>), 200)]
        public async Task<IActionResult>AddMesTransferDetails(MesTransferDetailsEntity entity)
        {
            await _iMesTransferDetailsBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/transferInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,TransferInfoDto dto)
        {
            await _iMesTransferInfoBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/transferInfo/mesTransferInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesTransferInfo(string id,MesTransferInfoEntity entity)
        {
            await _iMesTransferInfoBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新调拨物品明细mes_TransferDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/transferInfo/mesTransferDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesTransferDetails(string id,MesTransferDetailsEntity entity)
        {
            await _iMesTransferDetailsBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesTransferInfoBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferInfo/mesTransferInfo/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferInfo(string id)
        {
            await _iMesTransferInfoBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除调拨物品明细mes_TransferDetails数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferInfo/mesTransferDetails/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferDetails(string id)
        {
            await _iMesTransferDetailsBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/transferInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesTransferInfoBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除调拨信息mes_TransferInfo数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/transferInfo/mesTransferInfo/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferInfos(string ids)
        {
            await _iMesTransferInfoBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除调拨物品明细mes_TransferDetails数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/transferInfo/mesTransferDetails/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesTransferDetailss(string ids)
        {
            await _iMesTransferDetailsBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}