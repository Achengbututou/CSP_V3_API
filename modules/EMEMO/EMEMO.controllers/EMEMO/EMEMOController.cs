using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMEMO.ibll;
using learun.database;
using System.Data;
using learun.iapplication;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SqlSugar;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.HSSF.Record;
using NPOI.SS.Formula.Functions;
using Microsoft.Exchange.WebServices.Data;
using ce.autofac.extension;

namespace EMEMO.controllers
{
    /// <summary>
    /// EMEMO-EMEMO
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：超级管理员
    /// 日 期： 2023-11-02 16:14:06
    /// 描 述： EMEMO
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class EMEMOController : BaseApiController
    {
        //private readonly IBaseDataFromFVBBLL _iBaseDataFromFVBBLL;
        private readonly IEMEMO_dtlBLL _iEMEMO_dtlBLL;
        private readonly IEMEMO_hdrBLL _iEMEMO_hdrBLL;
        private readonly IEMEMO_dtl_subBLL _iEMEMO_dtl_subBLL;

        private readonly WFProcessIBLL _wfProcessIBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iBaseDataFromFVBBLL">null接口</param>
        public EMEMOController()
        {
            //_iBaseDataFromFVBBLL = iBaseDataFromFVBBLL ?? throw new ArgumentNullException(nameof(iBaseDataFromFVBBLL));
            _iEMEMO_hdrBLL = IocManager.Instance.GetService<IEMEMO_hdrBLL>();
            _iEMEMO_dtlBLL = IocManager.Instance.GetService<IEMEMO_dtlBLL>();
            _iEMEMO_dtl_subBLL = IocManager.Instance.GetService<IEMEMO_dtl_subBLL>();
        }

        
        #region 获取数据
        
        /// <summary>
        /// 获取EMEMO的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMOs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EMEMO_hdrEntity>>), 200)]
        public async Task<IActionResult> GetList([FromQuery] EMEMO_hdrEntity queryParams)
        {
            var list = await _iEMEMO_hdrBLL.GetList(queryParams);
            return Success(list);
        }


        /// <summary>
        /// 获取EMEMO的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EMEMO_hdrEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery]PaginationInputDto paginationInputDto, [FromQuery] EMEMO_hdrEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEMEMO_hdrBLL.GetPageList(pagination,queryParams);
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
        [HttpGet("EMEMO/EMEMO/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EMEMODto>), 200)]
        public async Task<IActionResult>GetForm(string id)
        {
            var res = new EMEMODto();
            res.EMEMO_hdrEntity = await _iEMEMO_hdrBLL.GetEntity(id);
            if(res.EMEMO_hdrEntity != null)
            {
                res.EMEMO_dtlList = await _iEMEMO_dtlBLL.GetList(new EMEMO_dtlEntity { ememo_hdr_rid = res.EMEMO_hdrEntity.rid });
                res.EMEMO_dtl_subList = await _iEMEMO_dtl_subBLL.GetList(new EMEMO_dtl_subEntity { ememo_hdr_rid = res.EMEMO_hdrEntity.rid });
            }
            return Success(res);
        }
        /// <summary>
        /// 获取nullattendance_error_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_hdr/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_hdrEntity>), 200)]
        public async Task<IActionResult> GetEMEMO_hdrEntity(string id)
        {
            var data = await _iEMEMO_hdrBLL.GetEntity(id);
            return Success(data);
        }

        /// <summary>
        /// 获取nullEMEMO_dtl的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_dtls")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EMEMO_dtlEntity>>), 200)]
        public async Task<IActionResult> GetEMEMO_dtlList([FromQuery] EMEMO_dtlEntity queryParams)
        {
            var list = await _iEMEMO_dtlBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取nullEMEMO_dtl_sub的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_dtl_subs")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<EMEMO_dtl_subEntity>>), 200)]
        public async Task<IActionResult> GetEMEMO_dtl_subList([FromQuery] EMEMO_dtl_subEntity queryParams)
        {
            var list = await _iEMEMO_dtl_subBLL.GetList(queryParams);
            return Success(list);
        }

        /// <summary>
        /// 获取nullEMEMO_dtl的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_dtl/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EMEMO_dtlEntity>>), 200)]
        public async Task<IActionResult> GetAttendanceErrorDtlPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] EMEMO_dtlEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEMEMO_dtlBLL.GetPageList(pagination, queryParams);
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
        /// 获取nullEMEMO_dtl_sub的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_dtl_sub/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<EMEMO_dtl_subEntity>>), 200)]
        public async Task<IActionResult> GetAttendanceErrorDtlPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] EMEMO_dtl_subEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iEMEMO_dtl_subBLL.GetPageList(pagination, queryParams);
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
        /// 获取nullEMEMO_dtl数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_dtl/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_dtlEntity>), 200)]
        public async Task<IActionResult> GetEMEMO_dtlEntity(string id)
        {
            var data = await _iEMEMO_dtlBLL.GetEntity(id);
            return Success(data);
        }

        /// <summary>
        /// 获取nullEMEMO_dtl_sub数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("EMEMO/EMEMO/EMEMO_dtl_sub/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_dtl_subEntity>), 200)]
        public async Task<IActionResult> GetEMEMO_dtl_subEntity(string id)
        {
            var data = await _iEMEMO_dtl_subBLL.GetEntity(id);
            return Success(data);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("EMEMO/EMEMO")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_hdrEntity>), 200)]
        public async Task<IActionResult>AddForm(EMEMODto dto)
        {
            await _iEMEMO_hdrBLL.SaveAll(null,dto);
            return Success("新增成功！", dto.EMEMO_hdrEntity);
        }
        /// <summary>
        /// 新增nullEMEMO_hdr数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("EMEMO/EMEMO/EMEMO_hdr")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_hdrEntity>), 200)]
        public async Task<IActionResult> AddEMEMO_hdr(EMEMO_hdrEntity entity)
        {
            await _iEMEMO_hdrBLL.SaveEntity(null,entity);
            return Success("新增成功！", entity);
        }

        /// <summary>
        /// 新增nullEMEMO_dtl数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("EMEMO/EMEMO/EMEMO_dtl")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_dtlEntity>), 200)]
        public async Task<IActionResult> AddEMEMO_dtl(EMEMO_dtlEntity entity)
        {
            await _iEMEMO_dtlBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }

        /// <summary>
        /// 新增nullEMEMO_dtl_sub数据
        /// </summary>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPost("EMEMO/EMEMO/EMEMO_dtl_sub")]
        [ProducesResponseType(typeof(ResponseDto<EMEMO_dtl_subEntity>), 200)]
        public async Task<IActionResult> AddEMEMO_dtl_sub(EMEMO_dtl_subEntity entity)
        {
            await _iEMEMO_dtl_subBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        [HttpPut("EMEMO/EMEMO/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>UpdateForm(string id, EMEMODto dto)
        {
            await _iEMEMO_hdrBLL.SaveAll(id,dto);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新nullEMEMO_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("EMEMO/EMEMO/EMEMO_hdr/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEMEMO_hdr(string id, EMEMO_hdrEntity entity)
        {
            await _iEMEMO_hdrBLL.SaveEntity(id,entity);
            return Success("更新成功！");
        }
        /// <summary>
        /// 更新nullEMEMO_dtl数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("EMEMO/EMEMO/EMEMO_dtl/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEMEMO_dtl(string id, EMEMO_dtlEntity entity)
        {
            await _iEMEMO_dtlBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }

        /// <summary>
        /// 更新nullEMEMO_dtl_sub数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("EMEMO/EMEMO/EMEMO_dtl_sub/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateEMEMO_dtl_sub(string id, EMEMO_dtl_subEntity entity)
        {
            await _iEMEMO_dtl_subBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }

        /// <summary>
        /// 删除nullEMEMO_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForm(string id)
        {
            await _iEMEMO_hdrBLL.DeleteAll(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除nullattendance_error_hdr数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/EMEMO_hdr/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteEMEMO_hdr(string id)
        {
            await _iEMEMO_hdrBLL.Delete(id);
            return Success("删除成功！");
        }
        /// <summary>
        /// 删除nullEMEMO_dtl数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/EMEMO_dtl/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteEMEMO_dtl(string id)
        {
            await _iEMEMO_dtlBLL.Delete(id);
            return Success("删除成功！");
        }

        /// <summary>
        /// 删除nullEMEMO_dtl_sub数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/EMEMO_dtl_sub/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteEMEMO_dtl_sub(string id)
        {
            await _iEMEMO_dtl_subBLL.Delete(id);
            return Success("删除成功！");
        }


        /// <summary>
        /// 批量删除nullEMEMO_hdr数据
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult>DeleteForms(string ids)
        {
            await _iEMEMO_hdrBLL.DeleteAlls(ids);
            return Success("删除成功！");
        }
        /// <summary>
        /// 批量删除nullEMEMO_hdr数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/EMEMO_hdr/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteEMEMO_hdrs(string ids)
        {
            await _iEMEMO_hdrBLL.Deletes(ids);
            return Success("删除成功！");
        }

        /// <summary>
        /// 批量删除nullEMEMO_dtl数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/EMEMO_dtl/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteEMEMO_dtls(string ids)
        {
            await _iEMEMO_dtlBLL.Deletes(ids);
            return Success("删除成功！");
        }

        /// <summary>
        /// 批量删除nullEMEMO_dtl_sub数据
        /// </summary>
        /// <param name="ids">主键集</param>
        /// <returns></returns>
        [HttpDelete("EMEMO/EMEMO/EMEMO_dtl_sub/deletes/{ids}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteEMEMO_dtl_subs(string ids)
        {
            await _iEMEMO_dtl_subBLL.Deletes(ids);
            return Success("删除成功！");
        }

        #endregion

        ///// <summary>
        ///// 请数据数据验证和数据检查
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("EMEMO/EMEMO/GetDataErrorATT")]
        //[ProducesResponseType(typeof(ResponseDto), 200)]
        //public async Task<IActionResult> GetDataErrorATT(DateTime From_Date,DateTime To_Date,string userid,string Emp_No, int page,int rows,string sidx)
        //{
        //    string From_Date_str = From_Date.ToString("dd MMM yyyy");
        //    string To_Date_str = To_Date.ToString("dd MMM yyyy");
        //    //添加userid条件  add by jack zhou  21 May 2024
        //    //改为使用脚本获取数据源 add by jack zhou  06 Jun 2024
        //    string SQLStr_name;
        //    SQLStr_name = "exec SP_GetErrorATTData '" + From_Date_str + "','" + To_Date_str + "','" + Emp_No + "','" + userid + "'";
        //    if (From_Date_str == "01 Jan 1900")
        //    {
        //        SQLStr_name = "exec SP_GetErrorATTData null,null,'" + Emp_No + "','" + userid + "'";
        //    }    

        //    RepositoryFactory repositoryFactory = new RepositoryFactory();

        //    DataTable dt_name = await repositoryFactory.BaseRepository("lrsystemdb").FindTable(SQLStr_name
        //                        , new
        //                        {
        //                            From_Date
        //                            ,
        //                            To_Date
        //                            ,
        //                            userid
        //                            ,
        //                            Emp_No
        //                        });

        //    long records = dt_name.Rows.Count;
        //    long total = rows;

        //    var jsonData = new
        //    {
        //        rows = dt_name,
        //        total,
        //        page,
        //        records
        //    };



        //    //for (int i = 0; i < dt_name.Rows.Count; i++)
        //    //{
        //    //    await _wfProcessIBLL.Create(ProcessId, SchemeCode, UserId, NextUsers, SecretLevel, Title);
        //    //}



        //    return Success(jsonData);

        //}

        [HttpPost("EMEMO/EMEMO/GetBaseDataFromFVB")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetBaseDataFromFVB(string company_code, string cggroup, string season, string plant, string mat_type, string factorycode)
        {
            string SQLStr_name;
            SQLStr_name = "exec Sp_GetBaseDataFromFVB @company_code, @cggroup, @season, @plant, @mat_type, @factorycode";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name, new
            {
                
                company_code,
                cggroup,
                season,
                plant,
                mat_type,
                factorycode
            });

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


        [HttpPost("EMEMO/EMEMO/EMEMOInterface")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> EMEMOInterface(string InType,string par1,string par2,string par3,string par4,string par5,string par6, string par7, string par8)
        {
            //string SQLStr_name;
            //SQLStr_name = "exec Sp_EMEMO  @InType,@par1,@par2,@par3,@par4,@par5,@par6,@par7,@par8";

            RepositoryFactory repositoryFactory = new RepositoryFactory();

            DataSet ds = await repositoryFactory.BaseRepository("OA").QueryProcDataSet("Sp_EMEMO", new List<SugarParameter>(){
              new SugarParameter("@InType",InType),
              new SugarParameter("@par1",par1),
              new SugarParameter("@par2",par2),
              new SugarParameter("@par3",par3),
              new SugarParameter("@par4",par4),
              new SugarParameter("@par5",par5),
              new SugarParameter("@par6",par6),
              new SugarParameter("@par7",par7),
              new SugarParameter("@par8",par8),
            });

            long records = 0;
            long total = 50;
            long page = 50;

            if (ds != null)
            {
                if (ds.Tables.Count > 1)
                {
                    records = long.Parse(ds.Tables[1].Rows[0]["records"].ToString());
                }
                else
                {
                    records = ds.Tables[0].Rows.Count;
                }
            }
            

            var jsonData = new
            {
                rows = ds.Tables[0],
                total,
                page,
                records
            };

            return Success(jsonData);

        }

    }
}