using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 16:43:25
    /// 描 述： 客户回款
    /// </summary>
    public class CaseErpCustomergatherBLL : BLLBase, ICaseErpCustomergatherBLL,BLL
    {
        private readonly CaseErpCustomergatherService caseErpCustomergatherService = new CaseErpCustomergatherService();

        

        #region 获取数据
        /// <summary>
        /// 获取客户回款的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpCustomergatherEntity>> GetList(CaseErpCustomergatherEntity queryParams)
        {
            return caseErpCustomergatherService.GetList(queryParams);
        }

        /// <summary>
        /// 获取客户回款的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<CaseErpCustomergatherEntity>> GetPageList(Pagination pagination, CaseErpCustomergatherEntity queryParams)
        {
            var list=await caseErpCustomergatherService.GetPageList(pagination, queryParams);
            foreach(var entity in list)
            {
                if (!string.IsNullOrEmpty(entity.F_ReceivedDate.ToString())&& !string.IsNullOrEmpty(entity.F_FinallyDate.ToString()))
                {
                    //返回逾期天数
                    entity.F_OverdueDays = GetOverdueDays(entity.F_FinallyDate ?? DateTime.Now);
                    //返回回款管理状态
                    entity.F_GatherState = GetGatherState(entity.F_ReceivedDate ?? DateTime.Now, entity.F_FinallyDate ?? DateTime.Now, entity.F_AlreadyAmount??0,entity.F_UnpaidAmount??0);
                }


            }
            return list;
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpCustomergatherEntity> GetEntity(string keyValue)
        {
            return caseErpCustomergatherService.GetEntity(keyValue);
        }

        

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue)
        {
            await caseErpCustomergatherService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpCustomergatherEntity entity)
        {
            
            await caseErpCustomergatherService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpCustomergatherService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 逾期天数计算
        /// </summary>
        /// <param name="F_FinallyDate">最迟回款日期</param>
        /// <returns></returns>
        public static string GetOverdueDays(DateTime F_FinallyDate)
        {
            DateTime NowTime=DateTime.Now;
            string overdueDays = string.Empty;
            if (NowTime.ToString("yyyy-MM-dd") == F_FinallyDate.ToString("yyyy-MM-dd"))
            {
                overdueDays = "今天逾期";
            }
            else if (NowTime < F_FinallyDate)
            {
                overdueDays = "未逾期";
            }
            else if (NowTime > F_FinallyDate)
            {
                int days = (NowTime - F_FinallyDate).Days;
                overdueDays = days.ToString()+"天";
            }
            return overdueDays;
        }
        /// <summary>
        /// 获取回款状态
        /// 进行中：1.有回款||2.在时间段内
        /// 已完成：未回款金额为0
        /// 未开始：已回款金额为0
        /// </summary>
        /// <param name="F_ReceivedDate">计划回款日期</param>
        /// <param name="F_FinallyDate">最迟回款日期</param>
        /// <param name="F_AlreadyAmount">已回款金额</param>
        /// <param name="F_UnpaidAmount">未回款金额</param>
        /// <returns></returns>
        public static string GetGatherState(DateTime F_ReceivedDate, DateTime F_FinallyDate,decimal F_AlreadyAmount,decimal F_UnpaidAmount)
        {
            DateTime NowDate = DateTime.Now;
            if (F_UnpaidAmount == 0&& F_AlreadyAmount!=0)//未回款金额为0，则已完成
            {
                return "已完成";
            }
            if (F_AlreadyAmount>0&& F_UnpaidAmount!=0)//已回款金额大于0，未回款不等于0，则回款状态未进行中
            {
                return "进行中";
            }
            if (NowDate >= F_ReceivedDate && NowDate <= F_FinallyDate)//当前时间大于计划回款日期，且小于最迟回款日期，则为进行中
            {
                return "进行中";
            }
            if (NowDate < F_ReceivedDate&& F_AlreadyAmount==0)//当前时间小于计划回款日期，且已回款金额为0
            {
                return "未开始";
            }
            
            return "未开始";
        }
        #endregion
    }
}
