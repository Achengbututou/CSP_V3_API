using ce.autofac.extension;
using learun.iapplication;
using learun.iquartz;
using learun.util;
using System.Threading.Tasks;

namespace demo
{
    /// <summary>
    /// 任务调度ioc测试
    /// </summary>
    [BLLName("tstest")]
    public class TSIocTest: ITsMethod
    {
        /// <summary>
        /// 任务调度器执行的方法
        /// </summary>
        public async Task<string> Execute() {
            await HttpMethods.Get("https://www.learun.cn/");
            return "";
        }
    }
}
