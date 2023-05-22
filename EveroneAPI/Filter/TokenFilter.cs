using EveroneAPI.jwt;
using EveroneAPI.Models;
using EveroneAPI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EveroneAPI.Filter
{

    public class TokenFilter : Attribute, IActionFilter
    {
        private ITokenHelper tokenHelper;
        public TokenFilter(ITokenHelper _tokenHelper) //通过依赖注入得到数据访问层实例
        {
            tokenHelper = _tokenHelper;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ReturnModel ret = new ReturnModel();
            //获取token
            object tokenobj = context.HttpContext.Request.Headers["access_token"].ToString();

            if (tokenobj == null)
            {
                ret.Code = 201;
                ret.Msg = "token不能为空";
                context.Result = new JsonResult(ret);
                return;
            }
            string token = tokenobj.ToString();

            string ID = "";
            //验证jwt,同时取出来jwt里边的用户ID
            TokenType tokenType = tokenHelper.ValiTokenState(token, a => a["iss"] == "NCY" && a["aud"] == "EveryTestOne", action => { ID = action["ID"]; });
            if (tokenType == TokenType.Fail)
            {
                ret.Code = 202;
                ret.Msg = "token验证失败";
                context.Result = new JsonResult(ret);
                return;
            }
            if (tokenType == TokenType.Expired)
            {
                ret.Code = 205;
                ret.Msg = "token已经过期";
                context.Result = new JsonResult(ret);
            }
            if (!string.IsNullOrEmpty(ID))
            {
                //给控制器传递参数(需要什么参数其实可以做成可以配置的，在过滤器里边加字段即可)
                //context.ActionArguments.Add("userId", Convert.ToInt32(userId));
            }
        }
    }
}
