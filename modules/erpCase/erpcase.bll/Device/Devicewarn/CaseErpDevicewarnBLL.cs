using ce.autofac.extension;
using learun.util;
using learun.iapplication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using erpCase.ibll;
using learun.oss;

namespace erpCase.bll
{
    /// <summary>
    /// 框架DEV开发-erp案例
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2022-11-28 17:03:09
    /// 描 述： 设备告警
    /// </summary>
    public class CaseErpDevicewarnBLL : BLLBase, ICaseErpDevicewarnBLL,BLL
    {
        private readonly ICaseErpDeviceinfoBLL _icaseErpDeviceinfoBLL;
        private readonly CaseErpDevicewarnService caseErpDevicewarnService = new CaseErpDevicewarnService();
        private readonly IAnnexes _iAnnexes;
        private readonly UserIBLL _userIBLL;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CaseErpDevicewarnBLL(ICaseErpDeviceinfoBLL icaseErpDeviceinfoBLL, IAnnexes iAnnexes, UserIBLL userIBLL)
        {
            _icaseErpDeviceinfoBLL = icaseErpDeviceinfoBLL ?? throw new ArgumentNullException(nameof(icaseErpDeviceinfoBLL));
            _iAnnexes = iAnnexes;
            _userIBLL = userIBLL;
        }


        #region 获取数据
        /// <summary>
        /// 获取设备告警的列表数据
        /// </summary>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDevicewarnEntity>> GetList(CaseErpDevicewarnEntity queryParams)
        {
            return caseErpDevicewarnService.GetList(queryParams);
        }

        /// <summary>
        /// 获取设备告警的分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryParams">查询参数</param>
        /// <returns></returns>
        public Task<IEnumerable<CaseErpDevicewarnEntity>> GetPageList(Pagination pagination, CaseErpDevicewarnEntity queryParams)
        {
            return caseErpDevicewarnService.GetPageList(pagination, queryParams);
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Task<CaseErpDevicewarnEntity> GetEntity(string keyValue)
        {
            return caseErpDevicewarnService.GetEntity(keyValue);
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
            await caseErpDevicewarnService.Delete(keyValue);
        }

        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task SaveEntity(string keyValue, CaseErpDevicewarnEntity entity)
        {
            
            await caseErpDevicewarnService.SaveEntity(keyValue, entity);
        }

        

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="keyValues">主键集</param>
        /// <returns></returns>
        public async Task Deletes(string keyValues)
        {
            await caseErpDevicewarnService.Deletes(keyValues);
        }



        #endregion

        #region 扩展方法

        #region 定时任务

        #region 定时插入设备告警信息
        /// <summary>
        /// 定时插入设备告警信息
        /// </summary>
        /// <returns></returns>
        public async Task DeviceWarn()
        {
            var DeviceList = (await caseErpDevicewarnService.BaseRepository().FindList<CaseErpDeviceinfoEntity>(it => it.F_State == 0, "F_CreateDate DESC")).ToObject<List<CaseErpDeviceinfoEntity>>();
            if (DeviceList.Count>0)
            {
                var DeviceEntity = DeviceList[new Random().Next(DeviceList.Count)];//随机拿出一条设备信息插入设备预警列表
                if (DeviceEntity!=null)
                {
                    CaseErpDevicewarnEntity devicewarnEntity = new CaseErpDevicewarnEntity();
                    devicewarnEntity.F_DeviceId = DeviceEntity.F_Id;
                    devicewarnEntity.F_Type = DeviceEntity.F_Type;
                    devicewarnEntity.F_Number = DeviceEntity.F_Number;
                    devicewarnEntity.F_Name = DeviceEntity.F_Name;
                    devicewarnEntity.F_Model = DeviceEntity.F_Model;
                    devicewarnEntity.F_Address = DeviceEntity.F_Address;
                    devicewarnEntity.F_Level = (new Random().Next(0, 3)).ToString();
                    devicewarnEntity.F_Description = "温度超高阈值告警";
                    devicewarnEntity.F_Date = DateTime.Now;
                    devicewarnEntity.F_State = 1;//处理状态(0已处理，1待处理)
                    await caseErpDevicewarnService.SaveEntity(null, devicewarnEntity);
                }
            }
        }
        #endregion

        #endregion

        #region 导出Excel
        /// <summary>
        /// 设备告警列表（导出Excel）
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetExportList(string ids)
        {
            var id = Guid.NewGuid().ToString();
            //取出数据源
            var List = await caseErpDevicewarnService.GetExportList(ids);
            //DataTable exportTable = await caseErpDeviceinfoService.GetExportList(ids);
            if (List!=null)
            {
                foreach (var item in List)
                {
                    item.F_StateStr = item.F_State == 0 ? "已处理" : "待处理";
                    item.F_UserIdStr = (await _userIBLL.GetEntity(item.F_UserId))?.F_RealName;
                    switch (item.F_Level)
                    {
                        case "0":
                            item.F_LevelStr = "一级预警";
                            break;
                        case "1":
                            item.F_LevelStr = "二级预警";
                            break;
                        case "2":
                            item.F_LevelStr = "三级预警";
                            break;
                        default:
                            break;
                    }
                }
            }
            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = "设备告警列表";
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 25;
            excelconfig.FileName = $"{ConfigHelper.GetValue<string>("baseDir")}/wwwroot/{id}.xls"; //$"{ConfigHelper.GetConfig().FilePath}/Learun_EXCEL_EXPORT/{id}";
            excelconfig.IsAllSizeColumn = true;
            //每一列的设置,没有设置的列信息，系统将按datatable中的列名导出
            excelconfig.ColumnEntity = new List<ColumnModel>();
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Number", ExcelColumn = "设备编号", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Name", ExcelColumn = "设备名称", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Type", ExcelColumn = "设备类型", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Address", ExcelColumn = "设备位置", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Model", ExcelColumn = "规格型号", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_LevelStr", ExcelColumn = "故障等级", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Description", ExcelColumn = "故障描述", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_UserIdStr", ExcelColumn = "负责人", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_Date", ExcelColumn = "告警时间", Alignment = "center" });
            excelconfig.ColumnEntity.Add(new ColumnModel() { Column = "F_StateStr", ExcelColumn = "处理状态", Alignment = "center" });

            _iAnnexes.UploadFile(id, $"Excel/{id}.xls", ".xls", ExcelHelper.ExportMemoryStream(List.ToJson().ToTable(), excelconfig).ToArray(),0);

            return id;
        }
        #endregion

        #endregion
    }
}
