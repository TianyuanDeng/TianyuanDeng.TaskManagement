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
    public class TasksHistoryRepository : EfRepository<TasksHistory>, ITasksHistoryRepository
    {
        public TasksHistoryRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<TasksHistory>> GetAllTasksById(int UserId)
        {
            var taskHistroies = await _dbContext.TasksHistories.Where(th => th.UserId == UserId).ToListAsync();
            return taskHistroies;
        }
    }
}
