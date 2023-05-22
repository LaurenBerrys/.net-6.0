using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveroneAPI.NvapVue
{
	[Table("MenuList")]
	public class MenuList
	{
        [Key]
        [Column("ID", Order = 0, TypeName = "INT")]//列名Zj，数据库序号0，类型int
        [Display(Name = "ID")]
		public int ID { get; set; }
		[MaxLength(20), Required]
		[Column("name",Order =1,TypeName = "varchar(20)")]
		[Display(Name ="菜单名")]
		public string name { get; set; }
		[MaxLength(20), Required]
		[Column("title",Order =2,TypeName = "varchar(20)")]
		[Display(Name ="菜单标题")]
		public string title { get; set; }
		[Column("parentId",Order =3,TypeName ="INT")]
		[Display(Name ="父菜单ID")]
		public int parentId { get; set; }
		[Column("icon",Order =4,TypeName ="varchar(100)")]
		[Display(Name ="icon图标")]
		public string icon { get; set; }
		[Column("path",Order =5,TypeName ="varchar(100)")]
		[Display(Name ="路径")]
		[Required]
		public string path { get; set; }
		[Column("component",Order=6,TypeName ="varchar(100)")]
		[Display(Name ="组件")]
		public string component { get; set; }
        [Required]
        [Column("hidden", Order = 7, TypeName = "TINYINT")]
        [Display(Name = "是否隐藏")]
        public bool hidden { get; set; }

		[Column("keepAlive",Order =8,TypeName = "TINYINT")]
		[Display(Name ="是否缓存")]
		public bool keepAlive { get; set; }

		[Column("order",Order =9,TypeName ="INT")]
		[Display(Name ="排序")]
	    public int order { get; set; }

		[Column("redirect",Order =10,TypeName ="varchar(100)")]
		[Display(Name ="重定向")]
		public string redirect { get; set; }

        [Column("code", Order = 11, TypeName = "varchar(20)")]
        [Display(Name = "菜单权限")]
        public string code { get; set; }

        [Column("permissions", Order = 12, TypeName = "varchar(20)")]
        [Display(Name = "按钮权限")]
        public string permissions { get; set; }

		public ICollection<MenuList> children { get; set; }
    }
}

