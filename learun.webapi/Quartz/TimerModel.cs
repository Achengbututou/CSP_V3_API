using System;

namespace learun.webapi
{
    /// <summary>
    /// 定时包对象
    /// </summary>
    public class TimerModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}