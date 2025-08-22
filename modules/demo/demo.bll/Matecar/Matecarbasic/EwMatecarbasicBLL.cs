using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demo.ibll;
using learun.database;

namespace demo.bll
{
    /// <summary>
    /// 案例汇总-应用案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：超级管理员
    /// 日 期： 2022-06-13 10:55:59
    /// 描 述： 配车单
    /// </summary>
    public class EwMatecarbasicBLL : BLLBase, IEwMatecarbasicBLL,BLL
    {
        private readonly RepositoryFactory repositoryFactory = new RepositoryFactory();
        private readonly EwMatecarbasicService ewMatecarbasicService = new EwMatecarbasicService();
        private readonly IEwMatecardetailBLL _iEwMatecardetailBLL;
        /// <summary>
        /// 构造方法
        /// <summary>
        /// <param name="iEwMatecardetailBLL">【苏州益维鑫】配车单子表接口</param>
        public EwMatecarbasicBLL(IEwMatecardetailBLL iEwMatecardetailBLL)
        {
            _iEwMatecardetailBLL = iEwMatecardetailBLL?? throw new ArgumentNullException(nameof(iEwMatecardetailBLL));
        }


        #region 获取数据
        /// <summary>
        /// 获取配车单的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecarbasicEntity>> GetList(EwMatecarbasicEntity queryParams)
        {
            return ewMatecarbasicService.GetList(queryParams);
        }

        /// <summary>
        /// 获取配车单的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<EwMatecarbasicEntity>> GetPageList(Pagination pagination, EwMatecarbasicEntity queryParams)
        {
            return ewMatecarbasicService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<EwMatecarbasicEntity> GetEntity(string keyValue)
        {
            return ewMatecarbasicService.GetEntity(keyValue);
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
            await ewMatecarbasicService.Delete(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task DeleteAll(string keyValue)
        {
            var res = new MatecarbasicDto();
            res.EwMatecarbasicEntity = await GetEntity(keyValue);
            if(res.EwMatecarbasicEntity != null)
            {
                res.EwMatecardetailList = await _iEwMatecardetailBLL.GetList(new EwMatecardetailEntity { F_matecarbasicId = res.EwMatecarbasicEntity.F_Id });
            }
            ewMatecarbasicService.BeginTrans();
            try
            {
                await Delete(keyValue);
                if(res.EwMatecarbasicEntity != null)
                {
                    await _iEwMatecardetailBLL.DeleteRelateEntity(res.EwMatecarbasicEntity.F_Id);
                }
                ewMatecarbasicService.Commit();
            }
            catch (Exception)
            {
                ewMatecarbasicService.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, EwMatecarbasicEntity entity)
        {
            entity.F_pcdh = (await GetRuleCodeEx(entity.F_pcdh)).ToString(); 

            await ewMatecarbasicService.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="dto">数据集合</param>
        /// <returns></returns>
        public async Task SaveAll(string keyValue, MatecarbasicDto dto)
        {
            ewMatecarbasicService.BeginTrans();
            try
            {
                if(string.IsNullOrEmpty(dto.EwMatecarbasicEntity.F_Id))
                {
                    dto.EwMatecarbasicEntity.F_Id = Guid.NewGuid().ToString();
                }
                await SaveEntity(keyValue,dto.EwMatecarbasicEntity);
                foreach (var item in dto.EwMatecardetailList)
                {
                    item.F_ddbh = (await GetRuleCodeEx(item.F_ddbh)).ToString();
                }
                await _iEwMatecardetailBLL.SaveList(dto.EwMatecarbasicEntity.F_Id,dto.EwMatecardetailList);
                ewMatecarbasicService.Commit();
            }
            catch (Exception)
            {
                ewMatecarbasicService.Rollback();
                throw;
            }
        }


        #endregion

        #region 扩展方法
        /// <summary>
        /// 生成送货单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public async Task CreateDelivery(string keyValue)
        {
            //主表数据
            var BasicEntity = await repositoryFactory.BaseRepository().FindEntityByKey<EwMatecarbasicEntity>(keyValue);
            if (BasicEntity != null)
            {
                //子表数据
                var DetailList= await repositoryFactory.BaseRepository().FindList<EwMatecardetailEntity>(it=>it.F_matecarbasicId== BasicEntity.F_Id);
                if (DetailList!=null)
                {
                    foreach (var item in DetailList)
                    {
                        //删除Curm
                        await repositoryFactory.BaseRepository().Delete<EwCurmEntity>(it => it.F_matecardetailId == item.F_Id);
                        //从库存表中寻找对对应的产品
                        var KcList = await repositoryFactory.BaseRepository().FindList<EwKcEntity>(it => it.F_cpbh == item.F_cpbh, "F_kwbh ASC");
                        if (KcList!=null)
                        {
                            var bcfhsl = item.F_bcfhsl ?? 0;
                            //循环计算出货数
                            foreach (var kc_item in KcList)
                            {
                                EwCurmEntity ewCurmEntity=new EwCurmEntity();
                                ewCurmEntity.F_kcs = kc_item.F_kcs;
                                if (kc_item.F_kcs > 0)
                                {
                                    if (kc_item.F_kcs <= bcfhsl)//如果库存数小于等于本次发货数量，则该库位库存全部发出
                                    {
                                        kc_item.F_kcs= 0;//库存数减去发货数
                                        await repositoryFactory.BaseRepository().Update<EwKcEntity>(kc_item);

                                        ewCurmEntity.F_chs = ewCurmEntity.F_kcs;
                                        bcfhsl = bcfhsl - (ewCurmEntity.F_chs ?? 0);
                                    }
                                    else//如果库存数大于本次发货数量，则所有的出货数，都在这个库位
                                    {
                                        kc_item.F_kcs = (kc_item.F_kcs ?? 0) - bcfhsl;//库存数减去发货数
                                        await repositoryFactory.BaseRepository().Update<EwKcEntity>(kc_item);

                                        ewCurmEntity.F_chs = bcfhsl;
                                        bcfhsl = bcfhsl - (ewCurmEntity.F_chs ?? 0);
                                    }
                                    ewCurmEntity.F_Id = Guid.NewGuid().ToString() ;
                                    ewCurmEntity.F_matecardetailId = item.F_Id;
                                    ewCurmEntity.F_cpbh = kc_item.F_cpbh;
                                    ewCurmEntity.F_kwbh = kc_item.F_kwbh;
                                    
                                    await repositoryFactory.BaseRepository().Insert<EwCurmEntity>(ewCurmEntity);
                                }
                            }
                        }
                    }
                }
            }

        }
        #endregion
    }
}
