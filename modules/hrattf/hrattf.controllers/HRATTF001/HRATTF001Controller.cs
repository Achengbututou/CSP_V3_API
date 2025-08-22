using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF.ibll;
using hrattf.ibll.HRATTF001;
using learun.database;
using System.Data;
using ce.autofac.extension;
using learun.iapplication;
using System.Diagnostics;
using SqlSugar;
using TencentCloud.Tci.V20190318.Models;


namespace HRATTF.controllers
{
    /// <summary>
    /// 电子请假-请假申请
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-10-24 09:19:39
    /// 描 述： 请假申请
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class HRATTF001Controller : BaseApiController
    {
        private readonly IFHISLeaveHeaderBLL _iFHISLeaveHeaderBLL;
        private readonly IFHISLeaveDetailBLL _iFHISLeaveDetailBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public HRATTF001Controller()
        {
            _iFHISLeaveHeaderBLL = IocManager.Instance.GetService<IFHISLeaveHeaderBLL>();
            _iFHISLeaveDetailBLL = IocManager.Instance.GetService<IFHISLeaveDetailBLL>();
        }
        
        #region 获取数据
        
        /// <summary>
        /// 获取请假申请的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattf/hrattF001s")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<FHISLeaveHeaderEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]FHISLeaveHeaderEntity queryParams)
        {
            var list = await _iFHISLeaveHeaderBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取请假申请的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattf/hrattF001/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<FHISLeaveHeaderEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]FHISLeaveHeaderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iFHISLeaveHeaderBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("hrattf/hrattF001/{id}")]
        [ProducesResponseType(typeof(ResponseDto<HRATTF001Dto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new HRATTF001Dto();
            res.FHISLeaveHeaderEntity = await _iFHISLeaveHeaderBLL.GetEntity(id);
            if(res.FHISLeaveHeaderEntity != null)
            {
                res.FHISLeaveDetailList = await _iFHISLeaveDetailBLL.GetList(new FHISLeaveDetailEntity { Leave_Header_RID = res.FHISLeaveHeaderEntity.RID });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattf/hrattF001/fhisLeaveHeader/{id}")]
        [ProducesResponseType(typeof(ResponseDto<FHISLeaveHeaderEntity>), 200)]
        public async Task<IActionResult>GetFHISLeaveHeaderEntity(string id)
        {
            var data = await _iFHISLeaveHeaderBLL.GetEntity(id);
            return Success(data);
        }
        /// <summary>
        /// 获取FHIS请假证明FHIS_Leave_Detail的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattf/hrattF001/fhisLeaveDetails")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<FHISLeaveDetailEntity>>), 200)]
        public async Task<IActionResult> GetFHISLeaveDetailList([FromQuery]FHISLeaveDetailEntity queryParams)
        {
            var list = await _iFHISLeaveDetailBLL.GetList(queryParams);
            return Success(list);
        }
        /// <summary>
        /// 获取FHIS请假证明FHIS_Leave_Detail的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattf/hrattF001/fhisLeaveDetail/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<FHISLeaveDetailEntity>>), 200)]
        public async Task<IActionResult> GetFHISLeaveDetailPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]FHISLeaveDetailEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iFHISLeaveDetailBLL.GetPageList(pagination,queryParams);
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
        /// 获取FHIS请假证明FHIS_Leave_Detail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattf/hrattF001/fhisLeaveDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto<FHISLeaveDetailEntity>), 200)]
        public async Task<IActionResult>GetFHISLeaveDetailEntity(string id)
        {
            var data = await _iFHISLeaveDetailBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattf/hrattF001")]
        [ProducesResponseType(typeof(ResponseDto<FHISLeaveHeaderEntity>), 200)]
        public async Task<IActionResult>AddForm(HRATTF001Dto dto)
        {
            await _iFHISLeaveHeaderBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.FHISLeaveHeaderEntity);
        }
        /// <summary>
        /// 新增请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattf/hrattF001/fhisLeaveHeader")]
        [ProducesResponseType(typeof(ResponseDto<FHISLeaveHeaderEntity>), 200)]
        public async Task<IActionResult>AddFHISLeaveHeader(FHISLeaveHeaderEntity entity)
        {
            await _iFHISLeaveHeaderBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增FHIS请假证明FHIS_Leave_Detail数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattf/hrattF001/fhisLeaveDetail")]
        [ProducesResponseType(typeof(ResponseDto<FHISLeaveDetailEntity>), 200)]
        public async Task<IActionResult>AddFHISLeaveDetail(FHISLeaveDetailEntity entity)
        {
            await _iFHISLeaveDetailBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("hrattf/hrattF001/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,HRATTF001Dto dto)
        {
            await _iFHISLeaveHeaderBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("hrattf/hrattF001/fhisLeaveHeader/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateFHISLeaveHeader(string id,FHISLeaveHeaderEntity entity)
        {
            await _iFHISLeaveHeaderBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新FHIS请假证明FHIS_Leave_Detail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("hrattf/hrattF001/fhisLeaveDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateFHISLeaveDetail(string id,FHISLeaveDetailEntity entity)
        {
            await _iFHISLeaveDetailBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattf/hrattF001/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iFHISLeaveHeaderBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattf/hrattF001/fhisLeaveHeader/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteFHISLeaveHeader(string id)
        {
            await _iFHISLeaveHeaderBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除FHIS请假证明FHIS_Leave_Detail数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattf/hrattF001/fhisLeaveDetail/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteFHISLeaveDetail(string id)
        {
            await _iFHISLeaveDetailBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattf/hrattF001/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iFHISLeaveHeaderBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除请假主表FHIS_Leave_Header数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("hrattf/hrattF001/fhisLeaveHeader/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteFHISLeaveHeaders(string ids)
        {
            await _iFHISLeaveHeaderBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除FHIS请假证明FHIS_Leave_Detail数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("hrattf/hrattF001/fhisLeaveDetail/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteFHISLeaveDetails(string ids)
        {
            await _iFHISLeaveDetailBLL.Deletes(ids);
            return Success("删除成功！");
        }
	
	/// <summary>
        /// 请数据数据验证和数据检查
        /// </summary>
        /// <returns></returns>
        [HttpPost("hrattf/hrattF001/LeaveGetDataAndCheck")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>LeaveGetDataAndCheck(LeaveInputDto ileaveInputDto)
        {
            //string SQLStr_name;
            //SQLStr_name="exec sp_FHIS_Leave_Get_Data_And_Check  @ActionType,@RID,@Leave_Note_NO,@Approve_Status,@Emp_No,@Leave_Type,@From_Date,@From_Time,@From_Date_Minute,@To_Date,@To_Time,@To_Date_Minute "+
            //                        ",@Leave_List_RID,@Industrial_injury_Date,@Category_Code,@Record_Code,@Cancel_Limit_Flag,@Not_Continu_Leave_Flag ";

            RepositoryFactory repositoryFactory = new RepositoryFactory();

            DataTable dt = await repositoryFactory.BaseRepository("OA").QueryProc("sp_FHIS_Leave_Get_Data_And_Check", new List<SugarParameter>(){
                new SugarParameter("@ActionType", ileaveInputDto.ActionType),
                new SugarParameter("@RID", ileaveInputDto.RID),
                new SugarParameter("@Leave_Note_NO", ileaveInputDto.Leave_Note_NO),
                new SugarParameter("@Approve_Status", ileaveInputDto.Approve_Status),
                new SugarParameter("@Emp_No", ileaveInputDto.Emp_No),
                new SugarParameter("@Leave_Type", ileaveInputDto.Leave_Type),
                new SugarParameter("@From_Date", ileaveInputDto.From_Date),
                new SugarParameter("@From_Time", ileaveInputDto.From_Time),
                new SugarParameter("@From_Date_Minute", ileaveInputDto.From_Date_Minute),
                new SugarParameter("@To_Date", ileaveInputDto.To_Date),
                new SugarParameter("@To_Time", ileaveInputDto.To_Time),
                new SugarParameter("@To_Date_Minute", ileaveInputDto.To_Date_Minute),
                new SugarParameter("@Leave_List_RID", ileaveInputDto.Leave_List_RID),
                new SugarParameter("@Industrial_injury_Date", ileaveInputDto.Industrial_injury_Date),
                new SugarParameter("@Category_Code", ileaveInputDto.Category_Code),
                new SugarParameter("@Record_Code", ileaveInputDto.Record_Code),
                new SugarParameter("@Cancel_Limit_Flag", ileaveInputDto.Cancel_Limit_Flag),
                new SugarParameter("@Not_Continu_Leave_Flag", ileaveInputDto.Not_Continu_Leave_Flag),
            });

            //DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
            //                    , new {
            //                        ileaveInputDto.ActionType 
            //                        ,ileaveInputDto.RID
            //                        ,ileaveInputDto.Leave_Note_NO
            //                        ,ileaveInputDto.Approve_Status
            //                        ,ileaveInputDto.Emp_No
            //                        ,ileaveInputDto.Leave_Type
            //                        ,ileaveInputDto.From_Date
            //                        ,ileaveInputDto.From_Time
            //                        ,ileaveInputDto.From_Date_Minute
            //                        ,ileaveInputDto.To_Date
            //                        ,ileaveInputDto.To_Time
            //                        ,ileaveInputDto.To_Date_Minute
            //                        ,ileaveInputDto.Leave_List_RID
            //                        ,ileaveInputDto.Industrial_injury_Date
            //                        ,ileaveInputDto.Category_Code
            //                        ,ileaveInputDto.Record_Code
            //                        ,ileaveInputDto.Cancel_Limit_Flag
            //                        ,ileaveInputDto.Not_Continu_Leave_Flag 
            //                    });


            return Success(dt);

        }


        #endregion       
    }
}