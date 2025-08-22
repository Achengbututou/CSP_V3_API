using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using oa.ibll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oa.controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS-Core 力软敏捷开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：邮件管理
    /// </summary>
    public class EmailController : BaseApiController
    {
        private readonly IEmailBLL _iEmailBLL;
        
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iEmailBLL"></param>
        public EmailController(IEmailBLL iEmailBLL) {
            _iEmailBLL = iEmailBLL;
        }

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="paginationInputDto">分页参数</param>
        /// <param name="type">类型</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        [HttpGet("oa/email/page")]
        [ProducesResponseType(typeof(ResponseDto<PaginationOutputDto<IEnumerable<EmailContentEntity>>>), 200)]
        public async Task<IActionResult> GetPageList([FromQuery] PaginationInputDto paginationInputDto, string type, string keyword)
        {
            Pagination pagination = paginationInputDto.ToObject<Pagination>();
            IEnumerable<EmailContentEntity> data = new List<EmailContentEntity>();
            switch (type) {
                case "1":
                    data = await _iEmailBLL.GetAddresseeMail(pagination, keyword);
                    break;
                case "2":
                    data = await _iEmailBLL.GetDraftMail(pagination,  keyword);
                    break;
                case "3":
                    data = await _iEmailBLL.GetSentMail(pagination, keyword);
                    break;
                case "4":
                    data = await _iEmailBLL.GetRecycleMail(pagination, keyword);
                    break;
            }
            var jsonData = new
            {
                rows = data,
                pagination.total,
                pagination.page,
                pagination.records,
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("oa/email/{id}")]
        [ProducesResponseType(typeof(ResponseDto<EmailContentEntity>), 200)]
        public async Task<IActionResult> GetEntity(string id)
        {
            var data =await _iEmailBLL.GetEntity(id);
            return Success(data);
        }
        #endregion 

        #region 提交数据
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="dto">邮件内容</param>
        /// <returns></returns>
        [HttpPost("oa/email")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> AddForm(EmailDto dto)
        {
            await _iEmailBLL.SaveForm(string.Empty, dto.Content, dto.AddresssIds, dto.CopysendIds, dto.BccsendIds);
            return SuccessInfo("保存成功！");
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="dto">邮件内容</param>
        /// <returns></returns>
        [HttpPut("oa/email/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> UpdateForm(string id, EmailDto dto)
        {
            await _iEmailBLL.SaveForm(id, dto.Content, dto.AddresssIds, dto.CopysendIds, dto.BccsendIds);
            return SuccessInfo("保存成功！");
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        [HttpDelete("oa/email/{id}/{type}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> DeleteForm(string id, int type)
        {
            string emailType = type == 1 ? "addresseeMail" : "sendMail";
            await _iEmailBLL.RemoveForm(id, emailType);
            return SuccessInfo("删除成功！");
        }
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        [HttpDelete("oa/email/remove/{id}/{type}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> ThoroughRemoveForm(string id, int type)
        {
            string emailType = "";
            switch (type) {
                case 1:
                    emailType = "addresseeMail";
                    break;
                case 2:
                    emailType = "draftMail";
                    break;
                case 3:
                    emailType = "sendMail";
                    break;
                case 4:
                    emailType = "recycleMail";
                    break;
            }
            await _iEmailBLL.ThoroughRemoveForm(id, emailType);
            return SuccessInfo("删除成功！");
        }
        #endregion
    }
}