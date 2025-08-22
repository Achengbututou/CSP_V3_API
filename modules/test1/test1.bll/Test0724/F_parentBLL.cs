using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test1.ibll;
namespace Test1.bll {
    /// <summary>
    /// 力软开发框架-Test1
    /// 力软信息技术
    /// 创建人：
    /// 日 期： 2024-07-24 16:39:53
    /// 描 述： 测试代码生成
    /// </summary>
    public class F_parentBLL: BLLBase, IF_parentBLL, BLL {
        private readonly F_parentService f_parentService = new F_parentService();
        private readonly IF_childrenBLL _iF_childrenBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iF_childrenBLL">接口</param>
        public F_parentBLL(IF_childrenBLL iF_childrenBLL) {
            _iF_childrenBLL = iF_childrenBLL ??
                throw new ArgumentNullException(nameof(iF_childrenBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取测试代码生成的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<F_parentEntity>>GetList(F_parentEntity queryParams) {
            return f_parentService.GetList(queryParams);
        }
        /// <summary>
        /// 获取测试代码生成的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<F_parentEntity>>GetPageList(Pagination pagination, F_parentEntity queryParams) {
            return f_parentService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<F_parentEntity>GetEntity(string keyValue) {
            return f_parentService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await f_parentService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new Test0724Dto();
            res.F_parentEntity = await GetEntity(keyValue);
            f_parentService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.F_parentEntity != null) {
                    await _iF_childrenBLL.DeleteRelateEntity(res.F_parentEntity.F_Id);
                }
                f_parentService.Commit();
            } catch (Exception) {
                f_parentService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await f_parentService.Deletes(keyValues);
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
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, F_parentEntity entity) {
            await f_parentService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, Test0724Dto dto) {
            f_parentService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.F_parentEntity);
                await _iF_childrenBLL.SaveList(dto.F_parentEntity.F_Id, dto.F_childrenList);
                f_parentService.Commit();
            } catch (Exception) {
                f_parentService.Rollback();
                throw;
            }
        }
        #endregion
    }
}