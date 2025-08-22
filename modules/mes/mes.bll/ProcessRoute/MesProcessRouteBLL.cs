using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-07 13:29:09
    /// 描 述： 工艺路线管理
    /// </summary>
    public class MesProcessRouteBLL: BLLBase, IMesProcessRouteBLL, BLL {
        private readonly MesProcessRouteService mesProcessRouteService = new MesProcessRouteService();
        private readonly IMesProceNodeRouteBLL _iMesProceNodeRouteBLL;
        private readonly IMesProcessLineRouteBLL _iMesProcessLineRouteBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesProceNodeRouteBLL">null接口</param>
        /// <param name="iMesProcessLineRouteBLL">工艺路线线条接口</param>
        public MesProcessRouteBLL(IMesProceNodeRouteBLL iMesProceNodeRouteBLL, IMesProcessLineRouteBLL iMesProcessLineRouteBLL) {
            _iMesProceNodeRouteBLL = iMesProceNodeRouteBLL ??
                throw new ArgumentNullException(nameof(iMesProceNodeRouteBLL));
            _iMesProcessLineRouteBLL = iMesProcessLineRouteBLL ??
                throw new ArgumentNullException(nameof(iMesProcessLineRouteBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取工艺路线管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>>GetList(MesProcessRouteEntity queryParams) {
            return mesProcessRouteService.GetList(queryParams);
        }
        /// <summary>
        /// 根据商品编码获取工艺路线
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>> GETListByCode(string code)
        {
            return mesProcessRouteService.GETListByCode(code);  
        }
        /// <summary>
        /// 获取物料工艺路线
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public  Task<IEnumerable<MesProcessRouteEntity>> GetPageAllList(Pagination pagination, MesProcessRouteEntity queryParams)
        {
            return   mesProcessRouteService.GetPageAllList(pagination, queryParams);
        }
        /// <summary>
        /// 获取工艺路线管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesProcessRouteEntity>>GetPageList(Pagination pagination, MesProcessRouteEntity queryParams) {
            return mesProcessRouteService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesProcessRouteEntity>GetEntity(string keyValue) {
            return mesProcessRouteService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesProcessRouteService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new ProcessRouteDto();
            res.F_ProcessRouteId = keyValue;
            mesProcessRouteService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.F_ProcessRouteId != null) {
                    await _iMesProceNodeRouteBLL.DeleteRelateEntity(res.F_ProcessRouteId);
                    await _iMesProcessLineRouteBLL.DeleteRelateEntity(res.F_ProcessRouteId);
                }
                mesProcessRouteService.Commit();
            } catch (Exception) {
                mesProcessRouteService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteChildrenAll(string keyValue)
        {
            var res = new ProcessRouteDto();
            res.F_ProcessRouteId = keyValue;
            mesProcessRouteService.BeginTrans();
            try
            {
                //await Delete(keyValue);
                if (res.F_ProcessRouteId != null)
                {
                    await _iMesProceNodeRouteBLL.DeleteRelateEntity(res.F_ProcessRouteId);
                    await _iMesProcessLineRouteBLL.DeleteRelateEntity(res.F_ProcessRouteId);
                }
                mesProcessRouteService.Commit();
            }
            catch (Exception)
            {
                mesProcessRouteService.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesProcessRouteService.Deletes(keyValues);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues) {
            var keyValuelist = keyValues.Split(",");
            foreach(var keyValue in keyValuelist) {
                await DeleteAll(keyValue);
            }
        }
        /// <summary>
        /// 改变产品下的工艺路线的常用状态
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns></returns>
        public async Task SetCmmon(CommonInfoDTO commonInfo)
        {
            await mesProcessRouteService.SetCmmon(commonInfo);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesProcessRouteEntity entity) {
            entity.F_RouteNumber = (await GetRuleCodeEx(entity.F_RouteNumber)).ToString();
            await mesProcessRouteService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, ProcessRouteDto dto) {
            mesProcessRouteService.BeginTrans();
            try {
                await _iMesProceNodeRouteBLL.SaveList(dto.F_ProcessRouteId, dto.nodes);
                await _iMesProcessLineRouteBLL.SaveList(dto.F_ProcessRouteId, dto.edges);
                mesProcessRouteService.Commit();
            } catch (Exception) {
                mesProcessRouteService.Rollback();
                throw;
            }
        }
        #endregion
    }
}