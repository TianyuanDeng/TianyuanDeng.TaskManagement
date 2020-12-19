using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.RepositoryInterfaces;
using TianyuanDeng.TaskManagement.Infrastructure.Data;

namespace TianyuanDeng.TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : EfRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Tasks> GetTasksById(int Id)
        {
            var task = await _dbContext.Task.FindAsync(Id);
            return task;
        }

    }
}
