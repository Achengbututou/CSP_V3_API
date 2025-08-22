using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using learun.oss;
using System.Data;
using learun.cache;
using NPOI.SS.Formula.Functions;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-28 17:00:53
    /// 描 述： 设备信息
    /// </summary>
    public class CaseErpDeviceinfoBLL : BLLBase, ICaseErpDeviceinfoBLL,BLL
    {
        private readonly CaseErpDeviceinfoService caseErpDeviceinfoService = new CaseErpDeviceinfoService();
        private readonly IAnnexes _iAnnexes;
        private readonly UserIBLL _userIBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iCache"></param>
        /// <param name="userRelationIBLL"></param>
        public CaseErpDeviceinfoBLL(IAnnexes iAnnexes, UserIBLL userIBLL)
        {
            _iAnnexes = iAnnexes;
            _userIBLL = userIBLL;
        }

        #region 获取数据
        /// <summary>
        /// 获取设备信息的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDeviceinfoEntity>> GetList(CaseErpDeviceinfoEntity queryParams)
        {
            return caseErpDeviceinfoService.GetList(queryParams);
        }

        /// <summary>
        /// 获取设备信息的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDeviceinfoEntity>> GetPageList(Pagination pagination, CaseErpDeviceinfoEntity queryParams)
        {
            return caseErpDeviceinfoService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpDeviceinfoEntity> GetEntity(string keyValue)
        {
            return caseErpDeviceinfoService.GetEntity(keyValue);
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
            await caseErpDeviceinfoService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpDeviceinfoEntity entity)
        {
            entity.F_Number = (await GetRuleCodeEx(entity.F_Number)).ToString(); 

            await caseErpDeviceinfoService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpDeviceinfoService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法
        /// <summary>
        /// 设备信息列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetExportList(string ids)
        {
            var id = Guid.NewGuid().ToString();
            //取出数据源
            var List = await caseErpDeviceinfoService.GetExportList(ids);
            //DataTable exportTable = await caseErpDeviceinfoService.GetExportList(ids);
            if (List!=null)
            {
                foreach (var item in List)
                {
                    item.F_StateStr = item.F_State==0?"正常":"异常";
                    item.F_PrincipalStr = (await _userIBLL.GetEntity(item.F_Principal))?.F_RealName;
                }
            }
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = "设备信息列表";
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 25;
            excelconfig.FileName = $"{ConfigHelper.GetValue<string>("baseDir")}/wwwroot/{id}.xls"; //$"{ConfigHelper.GetConfig().FilePath}/Learun_EXCEL_EXPORT/{id}";
            excelconfig.IsAllSizeColumn = true;
            //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
            excelconfig.ColumnEntity = new List<ColumnModel>();
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Number", ExcelColumn = "设备编号", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Name", ExcelColumn = "设备名称", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Type", ExcelColumn = "设备类型", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Supplier", ExcelColumn = "供应商", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Address", ExcelColumn = "设备位置", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Model", ExcelColumn = "规格型号", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_PrincipalStr", ExcelColumn = "负责人", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_StateStr", ExcelColumn = "设备状态", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_CreateDate", ExcelColumn = "创建日期", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_CreateUserName", ExcelColumn = "创建人", Alignment = "center" });

            _iAnnexes.UploadFile(id, $"Excel/{id}.xls", ".xls", ExcelHelper.ExportMemoryStream(List.ToJson().ToTable(), excelconfig).ToArray(),0);

            return id;
        }
        #endregion
    }
}
