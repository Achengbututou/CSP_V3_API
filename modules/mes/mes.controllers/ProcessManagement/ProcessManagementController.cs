using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;

namespace mes.controllers
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-07 09:53:29
    /// 描 述： 工序管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "mes")]
    public class ProcessManagementController : BaseApiController
    {
        private readonly IMesProcessManagementBLL _iMesProcessManagementBLL;
        private readonly IMesProcessWorkstationBLL _iMesProcessWorkstationBLL;
        private readonly IMesProcessMaterialBLL _iMesProcessMaterialBLL;
        private readonly IMesProcessTechnologyBLL _iMesProcessTechnologyBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessManagementBLL">工序管理接口</param>
        /// <param name="iMesProcessWorkstationBLL">工序工位管理接口</param>
        /// <param name="iMesProcessMaterialBLL">工序物料管理接口</param>
        /// <param name="iMesProcessTechnologyBLL">工序技术参数管理接口</param>
        public ProcessManagementController(IMesProcessManagementBLL iMesProcessManagementBLL,IMesProcessWorkstationBLL iMesProcessWorkstationBLL,IMesProcessMaterialBLL iMesProcessMaterialBLL,IMesProcessTechnologyBLL iMesProcessTechnologyBLL)
        {
            _iMesProcessManagementBLL = iMesProcessManagementBLL?? throw new ArgumentNullException(nameof(iMesProcessManagementBLL));
            _iMesProcessWorkstationBLL = iMesProcessWorkstationBLL?? throw new ArgumentNullException(nameof(iMesProcessWorkstationBLL));
            _iMesProcessMaterialBLL = iMesProcessMaterialBLL?? throw new ArgumentNullException(nameof(iMesProcessMaterialBLL));
            _iMesProcessTechnologyBLL = iMesProcessTechnologyBLL?? throw new ArgumentNullException(nameof(iMesProcessTechnologyBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取工序管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagements")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessManagementEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]MesProcessManagementEntity queryParams)
        {
            var list = await _iMesProcessManagementBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/GetProductNumberList")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessManagementEntity>>), 200)]
        public async Task<IActionResult> GetProductNumberList([FromQuery] MesProcessManagementEntity queryParams)
        {
            var prodTicketList = await _iMesProcessManagementBLL.GetProdTicketList(queryParams);
            if (prodTicketList.Count() > 0)
            {
                return Success(prodTicketList);
            }
            else
            {
                var list = await _iMesProcessManagementBLL.GetProductNumberList(queryParams);
                return Success(list);
            }
        }
        /// <summary>
        /// 获取工序管理的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessManagementEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessManagementEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessManagementBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("mes/processManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ProcessManagementDto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new ProcessManagementDto();
            res.MesProcessManagementEntity = await _iMesProcessManagementBLL.GetEntity(id);
            if(res.MesProcessManagementEntity != null)
            {
                res.MesProcessWorkstationList = await _iMesProcessWorkstationBLL.GetList(new MesProcessWorkstationEntity { F_ProcessManagementId = res.MesProcessManagementEntity.F_Id });
                res.MesProcessMaterialList = await _iMesProcessMaterialBLL.GetList(new MesProcessMaterialEntity { F_ProcessManagementId = res.MesProcessManagementEntity.F_Id });
                res.MesProcessTechnologyList = await _iMesProcessTechnologyBLL.GetList(new MesProcessTechnologyEntity { F_ProcessManagementId = res.MesProcessManagementEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/detail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ProcessManagementDto>), 200)]
        public async Task<IActionResult> GetDetailForm(string id)
        {
            var res = new ProcessManagementDto();
            res.MesProcessManagementEntity = await _iMesProcessManagementBLL.GetDetailEntity(id);
            if (res.MesProcessManagementEntity != null)
            {
                res.MesProcessWorkstationList = await _iMesProcessWorkstationBLL.GetList(new MesProcessWorkstationEntity { F_ProcessManagementId = res.MesProcessManagementEntity.F_Id });
                res.MesProcessMaterialList = await _iMesProcessMaterialBLL.GetList(new MesProcessMaterialEntity { F_ProcessManagementId = res.MesProcessManagementEntity.F_Id });
                res.MesProcessTechnologyList = await _iMesProcessTechnologyBLL.GetList(new MesProcessTechnologyEntity { F_ProcessManagementId = res.MesProcessManagementEntity.F_Id });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessManagementEntity>), 200)]
        public async Task<IActionResult>GetMesProcessManagementEntity(string id)
        {
            var data = await _iMesProcessManagementBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取工序工位管理mes_ProcessWorkstation的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessWorkstations")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessWorkstationEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessWorkstationList([FromQuery]MesProcessWorkstationEntity queryParams)
        {
            var list = await _iMesProcessWorkstationBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序工位管理mes_ProcessWorkstation的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessWorkstation/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessWorkstationEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessWorkstationPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessWorkstationEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessWorkstationBLL.GetPageList(pagination,queryParams);
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
        /// 获取工序工位管理mes_ProcessWorkstation数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessWorkstation/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessWorkstationEntity>), 200)]
        public async Task<IActionResult>GetMesProcessWorkstationEntity(string id)
        {
            var data = await _iMesProcessWorkstationBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取工序物料管理mes_ProcessMaterial的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessMaterials")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessMaterialEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessMaterialList([FromQuery]MesProcessMaterialEntity queryParams)
        {
            var list = await _iMesProcessMaterialBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序物料管理mes_ProcessMaterial的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessMaterial/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessMaterialEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessMaterialPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessMaterialEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessMaterialBLL.GetPageList(pagination,queryParams);
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
        /// 获取工序物料管理mes_ProcessMaterial数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessMaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessMaterialEntity>), 200)]
        public async Task<IActionResult>GetMesProcessMaterialEntity(string id)
        {
            var data = await _iMesProcessMaterialBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取工序技术参数管理mes_ProcessTechnology的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessTechnologys")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<MesProcessTechnologyEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessTechnologyList([FromQuery]MesProcessTechnologyEntity queryParams)
        {
            var list = await _iMesProcessTechnologyBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取工序技术参数管理mes_ProcessTechnology的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessTechnology/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<MesProcessTechnologyEntity>>), 200)]
        public async Task<IActionResult> GetMesProcessTechnologyPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]MesProcessTechnologyEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iMesProcessTechnologyBLL.GetPageList(pagination,queryParams);
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
        /// 获取工序技术参数管理mes_ProcessTechnology数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("mes/processManagement/mesProcessTechnology/{id}")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessTechnologyEntity>), 200)]
        public async Task<IActionResult>GetMesProcessTechnologyEntity(string id)
        {
            var data = await _iMesProcessTechnologyBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processManagement")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessManagementEntity>), 200)]
        public async Task<IActionResult>AddForm(ProcessManagementDto dto)
        {
            await _iMesProcessManagementBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.MesProcessManagementEntity);
        }
        /// <summary>
        /// 新增工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processManagement/mesProcessManagement")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessManagementEntity>), 200)]
        public async Task<IActionResult>AddMesProcessManagement(MesProcessManagementEntity entity)
        {
            await _iMesProcessManagementBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增工序工位管理mes_ProcessWorkstation数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processManagement/mesProcessWorkstation")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessWorkstationEntity>), 200)]
        public async Task<IActionResult>AddMesProcessWorkstation(MesProcessWorkstationEntity entity)
        {
            await _iMesProcessWorkstationBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增工序物料管理mes_ProcessMaterial数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processManagement/mesProcessMaterial")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessMaterialEntity>), 200)]
        public async Task<IActionResult>AddMesProcessMaterial(MesProcessMaterialEntity entity)
        {
            await _iMesProcessMaterialBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增工序技术参数管理mes_ProcessTechnology数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("mes/processManagement/mesProcessTechnology")]
        [ProducesResponseType(typeof(ResponseDto<MesProcessTechnologyEntity>), 200)]
        public async Task<IActionResult>AddMesProcessTechnology(MesProcessTechnologyEntity entity)
        {
            await _iMesProcessTechnologyBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("mes/processManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,ProcessManagementDto dto)
        {
            await _iMesProcessManagementBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processManagement/mesProcessManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProcessManagement(string id,MesProcessManagementEntity entity)
        {
            await _iMesProcessManagementBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新工序工位管理mes_ProcessWorkstation数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processManagement/mesProcessWorkstation/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProcessWorkstation(string id,MesProcessWorkstationEntity entity)
        {
            await _iMesProcessWorkstationBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新工序物料管理mes_ProcessMaterial数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processManagement/mesProcessMaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProcessMaterial(string id,MesProcessMaterialEntity entity)
        {
            await _iMesProcessMaterialBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新工序技术参数管理mes_ProcessTechnology数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("mes/processManagement/mesProcessTechnology/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateMesProcessTechnology(string id,MesProcessTechnologyEntity entity)
        {
            await _iMesProcessTechnologyBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
           var result=   await _iMesProcessManagementBLL.DeleteAll(id);
            if (result.IsSuccess)
            {
                return Success("删除成功！");
            }
            else
            {
                return Fail(result.MessageInfo);
            }
        }
        /// <summary>
        /// 删除工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessManagement/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessManagement(string id)
        {
            await _iMesProcessManagementBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除工序工位管理mes_ProcessWorkstation数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessWorkstation/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessWorkstation(string id)
        {
            await _iMesProcessWorkstationBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除工序物料管理mes_ProcessMaterial数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessMaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessMaterial(string id)
        {
            await _iMesProcessMaterialBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除工序技术参数管理mes_ProcessTechnology数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessTechnology/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessTechnology(string id)
        {
            await _iMesProcessTechnologyBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iMesProcessManagementBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除工序管理mes_ProcessManagement数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessManagement/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessManagements(string ids)
        {
            await _iMesProcessManagementBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除工序工位管理mes_ProcessWorkstation数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessWorkstation/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessWorkstations(string ids)
        {
            await _iMesProcessWorkstationBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除工序物料管理mes_ProcessMaterial数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessMaterial/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessMaterials(string ids)
        {
            await _iMesProcessMaterialBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除工序技术参数管理mes_ProcessTechnology数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("mes/processManagement/mesProcessTechnology/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteMesProcessTechnologys(string ids)
        {
            await _iMesProcessTechnologyBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion       
    }
}