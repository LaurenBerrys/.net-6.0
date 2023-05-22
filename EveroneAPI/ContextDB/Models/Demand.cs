using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.ContextDB.Models
{
    public class Demand
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        public int? UserID { get; set; }
        /// <summary>
        /// 发布用户
        /// </summary>
        public string? User { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public decimal? datatime { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string? theme { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string? Tranprice { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string? imagesrc { get; set; }
        /// <summary>
        /// 成交人
        /// </summary>
        public string? Transactor { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public int? order { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int? price { get; set; }

    }
}
