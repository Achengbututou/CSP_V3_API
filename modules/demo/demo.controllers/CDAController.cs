using demo.ibll.CDA;
using learun.util;
using learun.utils.web;
using learun.wechat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPOI.POIFS.Crypt.Dsig;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TencentCloud.Cam.V20190116.Models;

namespace demo.controllers
{
    /// <summary>
    /// 力软信息技术（苏州）有限公司出品
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2022-09-21 10:55:59
    /// 描 述： CDA授权接口-应用访问凭证获取
    /// </summary>
    public class CDAController : BaseApiController
    {
        /// <summary>
        /// 请求CDA
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPost("cda/getviewtoken")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetViewToken(string fileId)
        {
            //获取Access Token
            string getaccesstokenurl = string.Format("https://api.bimface.com/oauth2/token");
            Dictionary<string, string> accessheaders = new Dictionary<string, string>();
            Dictionary<string, string> accessparameters = new Dictionary<string, string>();
            byte[] accessbytes = Encoding.Default.GetBytes("fbbMSm1GYdvTW0mWK4SdrDih1qa3j580:7OsbQ13zowT1JQcR2to12agregQhjRoq");
            accessheaders["Authorization"] = "Basic " + Convert.ToBase64String(accessbytes);
            var res = await new HttpHelper().Post(getaccesstokenurl, accessparameters, Encoding.UTF8, Encoding.UTF8, 300, "", null, "", accessheaders);
            if (res.ToObject<AccessRes>().code == "success")
            {
                //获取模型的View Token
                if (string.IsNullOrEmpty(fileId))
                {
                    fileId = "10000764466766";
                }
                string getviewtokenurl = string.Format("https://api.bimface.com/view/token?fileId={0}", fileId);
                Dictionary<string, string> viewheaders = new Dictionary<string, string>();
                viewheaders["Authorization"] = "bearer " + res.ToObject<AccessRes>().data.token;
                var viewres = await new HttpHelper().Get(getviewtokenurl, Encoding.UTF8, 300, "", null, "", viewheaders);
                if (viewres.ToObject<ViewRes>().code == "success")
                {
                    return Success(viewres.ToObject<ViewRes>().data);
                }
            }
            return Success("生成失败！");
        }
    }
}
