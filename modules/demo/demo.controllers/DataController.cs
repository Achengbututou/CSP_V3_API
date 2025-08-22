using learun.util;
using learun.utils.web;
using learun.wechat;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace demo.controllers
{
    /// <summary>
    /// 力软信息技术（苏州）有限公司出品
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2022-09-21 10:55:59
    /// 描 述： 示例数据接口
    /// </summary>
    public class DataController : BaseApiController
    {
        /// <summary>
        /// 返回示例数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("demo/data/list")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public IActionResult GetDataList(string keyword)
        {
            List<object> list = new List<object>();
            
            // 添加数据
            list.Add(new {name = "力软快速开发框架core版本",num="SO0209000001",company="南京信息科技有限公司",user="李总",price=200000,unpay=0,payed=200000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架java版本",num="SO0209000002",company="苏州华语科技有限公司",user="刘总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架定制版本",num="SO0209000003",company="上海大发现公司",user="刘总",price=200000,unpay=0,payed=200000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架旗舰版本",num="SO0209000004",company="成都斗神网络公司",user="李总",price=220000,unpay=100000,payed=120000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架专业版本",num="SO0209000005",company="新发现技术有限公司",user="张总",price=180000,unpay=0,payed=180000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架尊贵版本",num="SO0209000006",company="重庆飞翔软件有限公司",user="胡总",price=200000,unpay=0,payed=200000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架core版本",num="SO0209000007",company="重庆美斯特软件有限公司",user="张总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架专业版本",num="SO0209000008",company="长沙安全网络科技公司",user="王总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架java版本",num="SO0209000009",company="长沙月神计划科技有限公司",user="刘总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架尊贵版本",num="SO0209000010",company="西安飞沙软件公司",user="刘总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架java版本",num="SO0209000011",company="深圳安防软件信息有限公司",user="张总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架专业版本",num="SO0209000012",company="上海神奇软件有限公司",user="张总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架java版本",num="SO0209000013",company="北京厉害了软件有限公司",user="刘总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架专业版本",num="SO0209000014",company="上海金星软件公司",user="张总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架尊贵版本",num="SO0209000015",company="广州信息技术有限公司",user="刘总",price=300000,unpay=100000,payed=200000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架尊贵版本",num="SO0209000016",company="东莞对外出口公司",user="李总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架尊贵版本",num="SO0209000017",company="成都悠闲信息公司",user="李总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架专业版本",num="SO0209000018",company="云南天际软件有限公司",user="李总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架java版本",num="SO0209000019",company="湖北神舟信息技术公司",user="李总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});
            list.Add(new {name = "力软快速开发框架尊贵版本",num="SO0209000020",company="山东好运来公司",user="李总",price=300000,unpay=0,payed=300000,payType="电汇",time="2023-02-22"});

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.FindAll(t => t.ToString().IndexOf(keyword, StringComparison.Ordinal) > -1);
            }

            return Success(list);
        }
    }
}
