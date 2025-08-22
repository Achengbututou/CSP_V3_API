using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demo.ibll;

namespace demo.bll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2022-06-13 10:53:49
    /// 描 述： 配车单
    /// </summary>
    public class EwMatecardetailCurmBLL : BLLBase, IEwMatecardetailCurmBLL, BLL
    {
        private readonly EwMatecardetailCurmService ewMatecardetailCurmService = new EwMatecardetailCurmService();

        private readonly IEwCurmBLL _iEwCurmBLL;
        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iEwCurmBLL">【苏州益维鑫】现存量表接口</param>
        public EwMatecardetailCurmBLL(IEwCurmBLL iEwCurmBLL)
        {
            _iEwCurmBLL = iEwCurmBLL?? throw new ArgumentNullException(nameof(iEwCurmBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取配车单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecardetailEntity>> GetList(EwMatecardetailEntity queryParams)
        {
            return ewMatecardetailCurmService.GetList(queryParams);
        }

        /// <summary>
        /// 获取配车单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecardetailEntity>> GetPageList(Pagination pagination, EwMatecardetailEntity queryParams)
        {
            return ewMatecardetailCurmService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EwMatecardetailEntity> GetEntity(string keyValue)
        {
            return ewMatecardetailCurmService.GetEntity(keyValue);
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
            await ewMatecardetailCurmService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new MatecardetailDto();
            res.EwMatecardetailEntity = await GetEntity(keyValue);
            if(res.EwMatecardetailEntity != null)
            {
                res.EwCurmList = await _iEwCurmBLL.GetList(new EwCurmEntity { F_matecardetailId = res.EwMatecardetailEntity.F_Id });
            }
            ewMatecardetailCurmService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if(res.EwMatecardetailEntity != null)
                {
                    await _iEwCurmBLL.DeleteRelateEntity(res.EwMatecardetailEntity.F_Id);
                }
                ewMatecardetailCurmService.Commit();
            }
            catch (Exception)
            {
                ewMatecardetailCurmService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EwMatecardetailEntity entity)
        {
            entity.F_ddbh = (await GetRuleCodeEx(entity.F_ddbh)).ToString(); 

            await ewMatecardetailCurmService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, MatecardetailDto dto)
        {
            ewMatecardetailCurmService.BeginTrans();
            try
            {
                if(string.IsNullOrEmpty(dto.EwMatecardetailEntity.F_Id))
                {
                    dto.EwMatecardetailEntity.F_Id = Guid.NewGuid().ToString();
                }
                await SaveEntity(keyValue,dto.EwMatecardetailEntity);
                await _iEwCurmBLL.SaveList(dto.EwMatecardetailEntity.F_Id,dto.EwCurmList);
                ewMatecardetailCurmService.Commit();
            }
            catch (Exception)
            {
                ewMatecardetailCurmService.Rollback();
                throw;
            }
        }


        #endregion
    }
}
