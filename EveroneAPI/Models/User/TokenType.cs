using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models.User
{
    public enum TokenType
    {
        Ok,
        Fail,
        Expired//token过期
    }
}
