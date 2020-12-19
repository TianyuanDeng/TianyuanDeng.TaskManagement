using Microsoft.EntityFrameworkCore;
using TianyuanDeng.TaskManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TianyuanDeng.TaskManagement.Infrastructure.Data
{
    public class TaskManagementDbContext: DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base (options)
        {

        }

        public DbSet<Tasks> Task { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<TasksHistory> TasksHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>(ConfigureTasks);
            modelBuilder.Entity<Users>(ConfigureUsers);
            modelBuilder.Entity<TasksHistory>(ConfigureTasksHistory);
        }

        private void ConfigureTasksHistory(EntityTypeBuilder<TasksHistory> builder)
        {
            builder.ToTable("TasksHistory");
            builder.HasKey(th => th.TaskId);
            builder.HasOne(th => th.Users).WithMany(u => u.TasksHistories).HasForeignKey(th => th.UserId);
            builder.Property(th => th.Title).HasMaxLength(50);
            builder.Property(th => th.Description).HasMaxLength(500);
            builder.Property(th => th.Remarks).HasMaxLength(500);
        }

        private void ConfigureTasks(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Users).WithMany(u => u.Tasks).HasForeignKey(t => t.userId);
            builder.Property(t => t.userId).IsRequired();

            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.Priority).HasMaxLength(10);
            builder.Property(t => t.Remakrs).HasMaxLength(500);
        }

        private void ConfigureUsers(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(10);
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.Mobileno).HasMaxLength(50);
        }
    }
}
