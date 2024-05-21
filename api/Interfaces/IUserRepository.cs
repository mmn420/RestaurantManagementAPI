using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(string id);
        Task<UserDto> CreateUserAsync(User user);
        Task<UserDto?> UpdateUserAsync(string id, UpdateUserDto userDto);
        Task<UserDto?> DeleteUserAsync(string id);
        Task<bool> UserExists(string id);
    }
}