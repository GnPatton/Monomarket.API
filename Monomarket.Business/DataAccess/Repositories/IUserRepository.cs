using Monomarket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
    }
}
