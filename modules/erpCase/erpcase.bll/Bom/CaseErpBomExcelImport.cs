
using System.Collections.Generic;
using System.Threading.Tasks;
using ce.autofac.extension;
using erpCase.ibll;
using learun.iapplication;
using learun.office;

namespace erpCase.bll
{
    /// <summary>
    /// bom导入
    /// </summary>
    [BLLName("erpBomImport")]
    public class CaseErpBomExcelImport : IExcelImportMethod2, BLL
    {
        private readonly ICaseErpBomBLL _iCaseErpBomBLL;

        public CaseErpBomExcelImport(ICaseErpBomBLL iCaseErpBomBLL)
        {
            _iCaseErpBomBLL = iCaseErpBomBLL;
        }

        /// <summary>
        /// 数据导入处理
        /// </summary>
        /// <param name="sheets">excel数据</param>
        /// <returns></returns>
        public async Task<bool> Execute(List<ExcelSheet> sheets)
        {
            return await _iCaseErpBomBLL.BomImport(sheets);
        }
    }
}

