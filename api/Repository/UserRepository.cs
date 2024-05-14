using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.User;
using api.Interfaces;
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

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUserAsync(int id)
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
                return user;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(existingUser == null)
            {
                return null;
            }
            else
            {
                System.Console.WriteLine(existingUser);
                existingUser.Name = userDto.Name == null ? existingUser.Name : userDto.Name;
                existingUser.Email = userDto.Email == null ? existingUser.Email : userDto.Email;
                existingUser.PhoneNumber = userDto.PhoneNumber == null ? existingUser.PhoneNumber : userDto.PhoneNumber;
                await _context.SaveChangesAsync();
                return existingUser;
            }
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(x => x.Id == id);
        }
    }
}