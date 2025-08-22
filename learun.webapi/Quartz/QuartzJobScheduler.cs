using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.cache;
using Quartz;
using Quartz.Impl;
using System.Threading;
using learun.application;
using learun.quartz;
using learun.timer;
using learun.sass.bll;
using learun.utils.web;
using Quartz.Impl.Triggers;

namespace learun.webapi
{
    /// <summary>
    /// 
    /// </summary>
    public class QuartzJobScheduler
    {
       
        
        /// <summary>
        /// 
        /// </summary>
        public static async Task Init()
        {
            await Start(IdHelper.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static async Task Start(string id)
        {
            try
            {
                string jobName = "learun_timer_job";
                IScheduler scheduler = TimerHelper.GetScheduler();
                TriggerKey triggerKey = new TriggerKey(jobName, "learun_timer_group");
                if (await scheduler.GetTrigger(triggerKey) != null)
                {
                    jobName += '1';
                }

                IJobDetail job = JobBuilder.Create<TimerJob>().UsingJobData("id", id).Build();
                //开始时间处理
                DateTime StarTime = DateTime.Now.AddSeconds(60);
                DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(StarTime, 1);
                //结束时间处理
                DateTime EndTime = DateTime.MaxValue.AddDays(-1);
                DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(EndTime, 1);
                // 创建一个时间触发器
                SimpleTriggerImpl trigger = new SimpleTriggerImpl
                {
                    Name = jobName,
                    Group = "learun_timer_group",
                    StartTimeUtc = starRunTime,
                    EndTimeUtc = endRunTime,
                    RepeatCount = 0
                };
                
                

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (System.Exception)
            {
            }
        }
    }
}