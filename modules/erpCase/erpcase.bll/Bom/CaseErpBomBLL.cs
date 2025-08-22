using System.Data;
using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using learun.oss;
using learun.office;
using System.Collections.ObjectModel;
using TencentCloud.Cme.V20191029.Models;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-ERP案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-12-05 17:17:21
    /// 描 述： BOM信息
    /// </summary>
    public class CaseErpBomBLL : BLLBase, ICaseErpBomBLL, BLL
    {
        private readonly CaseErpBomService caseErpBomService = new CaseErpBomService();

        private readonly IAnnexes _iAnnexes;
        private readonly DataSourceIBLL _dataSourceIBLL;
        private readonly ICaseErpMaterialBLL _erpMaterialBLL;
        private readonly ICaseErpUnitBLL _erpUnitBLL;
        private readonly ICaseErpMaterialclassesBLL _erpMaterialclassesBLL;
        private readonly ICaseErpMaterialpropertyBLL _erpMaterialpropertyBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iAnnexes"></param>
        /// <param name="dataSourceIBLL"></param>
        public CaseErpBomBLL(IAnnexes iAnnexes,
            DataSourceIBLL dataSourceIBLL,
            ICaseErpMaterialBLL erpMaterialBLL,
            ICaseErpUnitBLL erpUnitBLL,
            ICaseErpMaterialclassesBLL erpMaterialclassesBLL,
            ICaseErpMaterialpropertyBLL erpMaterialpropertyBLL)
        {
            _iAnnexes = iAnnexes;
            _dataSourceIBLL = dataSourceIBLL;
            _erpMaterialBLL = erpMaterialBLL ?? throw new ArgumentNullException(nameof(erpMaterialBLL));
            _erpUnitBLL = erpUnitBLL ?? throw new ArgumentNullException(nameof(erpUnitBLL));
            _erpMaterialclassesBLL = erpMaterialclassesBLL ?? throw new ArgumentNullException(nameof(erpMaterialclassesBLL));
            _erpMaterialpropertyBLL = erpMaterialpropertyBLL ?? throw new ArgumentNullException(nameof(erpMaterialpropertyBLL));
        }

        #region 获取数据
        /// <summary>
        /// 获取BOM信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpBomEntity>> GetList(CaseErpBomEntity queryParams)
        {
            return caseErpBomService.GetList(queryParams);
        }

        /// <summary>
        /// 获取BOM信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpBomEntity>> GetPageList(Pagination pagination, CaseErpBomEntity queryParams)
        {
            return caseErpBomService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpBomEntity> GetEntity(string keyValue)
        {
            return caseErpBomService.GetEntity(keyValue);
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
            await caseErpBomService.Delete(keyValue);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<bool> SaveEntity(string keyValue, CaseErpBomEntity entity)
        {

            caseErpBomService.BeginTrans();
            try
            {
                // 需要判断当前添加的物料子集里是否包含它的上级
                // 1.获取它的全部上级
                if (!string.IsNullOrWhiteSpace(entity.F_PId) && entity.F_PId != "0")
                {
                    var materialIdList = new List<string>();
                    materialIdList.Add(entity.F_PId);
                    List<CaseErpBomEntity> pList = await GetParentList(materialIdList);

                    if (pList.Count > 0 && pList.FindIndex(t => t.F_MaterialId == entity.F_MaterialId) > -1)
                    {
                        return false;
                    }

                    // 2.获取子集并比较
                    var pmaterialIdList = new List<string>();
                    pmaterialIdList.Add(entity.F_MaterialId);
                    if (pList.Count > 0 && await IsContainParent(pList, pmaterialIdList))
                    {
                        return false;
                    }
                }
                await caseErpBomService.SaveEntity(keyValue, entity);
                entity.ChlidNum = ((List<CaseErpBomEntity>)await caseErpBomService.BaseRepository().FindList<CaseErpBomEntity>(t => t.F_PId == entity.F_MaterialId)).Count;

                caseErpBomService.Commit();
            }
            catch (Exception)
            {
                caseErpBomService.Rollback();
            }


            return true;
        }

        private async Task<List<CaseErpBomEntity>> GetParentList(List<string> materialIdList)
        {
            var materialIdList2 = new List<string>();
            var list = (List<CaseErpBomEntity>)await caseErpBomService.GetList(materialIdList);
            foreach (var item in list)
            {
                if (item.F_PId != "0")
                {
                    materialIdList2.Add(item.F_PId);
                }
            }
            if (materialIdList2.Count > 0)
            {
                var res = await GetParentList(materialIdList2);
                list.AddRange(res);
            }

            return list;
        }

        private async Task<bool> IsContainParent(List<CaseErpBomEntity> parents, List<string> pmaterialIdList)
        {
            var list = (List<CaseErpBomEntity>)await caseErpBomService.GetChildList(pmaterialIdList);
            if (list.FindIndex(t => parents.FindIndex(t2 => t2.F_MaterialId == t.F_MaterialId) > -1) > -1)
            {
                return true;
            }
            else
            {
                var pmaterialIdList2 = new List<string>();
                foreach (var item in list)
                {
                    pmaterialIdList2.Add(item.F_MaterialId);
                }

                if (pmaterialIdList2.Count > 0)
                {
                    return await IsContainParent(parents, pmaterialIdList2);
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpBomService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 用户列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetExportExcel()
        {
            var id = Guid.NewGuid().ToString();
            List<ExcelSheet> sheets = new List<ExcelSheet>();
            Dictionary<string, bool> exportsDic = new Dictionary<string, bool>();
            await SetSheet("0", "BOM表", "", sheets, exportsDic);
            _iAnnexes.UploadFile(id, $"Excel/{id}.xls", ".xls", ExcelNewHelper.ExportMemoryStream(sheets, "BOM信息").ToArray(),0);
            return id;
        }

        /// <summary>
        /// 获取工作表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task SetSheet(string pid, string name, string number, List<ExcelSheet> sheets, Dictionary<string, bool> exportsDic)
        {
            var dt = await caseErpBomService.GetChildTable(pid);

            if (pid != "0" && dt.Rows.Count == 0)
            {
                return;
            }

            List<DataSourceCol> cols = new List<DataSourceCol>();
            cols.Add(new DataSourceCol()
            {
                Code = "ERP_Unit",
                Valuekey = "f_id",
                LabelKey = "f_name",
                Prop = "f_unit"
            });
            cols.Add(new DataSourceCol()
            {
                Code = "ERP_MaterialClasses",
                Valuekey = "f_id",
                LabelKey = "f_type",
                Prop = "f_type"
            });
            cols.Add(new DataSourceCol()
            {
                Code = "ERP_MaterialProp",
                Valuekey = "f_id",
                LabelKey = "f_type",
                Prop = "f_property"
            });
            dt = await _dataSourceIBLL.ConvertDataTable(dt, cols);


            ExcelSheet sheet = new ExcelSheet();
            sheets.Add(sheet);
            sheet.Name = name;
            sheet.Data = new List<ExcelArea>();
            int rowIndex = 0;

            // 添加上级物料信息
            if (pid != "0")
            {
                ExcelArea area = new ExcelArea();
                area.Type = 1;
                area.X = 0;
                area.Y = rowIndex;
                area.Row = new List<ExcelCell>();
                area.Row.Add(new ExcelCell()
                {
                    IsBold = true,
                    Text = "上级物料编号："
                });
                area.Row.Add(new ExcelCell()
                {
                    Text = number
                });
                area.Row.Add(new ExcelCell()
                {
                    IsBold = true,
                    Text = "上级物料名称："
                });
                area.Row.Add(new ExcelCell()
                {
                    Text = name
                });
                sheet.Data.Add(area);
                rowIndex++;
            }

            // 添加子集物料信息
            ExcelArea tableArea = new ExcelArea();
            tableArea.Type = 2;
            tableArea.Y = rowIndex;
            tableArea.X = 0;
            tableArea.Table = new ExcelTable();
            tableArea.Table.Data = dt;
            #region 添加表头
            tableArea.Table.Header = new List<ExcelCell>();
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "物料编号",
                Prop = "f_number"
            });
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "物料名称",
                Prop = "f_name"
            });
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "规格型号",
                Prop = "f_model"
            });
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "物料类别",
                Prop = "f_type"
            });
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "数量",
                Prop = "f_count"
            });
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "单位",
                Prop = "f_unit"
            });
            tableArea.Table.Header.Add(new ExcelCell()
            {
                IsBold = true,
                Text = "物料属性",
                Prop = "f_property"
            });
            sheet.Data.Add(tableArea);

            #endregion


            foreach (DataRow row in dt.Rows)
            {
                if (!exportsDic.ContainsKey(row["f_materialid"].ToString()))
                {
                    exportsDic.Add(row["f_materialid"].ToString(), true);
                    await SetSheet(row["f_materialid"].ToString(), row["f_name"].ToString(), row["f_number"].ToString(), sheets, exportsDic);
                }
            }

        }

        /// <summary>
        /// 数据导入处理
        /// </summary>
        /// <param name="sheets">excel数据</param>
        /// <returns></returns>
        public async Task<bool> BomImport(List<ExcelSheet> sheets)
        {
            caseErpBomService.BeginTrans();
            try
            {
                if (sheets != null)
                {
                    List<CaseErpBomEntity> erpBomEntities = new List<CaseErpBomEntity>();
                    foreach (var sheet in sheets)
                    {
                        var F_PId = string.Empty;
                        var superiormaterials = sheet.Data[0].Row;//上级物料信息
                        var materials = sheet.Data[1].Table.Data;//物料信息
                        //判断是否存在商机物料
                        if (!string.IsNullOrEmpty(superiormaterials[1].Text) && !string.IsNullOrEmpty(superiormaterials[3].Text))//存在商机物料
                        {
                            var superiormaterialentity = await _erpMaterialBLL.GetEntityByNumName(superiormaterials[1].Text);
                            if (superiormaterialentity != null)
                            {
                                F_PId = superiormaterialentity.F_Id;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else//不存在上级物料
                        {
                            F_PId = "0";
                        }
                        foreach (DataRow material in materials.Rows)
                        {
                            CaseErpBomEntity erpBomEntity = new CaseErpBomEntity();
                            erpBomEntity.F_Id = Guid.NewGuid().ToString();
                            erpBomEntity.F_PId = F_PId;
                            var materialentity = await _erpMaterialBLL.GetEntityByNumName(material["f_number"].ToString());
                            if (materialentity == null) //不存在物料则新增物料
                            {
                                CaseErpMaterialEntity AddMaterialEntity = new CaseErpMaterialEntity();
                                AddMaterialEntity.F_Number = material["f_number"].ToString();//物料编码
                                AddMaterialEntity.F_IsSysNum = 1;//是否系统编号(0是，1否)
                                AddMaterialEntity.F_Name = material["f_name"].ToString();//物料名称
                                AddMaterialEntity.F_Model = material["f_model"].ToString();//规格型号
                                AddMaterialEntity.F_Unit = await _erpUnitBLL.GetUnitId(material["f_unit"].ToString());//单位
                                AddMaterialEntity.F_Type = await _erpMaterialclassesBLL.GetMaterialClassesId(material["f_type"].ToString());//物料类别
                                AddMaterialEntity.F_Property = await _erpMaterialpropertyBLL.GetMaterialPropertyId(material["f_property"].ToString());//物料属性
                                AddMaterialEntity.F_State = 0;//物料状态(0已启用，1未启用)

                                await _erpMaterialBLL.SaveEntity(null, AddMaterialEntity);

                                if (!string.IsNullOrEmpty(AddMaterialEntity.F_Id))
                                {
                                    erpBomEntity.F_MaterialId = AddMaterialEntity.F_Id;//物料外键Id(case_erp_material)
                                    erpBomEntity.F_Number = AddMaterialEntity.F_Number;//物料编码
                                    erpBomEntity.F_Name = AddMaterialEntity.F_Name;//物料名称
                                    erpBomEntity.F_Model = AddMaterialEntity.F_Model;//规格型号
                                    erpBomEntity.F_Unit = AddMaterialEntity.F_Unit;//单位
                                    erpBomEntity.F_Type = AddMaterialEntity.F_Type;//物料类别
                                    erpBomEntity.F_Property = AddMaterialEntity.F_Property;//物料属性
                                    erpBomEntity.F_Count = Convert.ToInt32(material["f_count"].ToString() ?? "0");//子级物料数量
                                    erpBomEntity.F_CreateDate = DateTime.Now;
                                    erpBomEntity.F_CreateUserId = this.GetUserId();
                                    erpBomEntity.F_CreateUserName = this.GetUserName();
                                    erpBomEntity.F_EnabledMark = 0;

                                    erpBomEntities.Add(erpBomEntity);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (materialentity != null)
                            {
                                erpBomEntity.F_MaterialId = materialentity.F_Id;//物料外键Id(case_erp_material)
                                erpBomEntity.F_Number = materialentity.F_Number;//物料编码
                                erpBomEntity.F_Name = materialentity.F_Name;//物料名称
                                erpBomEntity.F_Model = materialentity.F_Model;//规格型号
                                erpBomEntity.F_Unit = materialentity.F_Unit;//单位
                                erpBomEntity.F_Type = materialentity.F_Type;//物料类别
                                erpBomEntity.F_Property = materialentity.F_Property;//物料属性
                                erpBomEntity.F_Count = Convert.ToInt32(material["f_count"].ToString() ?? "0");//子级物料数量
                                erpBomEntity.F_CreateDate = DateTime.Now;
                                erpBomEntity.F_CreateUserId = this.GetUserId();
                                erpBomEntity.F_CreateUserName = this.GetUserName();
                                erpBomEntity.F_EnabledMark = 0;

                                erpBomEntities.Add(erpBomEntity);
                            }
                        }
                    }
                    if (erpBomEntities.Count > 0)
                    {
                        await caseErpBomService.BaseRepository().Inserts<CaseErpBomEntity>(erpBomEntities);
                    }
                }
                else
                {
                    return false;
                }
                caseErpBomService.Commit();
                return true;
            }
            catch (Exception)
            {
                caseErpBomService.Rollback();
                return false;
                throw;
            }
        }
        #endregion
    }
}
