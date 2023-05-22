using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        [Column("ID", Order = 0, TypeName = "int")]//列名Zj，数据库序号0，类型int
        [Required()]//不允许为空
        [Display(Name = "ID")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public int ID { get; set; }
        [MaxLength(30)]
        [Column("UserID", Order = 1, TypeName = "nvarchar(20)")]
        [Display(Name = "UserTID")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public string? UserTID { get; set; }
        [MaxLength(30),Required]
        [Column("UserName", Order = 2, TypeName = "nvarchar(20)")]
        [Display(Name = "账户名")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public string UserName { get; set; }
        [MaxLength(30), Required]
        [Column("UserPwd", Order = 3, TypeName = "nvarchar(30)")]
        [Display(Name = "账户密码")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public string UserPwd { get; set; }
        [MaxLength(30)]
        [Column("RoleName", Order = 4, TypeName = "nvarchar(20)")]
        [Display(Name = "角色")]
        public string? RoleName { get; set; }
        [Column("Bak", Order = 5, TypeName = "nvarchar(50)")]
        [Display(Name = "描述")]
        public string? Bak { get; set; }
        [Column("Avatar", Order = 6, TypeName = "nvarchar(50)")]
        [Display(Name = "描述")]
        public string? Avatar { get; set; }

    }
}
