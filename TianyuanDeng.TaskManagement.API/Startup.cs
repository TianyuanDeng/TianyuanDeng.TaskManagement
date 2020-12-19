using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.RepositoryInterfaces;
using TianyuanDeng.TaskManagement.Core.ServiceInterface;
using TianyuanDeng.TaskManagement.Infrastructure.Data;
using TianyuanDeng.TaskManagement.Infrastructure.Repositories;
using TianyuanDeng.TaskManagement.Infrastructure.Services;

namespace TianyuanDeng.TaskManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TianyuanDeng.TaskManagement.API", Version = "v1" });
            });

            services.AddDbContext<TaskManagementDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("TaskManagementDbConnection"))));

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAsyncRepository<Tasks>, EfRepository<Tasks>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITasksHistoryRepository, TasksHistoryRepository>();
            services.AddScoped<ITasksHistoryService, TasksHistoryService>();
            services.AddScoped<IAsyncRepository<TasksHistory>, EfRepository<TasksHistory>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TianyuanDeng.TaskManagement.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
