using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF004.ibll;
using learun.database;
using System.Data;
using learun.iapplication;
using ce.autofac.extension;
using HRATTF004.bll;

namespace HRATTF004.controllers
{
    /// <summary>
    /// 错误考勤-错误考勤
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： 错误考勤
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class HRATTF004Controller : BaseApiController
    {
        private readonly IAttendanceErrorHdrBLL _iAttendanceErrorHdrBLL;
        private readonly IAttendanceErrorDtlBLL _iAttendanceErrorDtlBLL;
        //private readonly Iattendance_error_MasterBLL _iattendance_error_MasterBLL;
        private readonly WFProcessIBLL _wfProcessIBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        public HRATTF004Controller()
        {
            _iAttendanceErrorHdrBLL = IocManager.Instance.GetService<IAttendanceErrorHdrBLL>(); 
            _iAttendanceErrorDtlBLL = IocManager.Instance.GetService<IAttendanceErrorDtlBLL>(); 
           // _iattendance_error_MasterBLL = iattendance_error_MasterBLL ?? throw new ArgumentNullException(nameof(iattendance_error_MasterBLL));
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取错误考勤的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004s")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<AttendanceErrorHdrEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery]AttendanceErrorHdrEntity queryParams)
        {
            var list = await _iAttendanceErrorHdrBLL.GetList(queryParams);
            return Success(list);
        }

        ///// <summary>
        ///// 获取错误考勤的列表数据
        ///// </summary>
        ///// <param name="queryParams">查询参数</param>
        ///// <returns></returns>
        //[HttpGet("hrattF004/hrattF004s")]
        //[ProducesResponseType(typeof(ResponseDto<IEnumerable<attendance_error_MasterEntity>>), 200)]
        //public async Task<IActionResult> GetList([FromQuery] attendance_error_MasterEntity queryParams)
        //{
        //    var list = await _iattendance_error_MasterBLL.GetList(queryParams);
        //    return Success(list);
        //}

        /// <summary>
        /// 获取错误考勤的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<AttendanceErrorHdrEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]AttendanceErrorHdrEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iAttendanceErrorHdrBLL.GetPageList(pagination,queryParams);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }

        ///// <summary>
        ///// 获取错误考勤的分页列表数据
        ///// </summary>
        ///// <param name="paginationInputDto">分页参数</param>
        ///// <param name="queryParams">查询参数</param>
        ///// <returns></returns>
        //[HttpGet("hrattF004/hrattF004/page")]
        //[ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<attendance_error_MasterEntity>>), 200)]
        //public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery] attendance_error_MasterEntity queryParams)
        //{
        //    Pagination pagination = paginationInputDto.ToObject<Pagination>();
        //    var list = await _iattendance_error_MasterBLL.GetPageList(pagination,queryParams);
        //    var jsonData = new
        //    {
        //        rows = list,
        //        pagination.total,
        //        pagination.page,
        //        pagination.records
        //    };
        //    return Success(jsonData);
        //}

        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004/{id}")]
        [ProducesResponseType(typeof(ResponseDto<HRATTF004Dto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new HRATTF004Dto();
            res.AttendanceErrorHdrEntity = await _iAttendanceErrorHdrBLL.GetEntity(id);
            if(res.AttendanceErrorHdrEntity != null)
            {
                res.AttendanceErrorDtlList = await _iAttendanceErrorDtlBLL.GetList(new AttendanceErrorDtlEntity { attendance_error_rid = res.AttendanceErrorHdrEntity.rid });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取nullattendance_error_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004/attendanceErrorHdr/{id}")]
        [ProducesResponseType(typeof(ResponseDto<AttendanceErrorHdrEntity>), 200)]
        public async Task<IActionResult>GetAttendanceErrorHdrEntity(string id)
        {
            var data = await _iAttendanceErrorHdrBLL.GetEntity(id);
            return Success(data);
        }
        ///// <summary>
        ///// 获取nullattendance_error_Master数据
        ///// </summary>
        ///// <param name="id">主键</param>
        ///// <returns></returns>
        //[HttpGet("hrattF004/hrattF004/attendance_error_Master/{id}")]
        //[ProducesResponseType(typeof(ResponseDto<attendance_error_MasterEntity>), 200)]
        //public async Task<IActionResult> Getattendance_error_MasterEntity(string id)
        //{
        //    var data = await _iattendance_error_MasterBLL.GetEntity(id);
        //    return Success(data);
        //}

        /// <summary>
        /// 获取nullattendance_error_dtl的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004/attendanceErrorDtls")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<AttendanceErrorDtlEntity>>), 200)]
        public async Task<IActionResult> GetAttendanceErrorDtlList([FromQuery]AttendanceErrorDtlEntity queryParams)
        {
            var list = await _iAttendanceErrorDtlBLL.GetList(queryParams);
            return Success(list);
        }
        ///// <summary>
        ///// 获取nullattendance_error_Master的列表数据
        ///// </summary>
        ///// <param name="queryParams">查询参数</param>
        ///// <returns></returns>
        //[HttpGet("hrattF004/hrattF004/attendance_error_Master")]
        //[ProducesResponseType(typeof(ResponseDto<IEnumerable<attendance_error_MasterEntity>>), 200)]
        //public async Task<IActionResult> Getattendance_error_MasterList([FromQuery] attendance_error_MasterEntity queryParams)
        //{
        //    var list = await _iattendance_error_MasterBLL.GetList(queryParams);
        //    return Success(list);
        //}
        /// <summary>
        /// 获取nullattendance_error_dtl的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004/attendanceErrorDtl/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<AttendanceErrorDtlEntity>>), 200)]
        public async Task<IActionResult> GetAttendanceErrorDtlPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery]AttendanceErrorDtlEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iAttendanceErrorDtlBLL.GetPageList(pagination,queryParams);
            var jsonData = new
            {
                rows = list,
                pagination.total,
                pagination.page,
                pagination.records
            };
            return Success(jsonData);
        }
        ///// <summary>
        ///// 获取nullattendance_error_Master的分页列表数据
        ///// </summary>
        ///// <param name="paginationInputDto">分页参数</param>
        ///// <param name="queryParams">查询参数</param>
        ///// <returns></returns>
        //[HttpGet("hrattF004/hrattF004/attendance_error_Master/page")]
        //[ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<attendance_error_MasterEntity>>), 200)]
        //public async Task<IActionResult> Getattendance_error_MasterPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery] attendance_error_MasterEntity queryParams)
        //{
        //    Pagination pagination = paginationInputDto.ToObject<Pagination>();
        //    var list = await _iattendance_error_MasterBLL.GetPageList(pagination,queryParams);
        //    var jsonData = new
        //    {
        //        rows = list,
        //        pagination.total,
        //        pagination.page,
        //        pagination.records
        //    };
        //    return Success(jsonData);
        //}

        /// <summary>
        /// 获取nullattendance_error_dtl数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattF004/hrattF004/attendanceErrorDtl/{id}")]
        [ProducesResponseType(typeof(ResponseDto<AttendanceErrorDtlEntity>), 200)]
        public async Task<IActionResult>GetAttendanceErrorDtlEntity(string id)
        {
            var data = await _iAttendanceErrorDtlBLL.GetEntity(id);
            return Success(data);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattF004/hrattF004")]
        [ProducesResponseType(typeof(ResponseDto<AttendanceErrorHdrEntity>), 200)]
        public async Task<IActionResult>AddForm(HRATTF004Dto dto)
        {
            await _iAttendanceErrorHdrBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.AttendanceErrorHdrEntity);
        }
        /// <summary>
        /// 新增nullattendance_error_hdr数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattF004/hrattF004/attendanceErrorHdr")]
        [ProducesResponseType(typeof(ResponseDto<AttendanceErrorHdrEntity>), 200)]
        public async Task<IActionResult>AddAttendanceErrorHdr(AttendanceErrorHdrEntity entity)
        {
            await _iAttendanceErrorHdrBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }
        /// <summary>
        /// 新增nullattendance_error_dtl数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattF004/hrattF004/attendanceErrorDtl")]
        [ProducesResponseType(typeof(ResponseDto<AttendanceErrorDtlEntity>), 200)]
        public async Task<IActionResult>AddAttendanceErrorDtl(AttendanceErrorDtlEntity entity)
        {
            await _iAttendanceErrorDtlBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("hrattF004/hrattF004/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id,HRATTF004Dto dto)
        {
            await _iAttendanceErrorHdrBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新nullattendance_error_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("hrattF004/hrattF004/attendanceErrorHdr/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateAttendanceErrorHdr(string id,AttendanceErrorHdrEntity entity)
        {
            await _iAttendanceErrorHdrBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新nullattendance_error_dtl数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("hrattF004/hrattF004/attendanceErrorDtl/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateAttendanceErrorDtl(string id,AttendanceErrorDtlEntity entity)
        {
            await _iAttendanceErrorDtlBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }


        /// <summary>
        /// 删除nullattendance_error_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattF004/hrattF004/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iAttendanceErrorHdrBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除nullattendance_error_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattF004/hrattF004/attendanceErrorHdr/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteAttendanceErrorHdr(string id)
        {
            await _iAttendanceErrorHdrBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除nullattendance_error_dtl数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattF004/hrattF004/attendanceErrorDtl/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteAttendanceErrorDtl(string id)
        {
            await _iAttendanceErrorDtlBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除nullattendance_error_hdr数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("hrattF004/hrattF004/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iAttendanceErrorHdrBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除nullattendance_error_hdr数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("hrattF004/hrattF004/attendanceErrorHdr/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteAttendanceErrorHdrs(string ids)
        {
            await _iAttendanceErrorHdrBLL.Deletes(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除nullattendance_error_dtl数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("hrattF004/hrattF004/attendanceErrorDtl/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteAttendanceErrorDtls(string ids)
        {
            await _iAttendanceErrorDtlBLL.Deletes(ids);
            return Success("删除成功！");
        }


        #endregion

        /// <summary>
        /// 请数据数据验证和数据检查
        /// </summary>
        /// <returns></returns>
        [HttpPost("hrattF004/hrattF004/GetDataErrorATT")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetDataErrorATT(DateTime From_Date,DateTime To_Date,string userid,string Emp_No, int page,int rows,string sidx)
        {
            string From_Date_str = From_Date.ToString("dd MMM yyyy");
            string To_Date_str = To_Date.ToString("dd MMM yyyy");
            //添加userid条件  add by jack zhou  21 May 2024
            //改为使用脚本获取数据源 add by jack zhou  06 Jun 2024
            string SQLStr_name;
            SQLStr_name = "exec SP_GetErrorATTData '" + From_Date_str + "','" + To_Date_str + "','" + Emp_No + "','" + userid + "'";
            if (From_Date_str == "01 Jan 1900")
            {
                SQLStr_name = "exec SP_GetErrorATTData null,null,'" + Emp_No + "','" + userid + "'";
            }    

            RepositoryFactory repositoryFactory = new RepositoryFactory();

            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    From_Date
                                    ,
                                    To_Date
                                    ,
                                    userid
                                    ,
                                    Emp_No
                                });

            long records = dt_name.Rows.Count;
            long total = rows;
   

            var jsonData = new
            {
                rows = dt_name,
                total,
                page,
                records
            };

           

            //for (int i = 0; i < dt_name.Rows.Count; i++)
            //{
            //    await _wfProcessIBLL.Create(ProcessId, SchemeCode, UserId, NextUsers, SecretLevel, Title);
            //}



            return Success(jsonData);

        }

        [HttpPost("hrattF004/hrattF004/GetParentUrl")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetParentUrl(string Moudle_ID)
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_GetParentUrl  @Moudle_ID";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    Moudle_ID
                                });

            var jsonData = dt_name.ToJson();


            return Success(jsonData);

        }


        [HttpPost("hrattF004/hrattF004/ErrorAttInterface")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> ErrorAttInterface(string InType,string par1,string par2,string par3,string par4,string par5,string par6)
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_ErrorAttInterface  @InType,@par1,@par2,@par3,@par4,@par5,@par6";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    InType,
                                    par1,
                                    par2 , 
                                    par3 , 
                                    par4 , 
                                    par5, 
                                    par6
                                });

            var jsonData = dt_name.ToJson();


            return Success(jsonData);

        }

        [HttpPost("hrattF004/hrattF004/GetBaseDataFromFVB")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetBaseDataFromFVB()
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_GetBaseDataFromFVB";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name);

            //var jsonData = dt_name.ToJson();
            long records = dt_name.Rows.Count;
            long total = 50;
            long page = 50;

            var jsonData = new
            {
                rows = dt_name,
                total,
                page,
                records
            };

            return Success(jsonData);

        }



    }
}