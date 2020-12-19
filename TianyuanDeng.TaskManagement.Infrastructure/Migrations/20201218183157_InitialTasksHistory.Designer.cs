﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TianyuanDeng.TaskManagement.Infrastructure.Data;

namespace TianyuanDeng.TaskManagement.Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagementDbContext))]
    [Migration("20201218183157_InitialTasksHistory")]
    partial class InitialTasksHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TianyuanDeng.TaskManagement.Core.Entities.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priority")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Remakrs")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.Property<int?>("usersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userid");

                    b.HasIndex("usersId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TianyuanDeng.TaskManagement.Core.Entities.TasksHistory", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("Completed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("usersId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("UserId");

                    b.HasIndex("usersId");

                    b.ToTable("TasksHistory");
                });

            modelBuilder.Entity("TianyuanDeng.TaskManagement.Core.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fullname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobileno")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TianyuanDeng.TaskManagement.Core.Entities.Tasks", b =>
                {
                    b.HasOne("TianyuanDeng.TaskManagement.Core.Entities.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersId");

                    b.Navigation("users");
                });

            modelBuilder.Entity("TianyuanDeng.TaskManagement.Core.Entities.TasksHistory", b =>
                {
                    b.HasOne("TianyuanDeng.TaskManagement.Core.Entities.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersId");

                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
