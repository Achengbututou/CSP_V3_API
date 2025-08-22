using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF008.ibll;
using learun.database;
using System.Data;
using System.Linq;
using learun.iapplication;
using Microsoft.AspNetCore.Authorization;
using ce.autofac.extension;


namespace Password.controllers
{
    /// <summary>
    /// 电子请假-职员工资单
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期： 2024-07-24 09:19:39
    /// 描 述： 职员工资单
    /// </summary>
    [ApiExplorerSettings(GroupName = "extension")]
    public class HRATTF008Controller : BaseApiController
    {
        private readonly IPasswordNowBLL _iPasswordNowBLL;
        private readonly IEmployeeIDCardBLL _iEmployeeIDCardBLL;
        private readonly DataItemIBLL _dataItemIBLL;
        private readonly IFHISPayrollEnHeaderBLL _iFHISPayrollEnHeaderBLL;
        private readonly IMMsgIBLL _iMMsgIBLL;
        private readonly UserIBLL _userBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_iPasswordNowBLL">接口</param>
        public HRATTF008Controller()
        {
            _iPasswordNowBLL = IocManager.Instance.GetService<IPasswordNowBLL>(); 
            _iEmployeeIDCardBLL = IocManager.Instance.GetService<IEmployeeIDCardBLL>();
            _dataItemIBLL = IocManager.Instance.GetService<DataItemIBLL>();
            _iFHISPayrollEnHeaderBLL = IocManager.Instance.GetService<IFHISPayrollEnHeaderBLL>();
            _iMMsgIBLL = IocManager.Instance.GetService<IMMsgIBLL>();
            _userBLL = IocManager.Instance.GetService<UserIBLL>();
        }


        #region 获取数据
        /// <summary>
        /// 获取密码的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattf008/payrollEn/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<PasswordNowEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] FHISPayrollEnHeaderEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iFHISPayrollEnHeaderBLL.GetPageList(pagination, queryParams);

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
        [HttpGet("hrattf008/payrollEn/{id}")]
        [ProducesResponseType(typeof(ResponseDto<FHISPayrollEnHeaderEntity>), 200)]
        public async Task<IActionResult> GetForm(string id)
        {
            FHISPayrollEnHeaderEntity fHISLeaveHeaderEntity = await _iFHISPayrollEnHeaderBLL.GetEntity(id);
            return Success(fHISLeaveHeaderEntity);
        }

        /// <summary>
        /// 获取密码的分页列表数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpGet("hrattf008/password/page")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<PasswordNowEntity>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, [FromQuery] PasswordNowEntity queryParams)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            var list = await _iPasswordNowBLL.GetPageList(pagination, queryParams);
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
        /// 获取当前登录者信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattf008/password")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GetPassword()
        {
            var userInfo = await _userBLL.GetEntity();

            var employeeDatas = userInfo.F_DDOpenId.Split("_");
            if (employeeDatas.Length <= 0)
            {
                return Fail("找不到数据！");
            }

            PasswordNowEntity entity = new PasswordNowEntity()
            {
                Company_Code = employeeDatas[0],
                Emp_No = employeeDatas[1],
            };

            var list = await _iPasswordNowBLL.GetList(entity);

            if (list.Count() <= 0)
            {
                return Fail("找不到数据！");
            }

            var ID_NO = await _iEmployeeIDCardBLL.GetIDNO(list.ToList()[0].Company_Code, list.ToList()[0].Emp_No) ;

            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "RID", list.ToList()[0].RID },
                { "Company_Code", employeeDatas[0] },
                { "Emp_No", employeeDatas[1] },
                { "ID_NO", ID_NO.ToString() }
            };

            return Success(result);
        }

        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattf008/password/getRID")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GetRID([FromQuery] EmployeeDto dto)
        {
            PasswordNowEntity entity = new PasswordNowEntity()
            {
                Company_Code = dto.Company_Code,
                Emp_No = dto.Emp_No,
            };
            var list = await _iPasswordNowBLL.GetList(entity);

            if (list != null && list.Count() > 0)
            {
                return Success(list.ToList()[0].RID);
            } 

            return Success(entity.RID);
        }


        /// <summary>
        /// 获取职员工资明细数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattf008/getPayrollEnDetail")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GetPayrollEnDetail([FromQuery] PayrollEnDto dto)
        {
            //验证密码是否正确
            EmployeePasswordDto employeePasswordDto = new EmployeePasswordDto()
            {
                Emp_No = dto.Emp_No,
                User_ID = dto.User_ID,
                Company_Code = dto.User_Company_Code,
                Password = dto.Password,
                Type = dto.Type
            };
            var checkFlag = await _iPasswordNowBLL.CheckPassword(employeePasswordDto);

            if (checkFlag != null && checkFlag.code == ResponseCode.success)
            {
                //验证之前的数据是否已经签名
                if (dto.Type == 0 && !(await _iFHISPayrollEnHeaderBLL.CheckSignature(dto)))
                {
                    return Fail("之前的工资单签名完毕，才可查看该工资单！");
                }
                //用存储过程查询数据
                string SQLStr_name = "exec sp_FHIS_Payroll_En_" + dto.Company_Code; //根据不同公司执行存储过程，避免某个linkserver连接失败造成存储过程执行报错问题
                SQLStr_name = SQLStr_name + " @ActionType,@Emp_No,@Period_Code,@From_Date,@User_ID,@Password,@User_Company_Code,@Type ";

                dto.ActionType = "GetPayrollEnDetail";

                RepositoryFactory repositoryFactory = new RepositoryFactory();
                DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                    , new
                                    {
                                       dto.ActionType,
                                        dto.Emp_No,
                                        dto.Period_Code,
                                        dto.From_Date,
                                        dto.User_ID,
                                        dto.Password,
                                        dto.User_Company_Code,
                                        dto.Type,
                                    });

                //var jsonData = dt_name.ToJson();

                return Success(dt_name);

                //string token = RequestParams.GetHeadersParamValue("Token");
                //http://localhost:29733/View/HRIS447/Ajax.aspx?id=GetPayrollEn&Emp_No=L0005171&Period_Code=20240601&From_Date=01%20Jun%202024
                //string url = ""; //http://localhost:29733
                //var webData = await _dataItemIBLL.GetDetailList("FHIS_Web", dto.Company_Code);
                //if (webData != null && webData.ToList().Count() > 0)
                //{
                //    url = webData.ToList()[0].F_ItemValue;
                //}
                //url += "/View/HRIS447/Ajax.aspx?id=GetPayrollEn";
                //url += "&Emp_No=" + dto.Emp_No;
                //url += "&Period_Code=" + dto.Period_Code;
                //url += "&From_Date=" + dto.From_Date.ToString("dd MMM yyyy");
                //url += "&Token=" + token;
                //加密
                //string enCode = DESEncrypt.Encrypt(dto.Emp_No + "&" + dto.Period_Code + "&" + dto.From_Date.ToString("dd MMM yyyy") + "&" + dto.Password, "PayrollForCSP");
                //url += "&EnCode=" + enCode;
                //try
                //{
                //    // 初始化HttpClient实例  
                //    HttpClient _httpClient = new HttpClient();
                //    // 发送GET请求  
                //    HttpResponseMessage response = await _httpClient.GetAsync(url);
                //    // 确保HTTP请求成功  
                //    response.EnsureSuccessStatusCode();
                //    // 读取响应内容  
                //    string responseBody = await response.Content.ReadAsStringAsync();
                //    var data = responseBody.ToJson();
                //    return Success(data);
                //}
                //catch (HttpRequestException e)
                //{
                //    // 处理请求异常  
                //    Console.WriteLine($"\nException Caught!");
                //    Console.WriteLine("Message :{0} ", e.Message);
                //    return Fail(e.Message);
                //}
            }

            return Fail("密码错误！！");
        }

        [HttpGet("hrattf008/CheckPasswordForFHIS")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> CheckPasswordForFHIS([FromQuery] EmployeePasswordDto dto)
        {
            return OK(await _iPasswordNowBLL.CheckPassword(dto));
        }

        [HttpGet("hrattf008/hasPassword")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> HasPassword([FromQuery] EmployeePasswordDto dto)
        {
            return OK(await _iPasswordNowBLL.HasPassword(dto));
        }

        /// <summary>
        /// 获取年终奖明细数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("hrattf008/getPayrollEndEnDetail")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> getPayrollEndEnDetail([FromQuery] PayrollEnDto dto)
        {
            //验证密码是否正确
            EmployeePasswordDto employeePasswordDto = new EmployeePasswordDto()
            {
                Emp_No = dto.Emp_No,
                User_ID = dto.User_ID,
                Company_Code = dto.User_Company_Code,
                Password = dto.Password,
                Type = dto.Type
            };
            var checkFlag = await _iPasswordNowBLL.CheckPassword(employeePasswordDto);

            if (checkFlag != null && checkFlag.code == ResponseCode.success)
            {
                //用存储过程查询数据
                string SQLStr_name = "exec sp_FHIS_Payroll_End"; //根据不同公司执行存储过程，避免某个linkserver连接失败造成存储过程执行报错问题
                SQLStr_name = SQLStr_name + " @ActionType,@Emp_No,@Year,@User_ID,@Password,@User_Company_Code";

                dto.ActionType = "GetPayrollEndDetail";

                RepositoryFactory repositoryFactory = new RepositoryFactory();
                DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                    , new
                                    {
                                        dto.ActionType,
                                        dto.Emp_No,
                                        dto.Year,
                                        dto.User_ID,
                                        dto.Password,
                                        dto.User_Company_Code,
                                        dto.Type,
                                    });

                return Success(dt_name);
            }

            return Fail("密码错误！！");
        }


        #endregion

        #region 提交数据
        /// <summary>
        /// 新增表单数据
        /// </summary>
        /// <param name="dto">表单数据</param>
        /// <returns></returns>
        [HttpPost("hrattf008/password")]
        [ProducesResponseType(typeof(ResponseDto<PasswordNowEntity>), 200)]
        public async Task<IActionResult> AddForm(PasswordNowEntity entity)
        {
            await _iPasswordNowBLL.SaveEntity(null, entity);
            return Success("新增成功！", entity);
        }

        /// <summary>
        /// 更新请假主表Password_Now数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">表单数据</param>
        /// <returns></returns>
        [HttpPut("hrattf008/password/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdatePasswordNow(string id, PasswordNowEntity entity)
        {
            await _iPasswordNowBLL.SaveEntity(id, entity);
            return Success("更新成功！");
        }

        [HttpPost("hrattf008/checkEmployee")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> CheckEmployee(EmployeeDto dto)
        {
            return OK(await _iEmployeeIDCardBLL.CheckEmployee(dto));
        }

        [HttpPost("hrattf008/checkPassword")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> CheckPassword(EmployeePasswordDto dto)
        {
            return OK(await _iPasswordNowBLL.CheckPassword(dto));
        }

        /// <summary>
        /// 清空签名
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        [HttpPut("hrattf008/payrollEn/deleteSign/{id}")]
        [ProducesResponseType(typeof(PaginationOutputDto<IEnumerable<PasswordNowEntity>>), 200)]
        public async Task<IActionResult> UpdateForm(string id)
        {
            string SQLStr_name = "exec sp_FHIS_Payroll_En";
            SQLStr_name = SQLStr_name + " @ActionType,@Emp_No,@Period_Code,@From_Date,@User_ID,@Password,@Type ";

            PayrollEnDto dto = new PayrollEnDto()
            {
                ActionType = "getUserId",
                User_ID = id
            };
            var userList = new List<string>();
            string msg = "";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    dto.ActionType,
                                    dto.Emp_No,
                                    dto.Period_Code,
                                    dto.From_Date,
                                    dto.User_ID,
                                    dto.Password,
                                    dto.Type,
                                });
            if (dt != null || dt.Rows.Count > 0)
            {
                userList.Add(dt.Rows[0][0].ToString());
                msg = dt.Rows[0][1].ToString();
            }

            await _iFHISPayrollEnHeaderBLL.deleteSign(id);

            await _iMMsgIBLL.SendMsg("IMWF", userList, msg, "3", "");

            return Success("更新成功！");
        }

        /// <summary>
        /// 生成年终奖明细数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpPost("hrattf008/genPayrollEndHeader")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> GenPayrollEndHeader([FromQuery] PayrollEnDto dto)
        {
            //用存储过程查询数据
            string SQLStr_name = "exec sp_FHIS_Payroll_End";
            SQLStr_name = SQLStr_name + " @ActionType,@Company_Code,@Year";
            
            dto.ActionType = "GenPayrollEndHeader";

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository("OA").FindTable(SQLStr_name
                                , new
                                {
                                    dto.ActionType,
                                    dto.Company_Code,
                                    dto.Year,
                                });
            return Success(dt_name);
        }


        #endregion       
    }
}