using ce.autofac.extension;
using learun.iapplication;
using mes.ibll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mes.bll.FinishedReport
{
    /// <summary>
    /// 成品检验报告工作流操作
    /// </summary>
    [BLLName("MesFinishedReportIOC")]
    public class MesFinishedReportIOC : IWorkFlowMethod
    {
        private readonly IMesFinishedReportBLL _iMesFinishedReportBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesFinishedReportBLL">成品检验报告接口</param>
        /// <param name="iMesFinishedDetailBLL">成品检验数据接口</param>
        public MesFinishedReportIOC(IMesFinishedReportBLL iMesFinishedReportBLL)
        {
            _iMesFinishedReportBLL = iMesFinishedReportBLL ?? throw new ArgumentNullException(nameof(iMesFinishedReportBLL));
        }

        /// <summary>
        /// 流程绑定方法需要继承的接口
        /// </summary>
        /// <param name="parameter"></param>
        public async Task Execute(WfMethodParameter parameter)
        {
            await _iMesFinishedReportBLL.UpdateStateByWf(parameter.ProcessId, parameter.Code, parameter.UnitName);
        }
    }
}
