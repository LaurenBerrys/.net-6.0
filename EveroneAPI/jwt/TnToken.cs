﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.jwt
{
    /// <summary>
    /// 存放Token 跟过期时间的类
    /// </summary>
    public class TnToken
    {
        /// <summary>
        /// token
        /// </summary>
        public string TokenStr { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expires { get; set; }
    }

}
