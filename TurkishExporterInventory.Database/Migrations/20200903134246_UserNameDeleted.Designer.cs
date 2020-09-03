﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TurkishExporterInventory.Database.Context;

namespace TurkishExporterInventory.Database.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20200903134246_UserNameDeleted")]
    partial class UserNameDeleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.Allocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ItemGivenTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecordCreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("rlt_Item_Id")
                        .HasColumnType("int");

                    b.Property<int>("rlt_User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("rlt_Item_Id");

                    b.HasIndex("rlt_User_Id");

                    b.ToTable("Allocations");
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("RecordCreateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BuyingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal?>("PriceTL")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("RecordCreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("rlt_Supplier_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("rlt_Supplier_Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("RecordCreateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RecordCreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("rlt_Department_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("rlt_Department_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.Allocation", b =>
                {
                    b.HasOne("TurkishExporterInventory.Database.Models.Item", "Item")
                        .WithMany("Allocations")
                        .HasForeignKey("rlt_Item_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TurkishExporterInventory.Database.Models.User", "User")
                        .WithMany("Allocations")
                        .HasForeignKey("rlt_User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.Item", b =>
                {
                    b.HasOne("TurkishExporterInventory.Database.Models.Supplier", "Supplier")
                        .WithMany("Items")
                        .HasForeignKey("rlt_Supplier_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TurkishExporterInventory.Database.Models.User", b =>
                {
                    b.HasOne("TurkishExporterInventory.Database.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("rlt_Department_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
