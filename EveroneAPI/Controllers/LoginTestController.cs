using EveroneAPI.jwt;
using EveroneAPI.Models;
using EveroneAPI.Models.User;
using EveroneAPI.ContextDB;
using EveroneAPI.Filter;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EveroneAPI.Controllers
{
    [EnableCors("any")]
    //[ServiceFilter(typeof(TokenFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginTestController : ControllerBase
    {

        private readonly ContextDBs db ;
        private readonly ITokenHelper tokenHelper = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_tokenHelper"></param>
        public LoginTestController(ITokenHelper _tokenHelper, ContextDBs _db)
        {
            tokenHelper = _tokenHelper;
            db = _db;
        }
      


        /// <summary>
        /// 登录测试
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel Login([FromBody]UserDto user)
        {
            var ret = new ReturnModel();
            try
            {
                if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
                {
                    ret.Code = 201;
                    ret.Msg = "用户名密码不能为空";
                    return ret;
                }
                    var usess = db.UserInfo.ToList().FirstOrDefault(P=>P.UserName.Equals(user.UserName)&&P.UserPwd.Equals(user.Password));
                if (usess!=null)
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                    {
                        { "UserName", user.UserName }
                    };
                    ret.Code = 200;
                    ret.Msg = "登录成功";
                    ret.TnToken = tokenHelper.CreateToken(keyValuePairs);

                }
            }
            catch (Exception ex)
            {
                ret.Code = 500;
                ret.Msg = "登录失败:" + ex.Message;
            }
            return ret;
        }
        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="tokenStr">token</param>
        /// <returns></returns>
        [HttpGet]
        public ReturnModel ValiToken(string tokenStr)
        {
            var ret = new ReturnModel
            {
                TnToken = new TnToken()
            };
            bool isvilidate = tokenHelper.ValiToken(tokenStr);
            if (isvilidate)
            {
                ret.Code = 200;
                ret.Msg = "Token验证成功";
                ret.TnToken.TokenStr = tokenStr;
            }
            else
            {
                ret.Code = 500;
                ret.Msg = "Token验证失败";
                ret.TnToken.TokenStr = tokenStr;
            }
            return ret;
        }
        /// <summary>
        /// 验证Token 带返回状态
        /// </summary>
        /// <param name="tokenStr"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnModel ValiTokenState(string tokenStr)
        {
            var ret = new ReturnModel
            {
                TnToken = new TnToken()
            };
            string ID = "";
            TokenType tokenType = 
                tokenHelper.ValiTokenState(tokenStr, a => a["iss"] == "NCY" && a["aud"] == "EveryTestOne",
                action => { ID = action["ID"]; });
            if (tokenType == TokenType.Fail)
            {
                ret.Code = 202;
                ret.Msg = "token验证失败";
                return ret;
            }
            if (tokenType == TokenType.Expired)
            {
                ret.Code = 205;
                ret.Msg = "token已经过期";
                return ret;
            }

            //..............其他逻辑
            var data = new List<Dictionary<string, string>>();
            var bb = new Dictionary<string, string>
            {
                { "NCY", "123456" }
            };
            data.Add(bb);
            ret.Code = 200;
            ret.Msg = "访问成功!";
            ret.Data = data;
            return ret;
        }
    }
}