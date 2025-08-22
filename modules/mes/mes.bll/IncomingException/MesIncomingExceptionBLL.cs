using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
using System.Linq;
using TencentCloud.Cme.V20191029.Models;

namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-23 10:32:39
    /// 描 述： 来料异常检验报告
    /// </summary>
    public class MesIncomingExceptionBLL: BLLBase, IMesIncomingExceptionBLL, BLL {
        private readonly MesIncomingExceptionService mesIncomingExceptionService = new MesIncomingExceptionService();
        private readonly IMesIncomingInspectionBLL _iMesIncomingInspectionBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesIncomingInspectionBLL">来料检验报告接口</param>
        /// <param name="iMesIncomingByOrderBLL">来料检验报告按单检验接口</param>
        public MesIncomingExceptionBLL(IMesIncomingInspectionBLL iMesIncomingInspectionBLL)
        {
            _iMesIncomingInspectionBLL = iMesIncomingInspectionBLL ?? throw new ArgumentNullException(nameof(iMesIncomingInspectionBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取来料异常检验报告的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingExceptionEntity>>GetList(MesIncomingExceptionEntity queryParams) {
            return mesIncomingExceptionService.GetList(queryParams);
        }
        /// <summary>
        /// 获取来料异常检验报告的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesIncomingExceptionEntity>>GetPageList(Pagination pagination, MesIncomingExceptionEntity queryParams) {
            return mesIncomingExceptionService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesIncomingExceptionEntity>GetEntity(string keyValue) {
            return mesIncomingExceptionService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesIncomingExceptionService.Delete(keyValue);
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            List<string> keys = keyValues.Split(',').ToList();
            var lists = await mesIncomingExceptionService.GetListByIds(keys);
            var IncomingInspectionList = await _iMesIncomingInspectionBLL.GetList(lists.Select(t => t.F_IncomingInspectionId).ToList());
            List<MesIncomingInspectionEntity> mesIncomingInspections = new List<MesIncomingInspectionEntity>();
            foreach(var item in IncomingInspectionList)
            {
                item.F_States = 1;
                mesIncomingInspections.Add(item);
            }
            mesIncomingExceptionService.BeginTrans();
            try
            {
                await mesIncomingExceptionService.DeleteAll(keys);
                await _iMesIncomingInspectionBLL.UpdateList(mesIncomingInspections);
                mesIncomingExceptionService.Commit();
            }
            catch (Exception)
            {
                mesIncomingExceptionService.Rollback();
                throw;
            }
           
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, MesIncomingExceptionEntity entity) 
        {
            entity.F_ExceptionNumber = (await GetRuleCodeEx(entity.F_ExceptionNumber)).ToString();
            entity.F_States = 1;
            mesIncomingExceptionService.BeginTrans();
            var data = await _iMesIncomingInspectionBLL.GetEntity(entity.F_IncomingInspectionId);
            data.F_States = 5;
            try
            {
                await mesIncomingExceptionService.SaveEntity(keyValue, entity);
                await _iMesIncomingInspectionBLL.SaveEntity(data.F_Id, data);
                mesIncomingExceptionService.Commit();
            }
            catch (Exception)
            {
                mesIncomingExceptionService.Rollback();
                throw;
            }
        }
        #endregion
    }
}