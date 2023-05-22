using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveroneAPI.Models;
using EveroneAPI.ContextDB;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EveroneAPI.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ContextDBs db;
        public UserController(ContextDBs _db)
        {
            db = _db;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>返回结果</returns>
        [HttpPost]
        public ReturnModel CreateUser([FromBody]UserDto user)
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



                    else
                {

                    var users = new UserInfo()
                            {
                                UserName=user.UserName,
                                UserPwd = user.Password,
                            };
                            db.UserInfo.Add(users);
                            db.SaveChanges();
                            ret.Code = 200;
                            ret.Msg = "用户注册成功";
   
                        return ret;

                    }
               
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}