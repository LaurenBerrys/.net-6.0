using EveroneAPI.ContextDB.Models;
using EveroneAPI.Models;
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
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<shoping> shoping { get; set; }
        public DbSet<Demand> Demand { get; set; }
        public DbSet<Wxuser> Wxuser { get; set; }
        public DbSet<Buy> Buy { get; set; }
        //public DbSet<UserPowerNew> UserPowerNew { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserInfo>()
        //         .HasKey(t => t.ID);


        //}
    }
}
