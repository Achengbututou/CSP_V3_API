using ce.autofac.extension;
using learun.iapplication;
using learun.util;
using System.Data;
using System.Threading.Tasks;

namespace demo
{
    /// <summary>
    /// 任务调度ioc测试
    /// </summary>
    [BLLName("excelImportTest")]
    public class ExcelImportTest: IExcelImportMethod
    {
        /// <summary>
        /// 导入执行方法
        /// </summary>
        /// <param name="dt">excel数据</param>
        /// <returns></returns>
        public async Task<bool> Execute(DataTable dt) {
            await HttpMethods.Get("https://www.learun.cn/");// 纯属测试
            foreach (var item in dt.Rows) { 
                // 处理导入数据
            }
            return true;
        }
    }
}
