using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Models;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.ServiceInterface;

namespace TianyuanDeng.TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTasks()
        {
            var allTasks = await _taskService.GetAllTasks();
            if (!allTasks.Any())
            {
                return NotFound("No Tasks Found");
            }

            return Ok(allTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskRegisterModel taskRegisterModel)
        {
            var createdTask = await _taskService.CreateTask(taskRegisterModel);
            return Ok(createdTask);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskUpdateRegisterModel taskRegisterModel)
        {
            var updateedTask = await _taskService.UpdateTask(taskRegisterModel);
            return Ok(updateedTask);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTask(DeleteModel deleteModel)
        {
            await _taskService.DeletTask(deleteModel);
            return Ok("Successfully deleted");
        }
    }
}
