using learun.iapplication;
using oa.ibll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oa.bll
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.07.31
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>返回列表</returns>
        public Task<IEnumerable<ScheduleEntity>> GetList()
        {
            return this.BaseRepository().FindList<ScheduleEntity>(t=>t.F_CreateUserId == GetUserId());
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Task<ScheduleEntity> GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntityByKey<ScheduleEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public async Task RemoveForm(string keyValue)
        {
            await this.BaseRepository().Delete<ScheduleEntity>(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public async Task SaveForm(string keyValue, ScheduleEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.F_ScheduleId = keyValue;
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = this.GetUserId();
                entity.F_ModifyUserName = this.GetUserName();

                await this.BaseRepository().Update(entity);
            }
            else
            {
                entity.F_ScheduleId = Guid.NewGuid().ToString();
                entity.F_CreateDate = DateTime.Now;
                entity.F_CreateUserId = this.GetUserId();
                entity.F_CreateUserName = this.GetUserName();

                await this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
