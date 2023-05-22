using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.ContextDB.Models
{
    [Table("WXuser")]
    public class Wxuser
    {
        [Key]
        [Column("ID", Order = 0, TypeName = "int")]//列名Zj，数据库序号0，类型int
        [Required()]//不允许为空
        [Display(Name = "ID")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public int ID { get; set; }

        [MaxLength(30), Required]
        [Column("UserName", Order = 2, TypeName = "nvarchar(20)")]
        [Display(Name = "账户名")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public string UserName { get; set; }
        [MaxLength(11)]
        [Column("phone", Order = 3, TypeName = "int")]//列名Zj，数据库序号0，类型int
        [Display(Name = "phone")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public int? phone { get; set; }
    }
}
