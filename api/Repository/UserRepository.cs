using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.ToUserDto();
        }

        public async Task<UserDto?> DeleteUserAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return null;
            }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user.ToUserDto();
            }
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => u.ToUserDto()).ToList();
        }

        public async Task<UserDto?> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return null;
            }
            else
            {
                return user.ToUserDto();
            }
        }

        public async Task<UserDto?> UpdateUserAsync(string id, UpdateUserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(existingUser == null)
            {
                return null;
            }
            else
            {
                System.Console.WriteLine(existingUser);
                existingUser.UserName = userDto.Name == null ? existingUser.UserName : userDto.Name;
                existingUser.Email = userDto.Email == null ? existingUser.Email : userDto.Email;
                existingUser.PhoneNumber = userDto.PhoneNumber == null ? existingUser.PhoneNumber : userDto.PhoneNumber;
                await _context.SaveChangesAsync();
                return existingUser.ToUserDto();
            }
        }

        public async Task<bool> UserExists(string id)
        {
            return await _context.Users.AnyAsync(x => x.Id == id);
        }
    }
}