using erp.ibll;
using learun.iapplication;
using learun.util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erp.bll
{
    /// <summary>
    /// ERP
    /// Copyright (c) 2019-present 力软信息技术（苏州）有限公司
    /// 创建人：施赛一
    /// 日 期： 2021-06-08 10:32:13
    /// 描 述： lr_erp_purchaseorder数据库执行类
    /// </summary>
    public class PurchaseOrderService : ServiceBase
    {
        #region 获取数据
        /// <summary>
        /// 获取lr_erp_purchaseorder的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_purchase_orderEntity>> GetList(Erp_purchase_orderEntity queryParams)
        {
            var expression = LinqExtensions.True<Erp_purchase_orderEntity>();
            if(!string.IsNullOrEmpty(queryParams.F_Id))
            {
                expression = expression.And(t => t.F_Id.Contains(queryParams.F_Id));
            }
            if(queryParams.F_Amount != null)
            {
                expression = expression.And(t => t.F_Amount == queryParams.F_Amount);
            }
            if(!string.IsNullOrEmpty(queryParams.F_Appler))
            {
                expression = expression.And(t => t.F_Appler.Contains(queryParams.F_Appler));
            }
            if(queryParams.F_ApplyDate != null && queryParams.F_ApplyDate_end != null)
            {
                DateTime f_ApplyDate = (DateTime)queryParams.F_ApplyDate;
                DateTime f_ApplyDate_end = (DateTime)queryParams.F_ApplyDate_end;
                expression = expression.And(t => t.F_ApplyDate >= f_ApplyDate && t.F_ApplyDate <= f_ApplyDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_BarCode))
            {
                expression = expression.And(t => t.F_BarCode.Contains(queryParams.F_BarCode));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Code))
            {
                expression = expression.And(t => t.F_Code.Contains(queryParams.F_Code));
            }
            if(queryParams.F_Count != null)
            {
                expression = expression.And(t => t.F_Count == queryParams.F_Count);
            }
            if(queryParams.F_CreateDate != null && queryParams.F_CreateDate_end != null)
            {
                DateTime f_CreateDate = (DateTime)queryParams.F_CreateDate;
                DateTime f_CreateDate_end = (DateTime)queryParams.F_CreateDate_end;
                expression = expression.And(t => t.F_CreateDate >= f_CreateDate && t.F_CreateDate <= f_CreateDate_end);
            }
            if(queryParams.F_DeliveryDate != null && queryParams.F_DeliveryDate_end != null)
            {
                DateTime f_DeliveryDate = (DateTime)queryParams.F_DeliveryDate;
                DateTime f_DeliveryDate_end = (DateTime)queryParams.F_DeliveryDate_end;
                expression = expression.And(t => t.F_DeliveryDate >= f_DeliveryDate && t.F_DeliveryDate <= f_DeliveryDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_Department))
            {
                expression = expression.And(t => t.F_Department.Contains(queryParams.F_Department));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Description))
            {
                expression = expression.And(t => t.F_Description.Contains(queryParams.F_Description));
            }
            if(!string.IsNullOrEmpty(queryParams.F_File))
            {
                expression = expression.And(t => t.F_File.Contains(queryParams.F_File));
            }
            if(queryParams.F_ModifyDate != null && queryParams.F_ModifyDate_end != null)
            {
                DateTime f_ModifyDate = (DateTime)queryParams.F_ModifyDate;
                DateTime f_ModifyDate_end = (DateTime)queryParams.F_ModifyDate_end;
                expression = expression.And(t => t.F_ModifyDate >= f_ModifyDate && t.F_ModifyDate <= f_ModifyDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_ModifyUserName))
            {
                expression = expression.And(t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Name))
            {
                expression = expression.And(t => t.F_Name.Contains(queryParams.F_Name));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Number))
            {
                expression = expression.And(t => t.F_Number.Contains(queryParams.F_Number));
            }
            if(!string.IsNullOrEmpty(queryParams.F_PaymentType))
            {
                expression = expression.And(t => t.F_PaymentType.Contains(queryParams.F_PaymentType));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Place))
            {
                expression = expression.And(t => t.F_Place.Contains(queryParams.F_Place));
            }
            if(queryParams.F_Price != null)
            {
                expression = expression.And(t => t.F_Price == queryParams.F_Price);
            }
            if(!string.IsNullOrEmpty(queryParams.F_PRId))
            {
                expression = expression.And(t => t.F_PRId.Contains(queryParams.F_PRId));
            }
            if(!string.IsNullOrEmpty(queryParams.F_PurchaseNo))
            {
                expression = expression.And(t => t.F_PurchaseNo.Contains(queryParams.F_PurchaseNo));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Purchaser))
            {
                expression = expression.And(t => t.F_Purchaser.Contains(queryParams.F_Purchaser));
            }
            if(!string.IsNullOrEmpty(queryParams.F_PurchaseType))
            {
                expression = expression.And(t => t.F_PurchaseType.Contains(queryParams.F_PurchaseType));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Specification))
            {
                expression = expression.And(t => t.F_Specification.Contains(queryParams.F_Specification));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Status))
            {
                expression = expression.And(t => t.F_Status.Contains(queryParams.F_Status));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Theme))
            {
                expression = expression.And(t => t.F_Theme.Contains(queryParams.F_Theme));
            }
            if(queryParams.F_Total != null)
            {
                expression = expression.And(t => t.F_Total == queryParams.F_Total);
            }
            if(!string.IsNullOrEmpty(queryParams.F_Type))
            {
                expression = expression.And(t => t.F_Type.Contains(queryParams.F_Type));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Unit))
            {
                expression = expression.And(t => t.F_Unit.Contains(queryParams.F_Unit));
            }
            if(!string.IsNullOrEmpty(queryParams.F_We))
            {
                expression = expression.And(t => t.F_We.Contains(queryParams.F_We));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Your))
            {
                expression = expression.And(t => t.F_Your.Contains(queryParams.F_Your));
            }

            return this.BaseRepository().FindList<Erp_purchase_orderEntity>(expression);
        }

        /// <summary>
        /// 获取lr_erp_purchaseorder的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_purchase_orderEntity>> GetPageList(Pagination pagination, Erp_purchase_orderEntity queryParams)
        {
            var expression = LinqExtensions.True<Erp_purchase_orderEntity>();
            if(!string.IsNullOrEmpty(queryParams.F_Id))
            {
                expression = expression.And(t => t.F_Id.Contains(queryParams.F_Id));
            }
            if(queryParams.F_Amount != null)
            {
                expression = expression.And(t => t.F_Amount == queryParams.F_Amount);
            }
            if(!string.IsNullOrEmpty(queryParams.F_Appler))
            {
                expression = expression.And(t => t.F_Appler.Contains(queryParams.F_Appler));
            }
            if(queryParams.F_ApplyDate != null && queryParams.F_ApplyDate_end != null)
            {
                DateTime f_ApplyDate = (DateTime)queryParams.F_ApplyDate;
                DateTime f_ApplyDate_end = (DateTime)queryParams.F_ApplyDate_end;
                expression = expression.And(t => t.F_ApplyDate >= f_ApplyDate && t.F_ApplyDate <= f_ApplyDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_BarCode))
            {
                expression = expression.And(t => t.F_BarCode.Contains(queryParams.F_BarCode));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Code))
            {
                expression = expression.And(t => t.F_Code.Contains(queryParams.F_Code));
            }
            if(queryParams.F_Count != null)
            {
                expression = expression.And(t => t.F_Count == queryParams.F_Count);
            }
            if(queryParams.F_CreateDate != null && queryParams.F_CreateDate_end != null)
            {
                DateTime f_CreateDate = (DateTime)queryParams.F_CreateDate;
                DateTime f_CreateDate_end = (DateTime)queryParams.F_CreateDate_end;

                expression = expression.And(t => t.F_CreateDate >= f_CreateDate && t.F_CreateDate <= f_CreateDate_end);
            }
            if(queryParams.F_DeliveryDate != null && queryParams.F_DeliveryDate_end != null)
            {
                DateTime f_DeliveryDate = (DateTime)queryParams.F_DeliveryDate;
                DateTime f_DeliveryDate_end = (DateTime)queryParams.F_DeliveryDate_end;
                expression = expression.And(t => t.F_DeliveryDate >= f_DeliveryDate && t.F_DeliveryDate <= f_DeliveryDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_Department))
            {
                expression = expression.And(t => t.F_Department.Contains(queryParams.F_Department));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Description))
            {
                expression = expression.And(t => t.F_Description.Contains(queryParams.F_Description));
            }
            if(!string.IsNullOrEmpty(queryParams.F_File))
            {
                expression = expression.And(t => t.F_File.Contains(queryParams.F_File));
            }
            if(queryParams.F_ModifyDate != null && queryParams.F_ModifyDate_end != null)
            {
                DateTime f_ModifyDate = (DateTime)queryParams.F_ModifyDate;
                DateTime f_ModifyDate_end = (DateTime)queryParams.F_ModifyDate_end;
                expression = expression.And(t => t.F_ModifyDate >= f_ModifyDate && t.F_ModifyDate <= f_ModifyDate_end);
            }
            if(!string.IsNullOrEmpty(queryParams.F_ModifyUserName))
            {
                expression = expression.And(t => t.F_ModifyUserName.Contains(queryParams.F_ModifyUserName));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Name))
            {
                expression = expression.And(t => t.F_Name.Contains(queryParams.F_Name));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Number))
            {
                expression = expression.And(t => t.F_Number.Contains(queryParams.F_Number));
            }
            if(!string.IsNullOrEmpty(queryParams.F_PaymentType))
            {
                expression = expression.And(t => t.F_PaymentType.Contains(queryParams.F_PaymentType));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Place))
            {
                expression = expression.And(t => t.F_Place.Contains(queryParams.F_Place));
            }
            if(queryParams.F_Price != null)
            {
                expression = expression.And(t => t.F_Price == queryParams.F_Price);
            }
            if(!string.IsNullOrEmpty(queryParams.F_PRId))
            {
                expression = expression.And(t => t.F_PRId.Contains(queryParams.F_PRId));
            }
            if(!string.IsNullOrEmpty(queryParams.F_PurchaseNo))
            {
                expression = expression.And(t => t.F_PurchaseNo.Contains(queryParams.F_PurchaseNo));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Purchaser))
            {
                expression = expression.And(t => t.F_Purchaser.Contains(queryParams.F_Purchaser));
            }
            if(!string.IsNullOrEmpty(queryParams.F_PurchaseType))
            {
                expression = expression.And(t => t.F_PurchaseType.Contains(queryParams.F_PurchaseType));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Specification))
            {
                expression = expression.And(t => t.F_Specification.Contains(queryParams.F_Specification));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Status))
            {
                expression = expression.And(t => t.F_Status.Contains(queryParams.F_Status));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Theme))
            {
                expression = expression.And(t => t.F_Theme.Contains(queryParams.F_Theme));
            }
            if(queryParams.F_Total != null)
            {
                expression = expression.And(t => t.F_Total == queryParams.F_Total);
            }
            if(!string.IsNullOrEmpty(queryParams.F_Type))
            {
                expression = expression.And(t => t.F_Type.Contains(queryParams.F_Type));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Unit))
            {
                expression = expression.And(t => t.F_Unit.Contains(queryParams.F_Unit));
            }
            if(!string.IsNullOrEmpty(queryParams.F_We))
            {
                expression = expression.And(t => t.F_We.Contains(queryParams.F_We));
            }
            if(!string.IsNullOrEmpty(queryParams.F_Your))
            {
                expression = expression.And(t => t.F_Your.Contains(queryParams.F_Your));
            }

            return this.BaseRepository().FindList<Erp_purchase_orderEntity>(expression,pagination);
        }
        
        /// <summary>
        /// 获取主表lr_erp_purchaseorder的实体
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <returns></returns>
        public Task<Erp_purchase_orderEntity> GetEntity(String f_Id)
        {
            return this.BaseRepository().FindEntityByKey<Erp_purchase_orderEntity>(f_Id);
        }
        /// <summary>
        /// 获取表lr_erp_purchaseorderdetail的列表
        /// </summary>
        /// <param name="f_POID">表lr_erp_purchaseorder关联字段F_Id</param>
        /// <returns></returns>
        public Task<IEnumerable<Erp_purchase_order_detailEntity>> GetLr_erp_purchaseorderdetailList(String f_POID)
        {
            return this.BaseRepository().FindList<Erp_purchase_order_detailEntity>(t => t.F_POID == f_POID);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        public async Task Delete(String f_Id)
        {
            var lr_erp_purchaseorderEntity = await this.BaseRepository().FindEntityByKey<Erp_purchase_orderEntity>(f_Id);
            var db = this.BaseRepository().BeginTrans();
            try
            {
                await db.Delete<Erp_purchase_orderEntity>(f_Id);
                await db.Delete<Erp_purchase_order_detailEntity>(t=>t.F_POID == lr_erp_purchaseorderEntity.F_Id);
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 删除采购订单详细lr_erp_purchaseorderdetail表数据
        /// </summary>
        /// <param name="f_POID">表lr_erp_purchaseorder关联字段F_Id</param>
        public async Task DeleteLr_erp_purchaseorderdetail(String f_POID)
        {
            await this.BaseRepository().Delete<Erp_purchase_order_detailEntity>(t=>t.F_POID == f_POID);
        }


        /// <summary>
        /// 保存(新增,更新)
        /// </summary>
        /// <param name="f_Id">唯一标识【GUID】</param>
        /// <param name="lr_erp_purchaseorderEntity">采购订单lr_erp_purchaseorder实体数据</param>
        /// <param name="lr_erp_purchaseorderdetailList">采购订单详细lr_erp_purchaseorderdetail实体数据列表</param>
        public async Task SaveEntity(String f_Id,Erp_purchase_orderEntity lr_erp_purchaseorderEntity,IEnumerable<Erp_purchase_order_detailEntity> lr_erp_purchaseorderdetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if(!string.IsNullOrEmpty(f_Id)) // 更新
                {
                    lr_erp_purchaseorderEntity.F_Id = f_Id;
                    await db.Update(lr_erp_purchaseorderEntity);
                }
                else // 新增
                {
                    if(string.IsNullOrEmpty(lr_erp_purchaseorderEntity.F_Id))
                    {
                        lr_erp_purchaseorderEntity.F_Id = Guid.NewGuid().ToString();
                    }
                    await db.Insert(lr_erp_purchaseorderEntity);
                }
                foreach(var item in lr_erp_purchaseorderdetailList)
                {
                    item.F_POID = lr_erp_purchaseorderEntity.F_Id;
                    if(!string.IsNullOrEmpty(item.F_Id))
                    { // 更新
                        await db.Update(item);
                    }
                    else // 新增
                    {
                        item.F_Id = Guid.NewGuid().ToString();
                        await db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存采购订单详细lr_erp_purchaseorderdetail表数据
        /// </summary>
        /// <param name="f_Id">主键</param>
        /// <param name="lr_erp_purchaseorderdetailEntity">lr_erp_purchaseorderdetail实体数据</param>
        public async Task SaveLr_erp_purchaseorderdetail(String f_Id,Erp_purchase_order_detailEntity lr_erp_purchaseorderdetailEntity)
        {
            if(!string.IsNullOrEmpty(f_Id))
            { // 更新
                lr_erp_purchaseorderdetailEntity.F_Id = f_Id;
                await this.BaseRepository().Update(lr_erp_purchaseorderdetailEntity);
            }
            else // 新增
            {
                lr_erp_purchaseorderdetailEntity.F_Id = Guid.NewGuid().ToString();
                await this.BaseRepository().Insert(lr_erp_purchaseorderdetailEntity);
            }
        }


        #endregion
    }
}
