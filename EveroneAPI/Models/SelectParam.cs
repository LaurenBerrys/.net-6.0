using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models
{
    /// <summary>
    /// 查询参数基类
    /// </summary>
    public class SelectParam
    {
        public object Data { get; set; }
        public int Total { get; set; }
        public string Msg { get; set; }

        public int Code { get; set; }
        /// <summary>
        /// 每页显示多少条数据
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 当前显示第几页
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每次最大查询行数，为0则表示不限制
        /// </summary>
        public int MaxCount { get; set; } = 0;
    }
    public class SelectParam<T>
    {
        public string Key { get; set; }

        public T Data { get; set; }
    }

    /// <summary>
    /// 增加了号码段查询的查询参数类
    /// </summary>
    public class CodeFrameSelectParam : SelectParam
    {
        /// <summary>
        /// 特征码--发动机号前5位，副车架号前13位
        /// </summary>
        public string FeatureCode { get; set; }
        /// <summary>
        /// 查询号码段--发动机号后7位，副车架号后4位
        /// </summary>
        public int[] CodeFrame { get; set; }
    }
}
