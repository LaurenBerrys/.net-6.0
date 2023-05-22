using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.ContextDB.Models
{
    [Table("Buy")]
    public class Buy
    {
        [Column("ID", Order = 0, TypeName = "int")]//列名Zj，数据库序号0，类型int
        [Required()]//不允许为空
        [Display(Name = "ID")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public int ID { get; set; }

        [Required]
        [Column("UserName", Order = 1, TypeName = "nvarchar(20)")]
        [Display(Name = "购物车产品名")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public string Name { get; set; }

        [Required]
        [Column("Number", Order = 3, TypeName = "int")]
        [Display(Name = "产品数量")]
        public int Number { get; set; }

        [Column("Sugarcontent", Order = 4, TypeName = "nvarchar(20)")]
        [Display(Name = "糖度")]
        public string? Sugarcontent { get; set; }

        [Column("temperature", Order = 5, TypeName = "int")]
        [Display(Name = "温度")]
        public int? temperature { get; set; }

        [Column("Price", Order = 6, TypeName = "int")]
        [Display(Name = "价格")]
        public int? Price { get; set; }
    }
}
