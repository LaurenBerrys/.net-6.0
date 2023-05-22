﻿// <auto-generated />
using System;
using EveroneAPI.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EveroneAPI.Migrations
{
    [DbContext(typeof(ContextDBs))]
    partial class ContextDBsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EveroneAPI.ContextDB.Models.Buy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("int");

                    b.Property<string>("Sugarcontent")
                        .HasColumnName("Sugarcontent")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("temperature")
                        .HasColumnName("temperature")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Buy");
                });

            modelBuilder.Entity("EveroneAPI.ContextDB.Models.Demand", b =>
                {
                    b.Property<int?>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tranprice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("datatime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("imagesrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("order")
                        .HasColumnType("int");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.Property<string>("theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Demand");
                });

            modelBuilder.Entity("EveroneAPI.ContextDB.Models.Wxuser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(30);

                    b.Property<int?>("phone")
                        .HasColumnName("phone")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.HasKey("ID");

                    b.ToTable("WXuser");
                });

            modelBuilder.Entity("EveroneAPI.ContextDB.Models.shoping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("shoping");
                });

            modelBuilder.Entity("EveroneAPI.Models.UserInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnName("Avatar")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Bak")
                        .HasColumnName("Bak")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoleName")
                        .HasColumnName("RoleName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(30);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(30);

                    b.Property<string>("UserPwd")
                        .IsRequired()
                        .HasColumnName("UserPwd")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("UserTID")
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
