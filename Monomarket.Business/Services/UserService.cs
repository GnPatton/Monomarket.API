using Monomarket.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);
    }
}
