using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using oa.ibll;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learun.webapp.Areas.LR_OAModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS-Core 力软敏捷开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleController : BaseApiController
    {
        private readonly IScheduleBLL _ischeduleIBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ischeduleBLL"></param>
        public ScheduleController(IScheduleBLL ischeduleBLL) {
            _ischeduleIBLL = ischeduleBLL;
        }

        #region 获取数据
        /// <summary>
        /// 获取日程数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("oa/schedules")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Hashtable>>), 200)]
        public async Task<IActionResult> GetList()
        {
            List<Hashtable> data = new List<Hashtable>();
            foreach (ScheduleEntity entity in (await _ischeduleIBLL.GetList()).ToList())
            {
                Hashtable ht = new Hashtable();
                ht["id"] = entity.F_ScheduleId;
                ht["title"] = entity.F_ScheduleContent;
                ht["end"] = (entity.F_EndDate.ToDate().ToString("yyyy-MM-dd") + " " + entity.F_EndTime.Substring(0, 2) + ":" + entity.F_EndTime.Substring(2, 2)).ToDate().ToString("yyyy-MM-dd HH:mm:ss");
                ht["start"] = (entity.F_StartDate.ToDate().ToString("yyyy-MM-dd") + " " + entity.F_StartTime.Substring(0, 2) + ":" + entity.F_StartTime.Substring(2, 2)).ToDate().ToString("yyyy-MM-dd HH:mm:ss");
                ht["allDay"] = false;
                data.Add(ht);
            }
            return Success(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet("oa/schedule/{id}")]
        [ProducesResponseType(typeof(ResponseDto<ScheduleEntity>), 200)]
        public async Task<IActionResult> GetFormJson(string id)
        {
            var data =await _ischeduleIBLL.GetEntity(id);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpDelete("oa/schedule/{id}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> RemoveForm(string keyValue)
        {
            await _ischeduleIBLL.RemoveForm(keyValue);
            return SuccessInfo("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost("oa/schedule")]
        public async Task<IActionResult> AddForm(ScheduleEntity entity)
        {
            await _ischeduleIBLL.SaveForm(string.Empty, entity);
            return SuccessInfo("操作成功。");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("oa/schedule/{id}")]
        public async Task<IActionResult> UpdateForm(string id, ScheduleEntity entity)
        {
            await _ischeduleIBLL.SaveForm(id, entity);
            return SuccessInfo("操作成功。");
        }
        #endregion
    }
}