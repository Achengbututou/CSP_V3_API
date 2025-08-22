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
    /// 日 期： 2022-06-13 10:55:59
    /// 描 述： 配车单数据库执行类
    /// </summary>
    public class EwMatecarbasicService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<EwMatecarbasicEntity, bool>> GetExpression(EwMatecarbasicEntity queryParams) {
            var expression = LinqExtensions.True<EwMatecarbasicEntity>();
            if(!string.IsNullOrEmpty(queryParams.F_pcdh))
            {
                expression = expression.And(t => t.F_pcdh.Contains(queryParams.F_pcdh));
            }
            if(!string.IsNullOrEmpty(queryParams.F_djrqQRange))
            {
                var f_djrq_list = queryParams.F_djrqQRange.Split(',');
                DateTime f_djrq = Convert.ToDateTime(f_djrq_list[0]);
                DateTime f_djrq_end = Convert.ToDateTime(f_djrq_list[1]);
                expression = expression.And(t => t.F_djrq >= f_djrq &&t.F_djrq <= f_djrq_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_yscl))
            {
                expression = expression.And(t => t.F_yscl.Contains(queryParams.F_yscl));
            }
            if(!string.IsNullOrEmpty(queryParams.F_jsybh))
            {
                expression = expression.And(t => t.F_jsybh.Contains(queryParams.F_jsybh));
            }
            if(!string.IsNullOrEmpty(queryParams.F_zdr))
            {
                expression = expression.And(t => t.F_zdr.Contains(queryParams.F_zdr));
            }
            if(!string.IsNullOrEmpty(queryParams.F_zdsjQRange))
            {
                var f_zdsj_list = queryParams.F_zdsjQRange.Split(',');
                DateTime f_zdsj = Convert.ToDateTime(f_zdsj_list[0]);
                DateTime f_zdsj_end = Convert.ToDateTime(f_zdsj_list[1]);
                expression = expression.And(t => t.F_zdsj >= f_zdsj &&t.F_zdsj <= f_zdsj_end);
            }
            if(queryParams.F_bz != null)
            {
                expression = expression.And(t => t.F_bz == queryParams.F_bz);
            }
            if(queryParams.F_kh != null)
            {
                expression = expression.And(t => t.F_kh == queryParams.F_kh);
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
        public Task<IEnumerable<EwMatecarbasicEntity>> GetList(EwMatecarbasicEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<EwMatecarbasicEntity>(expression);
        }

        /// <summary>
        /// 获取配车单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecarbasicEntity>> GetPageList(Pagination pagination, EwMatecarbasicEntity queryParams)
        {
            var expression = GetExpression(queryParams);
            return this.BaseRepository().FindList<EwMatecarbasicEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EwMatecarbasicEntity> GetEntity(string keyValue) {
            return this.BaseRepository().FindEntityByKey<EwMatecarbasicEntity>(keyValue);
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
            await this.BaseRepository().Delete<EwMatecarbasicEntity>(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EwMatecarbasicEntity entity)
        {
            if ( string.IsNullOrEmpty(keyValue) )
            {
                if(string.IsNullOrEmpty(entity.F_Id))
                {
                    entity.F_CreateDate = DateTime.Now;
                    entity.F_CreateUserId = this.GetUserId();
                    entity.F_CreateUserName = this.GetUserName();
                    entity.F_Id = Guid.NewGuid().ToString();
                }


                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_ModifyDate = DateTime.Now;
                entity.F_ModifyUserId = this.GetUserId();
                entity.F_ModifyUserName = this.GetUserName();
                entity.F_Id = keyValue;


                await this.BaseRepository().Update(entity);
            }
        }

        
        #endregion
    }
}
