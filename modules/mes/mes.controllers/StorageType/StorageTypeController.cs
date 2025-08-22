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
    /// 日 期： 2023-07-31 11:46:28
    /// 描 述： 储存类型
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class StorageTypeController : BaseApiController
    {
        private readonly IMesStorageTypeBLL _iMesStorageTypeBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesStorageTypeBLL">存储类型信息维护接口</param>
        public StorageTypeController(IMesStorageTypeBLL iMesStorageTypeBLL)
        {
            _iMesStorageTypeBLL = iMesStorageTypeBLL?? throw new ArgumentNullException(nameof(iMesStorageTypeBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取储存类型的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/storageTypes")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesStorageTypeEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesStorageTypeEntity queryParams)
        {
            var list = await _iMesStorageTypeBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取储存类型的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/storageType/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesStorageTypeEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesStorageTypeEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesStorageTypeBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/storageType/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesStorageTypeEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iMesStorageTypeBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost("mes/storageType")]
        [ProducesResponseType(typeof(ResponseDto<MesStorageTypeEntity>), 200)]
        public async Task<IActionResult>AddForm(MesStorageTypeEntity entity)
        {
            await _iMesStorageTypeBLL.SaveEntity(null,entity);
            return Success("新增成功！",entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        [HttpPut("mes/storageType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,MesStorageTypeEntity entity)
        {
            await _iMesStorageTypeBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除存储类型信息维护mes_StorageType数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/storageType/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iMesStorageTypeBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除存储类型信息维护mes_StorageType数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/storageType/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesStorageTypeBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}