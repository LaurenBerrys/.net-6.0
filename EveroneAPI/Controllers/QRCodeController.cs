using System;
using System.IO;
using EveroneAPI.Models.File;
using EveroneAPI.Comoon;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EveroneAPI.Controllers
{
    [EnableCors("any")]//跨域
     //[ServiceFilter(typeof(TokenFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QRCodeController : Controller
    {
        private IQRCode _iQRCode;
        //private readonly ITokenHelper tokenHelper = null;

        public QRCodeController(IQRCode iQRCode)
        {
            _iQRCode = iQRCode;
            //tokenHelper = _tokenHelper;
        }

        ///// <summary>
        ///// 输入参数，像素大小，获取二维码
        ///// </summary>
        ///// <param name="url">存储内容地址或者数字都可以</param>
        ///// <param name="pixel">像素大小</param>
        ///// <returns></returns>
        //[HttpPost]
        //public void GetQRCode([FromBody]QRCodes sq)
        //{
        //        Response.ContentType = "image/jpeg";
        //        var bitmap = _iQRCode.GetQRCode(sq);
        //        MemoryStream ms = new MemoryStream();
        //        bitmap.Save(ms, ImageFormat.Jpeg);
        //        Response.Body.WriteAsync(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        //        Response.Body.Close();
        //}
        /// <summary> 
        /// 生成二维码 
        /// </summary> 
        /// <returns>返回二维码base64用于前端展示</returns> 
        [HttpPost]
          public RetModel QRCodeEncoderUtil([FromBody]QRCodes sq)
          {
            RetModel retModel = new RetModel();
            var img = _iQRCode.GetQRCode(sq); ;//指定utf-8编码， 支持中文 
             string strbaser64 = "";
             try
             {
                 using (MemoryStream ms = new MemoryStream())
                 {
                     img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                     byte[] arr = new byte[ms.Length];
                     ms.Position = 0;
                     ms.Read(arr, 0, (int) ms.Length);
                     ms.Close();
                     strbaser64 = Convert.ToBase64String(arr);
                 }
                retModel.code = "1";
                retModel.data = strbaser64;
                //return strbaser64;

                return retModel;
            }
             catch (Exception)
             {
                retModel.code = "-1";
                retModel.msg = "Something wrong during convert!";
                //throw new Exception("Something wrong during convert!");
                return retModel;
             }
         }
    }


}