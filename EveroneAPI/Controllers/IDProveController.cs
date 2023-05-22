using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Cors;
using EveroneAPI.Models.File;
using EveroneAPI.ContextDB;

namespace EveroneAPI.Controllers
{
    [Route("api/[controller]")]
    //[ServiceFilter(typeof(TokenFilter))]
    [EnableCors("any")]
    [ApiController]
    public class IDProveController : ControllerBase
    {
        public IHostingEnvironment env;
        private readonly ContextDBs db;
        public IDProveController(IHostingEnvironment _env, ContextDBs _db)
        {
            db = _db;
            env = _env;
        }

        [HttpPost]  
        public RetModel IDCodeOcr()
        {
            var retModel = new RetModel();

            //var dto = JsonConvert.DeserializeObject<ImagesDto>(Request.Form["fileUpload"]);//文件类实体参数
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var path = env.ContentRootPath + @"\Uploads\File\IDimage\" + files[0].FileName;//绝对路径
                //string dirPath = Path.Combine(path, );//绝对径路 储存文件路径的文件夹
                //if (!Directory.Exists(dirPath))//查看文件夹是否存在
                //    Directory.CreateDirectory(dirPath);
                //var file = files.Where(x => true).FirstOrDefault();//只取多文件的一个
                //var fileNam = $"{file.FileName}";//新文件名
                //string snPath = $"{dirPath + fileNam}";//储存文件路径

                string dirPath = env.ContentRootPath + @"\Uploads\File\IDimage\";//绝对径路 储存文件路径的文件夹
                if (!Directory.Exists(dirPath))//查看文件夹是否存在
                    Directory.CreateDirectory(dirPath);
                var file = files[0];
                using var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);
                stream.Close();
                try
                {
                    string results = Idcard(path);
                    retModel.data = results;
                    retModel.code = "200";
                    retModel.msg = "成功";
                }
                catch(Exception ex)
                {
                    retModel.code = "-200";
                    retModel.msg = "ERROR:" + ex.Message;
                }
                return retModel;
            }
            retModel.msg = "失败";
            retModel.data = "";
            retModel.code = "404";
            return retModel;
        }
        private static string GetAccessToken()//获取token
        {
            // 百度云中开通对应服务应用的 API Key
            string clientId = "6LFBXEHBOfd1LoZ2Rih9upLm";
            // 百度云中开通对应服务应用的 Secret Key
            string clientSecret = "PNqqWer0eMz5kzegjFGn3ynWSmzKU2y3";
            string authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
            paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            string token = result.Split(',')[3].Split(':')[1].Trim('"');
            return token;
        }
        private static string Idcard(string path)
        {
            string token = GetAccessToken();
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/idcard?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = GetFileBase64(path);
            string str = "id_card_side=" + "front" + "&image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            return result;
        }
        private static string GetFileBase64(string fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }
    }
}