using Microsoft.AspNetCore.Mvc;
using Monomarket.Business.DataAccess;
using Monomarket.Business.Dto;
using Monomarket.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monomarket.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : DataController
    {
        private readonly IUserService _userService;
        public UsersController(IUnitOfWork unitOfWork, IUserService userService) : base(unitOfWork)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<UserDto> GetUserAsync(int id)
        {
            return await _userService.GetUserAsync(id);
        }
    }
}
