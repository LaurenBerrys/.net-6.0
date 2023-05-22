using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models
{
    /// <summary>
    /// 登录类Dto
    /// </summary>
    public class UserDto
    {
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string repassed { get; set; }
    }
}
