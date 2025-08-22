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
    /// 日 期： 2022-12-05 16:49:03
    /// 描 述： 物料信息
    /// </summary>
    public class CaseErpMaterialBLL : BLLBase, ICaseErpMaterialBLL, BLL
    {
        private readonly CaseErpMaterialService caseErpMaterialService = new CaseErpMaterialService();



        #region 获取数据
        /// <summary>
        /// 获取物料信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpMaterialEntity>> GetList(CaseErpMaterialEntity queryParams)
        {
            return caseErpMaterialService.GetList(queryParams);
        }

        /// <summary>
        /// 获取物料信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpMaterialEntity>> GetPageList(Pagination pagination, CaseErpMaterialEntity queryParams)
        {
            return caseErpMaterialService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<CaseErpMaterialEntity> GetEntity(string keyValue)
        {
            #region 添加操作记录-客户
            string F_Description = "查看物料信息";
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(keyValue, "1", F_Description, GetUserId());
            #endregion

            return await caseErpMaterialService.GetEntity(keyValue);
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
            await caseErpMaterialService.Delete(keyValue);
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpMaterialEntity entity)
        {
            if (entity.F_IsSysNum == 0)//是否系统编号(0是，1否)
            {
                entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString();
            }
            await caseErpMaterialService.SaveEntity(keyValue, entity);

            #region 添加操作记录-物料
            string F_Description = "修改物料信息";
            if (string.IsNullOrEmpty(keyValue))
            {
                F_Description = "添加物料";
            }
            var _iCaseErpLogBLL = IocManager.Instance.GetService<ICaseErpLogBLL>();
            await _iCaseErpLogBLL.SaveLog(entity.F_Id, "1", F_Description, GetUserId());
            #endregion
        }



        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpMaterialService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取实体数据-【根据物料编号和物料名称获取物料实体】
        /// </summary>
        /// <param name="F_Number">物料编号</param>
        /// <returns></returns>
        public async Task<CaseErpMaterialEntity> GetEntityByNumName(string F_Number)
        {
            return await caseErpMaterialService.BaseRepository().FindEntity<CaseErpMaterialEntity>(t => t.F_Number == F_Number);
        }

        #endregion
    }
}
