using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.ContextDB.Models
{

    public class shoping
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string details { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Number { get; set; }
    }
}
