using EveroneAPI.Models.File;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Comoon
{
    public class RaffQRCode : IQRCode
    {
        /// <summary>
        /// 二维码
        /// </summary>
        /// <returns></returns>
        public Bitmap GetQRCode([FromBody]QRCodes qR)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(qR.url, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);

            Bitmap qrImage = qrcode.GetGraphic(qR.pixel, Color.Black, Color.White, true);

            return qrImage;
        }

    }
}
