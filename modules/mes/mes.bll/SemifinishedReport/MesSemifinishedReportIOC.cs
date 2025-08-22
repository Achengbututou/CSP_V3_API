using ce.autofac.extension;
using learun.iapplication;
using mes.ibll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mes.bll.SemifinishedReport
{/// <summary>
 /// 半成品检验报告流程状态更新
 /// </summary>
    [BLLName("MesSemifinishedReportIOC")]
    public  class MesSemifinishedReportIOC : IWorkFlowMethod
    {
        private readonly IMesSemifinishedReportBLL _iMesSemifinishedReportBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesSemifinishedReportBLL">半成品检验报告接口</param>
        public MesSemifinishedReportIOC(IMesSemifinishedReportBLL iMesSemifinishedReportBLL)
        {
            _iMesSemifinishedReportBLL = iMesSemifinishedReportBLL ?? throw new ArgumentNullException(nameof(iMesSemifinishedReportBLL));
        }

        /// <summary>
        /// 流程绑定方法需要继承的接口
        /// </summary>
        /// <param name="parameter"></param>
        public async Task Execute(WfMethodParameter parameter)
        {
            await _iMesSemifinishedReportBLL.UpdateStateByWf(parameter.ProcessId, parameter.Code, parameter.UnitName);
        }
    }
}
