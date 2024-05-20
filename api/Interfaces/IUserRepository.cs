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
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(User user);
        Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task<UserDto?> DeleteUserAsync(int id);
        Task<bool> UserExists(int id);
    }
}