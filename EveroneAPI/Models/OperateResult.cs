using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models
{
    /// <summary>
    /// 操作结果类
    /// </summary>
    public class OperateResult
    {
        /// <summary>
        /// 操作结果
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 查询出的数据总数（查询条件筛选后、分页之前）
        /// </summary>
        public int TotalCount { get; set; } = 0;
        /// <summary>
        /// 操作结果描述（操作成功/失败的原因）
        /// </summary>
        public string Describe { get; set; } = "";
    }
    /// <summary>
    /// 操作结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperateResult<T> : OperateResult where T : class
    {
        /// <summary>
        /// 操作返回的数据(分页后的)
        /// </summary>
        public List<T> Data { get; set; }
    }
}
