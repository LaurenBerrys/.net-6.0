using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EveroneAPI.NvapVue
{
	[Table("Role")]
	public class Roles
	{
        [Key]
        [Column("ID", Order = 0, TypeName = "INT")]//列名Zj，数据库序号0，类型int
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Column("name",Order =1,TypeName ="varchar(20)")]
        [Display(Name ="角色名")]
        public string name { get; set; }
        [Column("code",Order =2,TypeName ="varchar(max)")]
        [Display(Name ="菜单权限")]
        public string code { get; set; }
        [Column("permissions",Order =3,TypeName ="varchar(max)")]
        [Display(Name ="按钮权限")]
        public string permissions { get; set; }

    }
}

