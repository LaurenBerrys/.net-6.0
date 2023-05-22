//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Text;
//using System.Web;
//using Microsoft.AspNetCore.Mvc;
//using RestSharp;

//namespace JWT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class sendCodeController : ControllerBase
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Request.QueryString["sender"] != null)
//            {
//                Random rd = new Random();
//                int Randoms = rd.Next(100000, 999999);//六位随机数
//                string phone = Request.QueryString["phone"].ToString().Trim();
//                int sendCodeId = yingxiaoshi_Common.singleSend(phone, Randoms.ToString().Trim(), 63416);//方法在下面
//                Response.Write(sendCodeId);
//                Response.End();
//            }
//            else if (Request.QueryString["confirm"] != null)//确定按钮，验证输入的验证码是否正确
//            {
//                string sendCodeId = Request.QueryString["sendCodeId"].ToString().Trim();
//                string phone = Request.QueryString["phone"].ToString().Trim();
//                string code = Request.QueryString["code"].ToString().Trim();
                
//                //yingxiaoshi_sendCode info = new Helper.yingxiaoshi_sendCode(Convert.ToInt32(sendCodeId));//验证码所存的的数据表
//                if (info != null && info.sendCodeId > 0)
//                {
//                    if (info.mobile == phone && info.code == code)
//                    {
//                        DateTime t1 = DateTime.Now;
//                        DateTime t2 = Convert.ToDateTime(info.CreateTime);
//                        TimeSpan time = t1 - t2;
//                        if (time.Minutes > 4)//验证码是否超时
//                        {
//                            Response.Write(-1);
//                        }
//                        else
//                        {
//                            Response.Write(1);
//                        }

//                    }
//                    else
//                    {
//                        Response.Write(0);
//                    }
//                }
//                else
//                {
//                    Response.Write(0);
//                }
//                Response.End();
//            }

//        }
//        #region 发送短信验证码
//        /// <summary>
//        /// 发送短信验证码(单条发送)
//        /// </summary>
//        /// <param name="mobile">接收验证码手机号</param>
//        /// <param name="random">验证码</param>
//        /// <param name="templateId">短信模板ID</param>
//        /// <returns></returns>
//        public static int singleSend(string mobile, string random, int templateId)
//        {
//            string appkey = "*****************************"; //配置您申请的appkey
//            #region
//            //1.屏蔽词检查测
//            //string url1 = "http://v.juhe.cn/sms/black";

//            //var parameters1 = new Dictionary<string, string>();

//            //parameters1.Add("word", HttpUtility.UrlEncode(text, Encoding.UTF8)); //需要检测的短信内容，需要UTF8 URLENCODE
//            //parameters1.Add("key", appkey);//你申请的key

//            //string result1 = sendPost(url1, parameters1, "get");

//            //JsonObject newObj1 = new JsonObject(result1);
//            //String errorCode1 = newObj1["error_code"].Value;

//            //if (errorCode1 == "0")
//            //{
//            //    //Debug.WriteLine("成功");
//            //    //Debug.WriteLine(newObj1);
//            //}
//            //else
//            //{
//            //    //Debug.WriteLine("失败");
//            //    //Debug.WriteLine(newObj1["error_code"].Value + ":" + newObj1["reason"].Value);
//            //}
//            #endregion
//            //2.发送短信
//            string url2 = "http://v.juhe.cn/sms/send";
//            var parameters2 = new Dictionary<string, string>();
//            parameters2.Add("mobile", mobile); //接收短信的手机号码
//            parameters2.Add("tpl_id", templateId.ToString()); //短信模板ID，请参考个人中心短信模板设置
//            parameters2.Add("tpl_value", HttpUtility.UrlEncode("#code#=" + random, Encoding.UTF8)); //变量名和变量值对，如：#code#=431515，整串值需要urlencode，比如正确结果为：%23code%23%3d431515。如果你的变量名或者变量值中带有#&=中的任意一个特殊符号，请先分别进行urlencode编码后再传递，<a href="http://www.juhe.cn/news/index/id/50" target="_blank">详细说明></a>
//            parameters2.Add("key", appkey);//你申请的key
//            parameters2.Add("dtype", "json"); //返回数据的格式,xml或json，默认json

//            string result2 = sendPost(url2, parameters2, "get");//返回结果为json字符串

//            JsonObject newObj2 = new JsonObject(result2);
//            String errorCode2 = newObj2["error_code"].Value;//errorCode2=0时发送成功
//            #region 对发送的验证码等信息存库
//            yingxiaoshi_sendCode info = new yingxiaoshi_sendCode();
//            info.mobile = mobile;
//            info.code = random;
//            info.tpl_id = templateId;
//            info.error_code = Convert.ToInt16(errorCode2);
//            info.backJson = result2;
//            int sendCodeId = info.Add();
//            #endregion
//            if (errorCode2 == "0" && sendCodeId > 0)
//            {
//                return sendCodeId;
//            }
//            else
//            {
//                return 0;
//            }

//        }
//        /// <summary>
//        /// Http (GET/POST)
//        /// </summary>
//        /// <param name="url">请求URL</param>
//        /// <param name="parameters">请求参数</param>
//        /// <param name="method">请求方法</param>
//        /// <returns>响应内容</returns>
//        static string sendPost(string url, IDictionary<string, string> parameters, string method)
//        {
//            if (method.ToLower() == "post")
//            {
//                HttpWebRequest req = null;
//                HttpWebResponse rsp = null;
//                System.IO.Stream reqStream = null;
//                try
//                {
//                    req = (HttpWebRequest)WebRequest.Create(url);
//                    req.Method = method;
//                    req.KeepAlive = false;
//                    req.ProtocolVersion = HttpVersion.Version10;
//                    req.Timeout = 5000;
//                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
//                    byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
//                    reqStream = req.GetRequestStream();
//                    reqStream.Write(postData, 0, postData.Length);
//                    rsp = (HttpWebResponse)req.GetResponse();
//                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
//                    return GetResponseAsString(rsp, encoding);
//                }
//                catch (Exception ex)
//                {
//                    return ex.Message;
//                }
//                finally
//                {
//                    if (reqStream != null) reqStream.Close();
//                    if (rsp != null) rsp.Close();
//                }
//            }
//            else
//            {
//                //创建请求
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters, "utf8"));

//                //GET请求
//                request.Method = "GET";
//                request.ReadWriteTimeout = 5000;
//                request.ContentType = "text/html;charset=UTF-8";
//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                Stream myResponseStream = response.GetResponseStream();
//                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

//                //返回内容
//                string retString = myStreamReader.ReadToEnd();
//                return retString;
//            }
//        }

//        /// <summary>
//        /// 组装普通文本请求参数。
//        /// </summary>
//        /// <param name="parameters">Key-Value形式请求参数字典</param>
//        /// <returns>URL编码后的请求数据</returns>
//        static string BuildQuery(IDictionary<string, string> parameters, string encode)
//        {
//            StringBuilder postData = new StringBuilder();
//            bool hasParam = false;
//            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
//            while (dem.MoveNext())
//            {
//                string name = dem.Current.Key;
//                string value = dem.Current.Value;
//                // 忽略参数名或参数值为空的参数
//                if (!string.IsNullOrEmpty(name))//&& !string.IsNullOrEmpty(value)
//                {
//                    if (hasParam)
//                    {
//                        postData.Append("&");
//                    }
//                    postData.Append(name);
//                    postData.Append("=");
//                    if (encode == "gb2312")
//                    {
//                        postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
//                    }
//                    else if (encode == "utf8")
//                    {
//                        postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
//                    }
//                    else
//                    {
//                        postData.Append(value);
//                    }
//                    hasParam = true;
//                }
//            }
//            return postData.ToString();
//        }

//        /// <summary>
//        /// 把响应流转换为文本。
//        /// </summary>
//        /// <param name="rsp">响应流对象</param>
//        /// <param name="encoding">编码方式</param>
//        /// <returns>响应文本</returns>
//        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
//        {
//            System.IO.Stream stream = null;
//            StreamReader reader = null;
//            try
//            {
//                // 以字符流的方式读取HTTP响应
//                stream = rsp.GetResponseStream();
//                reader = new StreamReader(stream, encoding);
//                return reader.ReadToEnd();
//            }
//            finally
//            {
//                // 释放资源
//                if (reader != null) reader.Close();
//                if (stream != null) stream.Close();
//                if (rsp != null) rsp.Close();
//            }
//        }
//        #endregion

//    }
//}