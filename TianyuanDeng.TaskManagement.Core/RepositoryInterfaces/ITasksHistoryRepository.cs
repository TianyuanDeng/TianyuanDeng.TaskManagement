using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;

namespace TianyuanDeng.TaskManagement.Core.RepositoryInterfaces
{
    public interface ITasksHistoryRepository : IAsyncRepository<TasksHistory>
    {
        Task<IEnumerable<TasksHistory>> GetAllTasksById(int UserId);
    }
}
