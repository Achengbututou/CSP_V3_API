using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mes.ibll;
namespace mes.bll {
    /// <summary>
    /// MES-MES系统
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2023-08-08 14:33:08
    /// 描 述： 班组管理
    /// </summary>
    public class MesTeamManagementBLL: BLLBase, IMesTeamManagementBLL, BLL {
        private readonly MesTeamManagementService mesTeamManagementService = new MesTeamManagementService();
        private readonly IMesTeamMembersBLL _iMesTeamMembersBLL;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iMesTeamMembersBLL">班组人员接口</param>
        public MesTeamManagementBLL(IMesTeamMembersBLL iMesTeamMembersBLL) {
            _iMesTeamMembersBLL = iMesTeamMembersBLL ??
                throw new ArgumentNullException(nameof(iMesTeamMembersBLL));
        }
        #region 获取数据
        /// <summary>
        /// 获取班组管理的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamManagementEntity>>GetList(MesTeamManagementEntity queryParams) {
            return mesTeamManagementService.GetList(queryParams);
        }
        /// <summary>
        /// 获取班组管理的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<MesTeamManagementEntity>>GetPageList(Pagination pagination, MesTeamManagementEntity queryParams) {
            return mesTeamManagementService.GetPageList(pagination, queryParams);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<MesTeamManagementEntity>GetEntity(string keyValue) {
            return mesTeamManagementService.GetEntity(keyValue);
        }
        #endregion
        #region 提交数据
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task Delete(string keyValue) {
            await mesTeamManagementService.Delete(keyValue);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue) {
            var res = new TeamManagementDto();
            res.MesTeamManagementEntity = await GetEntity(keyValue);
            mesTeamManagementService.BeginTrans();
            try {
                await Delete(keyValue);
                if (res.MesTeamManagementEntity != null) {
                    await _iMesTeamMembersBLL.DeleteRelateEntity(res.MesTeamManagementEntity.F_Id);
                }
                mesTeamManagementService.Commit();
            } catch (Exception) {
                mesTeamManagementService.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues) {
            await mesTeamManagementService.Deletes(keyValues);
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
        public async Task SaveEntity(string keyValue, MesTeamManagementEntity entity) {
            entity.F_TeamManagementNumber = (await GetRuleCodeEx(entity.F_TeamManagementNumber)).ToString();
            await mesTeamManagementService.SaveEntity(keyValue, entity);
        }
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, TeamManagementDto dto) {
            mesTeamManagementService.BeginTrans();
            try {
                await SaveEntity(keyValue, dto.MesTeamManagementEntity);
                await _iMesTeamMembersBLL.SaveList(dto.MesTeamManagementEntity.F_Id, dto.MesTeamMembersList);
                mesTeamManagementService.Commit();
            } catch (Exception) {
                mesTeamManagementService.Rollback();
                throw;
            }
        }
        #endregion
    }
}