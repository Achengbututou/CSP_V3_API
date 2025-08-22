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
    /// 日 期： 2022-06-13 10:55:59
    /// 描 述： 配车单
    /// </summary>
    public class EwMatecardetailBLL : BLLBase, IEwMatecardetailBLL,BLL
    {
        private readonly EwMatecardetailService ewMatecardetailService = new EwMatecardetailService();

        

        #region 获取数据
        /// <summary>
        /// 获取配车单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecardetailEntity>> GetList(EwMatecardetailEntity queryParams)
        {
            return ewMatecardetailService.GetList(queryParams);
        }

        /// <summary>
        /// 获取配车单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecardetailEntity>> GetPageList(Pagination pagination, EwMatecardetailEntity queryParams)
        {
            return ewMatecardetailService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EwMatecardetailEntity> GetEntity(string keyValue)
        {
            return ewMatecardetailService.GetEntity(keyValue);
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
            await ewMatecardetailService.Delete(keyValue);
        }

        /// <summary>
        /// 删除@Des的实体根据外键
        /// <summary>
        /// <param name="key">关联键</param>
        /// <returns></returns>
        public Task DeleteRelateEntity(string key) {
            return ewMatecardetailService.Delete(key);
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EwMatecardetailEntity entity)
        {
            

            await ewMatecardetailService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存子表数据
        /// <summary>
        /// <param name="key">外键值</param>
        /// <param name="list">数据集合</param>
        /// <returns></returns>
        public async Task SaveList(string key, IEnumerable<EwMatecardetailEntity> list) {
            await ewMatecardetailService.SaveList(key,list);
        }


        #endregion

    }
}
