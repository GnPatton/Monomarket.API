using Microsoft.EntityFrameworkCore;
using Monomarket.Business.DataAccess.Repositories;
using Monomarket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MonoDbContext _dbContext;

        public UserRepository(MonoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dbContext.Users.Where(_ => _.UserId == id).FirstOrDefaultAsync();
        }
    }
}
