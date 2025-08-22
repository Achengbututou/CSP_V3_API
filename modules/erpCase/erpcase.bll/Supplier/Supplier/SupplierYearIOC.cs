using System.Threading.Tasks;
using ce.autofac.extension;
using learun.iapplication;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 供应商年审状态更新
    /// </summary>
    [BLLName("ERPSupplierYearIOC")]
    public class SupplierYearIOC : IWorkFlowMethod
    {
        private readonly ICaseErpSupplierBLL _ICaseErpSupplierBLL;


        public SupplierYearIOC(ICaseErpSupplierBLL iCaseErpSupplierBLL) {
            _ICaseErpSupplierBLL = iCaseErpSupplierBLL;
        }
        
        /// <summary>
        /// 流程绑定方法需要继承的接口
        /// </summary>
        /// <param name="parameter"></param>
        public async Task Execute(WfMethodParameter parameter)
        {
            await _ICaseErpSupplierBLL.UpdateStateByWfYear(parameter.ProcessId,parameter.Code);
        }
    }
}