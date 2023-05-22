//using EveroneAPI.ContextDB.Models;
//using EveroneAPI.Models;
using EveroneAPI.NvapVue;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveroneAPI.ContextDB
{
    public class ContextDBs : DbContext
    {


        public ContextDBs(DbContextOptions<ContextDBs> options): base(options)
        {
        }

        //mysql
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<MenuList> MenuLists { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserInfo>()
        //         .HasKey(t => t.ID);
        //}
    }

}

