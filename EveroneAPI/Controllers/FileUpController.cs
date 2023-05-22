using EveroneAPI.ContextDB;
using EveroneAPI.Models.File;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Controllers
{
    [EnableCors("any")]//跨域
    //[ServiceFilter(typeof(TokenFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileUpController : ControllerBase
    {
        [Obsolete]
        public IHostingEnvironment env;

        private readonly ContextDBs db;

        [Obsolete]
        public FileUpController(IHostingEnvironment _env, ContextDBs _db)
        {
            db = _db;
            env = _env;
        }
        //前端传  ImageModelInfo：{OutPut的对象}
        //传参示例
        //var data = new FormData(document.getElementById("formData"));
        ////参数
        //var parame = JSON.stringify({ Name: $("#fileName").val(), Remark: $("#txtRemake").val(), Type: $("#selType").val(), RelationId: $("#txtRelationId").val() });
        //    data.append("ImageModelInfo", parame);
        //  $.ajax({
        //type: "post",
        //        url: "http://localhost:5005/api/FileUp",
        //        dataType: "json",
        //        data: data,
        //        async: true,
        //        contentType: false,//实体头部用于指示资源的MIME类型 media type 。这里要为false
        //        processData: false,//processData 默认为true，当设置为true的时候,jquery ajax 提交的时候不会序列化 data，而是直接使用data
        //        success: function(data) {
        //        console.log(data);
        //    },
        //        error: function(data) {
        //        console.log("错误" + data);
        //    }
        //});

        //public async Task<OutPut> image()
        //{
        //    var ret = new OutPut();

        //    /////把数据库里的字符串转成流
        //    ///然后传给前端
        //    var inputStr = db.shoping.Find(1).Url;
        //    byte[] writeBytes = Encoding.UTF8.GetBytes(inputStr);
        //    // byte[] to MemoryStream
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        ms.Position = 0;
        //        ms.Write(writeBytes, 0, (int)ms.Length);
        //        ms.Close();
        //    }
        //}
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OutPut> FileUp()
        {

            var ret = new OutPut();
            try
            {
                //不能用FromBody
                var dto = JsonConvert.DeserializeObject<ImagesDto>(Request.Form["ImageModelInfo"]);//文件类实体参数
                var files = Request.Form.Files;//接收上传的文件，可能多个 看前台
                if (files.Count > 0)
                {

                    var path = env.ContentRootPath + @"/Uploads/File/";//绝对路径
                    string dirPath = Path.Combine(path, dto.Type + "/");//绝对径路 储存文件路径的文件夹
                    if (!Directory.Exists(dirPath))//查看文件夹是否存在
                        Directory.CreateDirectory(dirPath);
                    var file = files.Where(x => true).FirstOrDefault();//只取多文件的一个
                    var fileNam = $"{file.FileName}";//新文件名
                    string snPath = $"{dirPath + fileNam}";//储存文件路径
                    using var stream = new FileStream(snPath, FileMode.Create);
                    await file.CopyToAsync(stream);
                    //次出还可以进行数据库操作 保存到数据库 
                   //把流转成字符串存到数据库
                    //开辟内存区域 1024 * 1024 bytes
                    //byte[] readBytes = new byte[1024 * 1024];
                    ////开始读数据
                    //int count = stream.Read(readBytes, 0, readBytes.Length);
                    ////byte[]转字符
                    //string readStr = Encoding.UTF8.GetString(readBytes, 0, count);
                    //db.shoping.Add(new ContextDB.Models.shoping
                    //{
                    //    Url = readStr
                    //});
                    ret = new OutPut { Code = 200, Msg = "上传成功" + $"{snPath}", Success = true };
                }
                else//没有文件
                {
                    ret = new OutPut { Code = 400, Msg = "请上传文件", Success = false };
                }
            }
            catch (Exception ex)
            {
                ret = new OutPut { Code = 500, Msg = $"异常：{ex.Message}", Success = false };
            }
            return ret;
        }
       
        
    }
}
