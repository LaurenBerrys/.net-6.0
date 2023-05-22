using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models.File
{
    public class RetModels<T>
    {
        public string code { get; set; }

        public string msg { get; set; }

        public List<T> data { get; set; }
    }
}
