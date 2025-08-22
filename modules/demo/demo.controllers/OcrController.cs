using learun.iapplication;
using learun.oss;
using learun.util;
using learun.utils.web;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace demo.controllers
{
    /// <summary>
    /// 力软信息技术（苏州）有限公司出品
    /// Copyright © 2021-present 力软信息技术（苏州）有限公司出品
    /// 创建人：ssy
    /// 日 期： 2023.09.12
    /// 描 述： OCR演示接口
    /// </summary>
    public class OcrController : BaseApiController
    {
        private readonly AnnexesFileIBLL _annexesFileIBLL;
        private readonly IAnnexes _iAnnexes;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="annexesFileIBLL"></param>
        /// <param name="iAnnexes"></param>
        public OcrController(AnnexesFileIBLL annexesFileIBLL, IAnnexes iAnnexes)
        {
            _annexesFileIBLL = annexesFileIBLL;
            _iAnnexes = iAnnexes;
        }
        /// <summary>
        /// 测试OCR通用文字识别
        /// </summary>
        /// <returns></returns>
        [HttpPost("demo/ocr/recognizeadvanced/{fileId}")]
        [ProducesResponseType(typeof(ResponseDto<string>), 200)]
        public async Task<IActionResult> AddEwMatecardetail(string fileId)
        {
            string ocrres = string.Empty;
            string path =await _annexesFileIBLL.ToPreview(fileId,0);
            byte[] bytes = FileHelper.Read(path);
            Stream stream = new MemoryStream(bytes);
            AliyunOcrHelper ocrHelper= new AliyunOcrHelper();
            ocrres = ocrHelper.RecognizeBasic(stream).Body.Data.ToString();

            return Success("识别成功！", ocrres);
        }




    }
}
