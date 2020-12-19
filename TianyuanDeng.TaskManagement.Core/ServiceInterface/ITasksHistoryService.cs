using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.Models.Responsee;


namespace TianyuanDeng.TaskManagement.Core.ServiceInterface
{
    public interface ITasksHistoryService
    {
        //Task<Tasks> GetTaskById(int id);
        Task<IEnumerable<TasksHistoryResponseModel>> GetAllTasks(int UserId);

        Task<TasksHistoryRegisterModel> CreateTaskHistory(TasksHistoryRegisterModel taskRegisterModel);
        Task<TasksHistoryUpdateModel> UpdateTask(TasksHistoryUpdateModel taskRegisterModel);
        Task DeletTask(DeleteModel deleteModel);
    }
}
