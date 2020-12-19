using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.RepositoryInterfaces;
using TianyuanDeng.TaskManagement.Core.ServiceInterface;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using System.Linq;
using TianyuanDeng.TaskManagement.Core.Models.Responsee;

namespace TianyuanDeng.TaskManagement.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async Task<TaskRegisterModel> CreateTask(TaskRegisterModel taskRegisterModel)
        {
            var user = await _userRepository.GetByIdAsync(taskRegisterModel.UserId);
            if (user == null) throw new Exception("User not exists");

            var dbtask = new Tasks
            {
                Title = taskRegisterModel.Title,
                Description = taskRegisterModel.Description,
                DueDate = taskRegisterModel.DueDate,
                Priority = taskRegisterModel.Priority,
                Remakrs = taskRegisterModel.Remakrs,
                userId = taskRegisterModel.UserId
            };

            await _taskRepository.AddAsync(dbtask);
            return taskRegisterModel;
        }

        public async Task<TaskUpdateRegisterModel> UpdateTask(TaskUpdateRegisterModel taskRegisterModel)
        {
            var user = await _userRepository.GetByIdAsync(taskRegisterModel.UserId);
            if (user == null) throw new Exception("User not exists");

            var dbtask = new Tasks
            {
                Id = taskRegisterModel.Id,
                Title = taskRegisterModel.Title,
                Description = taskRegisterModel.Description,
                DueDate = taskRegisterModel.DueDate,
                Priority = taskRegisterModel.Priority,
                Remakrs = taskRegisterModel.Remakrs,
                userId = taskRegisterModel.UserId
            };

            await _taskRepository.UpdateAsync(dbtask);
            return taskRegisterModel;
        }

        public async Task DeletTask(DeleteModel deleteModel)
        {
            var user = await _userRepository.GetByIdAsync(deleteModel.UserId);
            if (user == null) throw new Exception("Please enter correct UserId");

            var review = await _taskRepository.ListAsync(r => r.userId == deleteModel.UserId && r.Id == deleteModel.TaskId);
            await _taskRepository.DeleteAsync(review.First());
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return task;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetAllTasks()
        {
            var allTask = await _taskRepository.ListAllAsync();
            var response = new List<TaskResponseModel>();

            foreach (var task in allTask)
                response.Add(new TaskResponseModel { 
                    Id = task.Id,
                    Title = task.Title,
                    DueDate = task.DueDate,
                    Description = task.Description
                });


            return response;
        }
    }
}
