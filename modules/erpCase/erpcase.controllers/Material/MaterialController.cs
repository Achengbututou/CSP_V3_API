using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;

namespace erpCase.controllers
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:49:03
    /// 描 述： 物料信息
    /// </summary>
    public class MaterialController : BaseApiController
    {
        private readonly ICaseErpMaterialBLL _iCaseErpMaterialBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCaseErpMaterialBLL">物料信息【case_erp_material】接口</param>
        public MaterialController(ICaseErpMaterialBLL iCaseErpMaterialBLL)
        {
            _iCaseErpMaterialBLL = iCaseErpMaterialBLL?? throw new ArgumentNullException(nameof(iCaseErpMaterialBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取物料信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/materials")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpMaterialEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]CaseErpMaterialEntity queryParams)
        {
            var list = await _iCaseErpMaterialBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取物料信息的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/material/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<CaseErpMaterialEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]CaseErpMaterialEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iCaseErpMaterialBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("erpCase/material/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialEntity>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var data = await _iCaseErpMaterialBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("erpCase/material/caseErpMaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialEntity>), 200)]
        public async Task<IActionResult>GetCaseErpMaterialEntity(string id)
        {
            var data = await _iCaseErpMaterialBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/material")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialEntity>), 200)]
        public async Task<IActionResult>AddForm(CaseErpMaterialEntity dto)
        {
            await _iCaseErpMaterialBLL.SaveEntity(null,dto);
            return Success("新增成功！",dto);
        }
        /// <summary>
        /// 新增物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("erpCase/material/caseErpMaterial")]
        [ProducesResponseType(typeof(ResponseDto<CaseErpMaterialEntity>), 200)]
        public async Task<IActionResult>AddCaseErpMaterial(CaseErpMaterialEntity entity)
        {
            await _iCaseErpMaterialBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("erpCase/material/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,CaseErpMaterialEntity dto)
        {
            await _iCaseErpMaterialBLL.SaveEntity(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("erpCase/material/caseErpMaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateCaseErpMaterial(string id,CaseErpMaterialEntity entity)
        {
            await _iCaseErpMaterialBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/material/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iCaseErpMaterialBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/material/caseErpMaterial/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpMaterial(string id)
        {
            await _iCaseErpMaterialBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("erpCase/material/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iCaseErpMaterialBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除物料信息【case_erp_material】case_erp_material数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("erpCase/material/caseErpMaterial/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteCaseErpMaterials(string ids)
        {
            await _iCaseErpMaterialBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取获取设备信息的
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("erpCase/materials/getrunstate")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<CaseErpMaterialEntity>>), 200)]
        public IActionResult GetRunState([FromQuery] CaseErpMaterialEntity queryParams)
        {
            List<int> data_gaugeList = new List<int>();//运行状况
            List<int> data_lineList = new List<int>();//生产效率

            data_gaugeList.Add(new Random().Next(10,101));

            data_lineList.Add(new Random().Next(40, 101));
            data_lineList.Add(new Random().Next(40, 101));
            data_lineList.Add(new Random().Next(40, 101));
            data_lineList.Add(new Random().Next(40, 101));
            data_lineList.Add(new Random().Next(40, 101));
            data_lineList.Add(new Random().Next(40, 101));

            var jsonData = new
            {
                data_gauge = data_gaugeList,
                data_line = data_lineList
            };
            return Success(jsonData);
        }
        #endregion
    }
}