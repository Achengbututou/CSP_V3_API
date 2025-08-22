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
    /// 日 期： 2022-12-05 16:54:57
    /// 描 述： 单位换算
    /// </summary>
    public class CaseErpUnitconvertBLL : BLLBase, ICaseErpUnitconvertBLL,BLL
    {
        private readonly CaseErpUnitconvertService caseErpUnitconvertService = new CaseErpUnitconvertService();

        private readonly ICaseErpUnitconvertdetailBLL _iCaseErpUnitconvertdetailBLL;
        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iCaseErpUnitconvertdetailBLL">单位换算详情【case_erp_unitconvertdetail】接口</param>
        public CaseErpUnitconvertBLL(ICaseErpUnitconvertdetailBLL iCaseErpUnitconvertdetailBLL)
        {
            _iCaseErpUnitconvertdetailBLL = iCaseErpUnitconvertdetailBLL?? throw new ArgumentNullException(nameof(iCaseErpUnitconvertdetailBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取单位换算的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitconvertEntity>> GetList(CaseErpUnitconvertEntity queryParams)
        {
            return caseErpUnitconvertService.GetList(queryParams);
        }

        /// <summary>
        /// 获取单位换算的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpUnitconvertEntity>> GetPageList(Pagination pagination, CaseErpUnitconvertEntity queryParams)
        {
            return caseErpUnitconvertService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpUnitconvertEntity> GetEntity(string keyValue)
        {
            return caseErpUnitconvertService.GetEntity(keyValue);
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
            await caseErpUnitconvertService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new UnitconvertDto();
            res.CaseErpUnitconvertEntity = await GetEntity(keyValue);
            if(res.CaseErpUnitconvertEntity != null)
            {
                res.CaseErpUnitconvertdetailList = await _iCaseErpUnitconvertdetailBLL.GetList(new CaseErpUnitconvertdetailEntity { F_UnitConvertId = res.CaseErpUnitconvertEntity.F_Id });
            }
            caseErpUnitconvertService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if(res.CaseErpUnitconvertEntity != null)
                {
                    await _iCaseErpUnitconvertdetailBLL.DeleteRelateEntity(res.CaseErpUnitconvertEntity.F_Id);
                }
                caseErpUnitconvertService.Commit();
            }
            catch (Exception)
            {
                caseErpUnitconvertService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpUnitconvertEntity entity)
        {
            
            await caseErpUnitconvertService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, UnitconvertDto dto)
        {
            caseErpUnitconvertService.BeginTrans();
            try
            {
                await SaveEntity(keyValue,dto.CaseErpUnitconvertEntity);
                await _iCaseErpUnitconvertdetailBLL.SaveList(dto.CaseErpUnitconvertEntity.F_Id,dto.CaseErpUnitconvertdetailList);
                caseErpUnitconvertService.Commit();
            }
            catch (Exception)
            {
                caseErpUnitconvertService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpUnitconvertService.Deletes(keyValues);
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task DeleteAlls(string keyValues)
        {
            var keyValuelist = keyValues.Split(",");
            foreach (var keyValue in keyValuelist)
            {
                var res = new UnitconvertDto();
                res.CaseErpUnitconvertEntity = await GetEntity(keyValue);
            if(res.CaseErpUnitconvertEntity != null)
            {
                res.CaseErpUnitconvertdetailList = await _iCaseErpUnitconvertdetailBLL.GetList(new CaseErpUnitconvertdetailEntity { F_UnitConvertId = res.CaseErpUnitconvertEntity.F_Id });
            }
                caseErpUnitconvertService.BeginTrans();
                try
                {
                    await Delete(keyValue);
                if(res.CaseErpUnitconvertEntity != null)
                {
                    await _iCaseErpUnitconvertdetailBLL.DeleteRelateEntity(res.CaseErpUnitconvertEntity.F_Id);
                }
                    caseErpUnitconvertService.Commit();
                }
                catch (Exception)
                {
                    caseErpUnitconvertService.Rollback();
                    throw;
                }
            }
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 获取单位列表配置信息
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<UnitconvertDto>> GetConfig(CaseErpUnitconvertEntity queryParams)
        {
            List<UnitconvertDto> list = new List<UnitconvertDto>();
            var UnitConvertList = await GetList(queryParams);
            if (UnitConvertList!=null)
            {
                foreach (var item in UnitConvertList)
                {
                    var ConvertDetailList = await _iCaseErpUnitconvertdetailBLL.GetList(new CaseErpUnitconvertdetailEntity { F_UnitConvertId = item.F_Id });
                    UnitconvertDto unitconvertDto=new UnitconvertDto();
                    unitconvertDto.CaseErpUnitconvertEntity = item;
                    unitconvertDto.CaseErpUnitconvertdetailList = ConvertDetailList;
                    list.Add(unitconvertDto);
                }
            }
            return list;
        }
        #endregion
    }
}
