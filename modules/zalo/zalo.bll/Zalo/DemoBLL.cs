using ce.autofac.extension;
using learun.cache;
using learun.iapplication;
using learun.operat;
using learun.util;
using learun.wechat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using zalo.ibll;
namespace zalo.bll 
{
    /// <summary>
    /// 
    /// Copyright © 2023-present Crystal International Group
    /// 创建人：
    /// 日 期： 
    /// 描 述： 
    /// </summary>
    public class DemoBLL : BLLBase, IDemoBLL, BLL
    {
        private readonly UserIBLL _userIBLL;
        private readonly LogIBLL _logIBLL;
        private readonly IOperator _operator;
        private readonly ISystemConfigBLL _iSystemConfigBLL;
        private readonly ICache _iCache;
        private readonly WFSchemeIBLL _nWFSchemeIBLL;

        private readonly DemoService demoService = new DemoService();

        public DemoBLL(UserIBLL userIBLL,
            LogIBLL logIBLL,
            IOperator ioperator,
            ISystemConfigBLL iSystemConfigBLL,
            ICache iCache,
            WFSchemeIBLL nWFSchemeIBLL
        )
        {
            _userIBLL = userIBLL ?? throw new ArgumentNullException(nameof(userIBLL));
            _logIBLL = logIBLL ?? throw new ArgumentNullException(nameof(logIBLL));
            _operator = ioperator ?? throw new ArgumentNullException(nameof(ioperator));
            _iSystemConfigBLL = iSystemConfigBLL ?? throw new ArgumentNullException(nameof(iSystemConfigBLL));
            _iCache = iCache;
            _nWFSchemeIBLL = nWFSchemeIBLL ?? throw new ArgumentNullException(nameof(nWFSchemeIBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<DemoEntity>>GetList(DemoEntity queryParams) {
            return demoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<DemoEntity>>GetPageList(Pagination pagination, DemoEntity queryParams) {
            return demoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<DemoEntity> GetEntity(string keyValue) {
            return demoService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await demoService.Delete(keyValue);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, DemoEntity entity) {
            await demoService.SaveEntity(keyValue, entity);
        }
        #endregion

        #region 供参考
        /// <summary>
        /// 企业微信-供参考
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async Task<ResponseDto<LoginOutputDto>> OpenIdLoginQY(string openid)
        {
            Stopwatch stopwatch = CommonHelper.TimerStart();
            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.F_Module = ConfigHelper.GetConfig().SoftName;
            #endregion


            logEntity.F_ExecuteResult = 0;
            logEntity.F_ExecuteResultJson = "OpenIDLoginQY, openid:" + openid;
            _logIBLL.Write(logEntity, stopwatch);

            string struserID = await GetQYuserID(openid);   //根据CODE取
            //weixin:F_WxOpenId, dingtalk:F_DDOpenId, qyweixin:F_AliOpenId, weixingzh:F_DDOpenId, azure:F_RealName, phone:F_Mobile, userid:F_UserId
            var userEntity = await _userIBLL.GetEntityByOpenId(struserID, "qyweixin");


            if (userEntity != null)
            {
                logEntity.F_OperateAccount = userEntity.F_Account;
                logEntity.F_OperateUserId = userEntity.F_Account;
            }
            if (userEntity == null)
            {
                logEntity.F_ExecuteResult = 0;
                logEntity.F_ExecuteResultJson = "没有此账号!";
                _logIBLL.Write(logEntity, stopwatch);
                return Fail<LoginOutputDto>("没有此账号");
            }

            if (userEntity.F_EnabledMark != 1)
            {
                logEntity.F_ExecuteResult = 0;
                logEntity.F_ExecuteResultJson = "账户被系统锁定,请联系管理员!";
                _logIBLL.Write(logEntity, stopwatch);
                return Fail<LoginOutputDto>("账户被系统锁定,请联系管理员!");
            }
            else
            {
                logEntity.F_ExecuteResult = 1;
                logEntity.F_ExecuteResultJson = "登录成功";
                _logIBLL.Write(logEntity, stopwatch);
                var loginrandomcode = Guid.NewGuid().ToString();//生成登录成功随机码
                // 登录时长
                var tokenTimeout = 0;
                // 加载登录配置
                var loginConfig = await _iSystemConfigBLL.GetLoginConfig();
                if (loginConfig != null)
                {
                    tokenTimeout = loginConfig.TokenTimeout;
                }

                userEntity.F_LoginRandomCode = loginrandomcode;
                //生成token
                string token = _operator.EncodeToken(userEntity.F_UserId, userEntity.F_RealName, userEntity.F_Account, userEntity.F_SecurityLevel ?? 0, tokenTimeout, loginrandomcode);
                userEntity.F_Password = string.Empty;
                userEntity.F_Secretkey = string.Empty;
                return Success("登录成功", new LoginOutputDto { token = token, user = userEntity });
            }
        }

        /// <summary>
        /// 根据code返回企业微信用户ID
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public async Task<string> GetQYuserID(string strCode)
        {
            Stopwatch stopwatch = CommonHelper.TimerStart();

            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.F_Module = ConfigHelper.GetConfig().SoftName;
            #endregion


            string strulr = "https://qyapi.weixin.qq.com/cgi-bin/auth/getuserinfo?access_token={0}&code={1}";   //ACCESS_TOKEN

            //string strToken = await Token.GetToken();  //获取TOKEN 
            //string strToken = await GetNewToken_WCS();  //从WCS获取TOKEN   

            string strToken = "";

            HttpHelper http = new HttpHelper();

            string strActurl = string.Format(strulr, strToken, strCode);

            //logEntity.F_ExecuteResult = 1;
            //logEntity.F_ExecuteResultJson = "GetQYuserID, strToken:" + strToken + ",url:" + strActurl;
            //_logIBLL.Write(logEntity, stopwatch);


            //string respone = await http.Get(string.Format(strulr, strToken, strCode), Encoding.UTF8);
            //访问API
            string respone = await http.Get(strActurl, Encoding.UTF8);
            string strUserID = "";



            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "GetQYuserID, respone:" + respone;
            _logIBLL.Write(logEntity, stopwatch);


            if (respone != "")
            {
                var vresult = respone.ToJObject();
                strUserID = vresult["userid"].ToString();
            }

            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "GetQYuserID, strUserID:" + strUserID;
            _logIBLL.Write(logEntity, stopwatch);

            return strUserID;
        }

        #endregion
    }
}