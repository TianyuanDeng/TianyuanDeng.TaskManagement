using System;
using System.Collections.Generic;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserResponseModel> CreateUser(UserRegisterModel usersRegister)
        {
            var user = new Users
            {
                Email = usersRegister.Email,
                Fullname = usersRegister.Fullname,
                Password = usersRegister.Password,
                Mobileno = usersRegister.Mobileno
            };

            var createdUser = await _userRepository.AddAsync(user);

            var response = new UserResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FullName = createdUser.Fullname,
                Mobileno = createdUser.Mobileno
            };

            return response;
        }

        public async Task DeletUser(UserDeleteModel deleteModel)
        {
            var user = await _userRepository.GetByIdAsync(deleteModel.Id);
            if (user == null) throw new Exception("Please enter correct UserId");

            await _userRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var allUsers = await _userRepository.ListAllAsync();
            var response = new List<UserResponseModel>();

            foreach (var uer in allUsers)
                response.Add(new UserResponseModel {
                    Id = uer.Id,
                    Email = uer.Email,
                    FullName = uer.Fullname,
                    Mobileno = uer.Mobileno
                });

            return response;
        }

        public async Task<UserResponseModel> GetUserDetails(int id)
        {
            var dbUser = await _userRepository.GetByIdAsync(id);
            if (dbUser == null) throw new NotFoundException("User", id);

            var response = new UserResponseModel
            {
                Id = dbUser.Id,
                Email = dbUser.Email,
                FullName = dbUser.Fullname,
                Mobileno = dbUser.Mobileno
            };
            return response;
        }

        public async Task<UserUpdateModel> UpdateUsers(UserUpdateModel userUpdateModel)
        {

            var dbUser = new Users
            {
                Id = userUpdateModel.Id,
                Password = userUpdateModel.Password,
                Email = userUpdateModel.Email,
                Fullname = userUpdateModel.Fullname,
                Mobileno = userUpdateModel.Mobileno
            };

            await _userRepository.UpdateAsync(dbUser);
            return userUpdateModel;
        }
    }
}
