using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto {
                Id = userModel.Id,
                Email = userModel.Email,
                Name = userModel.Name,
                PhoneNumber = userModel.PhoneNumber
            };
        }
    }
}