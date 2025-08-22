using ce.autofac.extension;
using erpCase.ibll;
using learun.iquartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erpCase.bll
{
    /// <summary>
    /// ERP-设备告警
    /// </summary>
    /// 创建人：施赛一
    /// 日 期： 2022-12-07 10:00:00
    [BLLName("iocdevicewarn")]
    public class IocDeviceWarn : ITsMethod
    {
        /// <summary>
        /// 任务调度主体执行方法
        /// </summary>
        public async Task<string> Execute()
        {
            try
            {
                await DeviceWarn();//设备告警
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region 设备告警
        public async Task DeviceWarn()
        {
            var _icaseErpDevicewarnBLL = IocManager.Instance.GetService<ICaseErpDevicewarnBLL>();
            await _icaseErpDevicewarnBLL.DeviceWarn();
        }
        #endregion
    }
}
