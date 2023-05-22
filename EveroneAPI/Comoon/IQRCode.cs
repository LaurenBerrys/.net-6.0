using EveroneAPI.Models.File;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Comoon
{
    /// <summary>
    /// 二维码生成接口
    /// </summary>
    public interface IQRCode
    {
        Bitmap GetQRCode( [FromBody]QRCodes qRCoder);
       
    }
}
