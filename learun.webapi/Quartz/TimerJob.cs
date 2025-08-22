using System;
using ce.autofac.extension;
using Quartz;
using System.Threading.Tasks;
using learun.application;
using learun.cache;
using learun.iapplication;
using learun.quartz;
using learun.sass.bll;
using learun.util;
using learun.utils.web;

namespace learun.webapi
{
    /// <summary>
    /// 版 本 Learun-Core-VUE 力软开发框架
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：tobin
    /// 日 期：2020.02.12
    /// 描 述：流程定时执行任务
    /// </summary>
    public class TimerJob:IJob
    {
        private string cacheKey = "learun_scheduler_key";
    
        private async Task Init(string id,TimerModel oldData)
        {
            var cache  = IocManager.Instance.GetService<ICache>();
            await cache.Lock(cacheKey, async _ =>
            {
                // 写入标记，启动任务调度
                // 1.需要再读取一次，确保当前没有其他节点启动
                var data = await cache.ReadAsync<TimerModel>(cacheKey);
                if (data == null || (oldData != null && oldData.ID == data.ID && oldData.DateTime == data.DateTime) )
                {
                    
                    // 流程超时程序
                    await WfJobScheduler.Start();
                    // 租户同步
                    await TenantHelper.InitJob();
                    // 临时文件删除
                    await FileJobScheduler.Start();
                    // 任务调度
                    await QuartzHelper.InitJob();

                    data = new TimerModel() { ID= id, DateTime = DateTime.Now };
                    await cache.WriteAsync(cacheKey,data);
                }
            });
        }
        
        
    
        /// <summary>
        /// 执行任务方法
        /// </summary>
        /// <param name="context"></param>
        public async Task Execute(IJobExecutionContext context)
        {
            var logIBLL = IocManager.Instance.GetService<LogIBLL>();
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string id = dataMap.GetString("id");
            try
            {
                
                var cache  = IocManager.Instance.GetService<ICache>();
                var data =await cache.ReadAsync<TimerModel>(cacheKey);
                if (data == null)
                {
                    await Init(id,null);
                }
                else
                {
                    if (data.ID == id)
                    {
                        await cache.Lock(cacheKey, async _ =>
                        {
                            var nowDta = await cache.ReadAsync<TimerModel>(cacheKey);
                            if (nowDta?.ID == id)
                            {
                                // 任务调度
                                await QuartzHelper.InitJob();
                                data = new TimerModel() { ID= id, DateTime = DateTime.Now };
                                await cache.WriteAsync(cacheKey,data);
                            }
                        });
                    }
                    else
                    {
                        // 进行判断是否大于5分钟
                        var time = DateTime.Now.AddMinutes(-5);
                        if (time >= data.DateTime)
                        {
                            // 超时
                            await Init(id,data);
                        }
                        else
                        {
                            await QuartzHelper.RemoveJob();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
                LogEntity logEntity = new LogEntity();
                logEntity.F_CategoryId = 4;
                logEntity.F_ExecuteResult = -1;
                logEntity.F_ExecuteResultJson = logIBLL.ExceptionFormat(e);
                logIBLL.Write(logEntity,null);
            }

            try
            {
                OnlineUserHelper.UpdateOnlineUserList();
            }
            catch (Exception e)
            {
                
                LogEntity logEntity = new LogEntity();
                logEntity.F_CategoryId = 4;
                logEntity.F_ExecuteResult = -1;
                logEntity.F_ExecuteResultJson = logIBLL.ExceptionFormat(e);
                logIBLL.Write(logEntity,null);
            }

            try
            {
                if (DateTime.Now.Hour == 23)
                {
                    await logIBLL.Remove(ConfigHelper.GetConfig().SaveLogDays);
                }
            }
            catch (Exception e)
            {
                
                LogEntity logEntity = new LogEntity();
                logEntity.F_CategoryId = 4;
                logEntity.F_ExecuteResult = -1;
                logEntity.F_ExecuteResultJson = logIBLL.ExceptionFormat(e);
                logIBLL.Write(logEntity,null);
            }

            try
            {
                await QuartzJobScheduler.Start(id);
            }
            catch (Exception e)
            {
                
                LogEntity logEntity = new LogEntity();
                logEntity.F_CategoryId = 4;
                logEntity.F_ExecuteResult = -1;
                logEntity.F_ExecuteResultJson = logIBLL.ExceptionFormat(e);
                logIBLL.Write(logEntity,null);
            }
        }
    }
}
