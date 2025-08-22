
using System.Threading.Tasks;
using ce.autofac.extension;
using learun.iapplication;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 供应商审批状态更新
    /// </summary>
    [BLLName("PurchaseIOC")]
    public class PurchaseIOC : IWorkFlowMethod
    {
        private readonly ICaseErpPurchaseBLL _iCaseErpPurchaseBLL;


        public PurchaseIOC(ICaseErpPurchaseBLL iCaseErpPurchaseBLL) {
            _iCaseErpPurchaseBLL = iCaseErpPurchaseBLL;
        }


        /// <summary>
        /// 流程绑定方法需要继承的接口
        /// </summary>
        /// <param name="parameter"></param>
        public async Task Execute(WfMethodParameter parameter)
        {
            await _iCaseErpPurchaseBLL.UpdateStateByWf(parameter.ProcessId,parameter.Code,parameter.UnitName);
        }
    }
}
