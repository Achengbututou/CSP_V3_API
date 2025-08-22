using ce.autofac.extension;
using learun.iapplication;
using learun.util;
using System.Threading.Tasks;

namespace demo
{
    /// <summary>
    /// 测试流程ioc
    /// </summary>
    [BLLName("wftest")]
    public class WFIocTest: IWorkFlowMethod
    {

        /// <summary>
        /// 流程绑定方法需要继承的接口
        /// </summary>
        /// <param name="parameter"></param>
        public async Task Execute(WfMethodParameter parameter) {
            var str = await HttpMethods.Get("https://www.learun.cn/");
        }
    }
}
