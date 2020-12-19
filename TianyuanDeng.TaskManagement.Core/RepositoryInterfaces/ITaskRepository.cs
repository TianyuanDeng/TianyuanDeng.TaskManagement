using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;

namespace TianyuanDeng.TaskManagement.Core.RepositoryInterfaces
{
    public interface ITaskRepository: IAsyncRepository<Tasks>
    {
        Task<Tasks> GetTasksById(int Id);
    }
}
