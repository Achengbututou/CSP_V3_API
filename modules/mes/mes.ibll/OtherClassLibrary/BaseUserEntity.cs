using learun.database;
using System;
using System.Collections.Generic;
using System.Text;

namespace mes.ibll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2019.09.12
    /// 描 述：用户实体类
    /// </summary>
    [MyTable("lr_base_user")]
    public class BaseUserEntity
    {

        #region 实体成员
        /// <summary>
        /// 用户主键
        /// </summary>
        [Column(IsPrimary = true)]
        public string F_UserId { get; set; }
        /// <summary>
        /// 账户
        /// </summary>	
        public string F_Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>		
        public string F_Password { get; set; }
        /// <summary>
        /// 密码秘钥
        /// </summary>
        public string F_Secretkey { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string F_RealName { get; set; }
        /// <summary>
        /// 呢称
        /// </summary>	
        public string F_NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>	
        public string F_HeadIcon { get; set; }
        /// <summary>
        /// 性别
        /// </summary>	
        public int? F_Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>	
        public DateTime? F_Birthday { get; set; }
        /// <summary>
        /// 手机
        /// </summary>	
        public string F_Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>		
        public string F_Telephone { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>	
        public string F_Email { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>		
        public string F_OICQ { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>	
        public string F_WeChat { get; set; }
        /// <summary>
        /// MSN
        /// </summary>		
        public string F_MSN { get; set; }
        /// <summary>
        /// 公司主键
        /// </summary>		
        public string F_CompanyId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>		
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 安全级别：1超级用户 2三员-系统管理员、3三员-安全管理员、4三员-审计员
        /// </summary>	
        public int? F_SecurityLevel { get; set; }

        /// <summary>
        /// 微信小程序 OpenId
        /// </summary>
        public string F_WxOpenId { get; set; }
        /// <summary>
        /// 钉钉小程序 OpenId
        /// </summary>
        public string F_DDOpenId { get; set; }
        /// <summary>
        /// 支付宝小程序 OpenId
        /// </summary>
        public string F_AliOpenId { get; set; }
        /// <summary>
        /// 同步后的钉钉用户ID----ADD BY SSY 20221017
        /// </summary>
        public string F_DingUserId { get; set; }

        #region 第三方对接扩展字段
        /// <summary>
        /// 基础-是否开启密码验证(0是，1否)--ADD BY SSY 20230323
        /// </summary>
        public int? F_IsCheckPassword { get; set; }
        /// <summary>
        /// 最后一次修改密码的时间--ADD BY SSY 20230323
        /// </summary>	
        public DateTime? F_LastChangePDate { get; set; }
        /// <summary>
        /// 基础-绑定IP--ADD BY SSY 20230315
        /// </summary>
        public string F_BindIp { get; set; }
        /// <summary>
        /// 基础-CA登录名--ADD BY SSY 20230315
        /// </summary>
        public string F_DomainName { get; set; }
        /// <summary>
        /// 基础-是否只能CA登录(默认是0,不是1)--ADD BY SSY 20230315
        /// </summary>
        public int? F_DomainOnly { get; set; }
        /// <summary>
        /// 身份-身份证号--ADD BY SSY 20230315
        /// </summary>
        public string F_IdCard { get; set; }
        /// <summary>
        /// 身份-政治面貌--ADD BY SSY 20230315
        /// </summary>
        public string F_Party { get; set; }
        /// <summary>
        /// 身份-行政职务--ADD BY SSY 20230315
        /// </summary>
        public string F_Job { get; set; }
        /// <summary>
        /// 身份-行政职级--ADD BY SSY 20230315
        /// </summary>
        public string F_Level { get; set; }
        /// <summary>
        /// 身份-用户密级(0公开，1内部，2秘密，3机密，4绝密)--ADD BY SSY 20230315
        /// </summary>
        public int? F_SecretLevel { get; set; }
        /// <summary>
        /// 身份-职称等级--ADD BY SSY 20230315
        /// </summary>
        public string F_Title { get; set; }
        /// <summary>
        /// 身份-技术职务--ADD BY SSY 20230315
        /// </summary>
        public string F_Role { get; set; }
        /// <summary>
        /// 身份-管理职务--ADD BY SSY 20230315
        /// </summary>
        public string F_Post { get; set; }
        /// <summary>
        /// 身份-职业技能--ADD BY SSY 20230315
        /// </summary>
        public string F_WorkerDegree { get; set; }
        /// <summary>
        /// 密码的盐
        /// </summary>
        public string F_PasswdSalt { get; set; }

        /// <summary>
        /// 全拼--ADD BY SSY 20230414
        /// </summary>
        public string F_FullSpelling { get; set; }
        /// <summary>
        /// 是否绑定IP(默认是0,不是1)--ADD BY SSY 20230414
        /// </summary>
        public int? F_BindIpOnly { get; set; }
        /// <summary>
        /// ADD BY SSY 20230414
        /// </summary>
        public string F_CardInfo { get; set; }
        /// <summary>
        /// (默认是0,不是1)--ADD BY SSY 20230414
        /// </summary>
        public int? F_CardOnly { get; set; }
        /// <summary>
        /// 科室--ADD BY SSY 20230414
        /// </summary>
        public string F_Room { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>	
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>	
        public string F_SimpleSpelling { get; set; }
        #endregion


        #region 多租户
        /// <summary>
        /// 租户ID
        /// </summary>
        public string F_TenantId { get; set; }
        #endregion

        #region 登录策略
        /// <summary>
        /// 最后登录时间--ADD BY SSY 20230519
        /// </summary>	
        public DateTime? F_LastLoginTime { get; set; }
        /// <summary>
        /// 锁定计数--ADD BY SSY 20230519
        /// </summary>	
        public int? F_LockCount { get; set; }
        /// <summary>
        /// 锁定时间--ADD BY SSY 20230519
        /// </summary>	
        public DateTime? F_LockTime { get; set; }
        /// <summary>
        /// 登录随机代码--ADD BY SSY 20230519
        /// </summary>
        public string F_LoginRandomCode { get; set; }
        #endregion


        //#region 备用字段
        ///// <summary>
        ///// 工号
        ///// </summary>	
        //public string F_EnCode { get; set; }

        ///// <summary>
        ///// 快速查询
        ///// </summary>	
        //public string F_QuickQuery { get; set; }

        ///// <summary>
        ///// 单点登录标识
        ///// </summary>		
        //public int? F_OpenId { get; set; }
        ///// <summary>
        ///// 密码提示问题
        ///// </summary>		
        //public string F_Question { get; set; }
        ///// <summary>
        ///// 密码提示答案
        ///// </summary>	
        //public string F_AnswerQuestion { get; set; }
        ///// <summary>
        ///// 允许多用户同时登录
        ///// </summary>		
        //public int? F_CheckOnLine { get; set; }
        ///// <summary>
        ///// 允许登录时间开始
        ///// </summary>		
        //public DateTime? F_AllowStartTime { get; set; }
        ///// <summary>
        ///// 允许登录时间结束
        ///// </summary>		
        //public DateTime? F_AllowEndTime { get; set; }
        ///// <summary>
        ///// 暂停用户开始日期
        ///// </summary>		
        //public DateTime? F_LockStartDate { get; set; }
        ///// <summary>
        ///// 暂停用户结束日期
        ///// </summary>		
        //public DateTime? F_LockEndDate { get; set; }

        //#endregion


        /// <summary>
        /// 删除标记
        /// </summary>	
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>	
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string F_Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>		
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>	
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>	
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>		
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>		
        public string F_ModifyUserName { get; set; }
        #endregion


        /// <summary>
        /// 用户角色信息
        /// </summary>
        [Column(IsIgnore = true)]
        public string RoleIds { get; set; }
        /// <summary>
        /// 用户岗位信息
        /// </summary>
        [Column(IsIgnore = true)]
        public string PostIds { get; set; }


        /// <summary>
        /// 功能权限id
        /// </summary>
        [Column(IsIgnore = true)]
        public IEnumerable<string> ModuleAuthIds { get; set; }

        /// <summary>
        /// 企业微信同步情况
        /// </summary>
        [Column(IsIgnore = true)]
        public string WebchatSyn { get; set; }


        /// <summary>
        /// 租户编码
        /// </summary>
        [Column(IsIgnore = true)]
        public string TenantNo { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        [Column(IsIgnore = true)]
        public string TenantName { get; set; }
        /// <summary>
        /// 租户公司
        /// </summary>
        [Column(IsIgnore = true)]
        public string TenantCompany { get; set; }

    }
}
