using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;
using TencentCloud.Cme.V20191029.Models;
using Tea.Utils;

namespace mes.bll
{
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-18 11:28:59
    /// 描 述： 工序派工用户
    /// </summary>
    public class MesProcessUserInfoBLL : BLLBase, IMesProcessUserInfoBLL, BLL
    {
        private readonly MesProcessUserInfoService mesProcessUserInfoService = new MesProcessUserInfoService();

        private readonly IMesProcessDispatchBLL _iMesProcessDispatchBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProcessDispatchBLL">工序派工接口</param>
        public MesProcessUserInfoBLL(IMesProcessDispatchBLL iMesProcessDispatchBLL)
        {
            _iMesProcessDispatchBLL = iMesProcessDispatchBLL ?? throw new ArgumentNullException(nameof(iMesProcessDispatchBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取工序派工用户的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessUserInfoEntity>> GetList(MesProcessUserInfoEntity queryParams)
        {
            return mesProcessUserInfoService.GetList(queryParams);
        }
        /// <summary>
        /// 获取工序派工用户的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessUserInfoEntity>> GetPageList(Pagination pagination, MesProcessUserInfoEntity queryParams)
        {
            return mesProcessUserInfoService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessUserInfoEntity> GetEntity(string keyValue)
        {
            return mesProcessUserInfoService.GetEntity(keyValue);
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
            await mesProcessUserInfoService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string ids)
        {
            List<string> keyValues = ids.Split(',').ToList();
            await mesProcessUserInfoService.Deletes(keyValues);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessUserInfoEntity entity)
        {
            await mesProcessUserInfoService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 工序派工用户派工
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DispatchUser(List<MesProcessUserInfoEntity> entitys)
        {
            List<MesProcessUserInfoEntity> mesProcessUsers = new List<MesProcessUserInfoEntity>();
            List<string> keyValues = new List<string>();
            List<string> values = new List<string>();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            string ProductionTicketId = "";
            foreach (var item in entitys)
            {
                MesProcessUserInfoEntity mesProcessUserInfo = new MesProcessUserInfoEntity();
                mesProcessUserInfo.F_ProductionTicketId = item.F_ProductionTicketId;
                ProductionTicketId=item.F_ProductionTicketId;   
                mesProcessUserInfo.F_ProcessRouteId = item.F_ProcessRouteId;
                mesProcessUserInfo.F_Distributions = item.F_Distributions;
                mesProcessUserInfo.F_UserId=item.F_UserId;  
                keyValues.Add(item.F_ProductionTicketId);
                mesProcessUsers.Add(mesProcessUserInfo);
                values.Add(item.F_ProcessRouteId);
                //处理派发数量

                if (keyValuePairs.ContainsKey(item.F_ProcessRouteId))
                {
                    int histotyValue = keyValuePairs[item.F_ProcessRouteId];
                    keyValuePairs.Remove(item.F_ProcessRouteId);
                    keyValuePairs.Add(item.F_ProcessRouteId, histotyValue + (int)item.F_Distributions);
                }
                else
                {
                    keyValuePairs.Add(item.F_ProcessRouteId, (int)item.F_Distributions);
                }

            }
            var mesProcessDispathList = await _iMesProcessDispatchBLL.GetListByIds(values, ProductionTicketId);
            List<MesProcessDispatchEntity> mesProcessDispatches = new List<MesProcessDispatchEntity>();
            foreach (var item in mesProcessDispathList)
            {
                item.F_States = 2;
                if (keyValuePairs.ContainsKey(item.F_ProcessManagementId))
                {
                    int DistriValue = keyValuePairs[item.F_ProcessManagementId];
                    item.F_QuantityIndicated = DistriValue;
                }
                mesProcessDispatches.Add(item);
            }
            mesProcessUserInfoService.BeginTrans();
            try
            {
                await _iMesProcessDispatchBLL.SaveList(mesProcessDispatches);
                await mesProcessUserInfoService.Deletes(values);
                await mesProcessUserInfoService.SaveList(mesProcessUsers);
                mesProcessUserInfoService.Commit();
            }
            catch (Exception)
            {
                mesProcessUserInfoService.Rollback();
                throw;
            }

        }
        #endregion
    }
}