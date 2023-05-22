using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.test
{
    public class SelectOFFManagerRequest
    {
        /// <summary>
        /// 发动机编码
        /// </summary>
        public string EngineCode { get; set; }

        /// <summary>
        /// 发动机类型
        /// </summary>
        public string EngineType { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string BatchName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime[] CreateTime { get; set; }
    }
}
