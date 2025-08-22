using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;
using demo.ibll;

namespace demo.bll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2022-06-13 10:53:49
    /// 描 述： 配车单数据库执行类
    /// </summary>
    public class EwCurmService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<EwCurmEntity, bool>> GetExpression(EwCurmEntity queryParams) {
            var expression = LinqExtensions.True<EwCurmEntity>();
            if(!string.IsNullOrEmpty(queryParams.F_matecardetailId))
            {
                expression = expression.And(t => t.F_matecardetailId == queryParams.F_matecardetailId);
            }
            if(!string.IsNullOrEmpty(queryParams.F_cpbh))
            {
                expression = expression.And(t => t.F_cpbh.Contains(queryParams.F_cpbh));
            }
            if(!string.IsNullOrEmpty(queryParams.F_kwbh))
            {
                expression = expression.And(t => t.F_kwbh.Contains(queryParams.F_kwbh));
            }
            if(queryParams.F_kcs != null)
            {
                expression = expression.And(t => t.F_kcs == queryParams.F_kcs);
            }
            if(queryParams.F_chs != null)
            {
                expression = expression.And(t => t.F_chs == queryParams.F_chs);
            }
            if(queryParams.F_DeleteMark != null)
            {
                expression = expression.And(t => t.F_DeleteMark == queryParams.F_DeleteMark);
            }
            if(!string.IsNullOrEmpty(queryParams.F_CreateDateQRange))
            {
                var f_CreateDate_list = queryParams.F_CreateDateQRange.Split(',');
                DateTime f_CreateDate = Convert.ToDateTime(f_CreateDate_list[0]);
                DateTime f_CreateDate_end = Convert.ToDateTime(f_CreateDate_list[1]);
                expression = expression.And(t => t.F_CreateDate >= f_CreateDate &&t.F_CreateDate <= f_CreateDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_CreateUserId))
            {
                expression = expression.And(t => t.F_CreateUserId.Contains(queryParams.F_CreateUserId));
            }
            if(!string.IsNullOrEmpty(queryParams.F_CreateUserName))
            {
                expression = expression.And(t => t.F_CreateUserName.Contains(queryParams.F_CreateUserName));
            }
            if(!string.IsNullOrEmpty(queryParams.F_ModifyDateQRange))
            {
                var f_ModifyDate_list = queryParams.F_ModifyDateQRange.Split(',');
                DateTime f_ModifyDate = Convert.ToDateTime(f_ModifyDate_list[0]);
                DateTime f_ModifyDate_end = Convert.ToDateTime(f_ModifyDate_list[1]);
                expression = expression.And(t => t.F_ModifyDate >= f_ModifyDate &&t.F_ModifyDate <= f_ModifyDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_ModifyUserId))
            {
                expression = expression.And(t => t.F_ModifyUserId.Contains(queryParams.F_ModifyUserId));
            }
            if(!string.IsNullOrEmpty(queryParams.F_ModifyUserName))
            {
                expression = expression.And(t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            }

            return expression;
        }

        /// <summary>
        /// 获取配车单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwCurmEntity>> GetList(EwCurmEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<EwCurmEntity>(expression);
        }

        /// <summary>
        /// 获取配车单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwCurmEntity>> GetPageList(Pagination pagination, EwCurmEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<EwCurmEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EwCurmEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<EwCurmEntity>(keyValue);
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
            await this.BaseRepository().Delete<EwCurmEntity>(keyValue);
        }

        /// <summary>
        /// 删除配车单的数据根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public async Task DeleteRelate(string key) {
            await this.BaseRepository().Delete<EwCurmEntity>(t=>t.F_matecardetailId == key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EwCurmEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_Id = Guid.NewGuid().ToString();
                }


                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_Id = keyValue;


                await this.BaseRepository().Update(entity);
            }
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<EwCurmEntity> list) {
            var addList = new List<EwCurmEntity>();
            var db = this.BaseRepository().BeginTrans();
            try{
                await db.Delete<EwCurmEntity>(t => t.F_matecardetailId == key);
                foreach (var item in list)
                {
                    if(string.IsNullOrEmpty(item.F_Id))
                    {
                        item.F_Id = Guid.NewGuid().ToString();
                    }
                    item.F_matecardetailId = key;
                    addList.Add(item);
                }
                if (addList.Count > 0)
                {
                    await db.Inserts(addList);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        #endregion
    }
}
