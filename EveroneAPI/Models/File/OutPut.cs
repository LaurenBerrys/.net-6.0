using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models.File
{
    /// <summary>
    /// 返回输出类
    /// </summary>
    public class OutPut
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
    /// <summary>
    /// 接收参数Dto
    /// </summary>
    public class ImagesDto
    {
        ///// <summary>
        ///// ID
        ///// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        ///// <summary>
        ///// 备注
        ///// </summary>
        public string Remark { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        public int RelationId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
    }
}
