using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveroneAPI.NvapVue
{
    //mysql数据库，表
    [Table("Users")]
    public class Users
    {
        [Key]
        [Column("ID", Order = 0, TypeName = "INT")]//列名Zj，数据库序号0，类型int
        [Display(Name = "ID")]//显示名称，这里大多都是中文 后面视图@Html.DisplayNameFor(item=> model.Name)用到 显示的
        public int ID { get; set; }
        [MaxLength(20),Required]
        [Column("realName",Order =1,TypeName = "varchar(20)")]
        [Display(Name ="真实名字")]
        public string realName { get; set; }
        [MaxLength(20)]
        [Column("name", Order = 2, TypeName = "varchar(20)")]
        [Display(Name ="昵称")]
        public string name { get; set; }
        [MaxLength(40)]
        [Column("password",Order =3,TypeName = "varchar(40)")]
        [Display(Name ="密码")]
        public string password { get; set; }
        [Column("when",Order =4,TypeName = "datetime")]
        [Display(Name ="时间")]
        public DateTime when { get; set; }
        [Display(Name = "角色")]
        public ICollection<Roles> roles { get; set; }    //可以找到对应的role表中的name
        [Column("salt",Order =6,TypeName = "varchar(1000)")]
        [Display(Name ="加密盐")]
        public string salt { get; set; }
    }
    }