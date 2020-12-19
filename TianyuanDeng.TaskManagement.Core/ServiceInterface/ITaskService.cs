using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.Models.Responsee;

namespace TianyuanDeng.TaskManagement.Core.ServiceInterface
{
    public interface ITaskService
    {
        Task<Tasks> GetTaskById(int id);
        Task<IEnumerable<TaskResponseModel>> GetAllTasks();

        Task<TaskRegisterModel> CreateTask(TaskRegisterModel taskRegisterModel);
        Task<TaskUpdateRegisterModel> UpdateTask(TaskUpdateRegisterModel taskRegisterModel);
        Task DeletTask(DeleteModel deleteModel);
    }
}
