using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRATTF008.ibll;
using System.Linq;
using NPOI.POIFS.Crypt;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using learun.application;
using learun.database;
using System.Data;
namespace HRATTF008.bll
{
    /// <summary>
    /// 查询密码
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：Kyle Feng
    /// 日 期：2024-07-11 15:06
    /// 描 述：Password_Now(查询密码)
    /// </summary>
    public class PasswordNowBLL : BLLBase, IPasswordNowBLL, BLL
    {
        private readonly PasswordNowService passwordNowService = new PasswordNowService();
        private readonly PasswordHistoryService passwordHistoryService = new PasswordHistoryService();
        private readonly FHISPayrollEnHeaderService payrollEnHeaderService = new FHISPayrollEnHeaderService();
        private readonly EmployeeIDCardService employeeIDCardService = new EmployeeIDCardService();
        private readonly RoleService roleService = new RoleService();
        private readonly UserRelationService userRelationService = new UserRelationService();

        #region 获取数据
        /// <summary>
        /// 获取最新密码的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<PasswordNowEntity>> GetList(PasswordNowEntity queryParams)
        {
            return passwordNowService.GetList(queryParams);
        }

        /// <summary>
        /// 获取密码的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<PasswordNowEntity>> GetPageList(Pagination pagination, PasswordNowEntity queryParams)
        {
            string AuthoritySql = ""; // await this.GetDataAuthoritySql("MyPassword");
            if (string.IsNullOrEmpty(AuthoritySql))
            {
                AuthoritySql = string.Empty;
            }
            return await passwordNowService.GetPageList(pagination, queryParams, AuthoritySql);
        }

        public async Task<ResponseDto<string>> CheckPassword(EmployeePasswordDto dto)
        {
            string AuthoritySql = ""; //await this.GetDataAuthoritySql("MyPassword");

            //如果是HRD，则需验证当前用户是否在HRD组中
            if (dto.Type == 1)
            {
                //organization/userrelation/17a1429f-812c-4086-bbc4-11b191a519cf
                string SQLStr_name = "exec sp_FHIS_Payroll_En";
                SQLStr_name = SQLStr_name + " @ActionType,@Emp_No,@Period_Code,@From_Date,@User_ID,@Password,@Type ";

                PayrollEnDto payrollEnDto = new PayrollEnDto()
                {
                    ActionType = "CheckIsHRD",
                    User_ID = dto.Company_Code + "_" + dto.User_ID,
                };
                
                RepositoryFactory repositoryFactory = new RepositoryFactory();
                DataTable dt_name = await repositoryFactory.BaseRepository().FindTable(SQLStr_name
                                    , new
                                    {
                                        payrollEnDto.ActionType,
                                        payrollEnDto.Emp_No,
                                        payrollEnDto.Period_Code,
                                        payrollEnDto.From_Date,
                                        payrollEnDto.User_ID,
                                        payrollEnDto.Password,
                                        payrollEnDto.Type,
                                    });
                if (dt_name.Rows.Count == 0)
                {
                    return Fail<string>("您无权查看该笔工资！！");
                }
            }
            else
            {
                //Type = 0代表是只查询自己的数据, 判断所查询的工号和User_ID是否是同一个人
                if(!await isOnePerson(dto.Emp_No, dto.User_ID))
                {
                    return Fail<string>("您无权查看该笔工资！！");
                }
            }

            Pagination pagination = new Pagination()
            {
                page = 1,
                rows = 1,
                sidx = "Effect_Date",
                sord = "desc"
            };

            PasswordNowEntity entity = new PasswordNowEntity()
            {
                Company_Code = dto.Company_Code,
                Emp_No = dto.User_ID,
                Type = dto.Type,
            };
            //先取盐
            var KeyList = await passwordNowService.GetPageList(pagination, entity, AuthoritySql);
            if (KeyList != null && KeyList.Count() > 0)
            {
                string key = KeyList.ToList()[0].Key;
                entity.Password = Md5Helper.Encrypt(DESEncrypt.Encrypt(dto.Password, key).ToLower(), 32).ToLower();
            }
            else
            {
                return Fail<string>("查询密码不正确！！");
            }

            var list = await passwordNowService.GetPageList(pagination, entity, AuthoritySql);

            //存在代表验证有效
            if (list != null && list.Count() > 0)
            {
                //Type == 2给修改密码时使用
                if (list.ToList()[0].End_Date < DateTime.Now && dto.Type != 2)
                {
                    return Fail<string>("密码已过期，请前往手机端修改密码！");
                }

                return Success("成功!/Succeeded!", "ok");
            }

            return Fail<string>("查询密码不正确！！");
        }


        public async Task<ResponseDto<string>> HasPassword(EmployeePasswordDto dto)
        {
            string AuthoritySql = ""; //await this.GetDataAuthoritySql("MyPassword");

            Pagination pagination = new Pagination()
            {
                page = 1,
                rows = 1,
                sidx = "Effect_Date",
                sord = "desc"
            };

            PasswordNowEntity entity = new PasswordNowEntity()
            {
                Company_Code = dto.Company_Code,
                Emp_No = dto.Emp_No,
            };

            var list = await passwordNowService.GetPageList(pagination, entity, AuthoritySql);

            //存在代表验证有效
            if (list != null && list.Count() > 0)
            {
                return Success("成功!/Succeeded!", "1");
            }

            return Success("成功!/Succeeded!", "0");
        }

        public async Task<bool> isOnePerson(string Emp_No, string User_ID)
        {
            if (Emp_No.Equals(User_ID))
            {
                return true;
            }
            Pagination pagination = new Pagination()
            {
                page = 1,
                rows = 1,
            };

            EmployeeIDCardEntity queryParams = new EmployeeIDCardEntity()
            {
                Emp_No = Emp_No,
            };

            var list = await employeeIDCardService.GetPageList(pagination, queryParams);

            queryParams = new EmployeeIDCardEntity()
            {
                Emp_No = User_ID,
            };
            var list2 = await employeeIDCardService.GetPageList(pagination, queryParams);
                
            if (list != null && list2 != null)
            {
                //身份证号一致代表是同一个人
                if (list.ToList()[0].ID_NO.Equals(list2.ToList()[0].ID_NO))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
        #region 提交数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, PasswordNowEntity entity)
        {
            //entity.Leave_Note_NO = (await GetRuleCodeEx(entity.Leave_Note_NO)).ToString();

            //验证旧密码是否正确
            if (entity.oldPassword != null)
            {
                EmployeePasswordDto dto = new EmployeePasswordDto()
                {
                    Emp_No = entity.Emp_No,
                    Password = entity.oldPassword,
                    Company_Code = entity.Company_Code,
                    User_ID = entity.Emp_No,
                    Type = 2
                };
                var checkFlag = await CheckPassword(dto);

                if (checkFlag == null)
                {
                    throw new Exception("旧密码不正确！");
                }
                if (checkFlag.code != ResponseCode.success)
                {
                    throw new Exception("旧密码不正确！");
                }
            }

            //保存前先验证, 新密码不能与之前三次密码重复
            //先取出最近三次密码的盐，再用密钥去加密，接着使用密文去数据库中查询，看是否有重复
            string AuthoritySql = ""; //await this.GetDataAuthoritySql("MyPassword");
            if (string.IsNullOrEmpty(AuthoritySql))
            {
                AuthoritySql = string.Empty;
            }

            PasswordHistoryEntity queryParams = new PasswordHistoryEntity()
            {
                Company_Code = entity.Company_Code,
                Emp_No = entity.Emp_No,
            };

            Pagination pagination = new Pagination()
            {
                page = 1,
                rows = 3,
                sidx = "Effect_Date",
                sord = "desc"
            };

            var list = await passwordHistoryService.GetPageList(pagination, queryParams, AuthoritySql);

            //用历史记录中的密钥去加密
            List<string> PasswordQRangeList = new List<string>();
            foreach (PasswordHistoryEntity data in list)
            {
                string dbPassword = Md5Helper.Encrypt(DESEncrypt.Encrypt(entity.Password, data.Key).ToLower(), 32).ToLower();
                PasswordQRangeList.Add(dbPassword);
            }

            //用加密后密码去查找
            if (PasswordQRangeList != null && PasswordQRangeList.Count > 0)
            {
                queryParams.Emp_No = entity.Emp_No;
                queryParams.Company_Code = entity.Company_Code;
                queryParams.PasswordQRangeList = PasswordQRangeList;
                list = await passwordHistoryService.GetPageList(pagination, queryParams, AuthoritySql);

                if (list != null && list.Count() > 0)
                {
                    throw new Exception("新密码不能与之前三次密码重复！");
                }
            }

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                // 密钥是自动生成的，但我们可以通过Key属性来获取它  
                string key = BitConverter.ToString(des.Key).Replace("-", "").ToLower();
                //加密
                string enPassword = Md5Helper.Encrypt(DESEncrypt.Encrypt(entity.Password, key).ToLower(), 32).ToLower();
                //保存加密后密码和密钥
                entity.Password = enPassword;
                entity.Key = key;
            }

            //截止日期修改为生效日期三个月后
            entity.Effect_Date = DateTime.Now;
            entity.End_Date = DateTime.Now.AddMonths(3);
            entity.Last_Update_Date = DateTime.Now;

            //organization/userrelation/17a1429f-812c-4086-bbc4-11b191a519cf
            string SQLStr_name = "exec sp_FHIS_Payroll_En";
            SQLStr_name = SQLStr_name + " @ActionType,@Emp_No,@Period_Code,@From_Date,@User_ID,@Password,@Type ";
            entity.Type = 0;

            PayrollEnDto payrollEnDto = new PayrollEnDto()
            {
                ActionType = "CheckIsHRD",
                User_ID = entity.Company_Code + "_" + entity.Emp_No,
            };

            RepositoryFactory repositoryFactory = new RepositoryFactory();
            DataTable dt_name = await repositoryFactory.BaseRepository().FindTable(SQLStr_name
                                , new
                                {
                                    payrollEnDto.ActionType,
                                    payrollEnDto.Emp_No,
                                    payrollEnDto.Period_Code,
                                    payrollEnDto.From_Date,
                                    payrollEnDto.User_ID,
                                    payrollEnDto.Password,
                                    payrollEnDto.Type,
                                });
            if (dt_name.Rows.Count != 0)
            {
                entity.Type = 1;
            }

            passwordNowService.BeginTrans();
            try
            {
                await passwordNowService.SaveEntity(keyValue, entity);

                if (keyValue == null)
                {
                    PasswordHistoryEntity passwordHistory = new PasswordHistoryEntity()
                    {
                        Company_Code = entity.Company_Code,
                        Emp_No = entity.Emp_No,
                        Password = entity.Password,
                        Key = entity.Key,
                        Effect_Date = entity.Effect_Date,
                        End_Date = entity.End_Date,
                        Last_Update_Date = entity.Last_Update_Date,
                    };
                    await passwordHistoryService.SaveEntity(keyValue, passwordHistory);
                }
                passwordNowService.Commit();
            }
            catch (Exception)
            {
                passwordNowService.Rollback();
                throw;
            }
        }
        #endregion
    }
}