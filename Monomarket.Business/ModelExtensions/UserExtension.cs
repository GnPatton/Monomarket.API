using Monomarket.Business.Dto;
using Monomarket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.ModelExtensions
{
    public static class UserExtension
    {
        public static bool Exists(this User self)
        {
            return self?.UserId > 0;
        }

        public static UserDto ToDto(this User self)
        {
            if (!self.Exists())
            {
                return null;
            }

            return new UserDto
            {
                UserId = self.UserId,
                City = self.City,
                DateOfBirth = self.DateOfBirth,
                District = self.District,
                FirstName = self.FirstName,
                LastName = self.LastName,
                PhoneNumber = self.PhoneNumber
            };
        }
    }
}
