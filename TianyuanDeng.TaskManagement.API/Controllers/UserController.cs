using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.ServiceInterface;

namespace TianyuanDeng.TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allTasks = await _userService.GetAllUsers();
            if (!allTasks.Any())
            {
                return NotFound("No User Found");
            }

            return Ok(allTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserDetails(id);

            if (user == null)
                throw new Exception("User Id does not exists!");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterModel usersRegister)
        {
            var createdUser = await _userService.CreateUser(usersRegister);
            return Ok(createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(UserUpdateModel userUpdateModel)
        {
            var updateedTask = await _userService.UpdateUsers(userUpdateModel);
            return Ok(updateedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _userService.DeletUser(id);
            return Ok("Successfully deleted");
        }


    }
}
