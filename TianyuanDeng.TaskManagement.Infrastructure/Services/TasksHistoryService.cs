using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.Exceptions;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.Models.Responsee;
using TianyuanDeng.TaskManagement.Core.RepositoryInterfaces;
using TianyuanDeng.TaskManagement.Core.ServiceInterface;

namespace TianyuanDeng.TaskManagement.Infrastructure.Services
{
    public class TasksHistoryService : ITasksHistoryService
    {
        private readonly ITasksHistoryRepository _tasksHistoryRepository;
        public TasksHistoryService(ITasksHistoryRepository tasksHistoryRepository)
        {
            _tasksHistoryRepository = tasksHistoryRepository;
        }

        public async Task<TasksHistoryRegisterModel> CreateTaskHistory(TasksHistoryRegisterModel taskRegisterModel)
        {
            var dbTaskHistory = new TasksHistory
            {
                Title = taskRegisterModel.Title,
                Description = taskRegisterModel.Description,
                DueDate = taskRegisterModel.DueDate,
                Completed = taskRegisterModel.Completed,
                Remarks = taskRegisterModel.Remakrs,
                UserId = taskRegisterModel.UserId
            };

            await _tasksHistoryRepository.AddAsync(dbTaskHistory);
            return taskRegisterModel;
        }

        public async Task DeletTask(int id)
        {
            var review = await _tasksHistoryRepository.GetByIdAsync(id);
            await _tasksHistoryRepository.DeleteAsync(review);
        }

        public async Task<IEnumerable<TasksHistoryResponseModel>> GetAllTasks(int UserId)
        {
            var allTasksHistory = await _tasksHistoryRepository.GetAllTasksById(UserId);
            var response = new List<TasksHistoryResponseModel>();

            foreach (var task in allTasksHistory)
                response.Add(new TasksHistoryResponseModel
                {
                    TaskId = task.TaskId,
                    UserId = task.UserId,
                    Title = task.Title,
                    DueDate = task.DueDate,
                    Completed = task.Completed,
                    Remarks = task.Remarks,
                    Description = task.Description
                });


            return response;
        }

        public async Task<TasksHistoryUpdateModel> UpdateTask(TasksHistoryUpdateModel taskRegisterModel)
        {
            var dbtask = new TasksHistory
            {
                TaskId = taskRegisterModel.Id,
                Title = taskRegisterModel.Title,
                Description = taskRegisterModel.Description,
                DueDate = taskRegisterModel.DueDate,
                Completed = taskRegisterModel.Completed,
                Remarks = taskRegisterModel.Remakrs,
                UserId = taskRegisterModel.UserId
            };

            await _tasksHistoryRepository.UpdateAsync(dbtask);
            return taskRegisterModel;
        }
    }
}
