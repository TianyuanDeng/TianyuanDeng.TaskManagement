﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.ServiceInterface;

namespace TianyuanDeng.TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksHistoryController : ControllerBase
    {
        private readonly ITasksHistoryService _tasksHistoryService;
        public TasksHistoryController(ITasksHistoryService tasksHistoryService)
        {
            _tasksHistoryService = tasksHistoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTasks(int id)
        {
            var allTasks = await _tasksHistoryService.GetAllTasks(id);
            if (!allTasks.Any())
            {
                return NotFound("No Tasks Found");
            }

            return Ok(allTasks);
        }

/*        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _tasksHistoryService.GetTaskById(id);
            return Ok(task);
            return Ok();
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateTask(TasksHistoryRegisterModel taskRegisterModel)
        {
             var createdTask = await _tasksHistoryService.CreateTaskHistory(taskRegisterModel);
             return Ok(createdTask);
   
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TasksHistoryUpdateModel taskRegisterModel)
        {
            var updateedTask = await _tasksHistoryService.UpdateTask(taskRegisterModel);
            return Ok(updateedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _tasksHistoryService.DeletTask(id);
            return NoContent();
        }
    }
}
