using learun.database;
using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace learun.quartz.controllers.Lr_erp
{
    /// <summary>
    /// 统计
    /// </summary>
    public class StatisticsController : BaseApiController
    {
        /// <summary>
        /// Object型转换为decimal型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ObjToDecimal(object expression, decimal defValue)
        {
            if (expression != null)
                return StrToDecimal(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(string expression, decimal defValue)
        {
            if ((expression == null) || (expression.Length > 10))
                return defValue;

            decimal intValue = defValue;
            if (expression != null)
            {
                bool IsDecimal = Regex.IsMatch(expression, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsDecimal)
                    decimal.TryParse(expression, out intValue);
            }
            return intValue;
        }

        #region 获取统计图信息
        /// <summary>
        /// 获取统计图的数据信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("erp/statistics/{param}")]
        [ProducesResponseType(typeof(ResponseDto), 200)]
        public async Task<IActionResult> GetStatistics(string param)
        {
            string DetailStr = "";
            if (!string.IsNullOrEmpty(param))
            {
                string data_name = string.Empty;//统计图的横坐标
                string data_value = string.Empty;//统计图的纵坐标
                string data_pie = string.Empty;//饼图所需要的数据

                switch (param)
                {
                    case "lr_erp_purchaserequisition"://采购申请
                        DetailStr = "lr_erp_productinfo";
                        break;
                    case "lr_erp_purchaseorder"://采购订单
                        DetailStr = "lr_erp_purchaseorderdetail";
                        break;
                    case "lr_erp_purchasewarehous"://采购入库
                        DetailStr = "lr_erp_purchasewarehoudetail";
                        break;
                    case "lr_erp_payinfo"://付款单
                        DetailStr = "lr_erp_payinfodetail";
                        break;
                    case "lr_erp_salesoffer"://销售报价
                        DetailStr = "lr_erp_salesofferdetail";
                        break;
                    case "lr_erp_salesorder"://销售订单
                        DetailStr = "lr_erp_salesorderdetail";
                        break;
                    case "lr_erp_salesreceipt"://销售出库
                        DetailStr = "lr_erp_salesreceiptdetail";
                        break;
                    case "lr_erp_receiptinfo"://收款单
                        DetailStr = "lr_erp_receiptinfodetail";
                        break;
                    default:
                        DetailStr = "lr_erp_purchaseorderdetail";
                        break;
                }
                string SQLStr_name = string.Format("SELECT F_Name FROM {0} GROUP BY F_Name", DetailStr);

                RepositoryFactory repositoryFactory = new RepositoryFactory();
                DataTable dt_name = await repositoryFactory.BaseRepository().FindTable(SQLStr_name);
                if (dt_name.Rows.Count > 0)
                {
                    foreach (DataRow name in dt_name.Rows)
                    {
                        data_name += name["F_Name"].ToString() + ",";
                        string SQLStr_value = string.Format("SELECT SUM(F_Count) AS Total FROM {0} where F_Name='{1}'", DetailStr, name["F_Name"].ToString());
                        DataTable dt_value = await repositoryFactory.BaseRepository().FindTable(SQLStr_value);
                        if (dt_value.Rows.Count > 0)
                        {
                            data_value += ObjToDecimal(dt_value.Rows[0]["Total"], 0) + ",";

                            var Total = ObjToDecimal(dt_value.Rows[0]["Total"], 0);
                            var F_Name = name["F_Name"].ToString();
                            data_pie += "{value:"+ Total + ",name:"+ F_Name + "}" + "#";
                        }
                    }
                }
                var jsonData = new
                {
                    data_name = data_name.TrimEnd(','),
                    data_value = data_value.TrimEnd(','),
                    data_pie = data_pie.TrimEnd('#')
                };
                return OK(jsonData);
            }
            else
            {
                return SuccessInfo("请传入数据类型！");
            }
        }
        #endregion
    }
}
