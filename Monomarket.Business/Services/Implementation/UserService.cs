using Monomarket.Business.DataAccess;
using Monomarket.Business.Dto;
using Monomarket.Business.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.Services.Implementation
{
    internal class UserService : ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserAsync(id);

            return user.ToDto();
        }
    }
}
