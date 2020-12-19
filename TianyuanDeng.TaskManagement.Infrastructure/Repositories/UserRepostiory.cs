using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TianyuanDeng.TaskManagement.Core.Entities;
using TianyuanDeng.TaskManagement.Core.RepositoryInterfaces;
using TianyuanDeng.TaskManagement.Infrastructure.Data;

namespace TianyuanDeng.TaskManagement.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<Users>, IUserRepository
    {
        public UserRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Users> GetUserById(int id)
        {
            return await _dbContext.User.FindAsync(id);
        }
    }
}
