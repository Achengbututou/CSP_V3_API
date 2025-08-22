using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace learun.webapi
{
    /// <summary>
    /// 方法入口类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 入口函数
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// 构建服务
        /// </summary>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseKestrel(option =>
                    {
                        option.Limits.MinRequestBodyDataRate = null;
                        //option.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);
                        //option.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);
                    });
                });
    }
}
