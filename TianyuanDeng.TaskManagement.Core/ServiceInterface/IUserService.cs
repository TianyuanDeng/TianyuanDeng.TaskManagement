using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.Models.Request;
using TianyuanDeng.TaskManagement.Core.Models.Responsee;

namespace TianyuanDeng.TaskManagement.Core.ServiceInterface
{
    public interface IUserService
    {
        Task<UserResponseModel> GetUserDetails(int id);
        Task<UserResponseModel> CreateUser(UserRegisterModel usersRegister);

        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<UserUpdateModel> UpdateUsers(UserUpdateModel userUpdateModel);
        Task DeletUser(int id);
    }
}
